using ContactManagerApi.Contracts.Common;
using ContactManagerApi.Contracts.Contacts;
using ContactManagerApi.Entities;

namespace ContactManagerApi.Infrastructure.Persistance.Repositories.Contacts;

public interface IContactRepository
{
    Task<Contact?> GetContactAsync(Guid id);
    Task<IEnumerable<Contact>> GetContactsByIdsAsync(IEnumerable<Guid> ids);
    Task<PaginatedResponse<Contact>> GetPaginatedContactsAsync(QueryContactRequest queryContactRequest);
    Task<Contact?> CreateContactAsync(Contact contact);
    Task<bool?> UpsertContactsAsync(IEnumerable<Contact> contacts);
    Task<Contact?> UpdateContactAsync(Guid id, Contact contact);
    Task<bool?> DeleteContactAsync(Guid id);
}