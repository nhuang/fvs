using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FestivalScheduler.Models.Resouces
{
    public class AttendeeViewModel
    {

        public int ID { get; set; }
        [Display(Name = "Show Title"), Required]
        public string Text { get; set; }
        [Display(Name = "Reference Number"), Required]
        public int Value { get; set; }
        [Display(Name = "Color"), Required]
        public string Color { get; set; }
        public bool Show { get; set; }
        [Display(Name = "Length(min.)"),Required]
        public int Length { get; set; }
         [Display(Name = "Number of Shows")]
        public int NumberOfShows { get; set; }

        public Attendee ToEntity()
        {
            var attendee = new Attendee
            {
                ID = ID,
                Text = Text,
                Value = Value,
                Color = Color,
                Show = Show,
                Length = Length
            };

            return attendee;
        }
    }
}