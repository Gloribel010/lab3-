using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3;
public class ContextDB : DbContext
{
    public DbSet<Evaluaciones> evaluaciones { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-NFDMETJ;Database=lab3;Trusted_Connection = True;");

    }
}
