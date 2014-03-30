using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FestivalScheduler.Controllers.Rules
{
    public class MeetingRule
    {

        public DateTime ResetMinMeetingDuration(DateTime start, DateTime end)
        {
            // if less than 45 minutes, the end time will be start + 45 minutes
            double difference = end.Subtract(start).TotalMinutes;

            if (difference <= 45)
            {
                end = start.AddMinutes(45);
            }
            else if (difference > 45 && difference < 60)
            {
                end = start.AddMinutes(60);
            }else if(difference >60 && difference< 75){
                end = start.AddMinutes(75);
            }
            return end;
        }
    }
}