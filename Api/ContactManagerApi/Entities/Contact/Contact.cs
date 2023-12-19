using ContactManagerApi.Contracts.Contacts;

namespace ContactManagerApi.Entities;

public class Contact
{
    private readonly List<Email> _emails = new();
    private readonly List<Phone> _phones = new();
    public Guid Id { get; private set; }
    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public string? Organization { get; private set; }
    public string? WebsiteUrl { get; private set; }
    public string? Notes { get; private set; }
    public DateTime Created { get; private set; }
    public DateTime? Updated { get; private set; }

    public IReadOnlyList<Email> Emails => _emails.AsReadOnly();
    public IReadOnlyList<Phone> Phones => _phones.AsReadOnly();
    // public virtual ICollection<string> Addresses { get; private set; }
    // public virtual ICollection<string> Categories { get; private set; }
    // public virtual ICollection<string> Tags { get; private set; }

    private Contact(Guid id, string firstName, string lastName, DateTime created, string? organization, string? websiteUrl, string? notes, DateTime? updated, List<Email>? emails, List<Phone>? phones)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Organization = organization;
        WebsiteUrl = websiteUrl != null ? websiteUrl.ToLower() : null;
        Notes = notes;
        Created = created;
        Updated = updated;
        
        if (emails is not null)
        {
            _emails.AddRange(emails);
        }

        if (phones is not null)
        {
            _phones.AddRange(phones);
        }
    }

    public static Contact Create(Guid? id, string firstName, string lastName, string? organization, string? websiteUrl, string? notes, DateTime created, DateTime? updated, List<Email>? emails, List<Phone>? phones)
    {
        return new Contact(id ?? Guid.NewGuid(), firstName, lastName, created, organization, websiteUrl, notes, updated, emails, phones);
    }

    public static Contact From(CreateContactRequest createContactRequest)
    {
        return Create(null, createContactRequest.FirstName, createContactRequest.LastName, createContactRequest.Organization, createContactRequest.WebsiteUrl, createContactRequest.Notes, DateTime.UtcNow, null, createContactRequest.Emails.ConvertAll(email => Email.Create(email.EmailAddress, email.Type)), createContactRequest.Phones.ConvertAll(phone => Phone.Create(phone.PhoneNumber, phone.Type)));
    }

    public string Name
    {
        get => $"{FirstName} {LastName}";
    }

    #pragma warning disable CS8618
    private Contact()
    {
        
    }
    #pragma warning restore CS8618
}