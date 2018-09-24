using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace shareit.Models.Database
{
    public class ShareItContext : DbContext
    {
        public ShareItContext(DbContextOptions<ShareItContext> options)
            : base(options)
        { }

        public DbSet<Subscriber> Subscribers { get; set; }
    }
}