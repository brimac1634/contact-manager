using ContactManagerApi.Contracts.Common;
using ContactManagerApi.Contracts.Contacts;
using ContactManagerApi.Entities;
using ContactManagerApi.Infrastructure.Persistance.Repositories.Contacts;

namespace ContactManagerApi.Services.Contacts;

public class ContactsService : IContactsService
{
    private readonly IContactRepository _contactsRepository;

    public ContactsService(IContactRepository contactsRepository)
    {
        _contactsRepository = contactsRepository;
    }


    public async Task<Contact> AddContact(Contact contact)
    {
        await _contactsRepository.CreateContactAsync(contact);
        return contact;
    }

    public Task DeleteContact(Guid contactId)
    {
        throw new NotImplementedException();
    }

    public Task<List<Contact>> GetContactsByIds(List<Guid> contactIds)
    {
        throw new NotImplementedException();
    }

    public Task<PaginatedResponse<Contact>> GetPaginatedContacts(QueryContactRequest queryContactRequest)
    {
        return _contactsRepository.GetPaginatedContactsAsync(queryContactRequest);
    }

    public Task UpdateContact(Contact contact)
    {
        throw new NotImplementedException();
    }

    public Task UpsertContacts(List<Contact> contacts)
    {
        throw new NotImplementedException();
    }
}