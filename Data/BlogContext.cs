﻿using MasteringEF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasteringEF.Data
{
    public class BlogContext:DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options): base(options)
        {

        }

      
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
