using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FestivalScheduler.Models.Resouces
{
    public class AttendeeViewModel
    {

        public int ID { get; set; }
        public string Text { get; set; }
        public int Value { get; set; }
        public string Color { get; set; }
        public bool Show { get; set; }
        public int Length { get; set; }

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