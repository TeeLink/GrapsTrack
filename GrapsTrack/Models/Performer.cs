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
        public string LastName { get; set; }
        public string InfoLink { get; set; }

        public virtual ICollection<Event> Events { get; set; } = new List<Event>();
        public virtual ICollection<User> Followers { get; set; } = new List<User>(); 
    }
}