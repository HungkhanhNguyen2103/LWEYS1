using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class LWEYSDbContext : IdentityDbContext<Account>
    {
        public LWEYSDbContext(DbContextOptions<LWEYSDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Config Identity
            builder.Entity<Account>().ToTable("Account").HasKey(x => x.Id);

        }
    }
}
