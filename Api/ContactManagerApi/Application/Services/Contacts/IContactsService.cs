using ContactManagerApi.Contracts.Common;
using ContactManagerApi.Contracts.Contacts;
using ContactManagerApi.Entities;

namespace ContactManagerApi.Services.Contacts;

public interface IContactsService
{
    Task<PaginatedResponse<Contact>> GetPaginatedContacts(QueryContactRequest queryContactRequest);
    Task<Contact> AddContact(Contact contact);
    Task UpdateContact(Contact contact);
    Task DeleteContact(Guid contactId);
    Task<List<Contact>> GetContactsByIds(List<Guid> contactIds);
    Task UpsertContacts(List<Contact> contacts);
}