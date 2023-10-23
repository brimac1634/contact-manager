using ContactManagerApi.Entities;

using MixERP.Net.VCards;
using MixERP.Net.VCards.Models;
using MixERP.Net.VCards.Types;

namespace ContactManagerApi.Utils;

public static class VCardConverter
{
    // public static byte[] ConvertToVCard(List<Contact> contacts)
    // {
        
    //     var vCards = contacts.ConvertAll(contact => new VCard
    //     {
    //         Version = VCardVersion.V4,
    //         FormattedName = $"{contact.FirstName} {contact.LastName}",
    //         FirstName = contact.FirstName,
    //         LastName = contact.LastName,
    //         Organization = contact.Organization,
    //         Addresses = new Address[]
    //         {
    //             new()
    //             {
    //                 Street = contact.Address,
    //                 Country = contact.Country,
    //                 Type = AddressType.Work
    //             }
    //         },
    //         Emails = new Email[]
    //         {
    //             new()
    //             {
    //                 EmailAddress = contact.Email,
    //                 Type = EmailType.Work
    //             }
    //         },
    //         Categories = new[] {"Friend", "Fella", "Amsterdam"},
    //     });
    // }
}