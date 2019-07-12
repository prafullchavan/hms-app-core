using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace lexis.hms.data.Entities
{


    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(GetConnectionString());
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS01;Integrated Security=SSPI;Database=lexis_hms;Trusted_Connection=True;");
        }
        
        //private static string GetConnectionString()
        //{
        //    const string databaseName = "webapijwt";
        //    const string databaseUser = "";
        //    const string databasePass = "";

        //    return $"Server=localhost;" +
        //           $"database={databaseName};" +
        //           $"uid={databaseUser};" +
        //           $"pwd={databasePass};" +
        //           $"pooling=true;";
        //}
    }


    public class ApplicationUserDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var dbContext = new ApplicationDbContext(new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(@"Server=localhost\SQLEXPRESS01;Integrated Security=SSPI;Database=lexis_hms;Trusted_Connection=True;").Options);

            dbContext.Database.Migrate();
            return dbContext;
        }
    }



    public class ApplicationUser : IdentityUser
    {

        [MaxLength(200)]
        public String FirstName { get; set; }

        [Required]
        [MaxLength(250)]
        public String LastName { get; set; }
    }

}
