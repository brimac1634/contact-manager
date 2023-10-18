namespace ContactManagerApi.Contracts.Contacts;

public record CreateManyContactsRequest(
    List<CreateContactRequest> Contacts
);