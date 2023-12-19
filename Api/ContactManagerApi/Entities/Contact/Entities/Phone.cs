public class Phone {
    public Guid Id { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Type { get; private set; }

    private Phone(Guid id, string phoneNumber, string type) {
        Id = id;
        PhoneNumber = phoneNumber;
        Type = type;
    }

    public static Phone Create(string phoneNumber, string type) {
        return new(Guid.NewGuid(), phoneNumber, type);
    }
}