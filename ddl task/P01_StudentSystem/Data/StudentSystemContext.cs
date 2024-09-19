using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<HomeWorkSubmission> HomeWorkSubmissions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // student

            modelBuilder.Entity<Student>()
                .Property(b => b.Name)
                    .HasMaxLength(500)
                    .IsUnicode(true);

            modelBuilder.Entity<Student>()
               .Property(b => b.PhoneNumber)
                   .HasMaxLength(10)
                   .IsUnicode(false);

            //course

            modelBuilder.Entity<Course>()
       .Property(b => b.Name)
           .HasMaxLength(80)
           .IsUnicode(true);

            modelBuilder.Entity<Course>()
     .Property(b => b.Description)
         .IsUnicode(true);

            modelBuilder.Entity<Course>()
        .Property(b => b.Price)
        .HasPrecision(8, 2);

            //Resource 

            modelBuilder.Entity<Resource>()
.Property(b => b.Url)
  .IsUnicode(false);

            //Homework

            modelBuilder.Entity<HomeWorkSubmission>()
.HasKey(c => c.HomeWorkId);

            //StudentCourse

            modelBuilder.Entity<StudentCourse>()
            .HasKey(c => new {c.StudentId , c.CourseId });

            // seeding data

            modelBuilder.Entity<Student>().HasData(
    new Student { StudentId = 1, Name = "ahmed", Birthday = DateOnly.Parse("15/09/1999"), PhoneNumber = "0101404111", RegestrionON= DateOnly.Parse("15/09/2024") },
                
               new Student { StudentId = 2, Name = "mohamed", Birthday = DateOnly.Parse("15/09/1998"), PhoneNumber = "0101404112", RegestrionON = DateOnly.Parse("13/09/2024") },  
            new Student { StudentId = 3, Name = "mostafa", Birthday = DateOnly.Parse("15/09/1997"), PhoneNumber = "0101404113", RegestrionON = DateOnly.Parse("12/09/2024") } ) ;

            modelBuilder.Entity<Course>().HasData(
    new Course { CourseId = 1, Name = "c#", Description = "for .net developer", Price = 5500.00m , StartDate= DateOnly.Parse("17/09/2024"), EndDate= DateOnly.Parse("17/12/2024") },
        new Course { CourseId = 2, Name = "java", Description = "for java developer", Price = 6000.00m, StartDate = DateOnly.Parse("18/09/2024"), EndDate = DateOnly.Parse("18/12/2024") }  );

            modelBuilder.Entity<StudentCourse>().HasData(
                new StudentCourse { StudentId = 1, CourseId = 2 },
                 new StudentCourse { StudentId = 2, CourseId = 1 },
                 new StudentCourse { StudentId = 3, CourseId = 1 }
                );

            modelBuilder.Entity<Resource>().HasData(
                new Resource { ResourceId = 1, Name = "Math Video", Url = "http://google.com/math-video", ResourceType = ResourceType.Video, CourseId = 1 },
                new Resource { ResourceId = 2, Name = "Physics Presentation", Url = "http://google.com/physics-presentation", ResourceType = ResourceType.Presentation, CourseId = 2 }
            );

            modelBuilder.Entity<HomeWorkSubmission>().HasData(
            new HomeWorkSubmission { HomeWorkId = 1, Name="homework s1 ", Content = "http://google.com/homework1", ContentType = ContentType.Pdf, SubmissionTime = DateTime.Now, StudentId = 1, CourseId = 1 },
            new HomeWorkSubmission { HomeWorkId = 2, Name = "homework s2 ", Content = "http://google.com/homework2", ContentType = ContentType.Zip, SubmissionTime = DateTime.Now, StudentId = 2, CourseId = 2 },
            new HomeWorkSubmission { HomeWorkId = 3, Name = "homework s3 ", Content = "http://google.com/homework2", ContentType = ContentType.Zip, SubmissionTime = DateTime.Now, StudentId = 3, CourseId = 2 }
        );


        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\MYFIRSTSQLSERVER;Database=StudentSystem;User ID=sa;Password=6339782;TrustServerCertificate = True");
        }
    }
}
