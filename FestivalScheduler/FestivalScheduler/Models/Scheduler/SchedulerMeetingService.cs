namespace FestivalScheduler.Models
{
    using Kendo.Mvc.UI;
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using System.Collections.Generic;
    using FestivalScheduler.Controllers.Rules;

    public class SchedulerMeetingService : ISchedulerEventService<MeetingViewModel>
    {
        private fschedulerEntities db;
        private MeetingRule meetingRules;

        public SchedulerMeetingService(fschedulerEntities context)
        {
            db = context;
            meetingRules = new MeetingRule();
        }

        public SchedulerMeetingService()
            : this(new fschedulerEntities())
        {
        }

        public virtual IQueryable<MeetingViewModel> GetAll()
        {
            return db.Meetings.ToList().Select(meeting => new MeetingViewModel
                {
                    MeetingID = meeting.MeetingID,
                    Title = meeting.Title,
                    Start = DateTime.SpecifyKind(meeting.Start, DateTimeKind.Utc),
                    End = DateTime.SpecifyKind(meeting.End, DateTimeKind.Utc),
                    StartTimezone = meeting.StartTimezone,
                    EndTimezone = meeting.EndTimezone,
                    Description = meeting.Description,
                    IsAllDay = meeting.IsAllDay,
                    RoomID = meeting.RoomID,
                    RecurrenceRule = meeting.RecurrenceRule,
                    RecurrenceException = meeting.RecurrenceException,
                    RecurrenceID = meeting.RecurrenceID,
                    Attendees = meeting.MeetingAttendees.Select(m => m.AttendeeID).ToArray()
                }).AsQueryable();
        }

        public List<Meeting> GetAllMeetingAgenda()
        {
            List<Meeting> results = new List<Meeting>();
            // get all attendees and order by ref number
            var attendees = db.Attendees.ToList().OrderBy(o => o.Value);

            foreach (Attendee a in attendees)
            {
                // get all meetings by this attendee
                var meetingAttendees = db.MeetingAttendees.ToList().Where(m => m.AttendeeID == a.Value);
                int[] meetingIds = new int[meetingAttendees.Count()];
                for (int i = 0; i < meetingIds.Length; i++)
                {
                    meetingIds[i] = meetingAttendees.ElementAt(i).MeetingID;
                }
                var query = db.Meetings.Where(m => meetingIds.Contains(m.MeetingID)).OrderBy(m => m.Start);
                foreach (Meeting j in query)
                {
                    results.Add(j);
                }
            }
            return results;
        }

        public void ResetAllMeetingTitle()
        {
            // get all attendees and order by ref number
            var attendees = db.Attendees.ToList().OrderBy(o => o.Value);
            string tempTitle = "";
            foreach (Attendee a in attendees)
            {
                // get all meetings by this attendee
                var meetingAttendees = db.MeetingAttendees.ToList().Where(m => m.AttendeeID == a.Value);
                int[] meetingIds = new int[meetingAttendees.Count()];
                for (int i = 0; i < meetingIds.Length; i++)
                {
                    meetingIds[i] = meetingAttendees.ElementAt(i).MeetingID;
                }
                var query = db.Meetings.Where(m => meetingIds.Contains(m.MeetingID)).OrderBy(m => m.Start);
                foreach (Meeting j in query)
                {
                    tempTitle = string.Format("#{0} {1}", a.Value, a.Text);
                    if (string.Compare(j.Title, tempTitle) != 0)
                    {
                        j.Title = tempTitle;
                        db.Entry(j).State = System.Data.Entity.EntityState.Modified;
                    }
                }
            }
            db.SaveChanges();
        }

        public virtual void Insert(MeetingViewModel meeting, ModelStateDictionary modelState)
        {
            if (ValidateModel(meeting, modelState))
            {
                meeting = ApplyMeetingRules(meeting);

                if (meeting.Attendees == null)
                {
                    meeting.Attendees = new int[0];
                }

                if (string.IsNullOrEmpty(meeting.Title))
                {
                    meeting.Title = "";
                }

                var entity = meeting.ToEntity();

                foreach (var attendeeId in meeting.Attendees)
                {
                    entity.MeetingAttendees.Add(new MeetingAttendee
                    {
                        AttendeeID = attendeeId
                    });
                }


                db.Meetings.Add(entity);
                db.SaveChanges();

                meeting.MeetingID = entity.MeetingID;
            }
        }



        public virtual void Update(MeetingViewModel meeting, ModelStateDictionary modelState)
        {
            if (ValidateModel(meeting, modelState))
            {

                meeting = ApplyMeetingRules(meeting);

                var entity = db.Meetings.Include("MeetingAttendees").FirstOrDefault(m => m.MeetingID == meeting.MeetingID);

                entity.Title = meeting.Title;
                entity.Start = meeting.Start;
                entity.End = meeting.End;
                entity.Description = meeting.Description;
                entity.IsAllDay = meeting.IsAllDay;
                entity.RoomID = meeting.RoomID;
                entity.RecurrenceID = meeting.RecurrenceID;
                entity.RecurrenceRule = meeting.RecurrenceRule;
                entity.RecurrenceException = meeting.RecurrenceException;
                entity.StartTimezone = meeting.StartTimezone;
                entity.EndTimezone = meeting.EndTimezone;

                foreach (var meetingAttendee in entity.MeetingAttendees.ToList())
                {
                    entity.MeetingAttendees.Remove(meetingAttendee);
                }

                if (meeting.Attendees != null)
                {
                    foreach (var attendeeId in meeting.Attendees)
                    {
                        var meetingAttendee = new MeetingAttendee
                        {
                            MeetingID = entity.MeetingID,
                            AttendeeID = attendeeId
                        };

                        entity.MeetingAttendees.Add(meetingAttendee);
                    }
                }
                db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public virtual void Delete(MeetingViewModel meeting, ModelStateDictionary modelState)
        {
            if (meeting.Attendees == null)
            {
                meeting.Attendees = new int[0];
            }

            var entity = meeting.ToEntity();

            db.Meetings.Attach(entity);

            var attendees = meeting.Attendees.Select(attendee => new MeetingAttendee
            {
                AttendeeID = attendee,
                MeetingID = entity.MeetingID
            });

            foreach (var attendee in attendees)
            {
                db.MeetingAttendees.Attach(attendee);
            }

            entity.MeetingAttendees.Clear();

            var recurrenceExceptions = db.Meetings.Where(m => m.RecurrenceID == entity.MeetingID);

            foreach (var recurrenceException in recurrenceExceptions)
            {
                db.Meetings.Remove(recurrenceException);
            }

            db.Meetings.Remove(entity);
            db.SaveChanges();
        }

        private MeetingViewModel ApplyMeetingRules(MeetingViewModel meeting)
        {
            if (meeting.Attendees != null)
            {
                int aId = meeting.Attendees.First();
                Attendee attendee = db.Attendees.Where(m => m.Value == aId).FirstOrDefault();
                meeting.End = meeting.Start.AddMinutes(attendee.Length);
            }


            // update meeting title
            meeting.Title = ResetMeetingTitle(meeting.Attendees);
            meeting.Description = ResetMeetingDescription(meeting.RoomID, meeting.Description);
            // update meeting end time
            meeting.End = meetingRules.ResetMinMeetingDuration(meeting.Start, meeting.End);

            return meeting;
        }

        private string ResetMeetingTitle(System.Collections.Generic.IEnumerable<int> enumerable)
        {
            string result = "";
            if (enumerable == null)
            {
                result = "No title";
            }
            else
            {
                Attendee attendee = null;
                foreach (int i in enumerable)
                {
                    attendee = db.Attendees.Where(w => w.Value == i).FirstOrDefault();
                    if (attendee != null)
                    {
                        result += string.Format("#{0} {1}\n", attendee.Value, attendee.Text);
                    }
                }

            }
            return result.Trim();
        }

        private string ResetMeetingDescription(int? Id, string description)
        {
            string result = "";

            if (Id == null)
            {
                result = "Waiting";
            }
            else
            {
                Room room = db.Rooms.Where(q => q.Value == Id).FirstOrDefault();
                result = string.Format("At: {0}.\n", room.Text);
            }
            return result;

        }
        private bool ValidateModel(MeetingViewModel appointment, ModelStateDictionary modelState)
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