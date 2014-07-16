using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TODO.Models
{
    public class Activities
    {
        // ID object is automatically generated when user creates new activity 
        public int ID { get; set; }
        // Activity object to be placed in the activity table
        public string Activity { get; set; }
        // Displays this format for the date
        [DisplayFormat(DataFormatString = "{0:d}")]
        // Date object to be placed in the activity table 
        public System.DateTime Date { get; set; }
    }
}