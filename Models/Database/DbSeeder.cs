using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace shareit.Models.Database
{
    public static class DbSeeder
    {
        public static void Initialize(ShareItContext context)
        {
            // ! REMOVE THIS LINE
            context.Database.EnsureDeleted();
                
            context.Database.EnsureCreated();

            if(context.Subscribers.Count() > 0)
                return;

            var emails = new string[] 
            {
                "test@example.com",
                "test_other@example.com"
            };

            var subscribers = emails.Select(e => new Subscriber()
                                            {
                                                Email = e,
                                                RegisteredDateTime = DateTime.Now
                                            });
            
            context.AddRange(subscribers);
            context.SaveChanges();
        }
    }
}