﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SampleWebAPI.DBModels;
using System;
using System.Linq;

namespace SampleWebAPI.DBContext
{
    public class BooksDataSeed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SampleDBContext(
                serviceProvider.GetRequiredService<DbContextOptions<SampleDBContext>>()))
            {
                // Look for any books already in database.
                if (context.BooksDbSet.Any())
                {
                    return;   // Database has been seeded
                }

                context.BooksDbSet.AddRange(
                    new BookModel
                    {

                        Title = "Azure for Architects",
                        Publisher = "Microsoft",
                        Author = "John Savill",
                        Category = "IT-Cloud",
                        Price = 50.00M
                    },
                    new BookModel
                    {

                        Title = "Microsoft Visual C# Step By Step",
                        Publisher = "Microsoft",
                        Author = "John Sharp",
                        Category = "IT-Programming",
                        Price = 55.00M
                    },
                    new BookModel
                    {

                        Title = "Step by Step Javascript",
                        Publisher = "Microsoft",
                        Author = "Steve Suehring",
                        Category = "IT-Programming",
                        Price = 35.50M
                    },
                    new BookModel
                    {

                        Title = "ASP.NET Core 3.0",
                        Publisher = "Microsoft",
                        Author = "John Savill",
                        Category = "IT-Programming",
                        Price = 65.00M
                    },
                    new BookModel
                    {

                        Title = "Azure for Developers",
                        Publisher = "Microsoft",
                        Author = "Kamil Mrzyglod",
                        Category = "IT-Cloud",
                        Price = 70.50M
                    },
                    new BookModel
                    {

                        Title = "C# in depth",
                        Publisher = "DreamTech",
                        Author = "Jon Skeet, Eric Lippert",
                        Category = "IT-Programming",
                        Price = 50.50M
                    });

                context.SaveChanges();
            }
        }
    }
}
