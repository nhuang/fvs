﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FestivalScheduler.Models.Resouces
{
    public class SupportTeamViewModel
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public int Value { get; set; }
        public string Color { get; set; }
        public bool Show { get; set; }

        public SupportTeam ToEntity()
        {
            var steam = new SupportTeam
            {
                ID = ID,
                Text = Text,
                Value = Value,
                Color = Color,
                Show = Show,
            };

            return steam;
        }
    }
}