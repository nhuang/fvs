using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kendo.Mvc.UI;
using System.Web.Mvc;
using LINQtoCSV;

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


        public virtual IQueryable<AttendeeViewModel> GetAttendeesIndoorForScheduler(string term)
        {
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
            }).Where(r => r.Status == term && (r.Type == "Local" || r.Type == "International" || r.Type == "National" || r.Type == "TYA")).OrderBy(r => r.Value).AsQueryable();
        }

        public virtual IQueryable<AttendeeViewModel> GetAttendeesOutdoorForScheduler(string term)
        {

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
            }).Where(r => r.Status == term && r.Type == "Outdoor").OrderBy(r => r.Value).AsQueryable();
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

        public virtual ArtistViewModel GetArtistsByID(int ID)
        {
            return db.Attendees.Where(m => m.ID == ID).Select(attendee => new ArtistViewModel
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
            }).FirstOrDefault();
        }


        public virtual IQueryable<ArtistViewExportModel> GetAllArtistsForExportData()
        {
            return db.Attendees.ToList().Select(attendee => new ArtistViewExportModel
            {
                Text = attendee.Text,
                Value = attendee.Value,
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
                ChequeAddress = attendee.ChequeAddress,
                ChequeCity = attendee.ChequeCity,
                ChequeProvState = attendee.ChequeProvState,
                ChequeCountry = attendee.ChequeCountry,
                ChequePCZip = attendee.ChequePCZip,
                GST = attendee.GST,
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
                DateEntered = attendee.DateEntered
            }).OrderBy(m => m.Value).AsQueryable();
        }

        public virtual string GetAllArtistsForExport()
        {
            string msg = "";
            string fileName = "ArtistMasterList.csv";
            string downloadPath = HttpContext.Current.Server.MapPath("~/File/Download/") + fileName;
            try
            {
                List<ArtistViewExportModel> results = GetAllArtistsForExportData().ToList();

                List<MeetingAttendee> ma;
                foreach (ArtistViewExportModel item in results)
                {
                    ma = db.MeetingAttendees.Where(m => m.AttendeeID == item.Value).ToList();
                    int[] keys = new int[ma.Count()];
                    for (int i = 0; i < ma.Count(); i++)
                    {
                        keys[i] = ma.ElementAt(i).MeetingID;
                    }
                    List<Meeting> meetings = (from meeting in db.Meetings
                                              where keys.Contains(meeting.MeetingID)
                                              select meeting).ToList<Meeting>();
                    meetings = meetings.OrderBy(m => m.Start).ToList();
                    foreach (Meeting meeting in meetings)
                    {
                        item.ShowDate += string.Format("{0} - {1}\r\n", meeting.Start.ToString("MMM hh:mm tt"), meeting.End.ToString("hh:mm tt"));
                    }
                }

                CsvContext cc = new CsvContext();
                cc.Write(results, downloadPath);
            }
            catch (Exception e)
            {
                msg = string.Format("Error: {0}", e.Message);
            }

            return msg = downloadPath;
        }

        public virtual List<ArtistViewModel> CountShowsForAttendee()
        {
            IEnumerable<ArtistViewModel> iAttendees = db.Attendees.Where(m => m.Status == "In").ToList().Select(attendee => new ArtistViewModel
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


        public string  Update(int id, FormCollection collection, ModelStateDictionary modelState)
        {
            try
            {
                Attendee attendee = db.Attendees.Where(m => m.ID == id).FirstOrDefault();

                attendee.Value = Convert.ToInt32(collection.GetValues("Value")[0]);
                attendee.Text = Convert.ToString(collection.GetValues("Text")[0]);
                attendee.Length = Convert.ToInt32(collection.GetValues("Length")[0]);
                attendee.Status = Convert.ToString(collection.GetValues("Status")[0]);
                attendee.Company = Convert.ToString(collection.GetValues("Company")[0]);
                attendee.Type = Convert.ToString(collection.GetValues("Type")[0]);
                attendee.PrimaryFirstName = Convert.ToString(collection.GetValues("PrimaryFirstName")[0]);
                attendee.PrimaryLastName = Convert.ToString(collection.GetValues("PrimaryLastName")[0]);
                attendee.PrimaryPhone = Convert.ToString(collection.GetValues("PrimaryPhone")[0]);
                attendee.PrimaryEmail = Convert.ToString(collection.GetValues("PrimaryEmail")[0]);
                attendee.PrimaryAddress = Convert.ToString(collection.GetValues("PrimaryAddress")[0]);
                attendee.PrimaryCity = Convert.ToString(collection.GetValues("PrimaryCity")[0]);
                attendee.PrimaryProvState = Convert.ToString(collection.GetValues("PrimaryProvState")[0]);
                attendee.PrimaryCountry = Convert.ToString(collection.GetValues("PrimaryCountry")[0]);
                attendee.PrimaryPCZip = Convert.ToString(collection.GetValues("PrimaryPCZip")[0]);
                attendee.SecondaryFirstName = Convert.ToString(collection.GetValues("SecondaryFirstName")[0]);
                attendee.SecondaryLastName = Convert.ToString(collection.GetValues("SecondaryLastName")[0]);
                attendee.SecondaryPhone = Convert.ToString(collection.GetValues("SecondaryPhone")[0]);
                attendee.SecondaryEmail = Convert.ToString(collection.GetValues("SecondaryEmail")[0]);
                attendee.SecondaryAddress = Convert.ToString(collection.GetValues("SecondaryAddress")[0]);
                attendee.SecondaryCity = Convert.ToString(collection.GetValues("SecondaryCity")[0]);
                attendee.SecondaryPovState = Convert.ToString(collection.GetValues("SecondaryPovState")[0]);
                attendee.SecondaryCountry = Convert.ToString(collection.GetValues("SecondaryCountry")[0]);
                attendee.SecondaryPCZip = Convert.ToString(collection.GetValues("SecondaryPCZip")[0]);
                attendee.Playwright = Convert.ToString(collection.GetValues("Playwright")[0]);
                attendee.Director = Convert.ToString(collection.GetValues("Director")[0]);
                attendee.StageManager = Convert.ToString(collection.GetValues("StageManager")[0]);
                attendee.Designer = Convert.ToString(collection.GetValues("Designer")[0]);
                attendee.CastMembers = Convert.ToString(collection.GetValues("CastMembers")[0]);
                attendee.TeamSize = Convert.ToString(collection.GetValues("TeamSize")[0]);
                attendee.NewWork = Convert.ToString(collection.GetValues("NewWork")[0]);
                attendee.Genre = Convert.ToString(collection.GetValues("Genre")[0]);
                attendee.ShowRating = Convert.ToString(collection.GetValues("ShowRating")[0]);
                attendee.AgeRestriction = Convert.ToString(collection.GetValues("AgeRestriction")[0]);
                attendee.ShowContains = Convert.ToString(collection.GetValues("ShowContains")[0]);
                attendee.ContentAdvisory = Convert.ToString(collection.GetValues("ContentAdvisory")[0]);
                attendee.GeneralAdmission = Convert.ToString(collection.GetValues("GeneralAdmission")[0]);
                attendee.StudentSenior = Convert.ToString(collection.GetValues("StudentSenior")[0]);
                attendee.Website = Convert.ToString(collection.GetValues("Website")[0]);
                attendee.ShowDescription = Convert.ToString(collection.GetValues("ShowDescription")[0]);
                attendee.ShowImage = Convert.ToString(collection.GetValues("ShowImage")[0]);
                attendee.NameonCheque = Convert.ToString(collection.GetValues("NameonCheque")[0]);
                attendee.CompanyNameonCheque = Convert.ToString(collection.GetValues("CompanyNameonCheque")[0]);
                attendee.ChequeProvState = Convert.ToString(collection.GetValues("ChequeProvState")[0]);
                attendee.ChequeCountry = Convert.ToString(collection.GetValues("ChequeCountry")[0]);
                attendee.ChequePCZip = Convert.ToString(collection.GetValues("ChequePCZip")[0]);
                attendee.Sharing = Convert.ToString(collection.GetValues("Sharing")[0]);
                attendee.SharingRef = Convert.ToString(collection.GetValues("SharingRef")[0]);
                attendee.Intermission = Convert.ToString(collection.GetValues("Intermission")[0]);
                attendee.SharingShowTitle = Convert.ToString(collection.GetValues("SharingShowTitle")[0]);
                attendee.LightingRequirements = Convert.ToString(collection.GetValues("LightingRequirements")[0]);
                attendee.SoundRequirements = Convert.ToString(collection.GetValues("SoundRequirements")[0]);
                attendee.Dancing = Convert.ToString(collection.GetValues("Dancing")[0]);
                attendee.DancingType = Convert.ToString(collection.GetValues("DancingType")[0]);
                attendee.Projection = Convert.ToString(collection.GetValues("Projection")[0]);
                attendee.ImageSize = Convert.ToString(collection.GetValues("ImageSize")[0]);
                attendee.ThrowDistance = Convert.ToString(collection.GetValues("ThrowDistance")[0]);
                attendee.ProjectionRatio = Convert.ToString(collection.GetValues("ProjectionRatio")[0]);
                attendee.ScreenHeight = Convert.ToString(collection.GetValues("ScreenHeight")[0]);
                attendee.ScreenWidth = Convert.ToString(collection.GetValues("ScreenWidth")[0]);
                attendee.MediaType = Convert.ToString(collection.GetValues("MediaType")[0]);
                attendee.ShootFrom = Convert.ToString(collection.GetValues("ShootFrom")[0]);
                attendee.ScreenMaterial = Convert.ToString(collection.GetValues("ScreenMaterial")[0]);
                attendee.SoundOut = Convert.ToString(collection.GetValues("SoundOut")[0]);
                attendee.Liquids = Convert.ToString(collection.GetValues("Liquids")[0]);
                attendee.LiquidsDescribe = Convert.ToString(collection.GetValues("LiquidsDescribe")[0]);
                attendee.OpenFlames = Convert.ToString(collection.GetValues("OpenFlames")[0]);
                attendee.Firearms = Convert.ToString(collection.GetValues("Firearms")[0]);
                attendee.Smoking = Convert.ToString(collection.GetValues("Smoking")[0]);
                attendee.FogMachine = Convert.ToString(collection.GetValues("FogMachine")[0]);
                attendee.Strobe = Convert.ToString(collection.GetValues("Strobe")[0]);
                attendee.Hazer = Convert.ToString(collection.GetValues("Hazer")[0]);
                attendee.MoreLights = Convert.ToString(collection.GetValues("MoreLights")[0]);
                attendee.WirelessMic = Convert.ToString(collection.GetValues("WirelessMic")[0]);
                attendee.OtherEquipments = Convert.ToString(collection.GetValues("OtherEquipments")[0]);
                attendee.SpecialNeeds = Convert.ToString(collection.GetValues("SpecialNeeds")[0]);
                attendee.Comments = Convert.ToString(collection.GetValues("Comments")[0]);

                db.Attendees.Attach(attendee);
                db.Entry(attendee).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return "";
            }
            catch (Exception e)
            {
                return e.Message;
            }
           

        }

        public virtual void ReplaceAttendeeStatus(string from, string to)
        {
            int fromID = Convert.ToInt32(from);
            int toID = Convert.ToInt32(to);

            Attendee fromAttendee = db.Attendees.Where(m => m.Value == fromID).FirstOrDefault();
            fromAttendee.Status = "Waiting List";
            db.Attendees.Attach(fromAttendee);

            Attendee toAttendee = db.Attendees.Where(m => m.Value == toID).FirstOrDefault();
            toAttendee.Status = "In";
            db.Attendees.Attach(toAttendee);

            db.SaveChanges();
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