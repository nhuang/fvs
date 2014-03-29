﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kendo.Mvc.UI;
using System.Web.Mvc;

namespace FestivalScheduler.Models.Resouces
{
    public class AttendeeService
    {
               private fschedulerEntities db;

        public AttendeeService(fschedulerEntities context)
        {
            db = context;
        }

        public AttendeeService()
            : this(new fschedulerEntities())
        {
        }


        public virtual IQueryable<AttendeeViewModel> GetAll()
        {
            return db.Attendees.ToList().Select(attendee => new AttendeeViewModel
                {
                    ID = attendee.ID,
                    Text = attendee.Text,
                    Value = attendee.Value,
                    Color = attendee.Color
                }).AsQueryable();
        }

        public virtual void Insert(AttendeeViewModel model, ModelStateDictionary modelState)
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

                db.Attendees.Add(entity);
                db.SaveChanges();

                model.ID = entity.ID;
            }
        }

        public virtual void Update(AttendeeViewModel model, ModelStateDictionary modelState)
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
                db.Attendees.Attach(entity);

                db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public virtual void Delete(AttendeeViewModel model, ModelStateDictionary modelState)
        {
            var entity = model.ToEntity();
            db.Attendees.Attach(entity);
            // TODO: here should verify the room id is not in the meeting tables
            db.Attendees.Remove(entity);
            db.SaveChanges();
        }

        private bool ValidateModel(AttendeeViewModel room, ModelStateDictionary modelState)
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