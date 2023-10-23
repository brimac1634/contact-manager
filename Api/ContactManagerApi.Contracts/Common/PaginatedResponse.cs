namespace ContactManagerApi.Contracts.Common;

public record PaginatedResponse<T>(
    int PageNumber,
    int PageSize,
    IEnumerable<T> Data
);