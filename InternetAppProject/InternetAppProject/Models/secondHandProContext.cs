using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace secondHandPro.Models
{
    public class secondHandProContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public secondHandProContext() : base("name=secondHandProContext")
        {
        }

        public DbSet<Notice> Notices { get; set; }
        

        public DbSet<User> Users { get; set; }

        public System.Data.Entity.DbSet<secondHandPro.Models.Branch> Branches { get; set; }

        object placeHolderVariable;
        
    }
}
