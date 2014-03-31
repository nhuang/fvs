namespace FestivalScheduler.Models.Resouces
{
    using System.Linq;
    using System.Web.Mvc;
    using Kendo.Mvc.UI;
    using System;
    using System.Data;
    using System.Data.Entity;
    public class SysSettingService
    {
        private fschedulerEntities db;

        public SysSettingService(fschedulerEntities context)
        {
            db = context;
        }

        public SysSettingService()
            : this(new fschedulerEntities())
        {
        }

        public virtual IQueryable<SysSettingViewModel> GetAll()
        {
            return db.SysSettings.ToList().Select(sys => new SysSettingViewModel
                {
                    ID = sys.ID,
                    KeyName = sys.KeyName,
                    ValueType = sys.ValueType,
                    Value = sys.Value,
                    Description = sys.Description,
                    KeyGroup = sys.KeyGroup
                }).AsQueryable();
        }

        public virtual SysSettingViewModel GetById(int id)
        {
            return db.SysSettings.Select(sys => new SysSettingViewModel
            {
                ID = sys.ID,
                KeyName = sys.KeyName,
                ValueType = sys.ValueType,
                Value = sys.Value,
                Description = sys.Description,
                KeyGroup = sys.KeyGroup
            }).Where(m => m.ID == id).FirstOrDefault();
        }

        public virtual SysSettingViewModel GetAbout()
        {
            return db.SysSettings.Select(sys => new SysSettingViewModel
            {
                ID = sys.ID,
                KeyName = sys.KeyName,
                ValueType = sys.ValueType,
                Value = sys.Value,
                Description = sys.Description,
                KeyGroup = sys.KeyGroup
            }).Where(m => m.KeyName.Equals("About")).FirstOrDefault();
        }

        public virtual SysSettingViewModel GetContact()
        {
            return db.SysSettings.Select(sys => new SysSettingViewModel
            {
                ID = sys.ID,
                KeyName = sys.KeyName,
                ValueType = sys.ValueType,
                Value = sys.Value,
                Description = sys.Description,
                KeyGroup = sys.KeyGroup
            }).Where(m => m.KeyName.Equals("Contact")).FirstOrDefault();
        }

        public virtual void Insert(SysSettingViewModel sys, ModelStateDictionary modelState)
        {
            if (ValidateModel(sys, modelState))
            {
                if (string.IsNullOrEmpty(sys.Description))
                {
                    sys.Description = "";
                }

                var entity = sys.ToEntity();

                db.SysSettings.Add(entity);
                db.SaveChanges();

                sys.ID = entity.ID;
            }
        }

        public virtual void Update(SysSettingViewModel sys, ModelStateDictionary modelState)
        {
            if (ValidateModel(sys, modelState))
            {
                if (string.IsNullOrEmpty(sys.Description))
                {
                    sys.Description = "";
                }
                var entity = sys.ToEntity();
                db.SysSettings.Attach(entity);

                db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public virtual void Delete(SysSettingViewModel sys, ModelStateDictionary modelState)
        {
            var entity = sys.ToEntity();
            db.SysSettings.Attach(entity);
            db.SysSettings.Remove(entity);
            db.SaveChanges();
        }

        private bool ValidateModel(SysSettingViewModel sys, ModelStateDictionary modelState)
        {
            return true;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
