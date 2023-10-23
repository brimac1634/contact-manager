using ContactManagerApi.Entities;

namespace ContactManagerApi.Services.Contacts;

public interface IContactsService
{
    List<Contact> GetPaginatedContacts();
    Contact AddContact(Contact contact);
    void UpdateContact(Contact contact);
    void DeleteContact(Guid contactId);
    List<Contact> GetContactsByIds(List<Guid> contactIds);
    void UpsertContacts(List<Contact> contacts);
}