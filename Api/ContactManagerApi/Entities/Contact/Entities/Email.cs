namespace ContactManagerApi.Entities;

public class Email
{
    public Guid Id { get; private set; }
    public string EmailAddress { get; private set; }
    public string Type { get; private set; }

    private Email(Guid id, string emailAddress, string type)
    {
        Id = id;
        EmailAddress = emailAddress;
        Type = type;
    }

    public static Email Create(string emailAddress, string type)
    {
        return new(Guid.NewGuid(), emailAddress, type);
    }
}