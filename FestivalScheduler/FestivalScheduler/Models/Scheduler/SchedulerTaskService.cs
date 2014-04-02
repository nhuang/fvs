namespace FestivalScheduler.Models
{
    using System.Linq;
    using System.Web.Mvc;
    using Kendo.Mvc.UI;
    using System;
    using System.Data;
    using System.Data.Entity;
    using System.Collections.Generic;

    public class SchedulerTaskService : ISchedulerEventService<TaskViewModel>
    {

        private fschedulerEntities db;

        public SchedulerTaskService(fschedulerEntities context)
        {
            db = context;
        }

        public SchedulerTaskService()
            : this(new fschedulerEntities())
        {
        }

        public virtual IQueryable<TaskViewModel> GetAll()
        {
            return db.Tasks.ToList().Select(task => new TaskViewModel
            {
                TaskID = task.TaskID,
                Title = task.Title,
                Start = DateTime.SpecifyKind(task.Start, DateTimeKind.Utc),
                End = DateTime.SpecifyKind(task.End, DateTimeKind.Utc),
                StartTimezone = task.StartTimezone,
                EndTimezone = task.EndTimezone,
                Description = task.Description,
                IsAllDay = task.IsAllDay,
                RecurrenceRule = task.RecurrenceRule,
                RecurrenceException = task.RecurrenceException,
                RecurrenceID = task.RecurrenceID,
                OwnerID = task.OwnerID
            }).AsQueryable();  
        }

        public virtual void Insert(TaskViewModel task, ModelStateDictionary modelState)
        {
            if (ValidateModel(task, modelState))
            {
                if (string.IsNullOrEmpty(task.Title))
                {
                    task.Title = "";
                }

                var entity = task.ToEntity();

                db.Tasks.Add(entity);
                db.SaveChanges();

                task.TaskID = entity.TaskID;
            }
        }

        public virtual void Update(TaskViewModel task, ModelStateDictionary modelState)
        {
            if (ValidateModel(task, modelState))
            {
                if (string.IsNullOrEmpty(task.Title))
                {
                    task.Title = "";
                }

                var entity = task.ToEntity();
                db.Tasks.Attach(entity);

                db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public virtual void Delete(TaskViewModel task, ModelStateDictionary modelState)
        {
            var entity = task.ToEntity();
            db.Tasks.Attach(entity);

            var recurrenceExceptions = db.Tasks.Where(t => t.RecurrenceID == task.TaskID);

            foreach (var recurrenceException in recurrenceExceptions)
            {
                db.Tasks.Remove(recurrenceException);
            }

            db.Tasks.Remove(entity);
            db.SaveChanges();
        }
        public virtual IQueryable<TaskViewModel> RecreateTasks()
        {
            db.Database.ExecuteSqlCommand(string.Format("TRUNCATE TABLE TASKS "));
            db.SaveChanges();
            List<Meeting> meetings = db.Meetings.ToList<Meeting>();
            foreach (Meeting meeting in meetings)
            {
                try
                {
                    Task entity = new Task();
                    entity.Start = meeting.Start;
                    entity.End = meeting.End;
                    entity.Title = meeting.Title;
                    entity.IsAllDay = meeting.IsAllDay;
                    entity.RecurrenceRule = meeting.RecurrenceRule;
                    entity.RecurrenceID = meeting.RecurrenceID;
                    entity.RecurrenceException = meeting.RecurrenceException;
                    entity.StartTimezone = meeting.StartTimezone;
                    entity.EndTimezone = meeting.EndTimezone;
                    entity.Description = meeting.Description;

                    if (meeting.MeetingAttendees.Count() > 0)
                    {
                        try
                        {
                            entity.OwnerID = meeting.MeetingAttendees.FirstOrDefault().AttendeeID;
                        }
                        catch (Exception) { }
                    }
                    if (!string.IsNullOrEmpty(meeting.RoomID + ""))
                    {
                        //entity.RecurrenceID = meeting.RoomID;
                    }
                    db.Tasks.Add(entity);
                    db.SaveChanges();
                }
                catch (Exception) { }

            }


            SchedulerTaskService service = new SchedulerTaskService();
            return service.GetAll();
        }
        //TODO: better naming or re-factor
        private bool ValidateModel(TaskViewModel appointment, ModelStateDictionary modelState)
        {
            if (appointment.Start > appointment.End)
            {
                modelState.AddModelError("errors", "End date must be greater or equal to Start date.");
                return false;
            }
            
            return true;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}