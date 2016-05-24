using System.Data.Entity;
using MyWedding.Models;

namespace MyWedding.Repository
{
    public class MyWeddingbContext : DbContext
    {
        public MyWeddingbContext() : base("MyWeddingDbContext")
        {
        }
        public DbSet<Message> Messages { get; set; }
    }
}