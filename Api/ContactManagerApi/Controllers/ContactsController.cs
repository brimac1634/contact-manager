using ContactManagerApi.Contracts.Contacts;

using Microsoft.AspNetCore.Mvc;

namespace ContactManagerApi.Controllers;

public class ContactsController : ApiController
{
    
    [HttpGet]
    [ProducesResponseType(typeof(List<ContactResponse>), 200)]
    public IActionResult GetContacts()
    {
        // List<ContactResponse> contacts = new()
        // {
        //     new ContactResponse(new Guid(), "John", "Doe", "jon@do.com", "Sug Co.", "web.com", "Some notes", DateTime.Now, null, new List<string>(), new List<string>(), new List<string>(), new List<string>(), new List<string>()),
        // };

        // return Ok(contacts);
        return Ok();
    }
}