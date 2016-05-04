using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GrapsTrack.Models
{
    public class Promotion
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        

        List<Event> Events = new List<Event>(); 
    }
}