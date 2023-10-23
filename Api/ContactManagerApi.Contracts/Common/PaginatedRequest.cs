namespace ContactManagerApi.Contracts.Common;

public record PaginatedRequest(
    int PageNumber = 1,
    int PageSize = 10
);