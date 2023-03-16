using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectHolOnBoardApi.models;

namespace ProjectHolOnBoardApi.Data
{
    public class ProjectHolOnBoardApiContext : DbContext
    {
        public ProjectHolOnBoardApiContext (DbContextOptions<ProjectHolOnBoardApiContext> options)
            : base(options)
        {
        }

        public DbSet<ProjectHolOnBoardApi.models.Circuit> Circuit { get; set; } = default!;

        public DbSet<ProjectHolOnBoardApi.models.Stage> Stage { get; set; }

        public DbSet<ProjectHolOnBoardApi.models.Anchor> Anchor { get; set; }
    }
}
