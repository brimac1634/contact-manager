using ContactManagerApi.Contracts.Common;
using ContactManagerApi.Contracts.Contacts;
using ContactManagerApi.Entities;
using ContactManagerApi.Persistance;

using Microsoft.EntityFrameworkCore;

namespace ContactManagerApi.Infrastructure.Persistance.Repositories.Contacts;

public class ContactRepository : IContactRepository
{
    private readonly ContactManagerDbContext _contactManagerDbContext;

    public ContactRepository(ContactManagerDbContext contactManagerDbContext)
    {
        _contactManagerDbContext = contactManagerDbContext;
    }

    public Task<Contact?> CreateContactAsync(Contact contact)
    {
        throw new NotImplementedException();
    }

    public Task<bool?> DeleteContactAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<Contact?> GetContactAsync(Guid id)
    {
        var contact = await _contactManagerDbContext.Contacts.FirstAsync(contact => contact.Id == id);
        return contact;
    }

    public Task<IEnumerable<Contact>> GetContactsByIdsAsync(IEnumerable<Guid> ids)
    {
        throw new NotImplementedException();
    }

    public async Task<PaginatedResponse<Contact>> GetPaginatedContactsAsync(QueryContactRequest queryContactRequest)
    {
        var contacts = await _contactManagerDbContext.Contacts
            .Where(c => (c.Email != null && c.Email.Contains(queryContactRequest.Search))
            || c.Name.Contains(queryContactRequest.Search)
            || c.Phones.Any(p => p.Contains(queryContactRequest.Search)
            || c.Categories.Any(c => c.Contains(queryContactRequest.Search))
            || (c.WebsiteUrl != null && c.WebsiteUrl.Contains(queryContactRequest.Search))
            || (c.Notes != null && c.Notes.Contains(queryContactRequest.Search))))
            .Skip((queryContactRequest.PageNumber - 1) * queryContactRequest.PageSize)
            .Take(queryContactRequest.PageSize)
            .ToArrayAsync();
        return new PaginatedResponse<Contact>(queryContactRequest.PageNumber, queryContactRequest.PageSize, contacts);
                            
    }

    public Task<Contact?> UpdateContactAsync(Guid id, Contact contact)
    {
        throw new NotImplementedException();
    }

    public Task<bool?> UpsertContactsAsync(IEnumerable<Contact> contacts)
    {
        throw new NotImplementedException();
    }
}