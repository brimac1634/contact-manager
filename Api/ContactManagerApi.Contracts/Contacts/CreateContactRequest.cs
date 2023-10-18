namespace ContactManagerApi.Contracts.Contacts;

public record CreateContactRequest(
    string FirstName,
    string LastName,
    List<string> Phones,
    List<string> Addresses,
    List<string> Emails,
    List<string> Categories,
    string Organization,
    string WebsiteUrl,
    string Notes,
    List<string> Tags
);