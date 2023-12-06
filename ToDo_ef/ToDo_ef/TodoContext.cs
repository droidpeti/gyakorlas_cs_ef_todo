using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo_ef
{
    internal class TodoContext : DbContext

    {
        public DbSet<Todo> TodoLista { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string c = "server=localhost;userid=root;password=;database=todo";

            optionsBuilder.UseMySql(c, ServerVersion.AutoDetect(c));
        }
    }
}
