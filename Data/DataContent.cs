using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using discussion_api.Entities;

    public class DataContent : DbContext
    {
        public DataContent (DbContextOptions<DataContent> options)
            : base(options)
        {
        }

        public DbSet<discussion_api.Entities.Discussion> Discussion { get; set; }
    }
