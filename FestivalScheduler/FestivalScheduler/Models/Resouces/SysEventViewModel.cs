using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FestivalScheduler.Models.Resouces
{
    public class SysEventViewModel
    {
        public long ID { get; set; }
        public string Level { get; set; }
        public string Message { get; set; }
        public System.DateTime UpdateAt { get; set; }
        public string CreateBy { get; set; }

        public readonly static string INFO = "INFO";
        public readonly static string WARNING = "WARNING";

        public SysEvent ToEntity()
        {
            var model = new SysEvent
            {
                ID = ID,
                Level = Level,
                Message = Message,
                UpdateAt = DateTime.Now,
                CreateBy = CreateBy
            };

            return model;
        }

        public SysEventViewModel Init(string level, string message, string createBy)
        {
            var model = new SysEventViewModel
            {
                ID = ID,
                Level = level,
                Message = message,
                UpdateAt = DateTime.Now,
                CreateBy = createBy
            };

            return model;

        }
    }
}