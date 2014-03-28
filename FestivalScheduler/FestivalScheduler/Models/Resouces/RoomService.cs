using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kendo.Mvc.UI;
using System.Web.Mvc;

namespace FestivalScheduler.Models.Resouces
{
    public class RoomService
    {
        private fschedulerEntities db;

        public RoomService(fschedulerEntities context)
        {
            db = context;
        }

        public RoomService()
            : this(new fschedulerEntities())
        {
        }


        public virtual IQueryable<RoomViewModel> GetAll()
        {
            return db.Rooms.ToList().Select(room => new RoomViewModel
                {
                    ID = room.ID,
                    Text = room.Text,
                    Value = room.Value,
                    Color = room.Color
                }).AsQueryable();
        }

        public virtual void Insert(RoomViewModel room, ModelStateDictionary modelState)
        {
            if (ValidateModel(room, modelState))
            {
                if (string.IsNullOrEmpty(room.Text))
                {
                    room.Text = "";
                }

                if (room.Value < 0)
                {
                    room.Value = 100;
                }

                var entity = room.ToEntity();

                db.Rooms.Add(entity);
                db.SaveChanges();

                room.ID = entity.ID;
            }
        }

        public virtual void Update(RoomViewModel room, ModelStateDictionary modelState)
        {
            if (ValidateModel(room, modelState))
            {
                if (string.IsNullOrEmpty(room.Text))
                {
                    room.Text = "";
                }

                if (room.Value < 0)
                {
                    room.Value = 100;
                }
                var entity = room.ToEntity();
                db.Rooms.Attach(entity);

                db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public virtual void Delete(RoomViewModel room, ModelStateDictionary modelState)
        {
            var entity = room.ToEntity();
            db.Rooms.Attach(entity);
            // TODO: here should verify the room id is not in the meeting tables
            db.Rooms.Remove(entity);
            db.SaveChanges();
        }

        private bool ValidateModel(RoomViewModel room, ModelStateDictionary modelState)
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