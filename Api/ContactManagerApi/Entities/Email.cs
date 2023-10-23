namespace ContactManagerApi.Entities;

public class Email
{
    public Guid Id { get; private set; }
    public string EmailAddress { get; private set; } = null!;
    public string Type { get; private set; } = null!;
    public Guid ContactId { get; private set; }
    public Contact Contact { get; private set; } = null!;
}