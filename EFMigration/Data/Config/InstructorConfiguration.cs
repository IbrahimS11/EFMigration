using EFMigration.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFMigration.Data.Config
{
  
        public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
        {
            public void Configure(EntityTypeBuilder<Instructor> builder)
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Id).ValueGeneratedNever();

                builder.Property(x => x.FName)
                    .HasColumnType("VARCHAR")
                    .HasMaxLength(50).IsRequired();

                builder.Property(x => x.LName)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50).IsRequired();

                builder.HasOne(x => x.Office)
                        .WithOne(x => x.Instructor)
                        .HasForeignKey<Instructor>(x => x.OfficeId)
                        .IsRequired(false);

                builder.ToTable("Instructors");

                builder.HasData(LoadInstructors());
            }

            private static List<Instructor> LoadInstructors()
            {
                return new List<Instructor>
            {
                new Instructor { Id = 1, FName = "Ahmed", LName = "Abdullah", OfficeId = 1},
                new Instructor { Id = 2, FName = "Yasmeen", LName = "Yasmeen", OfficeId = 2},
                new Instructor { Id = 3, FName = "Khalid", LName = "Hassan", OfficeId = 3},
                new Instructor { Id = 4, FName = "Nadia", LName = "Ali", OfficeId = 4},
                new Instructor { Id = 5, FName = "Ahmed", LName = "Abdullah", OfficeId = 5},
            };
            }
        }
    
}
