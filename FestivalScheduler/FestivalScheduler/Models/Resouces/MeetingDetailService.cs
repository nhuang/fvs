using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FestivalScheduler.Models.Resouces
{
    public class MeetingDetailService
    {
        private fschedulerEntities db;

        public MeetingDetailService(fschedulerEntities context)
        {
            db = context;
        }

        public MeetingDetailService()
            : this(new fschedulerEntities())
        {
        }

        public List<MeetingDetailViewModel> GetAll()
        {
            List<MeetingDetailViewModel> result = new List<MeetingDetailViewModel>();
            // 
            
            return result;
        }
    }
}