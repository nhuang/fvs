using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json.Linq;
using System.Text;

namespace FestivalScheduler.Models.Resouces
{
    public class AttendeeViewModel
    {

        public int ID { get; set; }
        [Display(Name = "Show Title"), Required]
        public string Text { get; set; }
        [Display(Name = "Reference Number"), Required]
        public int Value { get; set; }
        [Display(Name = "Color"), Required]
        public string Color { get; set; }
        public bool Show { get; set; }
        [Display(Name = "Running Time"), Required]
        public int Length { get; set; }
        [Display(Name = "Number of Shows")]
        public int NumberOfShows { get; set; }

        public Attendee ToEntity()
        {
            var attendee = new Attendee
            {
                ID = ID,
                Text = Text,
                Value = Value,
                Color = Color,
                Show = Show,
                Length = Length
            };

            return attendee;
        }


    }

    public class ArtistViewModel : AttendeeViewModel
    {
        public string Type { get; set; }
        public string Status { get; set; }
        public string Company { get; set; }
        public string PrimaryFirstName { get; set; }
        public string PrimaryLastName { get; set; }
        public string PrimaryAddress { get; set; }
        public string PrimaryCity { get; set; }
        public string PrimaryProvState { get; set; }
        public string PrimaryCountry { get; set; }
        public string PrimaryPCZip { get; set; }
        public string PrimaryPhone { get; set; }
        public string PrimaryEmail { get; set; }
        public string SecondaryFirstName { get; set; }
        public string SecondaryLastName { get; set; }
        public string SecondaryAddress { get; set; }
        public string SecondaryCity { get; set; }
        public string SecondaryPovState { get; set; }
        public string SecondaryCountry { get; set; }
        public string SecondaryPCZip { get; set; }
        public string SecondaryPhone { get; set; }
        public string SecondaryEmail { get; set; }
        public string CastMembers { get; set; }
        public string Playwright { get; set; }
        public string Director { get; set; }
        public string StageManager { get; set; }
        public string Designer { get; set; }
        public string TeamSize { get; set; }
        public string NewWork { get; set; }
        public string Genre { get; set; }
        public string GenreOther { get; set; }
        public string ShowRating { get; set; }
        public string AgeRestriction { get; set; }
        public string ShowContains { get; set; }
        public string ContentAdvisory { get; set; }
        public string GeneralAdmission { get; set; }
        public string StudentSenior { get; set; }
        public string ShowDescription { get; set; }
        public string Website { get; set; }
        public string ShowImage { get; set; }
        public string NameonCheque { get; set; }
        public string CompanyNameonCheque { get; set; }
        public string ChequeAddress { get; set; }
        public string ChequeCity { get; set; }
        public string ChequeProvState { get; set; }
        public string ChequeCountry { get; set; }
        public string ChequePCZip { get; set; }
        public string GST { get; set; }
        public string WhenNotAvailable { get; set; }
        public string Sharing { get; set; }
        public string SharingRef { get; set; }
        public string SharingCompany { get; set; }
        public string SharingShowTitle { get; set; }
        public string StagingRequirements { get; set; }
        public string Intermission { get; set; }
        public string LightingRequirements { get; set; }
        public string SoundRequirements { get; set; }
        public string Dancing { get; set; }
        public string DancingType { get; set; }
        public string Projection { get; set; }
        public string ImageSize { get; set; }
        public string ThrowDistance { get; set; }
        public string Holdovers { get; set; }
        public string ScreenElevation { get; set; }
        public string ScreenHeight { get; set; }
        public string ScreenWidth { get; set; }
        public string ProjectionRatio { get; set; }
        public string MediaType { get; set; }
        public string ShootFrom { get; set; }
        public string ShootFromOther { get; set; }
        public string ScreenMaterial { get; set; }
        public string SoundOut { get; set; }
        public string Liquids { get; set; }
        public string LiquidsDescribe { get; set; }
        public string OpenFlames { get; set; }
        public string Loud { get; set; }
        public string LoudDescribe { get; set; }
        public string Firearms { get; set; }
        public string Smoking { get; set; }
        public string FogMachine { get; set; }
        public string Strobe { get; set; }
        public string Hazer { get; set; }
        public string MoreLights { get; set; }
        public string WirelessMic { get; set; }
        public string Frequencies { get; set; }
        public string OtherEquipments { get; set; }
        public string EquipmentSpecify { get; set; }
        public string StageDesign { get; set; }
        public string SpecialNeeds { get; set; }
        public string Comments { get; set; }
        public string RehearsalTime { get; set; }
        public string ComingFrom { get; set; }
        public string FestivalComingFrom { get; set; }
        public string WhenArriving { get; set; }
        public string Release { get; set; }
        public string VenueName { get; set; }
        public string VenueAddress { get; set; }
        public string VenueTotal { get; set; }
        public string Wheelchair { get; set; }
        public string WheelchairCapacity { get; set; }
        public string Washrooms { get; set; }
        public string WheelchairWashrooms { get; set; }
        public string Alcohol { get; set; }
        public string Food { get; set; }
        public string EnterEarly { get; set; }
        public string MinutesBefore { get; set; }
        public string Bar { get; set; }
        public string Minors { get; set; }
        public string ShowDate { get; set; }
        public string PayDate { get; set; }
        public string PayMethod { get; set; }
        public string Amount { get; set; }
        public string Refund { get; set; }
        public string RefundDate { get; set; }
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
                    DateEntered = DateEntered
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
