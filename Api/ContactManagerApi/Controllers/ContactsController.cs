using ContactManagerApi.Contracts.Contacts;
using Microsoft.AspNetCore.Mvc;
using MixERP.Net.VCards;
using MixERP.Net.VCards.Serializer;
using MixERP.Net.VCards.Types;
using MixERP.Net.VCards.Models;
using System.Text;
using System.Net;
using ContactManagerApi.Infrastructure.Persistance.Repositories.Contacts;
using ContactManagerApi.Services.Contacts;
using ContactManagerApi.Entities;
using ContactManagerApi.Contracts.Common;

namespace ContactManagerApi.Controllers;

public class ContactsController : ApiController
{
    private readonly IContactsService _contactsService;

    public ContactsController(IContactsService contactsService)
    {
        _contactsService = contactsService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(PaginatedResponse<ContactResponse>), (int)HttpStatusCode.OK)]
    public IActionResult GetContacts([FromQuery] QueryContactRequest queryContactRequest)
    {
        var contacts = _contactsService.GetPaginatedContacts(queryContactRequest);
        return Ok(contacts);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ContactResponse), (int)HttpStatusCode.Created)]
    public async Task<ContactResponse> CreateContact([FromBody] CreateContactRequest createContactRequest)
    {
        var contact = Contact.From(createContactRequest);
        await _contactsService.AddContact(contact);
        return new ContactResponse(contact.Id, contact.FirstName, contact.LastName, contact.Organization, contact.WebsiteUrl, contact.Notes, contact.Created, contact.Updated, contact.Phones.Select(phone => new ContactPhone(phone.PhoneNumber, phone.Type)).ToList(), contact.Emails.Select(email => new ContactEmail(email.EmailAddress, email.Type)).ToList());
    }
    
    [HttpGet("vcard")]
    public async Task<IActionResult> DownloadVCard()
    {
        var vCard = new VCard
        {
            Version = VCardVersion.V4,
            FormattedName = "John Doe",
            FirstName = "John",
            LastName = "Doe",
            Addresses = new List<Address>
            {
                new() 
                {
                    Street = "123 Main Street",
                    Country = "Hong Kong",
                    Type = AddressType.Work
                }
            },
            Categories = new[] {"Friend", "Fella", "Amsterdam"},
        };
        var serialized = vCard.Serialize();
        var vcfBytes = Encoding.UTF8.GetBytes(serialized);
        using (var stream = new MemoryStream(vcfBytes))
        {
            Response.ContentType = "text/vcard";
            Response.Headers.Add("Content-Disposition", "attachment; filename=contact.vcf");
            await stream.CopyToAsync(Response.Body);
        }

        return new EmptyResult();
    }
    
    [HttpPost("vcard")]
    public async Task<IActionResult> UploadVCard([FromForm] UploadVCardRequest uploadVCardRequest)
    {

        try
        {
            if (uploadVCardRequest.VCard != null && uploadVCardRequest.VCard.Length > 0)
            {
                var fileName = Path.GetFileName(uploadVCardRequest.VCard.FileName);
                byte[] fileBytes;

                using (var memoryStream = new MemoryStream())
                {
                    await uploadVCardRequest.VCard.CopyToAsync(memoryStream);
                    fileBytes = memoryStream.ToArray();
                }

                var serializedVCard = Encoding.UTF8.GetString(fileBytes);
                IEnumerable<VCard> vcards = Deserializer.Deserialize(serializedVCard);

                // TODO:Convert vcard to contact
                // TODO: Upsert vcard to database

                return Ok();
            }
            
            return BadRequest("No file uploaded.");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}