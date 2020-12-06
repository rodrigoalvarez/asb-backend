using System;
using Microsoft.EntityFrameworkCore;

namespace ASBbackend.Models
{
    public class CreditCardContext : DbContext
    {
        public CreditCardContext(DbContextOptions<CreditCardContext> options) : base(options)
        {
        }

        public DbSet<CreditCard> CreditCards { get; set; }
    }
}
