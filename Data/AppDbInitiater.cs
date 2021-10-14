using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using my_book.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_book.Data
{
    public class AppDbInitiater
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using(var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                if(!context.Books.Any())
                {
                    context.Books.AddRange(new Book
                    {
                        Title = "1st Book title",
                        Description = "1st Book Description",
                        IsRead = true,
                        DateRead = DateTime.Now.AddDays(-10),
                        Rate = 4,
                        Genre = "Biography",
                        Author = "Mukesh Dubey",
                        CoverUrl = "https:www.google.com",
                        DateAdded = DateTime.Now
                    },
                    new Book
                    {
                        Title = "2st Book title",
                        Description = "2st Book Description",
                        IsRead = false,
                        Genre = "Biography",
                        Author = "Mukesh Dubey",
                        CoverUrl = "https:www.google.com",
                        DateAdded = DateTime.Now
                    }) ;

                    context.SaveChanges();
                }
            }
        }
    }
}
