using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FestivalScheduler.Models.Resouces
{
    public class SysSettingViewModel
    {
        public int ID { get; set; }
        public string KeyName { get; set; }
        public string ValueType { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public string KeyGroup { get; set; }

        public SysSetting ToEntity()
        {
            var sysSetting = new SysSetting
            {
                ID = ID,
                KeyName = KeyName,
                ValueType = ValueType,
                Value = Value,
                Description = Description,
                KeyGroup = KeyGroup
            };

            return sysSetting;
        }

    }
}