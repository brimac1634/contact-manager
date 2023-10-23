namespace ContactManagerApi.Entities;

public class Contact
{
    public Guid Id { get; private set; }
    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public string? Email { get; private set; } = string.Empty;
    public string? Organization { get; private set; }
    public string? WebsiteUrl { get; private set; }
    public string? Notes { get; private set; }
    public DateTime Created { get; private set; }
    public DateTime? Updated { get; private set; }

    public virtual ICollection<string> Phones { get; private set; }
    public virtual ICollection<string> Addresses { get; private set; }
    public virtual ICollection<string> Emails { get; private set; }
    public virtual ICollection<string> Categories { get; private set; }
    public virtual ICollection<string> Tags { get; private set; }

    private Contact(Guid id, string firstName, string lastName, string? email, string? organization, string? websiteUrl, string? notes, DateTime created, DateTime? updated)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email != null ? email.ToLower() : null;
        Organization = organization;
        WebsiteUrl = websiteUrl != null ? websiteUrl.ToLower() : null;
        Notes = notes;
        Created = created;
        Updated = updated;
    }

    public static Contact Create(Guid? id, string firstName, string lastName, string? email, string? organization, string? websiteUrl, string? notes, DateTime created, DateTime? updated)
    {
        return new Contact(id ?? Guid.NewGuid(), firstName, lastName, email, organization, websiteUrl, notes, created, updated);
    }

    public string Name
    {
        get => $"{FirstName} {LastName}";
    }
}