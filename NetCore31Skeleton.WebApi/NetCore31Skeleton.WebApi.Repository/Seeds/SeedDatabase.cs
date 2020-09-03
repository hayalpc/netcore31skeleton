using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using NetCore31Skeleton.WebApi.Repository.Context;
using NetCore31Skeleton.WebApi.Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore31Skeleton.WebApi.Repository.Seeds
{
    public class SeedDatabase
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<CoreDbContext>();

            var category = new Category
            {
                Title = "Yeni Kategori",
                Description = "Yeni Kategori Açıklama",
                CreateTime = DateTime.Now
            };
            if (!context.Category.Any())
            {
                context.Category.Add(category);
                if (context.SaveChanges() > 0)
                {
                    var note = new Note
                    {
                        Title = "Yeni Note",
                        Description = "Yeni Note Açıklama",
                        CreateTime = DateTime.Now,
                        Category = category,
                        CategoryId = category.Id
                    };

                    context.Note.Add(note);
                    context.SaveChanges();
                }
            }
        }
    }
}
