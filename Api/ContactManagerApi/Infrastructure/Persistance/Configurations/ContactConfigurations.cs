
using ContactManagerApi.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CollatrApi.Persistence.Configurations;

public class UserConfigurations : IEntityTypeConfiguration<Contact>
{
    private static readonly int MaxNoteLength = 200;

    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        // TODO: configure schema settings
        // builder.Property(b => b.FirstName)
        //     .HasMaxLength(User.MaxFieldLength);

        // builder.Property(b => b.Email)
        //     .HasMaxLength(User.MaxFieldLength);

        // builder.Property(b => b.Notes)
        //     .HasMaxLength(MaxNoteLength);

    }
}