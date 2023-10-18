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

    public string Name
    {
        get => $"{FirstName} {LastName}";
    }
}