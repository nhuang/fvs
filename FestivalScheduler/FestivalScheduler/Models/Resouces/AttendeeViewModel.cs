using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json.Linq;
using System.Text;
using LINQtoCSV;

namespace FestivalScheduler.Models.Resouces
{
    public class AttendeeViewModel
    {

        public int ID { get; set; }
        [Display(Name = "Show Title"), Required]
        public string Text { get; set; }
        [Display(Name = "Ref#"), Required]
        public int Value { get; set; }
        [Display(Name = "Color"), Required]
        public string Color { get; set; }
        public bool Show { get; set; }
        [Display(Name = "Running Time"), Required]
        public int Length { get; set; }
        [Display(Name = "Number of Shows")]
        public int NumberOfShows { get; set; }
        [Display(Name = "Status")]
        public string Status { get; set; }
        [Display(Name = "Type")]
        public string Type { get; set; }

        public Attendee ToEntity()
        {
            var attendee = new Attendee
            {
                ID = ID,
                Text = Text,
                Value = Value,
                Color = Color,
                Show = Show,
                Length = Length,
                Status = Status,
                Type = Type
            };

            return attendee;
        }
    }

    public class ArtistViewExportModel
    {
        [CsvColumn(Name = "Status", FieldIndex = 0)]
        public string Status { get; set; }
        [CsvColumn(Name = "Ref#", FieldIndex = 1)]
        public int Value { get; set; }
        [CsvColumn(Name = "Company", FieldIndex = 2)]
        public string Company { get; set; }
        [CsvColumn(Name = "ShowTitle", FieldIndex = 3)]
        public string Text { get; set; }
        [CsvColumn(Name = "PrimaryFirstName", FieldIndex = 4)]
        public string PrimaryFirstName { get; set; }
        [CsvColumn(Name = "PrimaryLastName", FieldIndex = 5)]
        public string PrimaryLastName { get; set; }
        [CsvColumn(Name = "PrimaryAddress", FieldIndex = 6)]
        public string PrimaryAddress { get; set; }
        [CsvColumn(Name = "PrimaryCity", FieldIndex = 7)]
        public string PrimaryCity { get; set; }
        [CsvColumn(Name = "PrimaryProvState", FieldIndex = 8)]
        public string PrimaryProvState { get; set; }
        [CsvColumn(Name = "PrimaryCountry", FieldIndex = 9)]
        public string PrimaryCountry { get; set; }
        [CsvColumn(Name = "PrimaryPCZip", FieldIndex = 10)]
        public string PrimaryPCZip { get; set; }
        [CsvColumn(Name = "PrimaryPhone", FieldIndex = 11)]
        public string PrimaryPhone { get; set; }
        [CsvColumn(Name = "PrimaryEmail", FieldIndex = 12)]
        public string PrimaryEmail { get; set; }
        [CsvColumn(Name = "SecondaryFirstName", FieldIndex = 13)]
        public string SecondaryFirstName { get; set; }
        [CsvColumn(Name = "SecondaryLastName", FieldIndex = 14)]
        public string SecondaryLastName { get; set; }
        [CsvColumn(Name = "SecondaryAddress", FieldIndex = 15)]
        public string SecondaryAddress { get; set; }
        [CsvColumn(Name = "SecondaryCity", FieldIndex = 16)]
        public string SecondaryCity { get; set; }
        [CsvColumn(Name = "SecondaryPovState", FieldIndex = 17)]
        public string SecondaryPovState { get; set; }
        [CsvColumn(Name = "SecondaryCountry", FieldIndex = 18)]
        public string SecondaryCountry { get; set; }
        [CsvColumn(Name = "SecondaryPCZip", FieldIndex = 19)]
        public string SecondaryPCZip { get; set; }
        [CsvColumn(Name = "SecondaryPhone", FieldIndex = 20)]
        public string SecondaryPhone { get; set; }
        [CsvColumn(Name = "SecondaryEmail", FieldIndex = 21)]
        public string SecondaryEmail { get; set; }
        [CsvColumn(Name = "CastMembers", FieldIndex = 22)]
        public string CastMembers { get; set; }
        [CsvColumn(Name = "Playwright", FieldIndex = 23)]
        public string Playwright { get; set; }
        [CsvColumn(Name = "Director", FieldIndex = 24)]
        public string Director { get; set; }
        [CsvColumn(Name = "StageManager", FieldIndex = 25)]
        public string StageManager { get; set; }
        [CsvColumn(Name = "Designer", FieldIndex = 26)]
        public string Designer { get; set; }
        [CsvColumn(Name = "TeamSize", FieldIndex = 27)]
        public string TeamSize { get; set; }

        [CsvColumn(Name = "ChequeAddress", FieldIndex = 28)]
        public string ChequeAddress { get; set; }
        [CsvColumn(Name = "ChequeCity", FieldIndex = 29)]
        public string ChequeCity { get; set; }
        [CsvColumn(Name = "ChequeProvState", FieldIndex = 30)]
        public string ChequeProvState { get; set; }
        [CsvColumn(Name = "ChequeCountry", FieldIndex = 31)]
        public string ChequeCountry { get; set; }
        [CsvColumn(Name = "ChequePCZip", FieldIndex = 32)]
        public string ChequePCZip { get; set; }
        [CsvColumn(Name = "GST", FieldIndex = 33)]
        public string GST { get; set; }

        [CsvColumn(Name = "VenueName", FieldIndex = 34)]
        public string VenueName { get; set; }
        [CsvColumn(Name = "VenueAddress", FieldIndex = 35)]
        public string VenueAddress { get; set; }
        [CsvColumn(Name = "VenueTotal", FieldIndex = 36)]        
        public string VenueTotal { get; set; }
        [CsvColumn(Name = "Wheelchair", FieldIndex = 37)]
        public string Wheelchair { get; set; }
        [CsvColumn(Name = "WheelchairCapacity", FieldIndex = 38)]
        public string WheelchairCapacity { get; set; }
        [CsvColumn(Name = "Washrooms", FieldIndex = 39)]
        public string Washrooms { get; set; }
        [CsvColumn(Name = "WheelchairWashrooms", FieldIndex = 40)]
        public string WheelchairWashrooms { get; set; }
        [CsvColumn(Name = "Alcohol", FieldIndex = 41)]
        public string Alcohol { get; set; }
        [CsvColumn(Name = "Food", FieldIndex = 42)]
        public string Food { get; set; }
        [CsvColumn(Name = "EnterEarly", FieldIndex = 43)]
        public string EnterEarly { get; set; }
        [CsvColumn(Name = "MinutesBefore", FieldIndex = 44)]
        public string MinutesBefore { get; set; }
        [CsvColumn(Name = "Bar", FieldIndex = 45)]
        public string Bar { get; set; }
        [CsvColumn(Name = "Minors", FieldIndex = 46)]
        public string Minors { get; set; }
        [CsvColumn(Name = "ShowDate", FieldIndex = 47)]
        public string ShowDate { get; set; }
        [CsvColumn(Name = "Release", FieldIndex = 48)]
        public string Release { get; set; }
        [CsvColumn(Name = "DateEntered", FieldIndex = 49)]
        public string DateEntered { get; set; }

        [CsvColumn(Name = "PayDate", FieldIndex = 50)]
        public string PayDate { get; set; }
        [CsvColumn(Name = "PayMethod", FieldIndex = 51)]
        public string PayMethod { get; set; }
        [CsvColumn(Name = "Amount", FieldIndex = 52)]
        public string Amount { get; set; }
        [CsvColumn(Name = "Refund", FieldIndex = 53)]
        public string Refund { get; set; }
        [CsvColumn(Name = "RefundDate", FieldIndex = 54)]
        public string RefundDate { get; set; }

    }

    public class ArtistViewModel : AttendeeViewModel
    {
        [Display(Name = "Company")]
        public string Company { get; set; }
        [Display(Name = "First Name")]
        public string PrimaryFirstName { get; set; }
        [Display(Name = "Last Name")]
        public string PrimaryLastName { get; set; }
        [Display(Name = "Address")]
        public string PrimaryAddress { get; set; }
        [Display(Name = "City")]
        public string PrimaryCity { get; set; }
        [Display(Name = "Prov/State")]
        public string PrimaryProvState { get; set; }
        [Display(Name = "Country")]
        public string PrimaryCountry { get; set; }
        [Display(Name = "PC/Zip")]
        public string PrimaryPCZip { get; set; }
        [Display(Name = "Phone")]
        public string PrimaryPhone { get; set; }
        [Display(Name = "Email")]
        public string PrimaryEmail { get; set; }
        [Display(Name = "First Name")]
        public string SecondaryFirstName { get; set; }
        [Display(Name = "Last Name")]
        public string SecondaryLastName { get; set; }
        [Display(Name = "Address")]
        public string SecondaryAddress { get; set; }
        [Display(Name = "City")]
        public string SecondaryCity { get; set; }
        [Display(Name = "Pov/State")]
        public string SecondaryPovState { get; set; }
        [Display(Name = "Country")]
        public string SecondaryCountry { get; set; }
        [Display(Name = "PC/Zip")]
        public string SecondaryPCZip { get; set; }
        [Display(Name = "Phone")]
        public string SecondaryPhone { get; set; }
        [Display(Name = "Email")]
        public string SecondaryEmail { get; set; }
        [Display(Name = "Cast Members")]
        public string CastMembers { get; set; }
        [Display(Name = "Playwright")]
        public string Playwright { get; set; }
        [Display(Name = "Director")]
        public string Director { get; set; }
        [Display(Name = "Stage Manager")]
        public string StageManager { get; set; }
        [Display(Name = "Designer")]
        public string Designer { get; set; }
        [Display(Name = "Team Size")]
        public string TeamSize { get; set; }
        [Display(Name = "New Work")]
        public string NewWork { get; set; }
        [Display(Name = "Genre")]
        public string Genre { get; set; }
        [Display(Name = "Genre Other")]
        public string GenreOther { get; set; }
        [Display(Name = "Show Rating")]
        public string ShowRating { get; set; }
        [Display(Name = "Age Restriction")]
        public string AgeRestriction { get; set; }
        [Display(Name = "Show Contains")]
        public string ShowContains { get; set; }
        [Display(Name = "Content Advisory")]
        public string ContentAdvisory { get; set; }
        [Display(Name = "General Admission")]
        public string GeneralAdmission { get; set; }
        [Display(Name = "Student Senior")]
        public string StudentSenior { get; set; }
        [Display(Name = "Show Description")]
        public string ShowDescription { get; set; }
        [Display(Name = "Website")]
        public string Website { get; set; }
        [Display(Name = "Show Image")]
        public string ShowImage { get; set; }
        [Display(Name = "Name on Cheque")]
        public string NameonCheque { get; set; }
        [Display(Name = "Company Name on Cheque")]
        public string CompanyNameonCheque { get; set; }
        [Display(Name = "Address")]
        public string ChequeAddress { get; set; }
        [Display(Name = "ChequeCity")]
        public string ChequeCity { get; set; }
        [Display(Name = "Prov/State")]
        public string ChequeProvState { get; set; }
        [Display(Name = "Country")]
        public string ChequeCountry { get; set; }
        [Display(Name = "PCZip")]
        public string ChequePCZip { get; set; }
        [Display(Name = "GST")]
        public string GST { get; set; }
        [Display(Name = "When Not Available")]
        public string WhenNotAvailable { get; set; }
        [Display(Name = "Sharing")]
        public string Sharing { get; set; }
        [Display(Name = "Sharing Ref")]
        public string SharingRef { get; set; }
        [Display(Name = "Sharing Company")]
        public string SharingCompany { get; set; }
        [Display(Name = "Sharing Show Title")]
        public string SharingShowTitle { get; set; }
        [Display(Name = "Staging Requirements")]
        public string StagingRequirements { get; set; }
        [Display(Name = "Intermission")]
        public string Intermission { get; set; }
        [Display(Name = "Lighting Requirements")]
        public string LightingRequirements { get; set; }
        [Display(Name = "Sound Requirements")]
        public string SoundRequirements { get; set; }
        [Display(Name = "Dancing")]
        public string Dancing { get; set; }
        [Display(Name = "Dancing Type")]
        public string DancingType { get; set; }
        [Display(Name = "Projection")]
        public string Projection { get; set; }
        [Display(Name = "Image Size")]
        public string ImageSize { get; set; }
        [Display(Name = "Throw Distance")]
        public string ThrowDistance { get; set; }
        [Display(Name = "Holdovers")]
        public string Holdovers { get; set; }
        [Display(Name = "Screen Elevation")]
        public string ScreenElevation { get; set; }
        [Display(Name = "Screen Height")]
        public string ScreenHeight { get; set; }
        [Display(Name = "Screen Width")]
        public string ScreenWidth { get; set; }
        [Display(Name = "Projection Ratio")]
        public string ProjectionRatio { get; set; }
        [Display(Name = "Media Type")]
        public string MediaType { get; set; }
        [Display(Name = "Shoot From")]
        public string ShootFrom { get; set; }
        [Display(Name = "Shoot From Other")]
        public string ShootFromOther { get; set; }
        [Display(Name = "Screen Material")]
        public string ScreenMaterial { get; set; }
        [Display(Name = "Sound Out")]
        public string SoundOut { get; set; }
        [Display(Name = "Liquids")]
        public string Liquids { get; set; }
        [Display(Name = "Liquids Describe")]
        public string LiquidsDescribe { get; set; }
        [Display(Name = "Open Flames")]
        public string OpenFlames { get; set; }
        [Display(Name = "Loud")]
        public string Loud { get; set; }
        [Display(Name = "Loud Describe")]
        public string LoudDescribe { get; set; }
        [Display(Name = "Firearms")]
        public string Firearms { get; set; }
        [Display(Name = "Smoking")]
        public string Smoking { get; set; }
        [Display(Name = "Fog Machine")]
        public string FogMachine { get; set; }
        [Display(Name = "Strobe")]
        public string Strobe { get; set; }
        [Display(Name = "Hazer")]
        public string Hazer { get; set; }
        [Display(Name = "More Lights")]
        public string MoreLights { get; set; }
        [Display(Name = "Wireless Mic")]
        public string WirelessMic { get; set; }
        [Display(Name = "Frequencies")]
        public string Frequencies { get; set; }
        [Display(Name = "Other Equipments")]
        public string OtherEquipments { get; set; }
        [Display(Name = "Equipment Specify")]
        public string EquipmentSpecify { get; set; }
        [Display(Name = "Stage Design")]
        public string StageDesign { get; set; }
        [Display(Name = "Special Needs")]
        public string SpecialNeeds { get; set; }
        [Display(Name = "Comments")]
        public string Comments { get; set; }
        [Display(Name = "Rehearsal Time")]
        public string RehearsalTime { get; set; }
        [Display(Name = "Coming From")]
        public string ComingFrom { get; set; }
        [Display(Name = "Festival Coming From")]
        public string FestivalComingFrom { get; set; }
        [Display(Name = "When Arriving")]
        public string WhenArriving { get; set; }
        [Display(Name = "Release")]
        public string Release { get; set; }        
        [Display(Name = "Venue No")]
        public string VenueNo { get; set; }
        [Display(Name = "Venue Name")]
        public string VenueName { get; set; }
        [Display(Name = "Venue Address")]
        public string VenueAddress { get; set; }
        [Display(Name = "Venue Total")]
        public string VenueTotal { get; set; }
        [Display(Name = "Wheelchair")]
        public string Wheelchair { get; set; }
        [Display(Name = "Wheelchair Capacity")]
        public string WheelchairCapacity { get; set; }
        [Display(Name = "Washrooms")]
        public string Washrooms { get; set; }
        [Display(Name = "Wheelchair Washrooms")]
        public string WheelchairWashrooms { get; set; }
        [Display(Name = "Alcohol")]
        public string Alcohol { get; set; }
        [Display(Name = "Food")]
        public string Food { get; set; }
        [Display(Name = "Enter Early")]
        public string EnterEarly { get; set; }
        [Display(Name = "Minutes Before")]
        public string MinutesBefore { get; set; }
        [Display(Name = "Bar")]
        public string Bar { get; set; }
        [Display(Name = "Minors")]
        public string Minors { get; set; }
        [Display(Name = "Show Date")]
        public string ShowDate { get; set; }
        [Display(Name = "Pay Date")]
        public string PayDate { get; set; }
        [Display(Name = "Pay Method")]
        public string PayMethod { get; set; }
        [Display(Name = "Amount")]
        public string Amount { get; set; }
        [Display(Name = "Refund")]
        public string Refund { get; set; }
        [Display(Name = "Refund Date")]
        public string RefundDate { get; set; }
        [Display(Name = "Date Entered")]
        public string DateEntered { get; set; }
       

        public Attendee ToArtistEntity(Attendee model)
        {
            if (model != null)
            {
                model.Text = Text;
                model.Value = Value;
                model.Color = Color;
                model.Show = Show;
                model.Length = Length;
                model.Type = Type;
                model.Status = Status;
                model.Company = Company;
                model.PrimaryFirstName = PrimaryFirstName;
                model.PrimaryLastName = PrimaryLastName;
                model.PrimaryAddress = PrimaryAddress;
                model.PrimaryCity = PrimaryCity;
                model.PrimaryProvState = PrimaryProvState;
                model.PrimaryCountry = PrimaryCountry;
                model.PrimaryPCZip = PrimaryPCZip;
                model.PrimaryPhone = PrimaryPhone;
                model.PrimaryEmail = PrimaryEmail;
                model.SecondaryFirstName = SecondaryFirstName;
                model.SecondaryLastName = SecondaryLastName;
                model.SecondaryAddress = SecondaryAddress;
                model.SecondaryCity = SecondaryCity;
                model.SecondaryPovState = SecondaryPovState;
                model.SecondaryCountry = SecondaryCountry;
                model.SecondaryPCZip = SecondaryPCZip;
                model.SecondaryPhone = SecondaryPhone;
                model.SecondaryEmail = SecondaryEmail;
                model.CastMembers = CastMembers;
                model.Playwright = Playwright;
                model.Director = Director;
                model.StageManager = StageManager;
                model.Designer = Designer;
                model.TeamSize = TeamSize;
                model.NewWork = NewWork;
                model.Genre = Genre;
                model.GenreOther = GenreOther;
                model.ShowRating = ShowRating;
                model.AgeRestriction = AgeRestriction;
                model.ShowContains = ShowContains;
                model.ContentAdvisory = ContentAdvisory;
                model.GeneralAdmission = GeneralAdmission;
                model.StudentSenior = StudentSenior;
                model.ShowDescription = ShowDescription;
                model.Website = Website;
                model.ShowImage = ShowImage;
                model.NameonCheque = NameonCheque;
                model.CompanyNameonCheque = CompanyNameonCheque;
                model.ChequeAddress = ChequeAddress;
                model.ChequeCity = ChequeCity;
                model.ChequeProvState = ChequeProvState;
                model.ChequeCountry = ChequeCountry;
                model.ChequePCZip = ChequePCZip;
                model.GST = GST;
                model.WhenNotAvailable = WhenNotAvailable;
                model.Sharing = Sharing;
                model.SharingRef = SharingRef;
                model.SharingCompany = SharingCompany;
                model.SharingShowTitle = SharingShowTitle;
                model.StagingRequirements = StagingRequirements;
                model.Intermission = Intermission;
                model.LightingRequirements = LightingRequirements;
                model.SoundRequirements = SoundRequirements;
                model.Dancing = Dancing;
                model.DancingType = DancingType;
                model.Projection = Projection;
                model.ImageSize = ImageSize;
                model.ThrowDistance = ThrowDistance;
                model.Holdovers = Holdovers;
                model.ScreenElevation = ScreenElevation;
                model.ScreenHeight = ScreenHeight;
                model.ScreenWidth = ScreenWidth;
                model.ProjectionRatio = ProjectionRatio;
                model.MediaType = MediaType;
                model.ShootFrom = ShootFrom;
                model.ShootFromOther = ShootFromOther;
                model.ScreenMaterial = ScreenMaterial;
                model.SoundOut = SoundOut;
                model.Liquids = Liquids;
                model.LiquidsDescribe = LiquidsDescribe;
                model.OpenFlames = OpenFlames;
                model.Loud = Loud;
                model.LoudDescribe = LoudDescribe;
                model.Firearms = Firearms;
                model.Smoking = Smoking;
                model.FogMachine = FogMachine;
                model.Strobe = Strobe;
                model.Hazer = Hazer;
                model.MoreLights = MoreLights;
                model.WirelessMic = WirelessMic;
                model.Frequencies = Frequencies;
                model.OtherEquipments = OtherEquipments;
                model.EquipmentSpecify = EquipmentSpecify;
                model.StageDesign = StageDesign;
                model.SpecialNeeds = SpecialNeeds;
                model.Comments = Comments;
                model.RehearsalTime = RehearsalTime;
                model.ComingFrom = ComingFrom;
                model.FestivalComingFrom = FestivalComingFrom;
                model.WhenArriving = WhenArriving;
                model.Release = Release;
                model.VenueName = VenueName;
                model.VenueAddress = VenueAddress;
                model.VenueTotal = VenueTotal;
                model.Wheelchair = Wheelchair;
                model.WheelchairCapacity = WheelchairCapacity;
                model.Washrooms = Washrooms;
                model.WheelchairWashrooms = WheelchairWashrooms;
                model.Alcohol = Alcohol;
                model.Food = Food;
                model.EnterEarly = EnterEarly;
                model.MinutesBefore = MinutesBefore;
                model.Bar = Bar;
                model.Minors = Minors;
                model.ShowDate = ShowDate;
                model.PayDate = PayDate;
                model.PayMethod = PayMethod;
                model.Amount = Amount;
                model.Refund = Refund;
                model.RefundDate = RefundDate;
                model.DateEntered = DateEntered;
                model.VenueNo = VenueNo;
                return model;
            }
            else
            {
                var attendee = new Attendee
                {
                    ID = ID,
                    Text = Text,
                    Value = Value,
                    Color = Color,
                    Show = Show,
                    Length = Length,
                    Type = Type,
                    Status = Status,
                    Company = Company,
                    PrimaryFirstName = PrimaryFirstName,
                    PrimaryLastName = PrimaryLastName,
                    PrimaryAddress = PrimaryAddress,
                    PrimaryCity = PrimaryCity,
                    PrimaryProvState = PrimaryProvState,
                    PrimaryCountry = PrimaryCountry,
                    PrimaryPCZip = PrimaryPCZip,
                    PrimaryPhone = PrimaryPhone,
                    PrimaryEmail = PrimaryEmail,
                    SecondaryFirstName = SecondaryFirstName,
                    SecondaryLastName = SecondaryLastName,
                    SecondaryAddress = SecondaryAddress,
                    SecondaryCity = SecondaryCity,
                    SecondaryPovState = SecondaryPovState,
                    SecondaryCountry = SecondaryCountry,
                    SecondaryPCZip = SecondaryPCZip,
                    SecondaryPhone = SecondaryPhone,
                    SecondaryEmail = SecondaryEmail,
                    CastMembers = CastMembers,
                    Playwright = Playwright,
                    Director = Director,
                    StageManager = StageManager,
                    Designer = Designer,
                    TeamSize = TeamSize,
                    NewWork = NewWork,
                    Genre = Genre,
                    GenreOther = GenreOther,
                    ShowRating = ShowRating,
                    AgeRestriction = AgeRestriction,
                    ShowContains = ShowContains,
                    ContentAdvisory = ContentAdvisory,
                    GeneralAdmission = GeneralAdmission,
                    StudentSenior = StudentSenior,
                    ShowDescription = ShowDescription,
                    Website = Website,
                    ShowImage = ShowImage,
                    NameonCheque = NameonCheque,
                    CompanyNameonCheque = CompanyNameonCheque,
                    ChequeAddress = ChequeAddress,
                    ChequeCity = ChequeCity,
                    ChequeProvState = ChequeProvState,
                    ChequeCountry = ChequeCountry,
                    ChequePCZip = ChequePCZip,
                    GST = GST,
                    WhenNotAvailable = WhenNotAvailable,
                    Sharing = Sharing,
                    SharingRef = SharingRef,
                    SharingCompany = SharingCompany,
                    SharingShowTitle = SharingShowTitle,
                    StagingRequirements = StagingRequirements,
                    Intermission = Intermission,
                    LightingRequirements = LightingRequirements,
                    SoundRequirements = SoundRequirements,
                    Dancing = Dancing,
                    DancingType = DancingType,
                    Projection = Projection,
                    ImageSize = ImageSize,
                    ThrowDistance = ThrowDistance,
                    Holdovers = Holdovers,
                    ScreenElevation = ScreenElevation,
                    ScreenHeight = ScreenHeight,
                    ScreenWidth = ScreenWidth,
                    ProjectionRatio = ProjectionRatio,
                    MediaType = MediaType,
                    ShootFrom = ShootFrom,
                    ShootFromOther = ShootFromOther,
                    ScreenMaterial = ScreenMaterial,
                    SoundOut = SoundOut,
                    Liquids = Liquids,
                    LiquidsDescribe = LiquidsDescribe,
                    OpenFlames = OpenFlames,
                    Loud = Loud,
                    LoudDescribe = LoudDescribe,
                    Firearms = Firearms,
                    Smoking = Smoking,
                    FogMachine = FogMachine,
                    Strobe = Strobe,
                    Hazer = Hazer,
                    MoreLights = MoreLights,
                    WirelessMic = WirelessMic,
                    Frequencies = Frequencies,
                    OtherEquipments = OtherEquipments,
                    EquipmentSpecify = EquipmentSpecify,
                    StageDesign = StageDesign,
                    SpecialNeeds = SpecialNeeds,
                    Comments = Comments,
                    RehearsalTime = RehearsalTime,
                    ComingFrom = ComingFrom,
                    FestivalComingFrom = FestivalComingFrom,
                    WhenArriving = WhenArriving,
                    Release = Release,
                    VenueName = VenueName,
                    VenueAddress = VenueAddress,
                    VenueTotal = VenueTotal,
                    Wheelchair = Wheelchair,
                    WheelchairCapacity = WheelchairCapacity,
                    Washrooms = Washrooms,
                    WheelchairWashrooms = WheelchairWashrooms,
                    Alcohol = Alcohol,
                    Food = Food,
                    EnterEarly = EnterEarly,
                    MinutesBefore = MinutesBefore,
                    Bar = Bar,
                    Minors = Minors,
                    ShowDate = ShowDate,
                    PayDate = PayDate,
                    PayMethod = PayMethod,
                    Amount = Amount,
                    Refund = Refund,
                    RefundDate = RefundDate,
                    DateEntered = DateEntered,
                    VenueNo = VenueNo
                };
                return attendee;
            }
        }

        internal void ConvertFromJson(JObject obj)
        {
            IDictionary<string, JToken> dictionary = obj;
            if (dictionary.ContainsKey("Ref #"))
            {
                Value = Convert.ToInt32(obj["Ref #"].ToString());
            }

            if (dictionary.ContainsKey("Show Title"))
            {
                Text = obj["Show Title"].ToString();
            }

            if (dictionary.ContainsKey("Running Time"))
            {
                string temp = obj["Running Time"].ToString();
                if (!string.IsNullOrEmpty(temp))
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (Char c in temp.ToCharArray())
                    {
                        if (Char.IsDigit(c))
                        {
                            sb.Append(c);
                        }
                    }
                    if (!string.IsNullOrEmpty(sb.ToString()))
                    {
                        Length = Convert.ToInt32(sb.ToString());
                    }
                    else
                    {
                        Length = 0;
                    }                    
                }
            }


            //"Type": "Local",
            if (dictionary.ContainsKey("Type"))
            {
                Type = obj["Type"].ToString();
            }
            //"Status": "Waiting List",
            if (dictionary.ContainsKey("Status"))
            {
                Status = obj["Status"].ToString();
            }
            //"Company": "Pocket Theatre",
            if (dictionary.ContainsKey("Company"))
            {
                Company = obj["Company"].ToString();
            }

            //"Primary First Name": "James",
            if (dictionary.ContainsKey("Primary First Name"))
            {
                PrimaryFirstName = obj["Primary First Name"].ToString();
            }
            //"Primary Last Name": "DeFelice",
            if (dictionary.ContainsKey("Primary Last Name"))
            {
                PrimaryLastName = obj["Primary Last Name"].ToString();
            }
            //"Primary Address": "5611-109th Street",
            if (dictionary.ContainsKey("Primary Address"))
            {
                PrimaryAddress = obj["Primary Address"].ToString();
            }
            //"Primary City": "Edmonton",
            if (dictionary.ContainsKey("Primary City"))
            {
                PrimaryCity = obj["Primary City"].ToString();
            }
            //"Primary Prov/State": "Alberta",
            if (dictionary.ContainsKey("Primary Prov/State"))
            {
                PrimaryProvState = obj["Primary Prov/State"].ToString();
            }

            //"Primary Country": "Canada",
            if (dictionary.ContainsKey("Primary Country"))
            {
                PrimaryCountry = obj["Primary Country"].ToString();
            }
            //"Primary PC/Zip": "T6H 3A7",
            if (dictionary.ContainsKey("Primary PC/Zip"))
            {
                PrimaryPCZip = obj["Primary PC/Zip"].ToString();
            }
            //"Primary Phone": "(780) 434-9702",
            if (dictionary.ContainsKey("Primary Phone"))
            {
                PrimaryPhone = obj["Primary Phone"].ToString();
            }
            //"Primary Email": "defelice@shaw.ca",
            if (dictionary.ContainsKey("Primary Email"))
            {
                PrimaryEmail = obj["Primary Email"].ToString();
            }

            //"Secondary First Name": "Gail",
            if (dictionary.ContainsKey("Secondary First Name"))
            {
                SecondaryFirstName = obj["Secondary First Name"].ToString();
            }

            //"Secondary Last Name": "DeFelice",
            if (dictionary.ContainsKey("Secondary Last Name"))
            {
                SecondaryLastName = obj["Secondary Last Name"].ToString();
            }
            //"Secondary Address": "5611-109 Street",
            if (dictionary.ContainsKey("Secondary Address"))
            {
                SecondaryAddress = obj["Secondary Address"].ToString();
            }
            //"Secondary City": "Edmonton",
            if (dictionary.ContainsKey("Secondary City"))
            {
                SecondaryCity = obj["Secondary City"].ToString();
            }
            //"Secondary Pov/State": "Alberta",
            if (dictionary.ContainsKey("Secondary Pov/State"))
            {
                SecondaryPovState = obj["Secondary Pov/State"].ToString();
            }

            //"Secondary Country": "Canada",
            if (dictionary.ContainsKey("Secondary Country"))
            {
                SecondaryCountry = obj["Secondary Country"].ToString();
            }

            //"Secondary PC/Zip": "T6H-3A7",
            if (dictionary.ContainsKey("Secondary PC/Zip"))
            {
                SecondaryPCZip = obj["Secondary PC/Zip"].ToString();
            }
            //"Secondary Phone": "780-690-0619",
            if (dictionary.ContainsKey("Secondary Phone"))
            {
                SecondaryPhone = obj["Secondary Phone"].ToString();
            }

            //"Secondary Email": "defelice@shaw.ca",
            if (dictionary.ContainsKey("Secondary Email"))
            {
                SecondaryEmail = obj["Secondary Email"].ToString();
            }

            //"Cast Members": "",
            if (dictionary.ContainsKey("Cast Members"))
            {
                CastMembers = obj["Cast Members"].ToString();
            }
            //"Playwright": "",
            if (dictionary.ContainsKey("Playwright"))
            {
                Playwright = obj["Playwright"].ToString();
            }
            //"Director": "",
            if (dictionary.ContainsKey("Director"))
            {
                Director = obj["Director"].ToString();
            }
            //"Stage Manager": "",
            if (dictionary.ContainsKey("Stage Manager"))
            {
                StageManager = obj["Stage Manager"].ToString();
            }
            //"Designer": "",
            if (dictionary.ContainsKey("Designer"))
            {
                Designer = obj["Designer"].ToString();
            }
            //"Team Size": "",
            if (dictionary.ContainsKey("Team Size"))
            {
                TeamSize = obj["Team Size"].ToString();
            }
            //"New Work": "",
            if (dictionary.ContainsKey("New Work"))
            {
                NewWork = obj["New Work"].ToString();
            }
            //"Genre": "",
            if (dictionary.ContainsKey("Genre"))
            {
                Genre = obj["Genre"].ToString();
            }
            //"Genre Other": "",
            if (dictionary.ContainsKey("Genre Other"))
            {
                GenreOther = obj["Genre Other"].ToString();
            }
            //"Show Rating": "",
            if (dictionary.ContainsKey("Show Rating"))
            {
                ShowRating = obj["Show Rating"].ToString();
            }
            //"Age Restriction": "",
            if (dictionary.ContainsKey("Age Restriction"))
            {
                AgeRestriction = obj["Age Restriction"].ToString();
            }
            //"Show Contains": "",
            if (dictionary.ContainsKey("Show Contains"))
            {
                ShowContains = obj["Show Contains"].ToString();
            }
            //"Content Advisory": "",
            if (dictionary.ContainsKey("Content Advisory"))
            {
                ContentAdvisory = obj["Content Advisory"].ToString();
            }

            //"General Admission": "",
            if (dictionary.ContainsKey("General Admission"))
            {
                GeneralAdmission = obj["General Admission"].ToString();
            }
            //"Student/Senior": "",
            if (dictionary.ContainsKey("Student/Senior"))
            {
                StudentSenior = obj["Student/Senior"].ToString();
            }
            //"Show Description": "",
            if (dictionary.ContainsKey("Show Description"))
            {
                ShowDescription = obj["Show Description"].ToString();
            }

            //"Website": "",
            if (dictionary.ContainsKey("Website"))
            {
                Website = obj["Website"].ToString();
            }
            //"Show Image": "",
            if (dictionary.ContainsKey("Show Image"))
            {
                ShowImage = obj["Show Image"].ToString();
            }
            //"Name on Cheque": "",
            if (dictionary.ContainsKey("Name on Cheque"))
            {
                NameonCheque = obj["Name on Cheque"].ToString();
            }

            //"Company Name on Cheque": "",
            if (dictionary.ContainsKey("Company Name on Cheque"))
            {
                NameonCheque = obj["Company Name on Cheque"].ToString();
            }

            //"Cheque Address": "",
            if (dictionary.ContainsKey("Cheque Address"))
            {
                ChequeAddress = obj["Cheque Address"].ToString();
            }

            //"Cheque City": "",
            if (dictionary.ContainsKey("Cheque City"))
            {
                ChequeCity = obj["Cheque City"].ToString();
            }

            //"Cheque Prov/State": "",
            if (dictionary.ContainsKey("Cheque Prov/State"))
            {
                ChequeProvState = obj["Cheque Prov/State"].ToString();
            }
            //"Cheque Country": "",
            if (dictionary.ContainsKey("Cheque Country"))
            {
                ChequeCountry = obj["Cheque Country"].ToString();
            }

            //"Cheque PC/Zip": "",
            if (dictionary.ContainsKey("Cheque PC/Zip"))
            {
                ChequePCZip = obj["Cheque PC/Zip"].ToString();
            }
            //"GST": "",
            if (dictionary.ContainsKey("GST"))
            {
                GST = obj["GST"].ToString();
            }
            //"When Not Available": "",
            if (dictionary.ContainsKey("When Not Available"))
            {
                WhenNotAvailable = obj["When Not Available"].ToString();
            }
            //"Sharing": "",
            if (dictionary.ContainsKey("Sharing"))
            {
                Sharing = obj["Sharing"].ToString();
            }
            //"Sharing Ref #": "",
            if (dictionary.ContainsKey("Sharing Ref #"))
            {
                SharingRef = obj["Sharing Ref #"].ToString();
            }
            //"Sharing Company": "",
            if (dictionary.ContainsKey("Sharing Company"))
            {
                SharingCompany = obj["Sharing Company"].ToString();
            }
            //"Sharing Show Title": "",
            if (dictionary.ContainsKey("Sharing Show Title"))
            {
                SharingShowTitle = obj["Sharing Show Title"].ToString();
            }
            //"Staging Requirements": "",
            if (dictionary.ContainsKey("Staging Requirements"))
            {
                StagingRequirements = obj["Staging Requirements"].ToString();
            }
            //"Intermission": "",
            if (dictionary.ContainsKey("Intermission"))
            {
                Intermission = obj["Intermission"].ToString();
            }
            //"Lighting Requirements": "",
            if (dictionary.ContainsKey("Lighting Requirements"))
            {
                LightingRequirements = obj["Lighting Requirements"].ToString();
            }
            //"Sound Requirements": "",
            if (dictionary.ContainsKey("Sound Requirements"))
            {
                SoundRequirements = obj["Sound Requirements"].ToString();
            }
            //"Dancing": "",
            if (dictionary.ContainsKey("Dancing"))
            {
                Dancing = obj["Dancing"].ToString();
            }
            //"Dancing Type": "",
            if (dictionary.ContainsKey("Dancing Type"))
            {
                DancingType = obj["Dancing Type"].ToString();
            }
            //"Projection": "",
            if (dictionary.ContainsKey("Projection"))
            {
                Projection = obj["Projection"].ToString();
            }
            //"Image Size": "",
            if (dictionary.ContainsKey("Image Size"))
            {
                ImageSize = obj["Image Size"].ToString();
            }
            //"Throw Distance": "",
            if (dictionary.ContainsKey("Throw Distance"))
            {
                ThrowDistance = obj["Throw Distance"].ToString();
            }
            //"Holdovers": "",
            if (dictionary.ContainsKey("Holdovers"))
            {
                Holdovers = obj["Holdovers"].ToString();
            }
            //"Screen Elevation": "",
            if (dictionary.ContainsKey("Screen Elevation"))
            {
                ScreenElevation = obj["Screen Elevation"].ToString();
            }
            //"Screen Height": "",
            if (dictionary.ContainsKey("Screen Height"))
            {
                ScreenHeight = obj["Screen Height"].ToString();
            }

            //"Screen Width": "",
            if (dictionary.ContainsKey("Screen Width"))
            {
                ScreenWidth = obj["Screen Width"].ToString();
            }

            //"Projection Ratio": "",
            if (dictionary.ContainsKey("Projection Ratio"))
            {
                ProjectionRatio = obj["Projection Ratio"].ToString();
            }
            //"Media Type": "",
            if (dictionary.ContainsKey("Media Type"))
            {
                MediaType = obj["Media Type"].ToString();
            }
            //"Shoot From": "",
            if (dictionary.ContainsKey("Shoot From"))
            {
                ShootFrom = obj["Shoot From"].ToString();
            }
            //"Shoot From Other": "",
            if (dictionary.ContainsKey("Shoot From Other"))
            {
                ShootFromOther = obj["Shoot From Other"].ToString();
            }
            //"Screen Material": "",
            if (dictionary.ContainsKey("Screen Material"))
            {
                ScreenMaterial = obj["Screen Material"].ToString();
            }

            //"Sound Out": "",
            if (dictionary.ContainsKey("Sound Out"))
            {
                SoundOut = obj["Sound Out"].ToString();
            }
            //"Liquids": "",
            if (dictionary.ContainsKey("Liquids"))
            {
                Liquids = obj["Liquids"].ToString();
            }
            //"Liquids Describe": "",
            if (dictionary.ContainsKey("Liquids Describe"))
            {
                LiquidsDescribe = obj["Liquids Describe"].ToString();
            }
            //"Open Flames": "",
            if (dictionary.ContainsKey("Open Flames"))
            {
                OpenFlames = obj["Open Flames"].ToString();
            }
            //"Loud": "",
            if (dictionary.ContainsKey("Loud"))
            {
                Loud = obj["Loud"].ToString();
            }
            //"Loud Describe": "",
            if (dictionary.ContainsKey("Loud Describe"))
            {
                LoudDescribe = obj["Loud Describe"].ToString();
            }
            //"Firearms": "",
            if (dictionary.ContainsKey("Firearms"))
            {
                Firearms = obj["Firearms"].ToString();
            }
            //"Smoking": "",
            if (dictionary.ContainsKey("Smoking"))
            {
                Smoking = obj["Smoking"].ToString();
            }
            //"Fog Machine": "",
            if (dictionary.ContainsKey("Fog Machine"))
            {
                FogMachine = obj["Fog Machine"].ToString();
            }
            //"Strobe": "",
            if (dictionary.ContainsKey("Strobe"))
            {
                Strobe = obj["Strobe"].ToString();
            }
            //"Hazer": "",
            if (dictionary.ContainsKey("Hazer"))
            {
                Hazer = obj["Hazer"].ToString();
            }
            //"More Lights": "",
            if (dictionary.ContainsKey("More Lights"))
            {
                MoreLights = obj["More Lights"].ToString();
            }
            //"Wireless Mic": "",
            if (dictionary.ContainsKey("Wireless Mic"))
            {
                WirelessMic = obj["Wireless Mic"].ToString();
            }
            //"Frequencies": "",
            if (dictionary.ContainsKey("Frequencies"))
            {
                Frequencies = obj["Frequencies"].ToString();
            }
            //"Other Equipments": "",
            if (dictionary.ContainsKey("Other Equipments"))
            {
                OtherEquipments = obj["Other Equipments"].ToString();
            }
            //"Equipment Specify": "",
            if (dictionary.ContainsKey("Equipment Specify"))
            {
                EquipmentSpecify = obj["Equipment Specify"].ToString();
            }
            //"Stage Design": "",
            if (dictionary.ContainsKey("Stage Design"))
            {
                StageDesign = obj["Stage Design"].ToString();
            }
            //"Special Needs": "",
            if (dictionary.ContainsKey("Special Needs"))
            {
                SpecialNeeds = obj["Special Needs"].ToString();
            }
            //"Comments": "",
            if (dictionary.ContainsKey("Comments"))
            {
                Comments = obj["Comments"].ToString();
            }
            //"Rehearsal Time": "",
            if (dictionary.ContainsKey("Rehearsal Time"))
            {
                RehearsalTime = obj["Rehearsal Time"].ToString();
            }
            //"August 8 Afternoon": null,
            //"August 8 Evening": null,
            //"August 9 Afternoon": null,
            //"August 9 Evening": null,
            //"August 11 Afternoon": null,
            //"August 11 Evening": null,
            //"August 12 Afternoon": null,
            //"August 12 Evening": null,
            //"August 13 Morning": null,
            //"August 13 Afternoon": null,
            //"Coming From": "",
            if (dictionary.ContainsKey("Coming From"))
            {
                ComingFrom = obj["Coming From"].ToString();
            }
            //"Festival Coming From": "",
            if (dictionary.ContainsKey("Festival Coming From"))
            {
                FestivalComingFrom = obj["Festival Coming From"].ToString();
            }
            //"When Arriving": null,
            if (dictionary.ContainsKey("When Arriving"))
            {
                WhenArriving = obj["When Arriving"].ToString();
            }
            //"Release": "",
            if (dictionary.ContainsKey("Release"))
            {
                Release = obj["Release"].ToString();
            }
            //"Venue Name": "",
            if (dictionary.ContainsKey("Venue Name"))
            {
                VenueName = obj["Venue Name"].ToString();
            }
            //"Venue Address": "",
            if (dictionary.ContainsKey("Venue Address"))
            {
                VenueAddress = obj["Venue Address"].ToString();
            }
            //"Venue Total": null,
            if (dictionary.ContainsKey("Venue Total"))
            {
                VenueTotal = obj["Venue Total"].ToString();
            }
            //"Wheelchair": "",
            if (dictionary.ContainsKey("Wheelchair"))
            {
                Wheelchair = obj["Wheelchair"].ToString();
            }
            //"Wheelchair Capacity": null,
            if (dictionary.ContainsKey("Wheelchair Capacity"))
            {
                WheelchairCapacity = obj["Wheelchair Capacity"].ToString();
            }
            //"Washrooms": "",
            if (dictionary.ContainsKey("Washrooms"))
            {
                Washrooms = obj["Washrooms"].ToString();
            }
            //"Wheelchair Washrooms": "",
            if (dictionary.ContainsKey("Wheelchair Washrooms"))
            {
                WheelchairWashrooms = obj["Wheelchair Washrooms"].ToString();
            }
            //"Alcohol": "",
            if (dictionary.ContainsKey("Alcohol"))
            {
                Alcohol = obj["Alcohol"].ToString();
            }
            //"Food": "",
            if (dictionary.ContainsKey("Food"))
            {
                Food = obj["Food"].ToString();
            }
            //"Enter Early": "",
            if (dictionary.ContainsKey("Enter Early"))
            {
                EnterEarly = obj["Enter Early"].ToString();
            }
            //"Minutes Before": null,
            if (dictionary.ContainsKey("Minutes Before"))
            {
                MinutesBefore = obj["Minutes Before"].ToString();
            }
            //"Bar": "",
            if (dictionary.ContainsKey("Bar"))
            {
                Bar = obj["Bar"].ToString();
            }
            //"Minors": "",
            if (dictionary.ContainsKey("Minors"))
            {
                Minors = obj["Minors"].ToString();
            }
            //"Show Date": "",
            if (dictionary.ContainsKey("Show Date"))
            {
                ShowDate = obj["Show Date"].ToString();
            }
            //"Pay Date": "0000-00-00 00:00:00",
            if (dictionary.ContainsKey("Pay Date"))
            {
                PayDate = obj["Pay Date"].ToString();
            }
            //"Pay Method": "Credit Card",
            if (dictionary.ContainsKey("Pay Method"))
            {
                PayMethod = obj["Pay Method"].ToString();
            }
            //"Amount": null,
            if (dictionary.ContainsKey("Amount"))
            {
                Amount = obj["Amount"].ToString();
            }
            //"Refund": "",
            if (dictionary.ContainsKey("Refund"))
            {
                Refund = obj["Refund"].ToString();
            }
            //"Refund Date": "0000-00-00 00:00:00",
            if (dictionary.ContainsKey("Refund Date"))
            {
                RefundDate = obj["Refund Date"].ToString();
            }
            //"Date Entered": "2014-02-17 21:13:00"
            if (dictionary.ContainsKey("Date Entered"))
            {
                DateEntered = obj["Date Entered"].ToString();
            }

        }
    }
}
