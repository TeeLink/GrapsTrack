using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GrapsTrack.Models
{
    public class Performer
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public enum Gender 
        {
            Male,
            Female
        }

        List<Event> Events = new List<Event>();
    }
}