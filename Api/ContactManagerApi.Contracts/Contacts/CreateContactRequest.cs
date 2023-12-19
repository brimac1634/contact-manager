namespace ContactManagerApi.Contracts.Contacts;

public record CreateContactRequest(
    string FirstName,
    string LastName,
    List<ContactPhone> Phones,
    // List<string> Addresses,
    List<ContactEmail> Emails,
    // List<string> Categories,
    string Organization,
    string WebsiteUrl,
    string Notes
    // List<string> Tags
);