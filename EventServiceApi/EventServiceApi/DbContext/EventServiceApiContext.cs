using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EventServiceApi.Models
{
    public class EventServiceApiContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public EventServiceApiContext() : base("name=EventServiceApiContext")
        {
        }

        public System.Data.Entity.DbSet<EventServiceApi.Models.Company> Companies { get; set; }

        public System.Data.Entity.DbSet<EventServiceApi.Models.Polyclinic> Polyclinics { get; set; }

        public System.Data.Entity.DbSet<EventServiceApi.Models.Cemetery> Cemeteries { get; set; }

        public System.Data.Entity.DbSet<EventServiceApi.Models.Preacher> Preachers { get; set; }

        public System.Data.Entity.DbSet<EventServiceApi.Models.Transport> Transports { get; set; }
    }
}
