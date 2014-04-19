using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Text;
using FestivalScheduler.Models.Resouces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using FestivalScheduler.Models.DataResource;

namespace FestivalScheduler.Models.DataResource
{
    public class PDFService
    {
        AttendeeService attendeeService;
        RoomService roomService;
        SchedulerMeetingService schedulerMeetingService;
        JObject keys;

        public PDFService()
        {
            attendeeService = new AttendeeService();
            roomService = new RoomService();
            schedulerMeetingService = new SchedulerMeetingService();
        }

        private void GetKeyMappingFiles()
        {
            string path = HttpContext.Current.Server.MapPath("~/File/Resource/") + "KeysMapping.json";
            keys = JObject.Parse(File.ReadAllText(path));
        }
        public string GenerateAgendaPDF()
        {

            // Set up the fonts to be used on the pages 
            Font _largeFont_UnderLine = new Font(Font.FontFamily.TIMES_ROMAN, 18, Font.BOLD|Font.UNDERLINE, BaseColor.BLACK);
            Font _largeFont = new Font(Font.FontFamily.TIMES_ROMAN, 18, Font.BOLD, BaseColor.BLACK);
            Font _standardFont = new Font(Font.FontFamily.TIMES_ROMAN, 14, Font.NORMAL, BaseColor.BLACK);
            Font _smallFont = new Font(Font.FontFamily.TIMES_ROMAN, 10, Font.NORMAL, BaseColor.BLACK);
            string datePatten = "MMMM dd, yyyy";
            string timePatten = "h:mm tt";

            GetKeyMappingFiles();

            IEnumerable<ArtistViewModel> models = attendeeService.GetAllArtists();

            string downloadPath = HttpContext.Current.Server.MapPath("~/File/Download/");

            foreach (ArtistViewModel item in models)
            {

                iTextSharp.text.Document doc = null;
                try
                {
                    // Initialize the PDF document 
                    doc = new Document();
                    iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(doc,
                        new System.IO.FileStream(downloadPath + item.Value + ".pdf",
                            System.IO.FileMode.OpenOrCreate));
                    doc.Open();
                    // Set margins and page size for the document 
                    doc.SetMargins(50, 50, 50, 50);
                    // There are a huge number of possible page sizes, including such sizes as 
                    // EXECUTIVE, LEGAL, LETTER_LANDSCAPE, and NOTE 
                    doc.SetPageSize(new iTextSharp.text.Rectangle(iTextSharp.text.PageSize.LETTER.Width,
                        iTextSharp.text.PageSize.LETTER.Height));
                    // Add metadata to the document.  This information is visible when viewing the 
                    // document properities within Adobe Reader. 
                    doc.AddTitle("Edmonton International Fringe Theatre Festival");
                    doc.AddCreator("Fringe Theatre ");
                    doc.AddKeywords("Edmonton International Fringe Theatre Festival");

                    this.AddParagraph(doc, iTextSharp.text.Element.ALIGN_CENTER, _largeFont_UnderLine, new Chunk(string.Format("Venue #{0} {1}", item.VenueNo, item.VenueName)));

                    this.AddParagraph(doc, iTextSharp.text.Element.ALIGN_LEFT, _standardFont, new Chunk(string.Format("{0} : {1}", keys["Ref"].ToString(), item.Value)));
                    this.AddParagraph(doc, iTextSharp.text.Element.ALIGN_LEFT, _standardFont, new Chunk(string.Format("{0} #: {1}", "Venue", item.VenueNo)));
                    this.AddParagraph(doc, iTextSharp.text.Element.ALIGN_LEFT, _standardFont, new Chunk(string.Format("{0} #: {1}", "Venue", item.VenueName)));
                    this.AddParagraph(doc, iTextSharp.text.Element.ALIGN_LEFT, _standardFont, new Chunk(string.Format("{0} : {1}\n\n", keys["VenueAddress"].ToString(), item.VenueAddress)));

                    this.AddParagraph(doc, iTextSharp.text.Element.ALIGN_LEFT, _standardFont, new Chunk(string.Format("{0} : {1}", keys["ShowTitle"].ToString(), item.Text)));
                    this.AddParagraph(doc, iTextSharp.text.Element.ALIGN_LEFT, _standardFont, new Chunk(string.Format("{0} : {1}", keys["Company"].ToString(), item.Company)));
                    this.AddParagraph(doc, iTextSharp.text.Element.ALIGN_LEFT, _standardFont, new Chunk(string.Format("{0} : {1}, {2}, {3}", "Location", item.PrimaryCity, item.PrimaryProvState, item.PrimaryCountry)));
                    this.AddParagraph(doc, iTextSharp.text.Element.ALIGN_LEFT, _standardFont, new Chunk(string.Format("{0} : {1} min", keys["RunningTime"].ToString(), item.Length)));
                    this.AddParagraph(doc, iTextSharp.text.Element.ALIGN_LEFT, _standardFont, new Chunk(string.Format("{0} : {1}", keys["Genre"].ToString(), item.Genre)));
                    this.AddParagraph(doc, iTextSharp.text.Element.ALIGN_LEFT, _standardFont, new Chunk(string.Format("{0} : Adult: {1}", "Ticket Price", item.GeneralAdmission)));
                    this.AddParagraph(doc, iTextSharp.text.Element.ALIGN_LEFT, _standardFont, new Chunk(string.Format("{0} : Student/Senior: {1}\n\n", "Ticket Price", item.StudentSenior)));
                    
                    this.AddParagraph(doc, iTextSharp.text.Element.ALIGN_LEFT, _standardFont, new Chunk(string.Format("{0} : {1}\n\n", keys["ShowDescription"].ToString(), item.ShowDescription))); 

                    this.AddParagraph(doc, iTextSharp.text.Element.ALIGN_LEFT, _standardFont, new Chunk(string.Format("{0} : {1}", keys["Playwright"].ToString(), item.Playwright)));
                    this.AddParagraph(doc, iTextSharp.text.Element.ALIGN_LEFT, _standardFont, new Chunk(string.Format("{0} : {1}", keys["Director"].ToString(), item.Director)));
                    this.AddParagraph(doc, iTextSharp.text.Element.ALIGN_LEFT, _standardFont, new Chunk(string.Format("{0} : {1}", keys["CastMembers"].ToString(), item.CastMembers)));
                    this.AddParagraph(doc, iTextSharp.text.Element.ALIGN_LEFT, _standardFont, new Chunk(string.Format("{0} : {1}", keys["StageManager"].ToString(), item.StageManager)));
                    this.AddParagraph(doc, iTextSharp.text.Element.ALIGN_LEFT, _standardFont, new Chunk(string.Format("{0} : {1}\n\n", keys["Designer"].ToString(), item.Designer))); 

                    this.AddParagraph(doc, iTextSharp.text.Element.ALIGN_LEFT, _standardFont, new Chunk(string.Format("{0} : {1}", keys["ContentAdvisory"].ToString(), item.ContentAdvisory)));
                    this.AddParagraph(doc, iTextSharp.text.Element.ALIGN_LEFT, _standardFont, new Chunk(string.Format("{0} : {1}", keys["ShowRating"].ToString(), item.ShowRating)));
                    this.AddParagraph(doc, iTextSharp.text.Element.ALIGN_LEFT, _standardFont, new Chunk(string.Format("{0} : {1}", keys["AgeRestriction"].ToString(), item.AgeRestriction)));
                    this.AddParagraph(doc, iTextSharp.text.Element.ALIGN_LEFT, _standardFont, new Chunk(string.Format("{0} : {1}", keys["NewWork"].ToString(), item.NewWork)));
                    this.AddParagraph(doc, iTextSharp.text.Element.ALIGN_LEFT, _standardFont, new Chunk(string.Format("{0} : {1}\n\n", keys["Website"].ToString(), item.Website))); 

                    this.AddParagraph(doc, iTextSharp.text.Element.ALIGN_LEFT, _standardFont, new Chunk(string.Format("{0} :\n\n", "Schedule"))); 


                    // table for the date start end 
                    List<Meeting> meetings = schedulerMeetingService.GetMeetingsByAttendee(item.Value);

                    PdfPTable table = new PdfPTable(3);
                    table.HorizontalAlignment = Element.ALIGN_LEFT;
                    table.TotalWidth = 300f;
                    table.LockedWidth = true;
                    float[] widths = new float[] { 120f, 90f, 90f};
                    table.SetWidths(widths);

                    table.AddCell(new PdfPCell(new Phrase("Date")) { VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_CENTER, Border = Rectangle.NO_BORDER });
                    table.AddCell(new PdfPCell(new Phrase("Start Time")) { VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_RIGHT, Border = Rectangle.NO_BORDER });
                    table.AddCell(new PdfPCell(new Phrase("End Time")) { VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_RIGHT, Border = Rectangle.NO_BORDER }); 


                    foreach (Meeting meeting in meetings)
                    {
                        table.AddCell(new PdfPCell(new Phrase(meeting.Start.ToString(datePatten))) { VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_RIGHT, Border = Rectangle.NO_BORDER });
                        table.AddCell(new PdfPCell(new Phrase(meeting.Start.ToString(timePatten))) { VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_RIGHT, Border = Rectangle.NO_BORDER });
                        table.AddCell(new PdfPCell(new Phrase(meeting.End.ToString(timePatten))) { VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_RIGHT, Border = Rectangle.NO_BORDER }); 
                    }
                     doc.Add(table);

                    // Clean up
                    doc.Close();
                    doc = null;
                }
                catch (iTextSharp.text.DocumentException dex)
                {
                    return string.Format("PDF agenda file failed at {0}, caused by {1}", item.Value, dex.Message);
                }
                catch (Exception e)
                {
                    return string.Format("PDF agenda file failed at {0}, caused by {1}", item.Value, e.Message);
                }
            }
            return "";
        }

        private void AddParagraph(Document doc, int alignment, iTextSharp.text.Font font, iTextSharp.text.IElement content)
        {
            Paragraph paragraph = new Paragraph();
            paragraph.SetLeading(0f, 1.2f);
            paragraph.Alignment = alignment;
            paragraph.Font = font;
            paragraph.Add(content);
            doc.Add(paragraph);
        }

    }

}