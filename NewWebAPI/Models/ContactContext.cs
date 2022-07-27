﻿using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace NewWebAPI.Models
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options)
            : base(options)
        {
        }

        public DbSet<ContactItem> Contacts { get; set; } = default!;
        public DbSet<ContactDetailItem> ContactDetails { get; set; } = default!;

    }
}