using ContactManagerApi.Contracts.Contacts;
using Microsoft.AspNetCore.Mvc;
using MixERP.Net.VCards;
using MixERP.Net.VCards.Serializer;
using MixERP.Net.VCards.Types;
using MixERP.Net.VCards.Models;
using System.Text;

namespace ContactManagerApi.Controllers;

public class ContactsController : ApiController
{
    
    [HttpGet]
    [ProducesResponseType(typeof(List<ContactResponse>), 200)]
    public IActionResult GetContacts()
    {
        List<ContactResponse> contacts = new()
        {
            new ContactResponse(new Guid(), "John", "Doe", "jon@do.com", "Sug Co.", "web.com", "Some notes", DateTime.Now, null, new List<string>(), new List<string>(), new List<string>(), new List<string>(), new List<string>()),
        };

        return Ok(contacts);
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