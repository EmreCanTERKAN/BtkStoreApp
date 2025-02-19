﻿using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Repositories.EFCore.Config;
public class BookConfig : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasData(
            new Book { Id = 1, Price = 63, Title = "ali" },
            new Book { Id = 2, Price = 69, Title = "veli" },
            new Book { Id = 3, Price = 06, Title = "deli" }
            );
    }
}