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
    public class RoomService
    {
        private fschedulerEntities db;
        public string INDOOR = "Indoor";
        public string OUTDOOR = "Outdoor";
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
                    Color = room.Color,
                    Show = room.Show,
                    Address = room.Address,
                    RoomType = room.RoomType
                }).AsQueryable();
        }

        public virtual IQueryable<RoomViewModel> GetRoomsByType(string roomType)
        {
            return db.Rooms.ToList().Select(room => new RoomViewModel
            {
                ID = room.ID,
                Text = room.Text,
                Value = room.Value,
                Color = room.Color,
                Show = room.Show,
                Address = room.Address,
                RoomType = room.RoomType
            }).Where(m => m.RoomType == roomType).OrderBy(m=>m.Value).AsQueryable();
        }


        public virtual IQueryable<RoomViewModel> GetRoomsForScheduler(string roomType)
        {
            return db.Rooms.ToList().Select(room => new RoomViewModel
            {
                ID = room.ID,
                Text = room.Text,
                Value = room.Value,
                Color = room.Color,
                Show = room.Show,
                Address = room.Address,
                RoomType = room.RoomType
            }).Where(r => r.Show == true && r.RoomType==roomType).AsQueryable();
        }

        public virtual void UpdateRoomsToShow(string[] strs )
        {
            if (strs != null && strs.Length > 0)
            {
                db.Database.ExecuteSqlCommand("update Room set show = 0");
                int roomId = 0;
                for (int i = 0; i < strs.Length; i++)
                {
                    roomId = Convert.ToInt32(strs[i]);
                    Room r = db.Rooms.FirstOrDefault(room => room.Value == roomId);
                    r.Show = true;
                    db.SaveChanges();
                }
            }
            else
            {
                db.Database.ExecuteSqlCommand("update Room set show = 0");
                db.SaveChanges();
            }        
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

                UpdateAttendeeRoomDetail(entity);
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

        public void UpdateAttendeeRoomDetail(Room room)
        {
            List<Attendee> models = db.Attendees.Where(m => m.VenueNo == room.Value.ToString()).ToList();
            foreach (Attendee item in models)
            {
                item.VenueName = room.Text;
                item.VenueAddress = room.Address;
                db.Attendees.Attach(item);
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
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