using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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

        public void Dispose()
        {
            db.Dispose();
        }
    }
}