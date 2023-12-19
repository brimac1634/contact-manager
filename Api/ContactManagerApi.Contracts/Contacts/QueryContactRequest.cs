using ContactManagerApi.Contracts.Common;

namespace ContactManagerApi.Contracts.Contacts;

public record QueryContactRequest(
    string? Search
) : PaginatedRequest;