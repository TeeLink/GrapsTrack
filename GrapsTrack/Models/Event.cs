﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GrapsTrack.Models
{
    public class Event
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        public Promotion Promotion { get; set; }
    }
}