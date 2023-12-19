
using ContactManagerApi.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContactManagerApi.Persistence.Configurations;

public class UserConfigurations : IEntityTypeConfiguration<Contact>
{
    private static readonly byte MaxFieldLength = 100;
    private static readonly int MaxNoteLength = 200;

    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        ConfigureContactsTable(builder);
        ConfigureEmailsTable(builder);
        ConfigurePhonesTable(builder);

    }

    private void ConfigureEmailsTable(EntityTypeBuilder<Contact> builder)
    {
        builder.OwnsMany(b => b.Emails, eb =>
        {
            eb.ToTable("Emails");
            eb.WithOwner().HasForeignKey("ContactId");
            eb.HasKey("Id", "ContactId");
        });

        builder.Metadata.FindNavigation(nameof(Contact.Emails))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigurePhonesTable(EntityTypeBuilder<Contact> builder)
    {
        builder.OwnsMany(b => b.Phones, pb =>
        {
            pb.ToTable("Phones");
            pb.WithOwner().HasForeignKey("ContactId");
            pb.HasKey("Id", "ContactId");
        });

        builder.Metadata.FindNavigation(nameof(Contact.Phones))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureContactsTable(EntityTypeBuilder<Contact> builder)
    {
        builder.ToTable("Contacts");
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id)
            .ValueGeneratedNever();
        builder.Property(b => b.FirstName)
            .HasMaxLength(MaxFieldLength);
        builder.Property(b => b.LastName)
            .HasMaxLength(MaxFieldLength);
        builder.Property(b => b.Organization)
            .HasMaxLength(MaxFieldLength);
        builder.Property(b => b.WebsiteUrl)
            .HasMaxLength(MaxFieldLength);
        builder.Property(b => b.Notes)
            .HasMaxLength(MaxNoteLength);
        builder.Property(b => b.Created)
            .IsRequired();
        builder.Property(b => b.Updated);
    }
}