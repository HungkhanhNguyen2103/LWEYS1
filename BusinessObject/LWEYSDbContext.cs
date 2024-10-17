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
			//builder.Seed();

			// Config Identity
			builder.Entity<Account>().ToTable("Account").HasKey(x => x.Id);
			builder.Entity<Post>().ToTable("Post").HasKey(x => x.Id);
			builder.Entity<PostCategory>().ToTable("PostCategory").HasKey(x => x.Id);
			builder.Entity<AboutUs>().ToTable("AboutUs").HasKey(x => x.Id);
			builder.Entity<Service>().ToTable("Service").HasKey(x => x.Id);
			builder.Entity<ServiceOrder>().ToTable("ServiceOrder").HasKey(x => x.Id);
			builder.Entity<ServiceOrderHistory>().ToTable("ServiceOrderHistory").HasKey(x => x.Id);
			builder.Entity<UserQuestion>().ToTable("UserQuestion").HasKey(x => x.Id);
			builder.Entity<Feedbacks>().ToTable("Feedbacks").HasKey(x => x.Id);

        }

        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<PostCategory> PostCategories { get; set; }
        public virtual DbSet<AboutUs> AboutUs { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<ServiceOrder> ServiceOrders { get; set; }
        public virtual DbSet<ServiceOrderHistory> ServiceOrderHistories { get; set; }
        public virtual DbSet<UserQuestion> UserQuestions { get; set; }
        public virtual DbSet<Feedbacks> Feedbacks { get; set; }
    }
}
