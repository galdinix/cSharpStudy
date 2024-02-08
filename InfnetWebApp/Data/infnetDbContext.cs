using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InfnetWebApp.Models;

    public class InfnetDbContext : DbContext
    {
        public InfnetDbContext (DbContextOptions<InfnetDbContext> options)
            : base(options)
        {
        }

        public DbSet<InfnetWebApp.Models.Aluno> Aluno { get; set; } = default!;
    }
