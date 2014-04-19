using System;
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
                    Color = attendee.Color,
                    Show = attendee.Show,
                    Length = attendee.Length,
                    Type = attendee.Type
                }).AsQueryable();
        }

        public virtual IQueryable<AttendeeViewModel> GetAttendeesForScheduler()
        {
            string term = "In";
         
            return db.Attendees.ToList().Select(attendee => new AttendeeViewModel
            {
                ID = attendee.ID,
                Text = attendee.Text,
                Value = attendee.Value,
                Color = attendee.Color,
                Show = attendee.Show,
                Length = attendee.Length,
                Status = attendee.Status,
                Type = attendee.Type
            }).Where(r => r.Status == term && (r.Type == "Local" || r.Type == "International")).OrderBy(r => r.Value).AsQueryable();
        }

        public virtual IQueryable<ArtistViewModel> GetAllArtists()
        {
            return db.Attendees.ToList().Select(attendee => new ArtistViewModel
            {
                ID = attendee.ID,
                Text = attendee.Text,
                Value = attendee.Value,
                Color = attendee.Color,
                Show = attendee.Show,
                Length = attendee.Length,
                Type = attendee.Type,
                Status = attendee.Status,
                Company = attendee.Company,
                PrimaryFirstName = attendee.PrimaryFirstName,
                PrimaryLastName = attendee.PrimaryLastName,
                PrimaryAddress = attendee.PrimaryAddress,
                PrimaryCity = attendee.PrimaryCity,
                PrimaryProvState = attendee.PrimaryProvState,
                PrimaryCountry = attendee.PrimaryCountry,
                PrimaryPCZip = attendee.PrimaryPCZip,
                PrimaryPhone = attendee.PrimaryPhone,
                PrimaryEmail = attendee.PrimaryEmail,
                SecondaryFirstName = attendee.SecondaryFirstName,
                SecondaryLastName = attendee.SecondaryLastName,
                SecondaryAddress = attendee.SecondaryAddress,
                SecondaryCity = attendee.SecondaryCity,
                SecondaryPovState = attendee.SecondaryPovState,
                SecondaryCountry = attendee.SecondaryCountry,
                SecondaryPCZip = attendee.SecondaryPCZip,
                SecondaryPhone = attendee.SecondaryPhone,
                SecondaryEmail = attendee.SecondaryEmail,
                CastMembers = attendee.CastMembers,
                Playwright = attendee.Playwright,
                Director = attendee.Director,
                StageManager = attendee.StageManager,
                Designer = attendee.Designer,
                TeamSize = attendee.TeamSize,
                NewWork = attendee.NewWork,
                Genre = attendee.Genre,
                GenreOther = attendee.GenreOther,
                ShowRating = attendee.ShowRating,
                AgeRestriction = attendee.AgeRestriction,
                ShowContains = attendee.ShowContains,
                ContentAdvisory = attendee.ContentAdvisory,
                GeneralAdmission = attendee.GeneralAdmission,
                StudentSenior = attendee.StudentSenior,
                ShowDescription = attendee.ShowDescription,
                Website = attendee.Website,
                ShowImage = attendee.ShowImage,
                NameonCheque = attendee.NameonCheque,
                CompanyNameonCheque = attendee.CompanyNameonCheque,
                ChequeAddress = attendee.ChequeAddress,
                ChequeCity = attendee.ChequeCity,
                ChequeProvState = attendee.ChequeProvState,
                ChequeCountry = attendee.ChequeCountry,
                ChequePCZip = attendee.ChequePCZip,
                GST = attendee.GST,
                WhenNotAvailable = attendee.WhenNotAvailable,
                Sharing = attendee.Sharing,
                SharingRef = attendee.SharingRef,
                SharingCompany = attendee.SharingCompany,
                SharingShowTitle = attendee.SharingShowTitle,
                StagingRequirements = attendee.StagingRequirements,
                Intermission = attendee.Intermission,
                LightingRequirements = attendee.LightingRequirements,
                SoundRequirements = attendee.SoundRequirements,
                Dancing = attendee.Dancing,
                DancingType = attendee.DancingType,
                Projection = attendee.Projection,
                ImageSize = attendee.ImageSize,
                ThrowDistance = attendee.ThrowDistance,
                Holdovers = attendee.Holdovers,
                ScreenElevation = attendee.ScreenElevation,
                ScreenHeight = attendee.ScreenHeight,
                ScreenWidth = attendee.ScreenWidth,
                ProjectionRatio = attendee.ProjectionRatio,
                MediaType = attendee.MediaType,
                ShootFrom = attendee.ShootFrom,
                ShootFromOther = attendee.ShootFromOther,
                ScreenMaterial = attendee.ScreenMaterial,
                SoundOut = attendee.SoundOut,
                Liquids = attendee.Liquids,
                LiquidsDescribe = attendee.LiquidsDescribe,
                OpenFlames = attendee.OpenFlames,
                Loud = attendee.Loud,
                LoudDescribe = attendee.LoudDescribe,
                Firearms = attendee.Firearms,
                Smoking = attendee.Smoking,
                FogMachine = attendee.FogMachine,
                Strobe = attendee.Strobe,
                Hazer = attendee.Hazer,
                MoreLights = attendee.MoreLights,
                WirelessMic = attendee.WirelessMic,
                Frequencies = attendee.Frequencies,
                OtherEquipments = attendee.OtherEquipments,
                EquipmentSpecify = attendee.EquipmentSpecify,
                StageDesign = attendee.StageDesign,
                SpecialNeeds = attendee.SpecialNeeds,
                Comments = attendee.Comments,
                RehearsalTime = attendee.RehearsalTime,
                ComingFrom = attendee.ComingFrom,
                FestivalComingFrom = attendee.FestivalComingFrom,
                WhenArriving = attendee.WhenArriving,
                Release = attendee.Release,
                VenueName = attendee.VenueName,
                VenueAddress = attendee.VenueAddress,
                VenueTotal = attendee.VenueTotal,
                Wheelchair = attendee.Wheelchair,
                WheelchairCapacity = attendee.WheelchairCapacity,
                Washrooms = attendee.Washrooms,
                WheelchairWashrooms = attendee.WheelchairWashrooms,
                Alcohol = attendee.Alcohol,
                Food = attendee.Food,
                EnterEarly = attendee.EnterEarly,
                MinutesBefore = attendee.MinutesBefore,
                Bar = attendee.Bar,
                Minors = attendee.Minors,
                ShowDate = attendee.ShowDate,
                PayDate = attendee.PayDate,
                PayMethod = attendee.PayMethod,
                Amount = attendee.Amount,
                Refund = attendee.Refund,
                RefundDate = attendee.RefundDate,
                DateEntered = attendee.DateEntered,
                VenueNo = attendee.VenueNo
            }).AsQueryable();
        }


        public virtual List<ArtistViewModel> CountShowsForAttendee()
        {
            IEnumerable<ArtistViewModel> iAttendees = db.Attendees.ToList().Select(attendee => new ArtistViewModel
                {
                    ID = attendee.ID,
                    Text = attendee.Text,
                    Value = attendee.Value,
                    Color = attendee.Color,
                    Show = attendee.Show,
                    Length = attendee.Length,
                    Type = attendee.Type
                });

            List<ArtistViewModel> result = iAttendees.ToList();
            foreach (AttendeeViewModel comp in result)
            {
                comp.NumberOfShows = db.MeetingAttendees.Count(m => m.AttendeeID == comp.Value);
            }
            return result;
        }

 

        public virtual void UpdateAttendeesToShow(string[] strs)
        {
            if (strs != null && strs.Length > 0)
            {
                db.Database.ExecuteSqlCommand("update Attendees set show = 0");
                int attendeeId = 0;
                for (int i = 0; i < strs.Length; i++)
                {
                    attendeeId = Convert.ToInt32(strs[i]);
                    Attendee r = db.Attendees.FirstOrDefault(attendee => attendee.Value == attendeeId);
                    r.Show = true;
                    db.SaveChanges();
                }
            }
            else
            {
                db.Database.ExecuteSqlCommand("update Attendees set show = 0");
                db.SaveChanges();
            }

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