using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.UI;
using System;
using System.Data;
using System.Data.Entity;

namespace FestivalScheduler.Models.Resouces
{
    public class SysEventService
    {
        private fschedulerEntities db;

        public SysEventService(fschedulerEntities context)
        {
            db = context;
        }

        public SysEventService()
            : this(new fschedulerEntities())
        {
        }


        public virtual IQueryable<SysEventViewModel> GetAll()
        {
            return db.SysEvents.ToList().Select(sys => new SysEventViewModel
                {
                    ID = sys.ID,
                    Level = sys.Level,
                    Message = sys.Message,
                    UpdateAt = sys.UpdateAt,
                    CreateBy = sys.CreateBy
                }).OrderByDescending(m => m.ID).AsQueryable();
        }

        public virtual SysEventViewModel GetById(int id)
        {
            return db.SysEvents.Select(sys => new SysEventViewModel
            {
                ID = sys.ID,
                Level = sys.Level,
                Message = sys.Message,
                UpdateAt = sys.UpdateAt,
                CreateBy = sys.CreateBy
            }).Where(m => m.ID == id).FirstOrDefault();
        }

        public virtual IQueryable<SysEventViewModel> GetTodayEvents()
        {
            return db.SysEvents.ToList().Select(sys => new SysEventViewModel
            {
                ID = sys.ID,
                Level = sys.Level,
                Message = sys.Message,
                UpdateAt = sys.UpdateAt,
                CreateBy = sys.CreateBy
            }).Where(m => m.UpdateAt >= DateTime.Now.Date)
            .OrderByDescending(m => m.ID)
            .AsQueryable();
        }


        public virtual void Insert(SysEventViewModel sys, ModelStateDictionary modelState)
        {
            if (ValidateModel(sys, modelState))
            {
                if (string.IsNullOrEmpty(sys.Message))
                {
                    sys.Message = "";
                }

                var entity = sys.ToEntity();

                db.SysEvents.Add(entity);
                db.SaveChanges();

                sys.ID = entity.ID;
            }
        }

        public virtual void Update(SysEventViewModel sys, ModelStateDictionary modelState)
        {
            if (ValidateModel(sys, modelState))
            {
                if (string.IsNullOrEmpty(sys.Message))
                {
                    sys.Message = "";
                }
                var entity = sys.ToEntity();
                db.SysEvents.Attach(entity);

                db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public virtual void Delete(SysEventViewModel sys, ModelStateDictionary modelState)
        {
            var entity = sys.ToEntity();
            db.SysEvents.Attach(entity);
            db.SysEvents.Remove(entity);
            db.SaveChanges();
        }

        private bool ValidateModel(SysEventViewModel sys, ModelStateDictionary modelState)
        {
            return true;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}