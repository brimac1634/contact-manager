namespace ContactManagerApi.Contracts.Contacts;

public record ContactResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string? Email,
    string? Organization,
    string? WebsiteUrl,
    string? Notes,
    DateTime Created,
    DateTime? Updated,
    ICollection<string> Phones,
    ICollection<string> Addresses,
    ICollection<string> Emails,
    ICollection<string> Categories,
    ICollection<string> Tags);