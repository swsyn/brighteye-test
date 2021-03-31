using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrighteyeTest.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<FirstNumber> FirstNumbersTable { get; set; }
        public DbSet<SecondNumber> SecondNumbersTable { get; set; }
        public ApplicationContext() : base("DefaultConnection")
        {

        }
    }
}
