using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;


namespace TODO.Models
{
    public class ActivityContext: DbContext
    {
        // Used to create a database table called activity
        public DbSet<Activities> Activities { get; set; }
    }
}