namespace ContactManagerApi.Contracts.Contacts;

public record ContactResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string? Organization,
    string? WebsiteUrl,
    string? Notes,
    DateTime Created,
    DateTime? Updated,
    ICollection<ContactPhone> Phones,
    ICollection<ContactEmail> Emails
    );