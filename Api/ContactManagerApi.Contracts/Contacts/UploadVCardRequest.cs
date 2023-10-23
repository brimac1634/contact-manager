using Microsoft.AspNetCore.Http;

namespace ContactManagerApi.Contracts.Contacts;

public record UploadVCardRequest(
    IFormFile VCard
);