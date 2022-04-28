using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebAppMenu.Models
{
    public class MenuContext : DbContext
    {
        public MenuContext(DbContextOptions<MenuContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Table_Access> Table_Access { get; set; }
    }
}
