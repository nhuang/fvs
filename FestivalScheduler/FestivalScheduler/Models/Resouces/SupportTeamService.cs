using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kendo.Mvc.UI;
using System.Web.Mvc;

using System.Data;
using System.Data.Entity;

namespace FestivalScheduler.Models.Resouces
{
    public class SupportTeamService
    {
       

       private fschedulerEntities db;

        public SupportTeamService(fschedulerEntities context)
        {
            db = context;
        }

        public SupportTeamService()
            : this(new fschedulerEntities())
        {
        }


        public virtual IQueryable<SupportTeamViewModel> GetAll()
        {
            return db.SupportTeams.ToList().Select(sTeam => new SupportTeamViewModel
                {
                    ID = sTeam.ID,
                    Text = sTeam.Text,
                    Value = sTeam.Value,
                    Color = sTeam.Color,
                    Show = sTeam.Show
                }).AsQueryable();
        }

    
        public virtual void Insert(SupportTeamViewModel model, ModelStateDictionary modelState)
        {
            if (ValidateModel(model, modelState))
            {
                if (string.IsNullOrEmpty(model.Text))
                {
                    model.Text = "";
                }

                if (model.Value < 0)
                {
                    model.Value = 100;
                }

                var entity = model.ToEntity();

                db.SupportTeams.Add(entity);
                db.SaveChanges();

                model.ID = entity.ID;
            }
        }

        public virtual void Update(SupportTeamViewModel model, ModelStateDictionary modelState)
        {
            if (ValidateModel(model, modelState))
            {
                if (string.IsNullOrEmpty(model.Text))
                {
                    model.Text = "";
                }

                if (model.Value < 0)
                {
                    model.Value = 100;
                }

                var entity = model.ToEntity();
                db.SupportTeams.Attach(entity);

                db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public virtual void Delete(SupportTeamViewModel model, ModelStateDictionary modelState)
        {
            var entity = model.ToEntity();
            db.SupportTeams.Attach(entity);
            // TODO: here should verify the room id is not in the meeting tables
            db.SupportTeams.Remove(entity);
            db.SaveChanges();
        }

        private bool ValidateModel(SupportTeamViewModel room, ModelStateDictionary modelState)
        {
            //if (appointment.Start > appointment.End)
            //{
            //    modelState.AddModelError("errors", "End date must be greater or equal to Start date.");
            //    return false;
            //}

            return true;
        }


        public void Dispose()
        {
            db.Dispose();
        }
    }
}