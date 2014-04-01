using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FestivalScheduler.Models.Resouces
{
    public class MeetingDetailViewModel
    {
        MeetingViewModel mvm { get; set; }
        RoomViewModel rvm { get; set; }
        AttendeeViewModel avm { get; set; }
        SupportTeamViewModel svm { get; set; }
    }
}