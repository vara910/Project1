using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SubjectManagement1.Models;

namespace StudentManagement1.Data
{
    public class StudentManagement1Context : DbContext
    {
        public StudentManagement1Context (DbContextOptions<StudentManagement1Context> options)
            : base(options)
        {
        }

        public DbSet<SubjectManagement1.Models.Subject> Subject { get; set; } = default!;
    }
}
