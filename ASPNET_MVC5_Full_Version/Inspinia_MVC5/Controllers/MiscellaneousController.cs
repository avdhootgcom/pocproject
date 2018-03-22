using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using System;
using System.IO;
using System.Web.Mvc;

namespace Inspinia_MVC5.Controllers
{
    public class MiscellaneousController : Controller
    {

        public ActionResult GoogleMaps()
        {
            return View();
        }

        public ActionResult Notification()
        {
            return View();
        }
   

        public ActionResult PdfViewer()
        {
            return View();
        }

        public ActionResult GeneratePDF()
        {
            //clsGeneratePDFFile CreatePDF = new clsGeneratePDFFile();
            //MemoryStream reportStream = CreatePDF.CreatePdfDocument(); //_pdfService.GeneratePDF();
            //return File(reportStream, "application/pdf");
            PdfDocument pdfdoc = new PdfDocument();
            pdfdoc.Info.Title = "VRVSS";
            pdfdoc.Info.Author = "VRVSS";

            //Create an Empty Page
            PdfPage pdfpage = pdfdoc.AddPage();
            pdfpage.Size = PageSize.Letter; // Change the Page Size
            pdfpage.Orientation = PageOrientation.Portrait;// Change the orientation property
            //Get an XGraphics object for drawing
            XGraphics xGrap = XGraphics.FromPdfPage(pdfpage);

            //Create Fonts
            XFont titlefont = new XFont("Calibri", 20, XFontStyle.Regular);
            XFont tableheader = new XFont("Calibri", 15, XFontStyle.Bold);
            XFont bodyfont = new XFont("Calibri", 11, XFontStyle.Regular);

            //Draw the text

            double x = 250;
            double y = 50;
            double width = 800;
            double height = 25;

            //Title Binding
            XTextFormatter textformater = new XTextFormatter(xGrap);  //Used to Hold the Custom text Area
            xGrap.DrawRectangle(XBrushes.White, new XRect(x, y, width, height));
            textformater.DrawString("Sample File", titlefont, XBrushes.Blue,
                new XRect(x, y, width, height), XStringFormats.TopLeft);

            //Table Declaration (height and width of columns declaration)
            y = y + 40; //Increasing the height  from top
            XRect renderingEngine = new XRect(35, y, 150, height);
            XRect browser = new XRect(180, y, 250, height);
            XRect plateForm = new XRect(300, y, 100, height);
            XRect engineVersion = new XRect(400, y, 150, height);
            //XRect cssGrade = new XRect(550, y, 150, height);


            //Draw the table Row Borders

            xGrap.DrawRectangle(XPens.DarkSeaGreen, XBrushes.DarkSeaGreen, renderingEngine); //Use different Color for Colum
            xGrap.DrawRectangle(XPens.DarkSeaGreen, XBrushes.DarkSeaGreen, browser);
            xGrap.DrawRectangle(XPens.DarkSeaGreen, XBrushes.DarkSeaGreen, plateForm);
            xGrap.DrawRectangle(XPens.DarkSeaGreen, XBrushes.DarkSeaGreen, engineVersion);
            //xGrap.DrawRectangle(XPens.DarkSeaGreen, XBrushes.DarkSeaGreen, cssGrade);

            //Writting Table Header Text

            textformater.DrawString(" Rendering Engine", tableheader, XBrushes.Black, renderingEngine);
            textformater.DrawString(" Browser", tableheader, XBrushes.Black, browser);
            textformater.DrawString(" Plateform(S)", tableheader, XBrushes.Black, plateForm);
            textformater.DrawString(" Engine Version", tableheader, XBrushes.Black, engineVersion);
            //textformater.DrawString("CSS grade", tableheader, XBrushes.Black, cssGrade);

            //Writting the Body Content of Table

            y = y + 30; //increase the height of content position from top
            XRect renderingEVal = new XRect(35, y, 150, height);
            XRect browserNameVal = new XRect(180, y, 250, height);
            XRect plateFormVal = new XRect(300, y, 100, height);
            XRect engineVersionVal = new XRect(400, y, 150, height);
            //XRect cssGradeVal = new XRect(500, y, 150, height);

            textformater.DrawString("Gecko", tableheader, XBrushes.Black, renderingEVal);
            textformater.DrawString(" Firefox 1.0", tableheader, XBrushes.Black, browserNameVal);
            textformater.DrawString(" Win 98+ OSX.2+", tableheader, XBrushes.Black, plateFormVal);
            textformater.DrawString(" 1.7", tableheader, XBrushes.Black, engineVersionVal);
            //textformater.DrawString(" A", tableheader, XBrushes.Black, cssGrade);




            y = y + 30;
             renderingEVal = new XRect(35, y, 150, height);
             browserNameVal = new XRect(180, y, 250, height);
             plateFormVal = new XRect(300, y, 100, height);
             engineVersionVal = new XRect(400, y, 150, height);
            //cssGradeVal = new XRect(500, y, 150, height);

            textformater.DrawString(" Gecko", tableheader, XBrushes.Black, renderingEVal);
            textformater.DrawString(" Firefox 1.5", tableheader, XBrushes.Black, browserNameVal);
            textformater.DrawString(" Win 98+ OSX.2+", tableheader, XBrushes.Black, plateFormVal);
            textformater.DrawString(" 1.8", tableheader, XBrushes.Black, engineVersionVal);
            //textformater.DrawString(" A", tableheader, XBrushes.Black, cssGrade);

            y = y + 30;
            renderingEVal = new XRect(35, y, 150, height);
            browserNameVal = new XRect(180, y, 250, height);
            plateFormVal = new XRect(300, y, 100, height);
            engineVersionVal = new XRect(400, y, 150, height);

            textformater.DrawString(" Gecko", tableheader, XBrushes.Black, renderingEVal);
            textformater.DrawString(" Firefox 2.0", tableheader, XBrushes.Black, browserNameVal);
            textformater.DrawString(" Win 98+ OSX.2+", tableheader, XBrushes.Black, plateFormVal);
            textformater.DrawString(" 1.7", tableheader, XBrushes.Black, engineVersionVal);
            //textformater.DrawString(" A", tableheader, XBrushes.Black, cssGrade);

            //y = y + 30;
            //renderingEVal = new XRect(35, y, 70, height);
            //browserNameVal = new XRect(100, y, 250, height);
            //plateFormVal = new XRect(280, y, 60, height);
            //engineVersionVal = new XRect(250, y, 150, height);
            //cssGradeVal = new XRect(250, y, 150, height);

            //textformater.DrawString(" Gecko", tableheader, XBrushes.Black, renderingEngine);
            //textformater.DrawString(" Firefox 3.0", tableheader, XBrushes.Black, browser);
            //textformater.DrawString(" Win 2K+ OSX.3+", tableheader, XBrushes.Black, plateForm);
            //textformater.DrawString(" 1.3", tableheader, XBrushes.Black, engineVersion);
            //textformater.DrawString(" A", tableheader, XBrushes.Black, cssGrade);

            //y = y + 30;
            //renderingEVal = new XRect(35, y, 70, height);
            //browserNameVal = new XRect(100, y, 250, height);
            //plateFormVal = new XRect(280, y, 60, height);
            //engineVersionVal = new XRect(250, y, 150, height);
            //cssGradeVal = new XRect(250, y, 150, height);

            //textformater.DrawString(" Gecko", tableheader, XBrushes.Black, renderingEngine);
            //textformater.DrawString(" Firefox 1.0", tableheader, XBrushes.Black, browser);
            //textformater.DrawString(" Win 98+ OSX.2+", tableheader, XBrushes.Black, plateForm);
            //textformater.DrawString(" 1.7", tableheader, XBrushes.Black, engineVersion);
            //textformater.DrawString(" A", tableheader, XBrushes.Black, cssGrade);

            //y = y + 30;
            //renderingEVal = new XRect(35, y, 70, height);
            //browserNameVal = new XRect(100, y, 250, height);
            //plateFormVal = new XRect(280, y, 60, height);
            //engineVersionVal = new XRect(250, y, 150, height);
            //cssGradeVal = new XRect(250, y, 150, height);

            //textformater.DrawString(" Gecko", tableheader, XBrushes.Black, renderingEngine);
            //textformater.DrawString(" Camino 1.0", tableheader, XBrushes.Black, browser);
            //textformater.DrawString(" OSX.2+", tableheader, XBrushes.Black, plateForm);
            //textformater.DrawString(" 1.8", tableheader, XBrushes.Black, engineVersion);
            //textformater.DrawString(" A", tableheader, XBrushes.Black, cssGrade);

            //y = y + 30;
            //renderingEVal = new XRect(35, y, 70, height);
            //browserNameVal = new XRect(100, y, 250, height);
            //plateFormVal = new XRect(280, y, 60, height);
            //engineVersionVal = new XRect(250, y, 150, height);
            //cssGradeVal = new XRect(250, y, 150, height);

            //textformater.DrawString(" Gecko", tableheader, XBrushes.Black, renderingEngine);
            //textformater.DrawString(" Camino 1.5", tableheader, XBrushes.Black, browser);
            //textformater.DrawString(" OSX.3+", tableheader, XBrushes.Black, plateForm);
            //textformater.DrawString(" 1.7", tableheader, XBrushes.Black, engineVersion);
            //textformater.DrawString(" A", tableheader, XBrushes.Black, cssGrade);

            //y = y + 30;
            //renderingEVal = new XRect(35, y, 70, height);
            //browserNameVal = new XRect(100, y, 250, height);
            //plateFormVal = new XRect(280, y, 60, height);
            //engineVersionVal = new XRect(250, y, 150, height);
            //cssGradeVal = new XRect(250, y, 150, height);

            //textformater.DrawString("Gecko", tableheader, XBrushes.Black, renderingEngine);
            //textformater.DrawString(" Firefox 1.0", tableheader, XBrushes.Black, browser);
            //textformater.DrawString(" Win 98+ OSX.2+", tableheader, XBrushes.Black, plateForm);
            //textformater.DrawString(" 1.7", tableheader, XBrushes.Black, engineVersion);
            //textformater.DrawString(" A", tableheader, XBrushes.Black, cssGrade);
            string strPDFFileName = string.Format("SamplePdf" + DateTime.Now.ToString("yyyyMMddhhmm") + "-" + ".pdf");
            string filename = Server.MapPath("~/Downloads/") + strPDFFileName;  //Choose the path where the file want to save

            MemoryStream stream = new MemoryStream();
            pdfdoc.Save(stream, false);
            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-length", stream.Length.ToString());
            Response.BinaryWrite(stream.ToArray());
            Response.Flush();
            stream.Close();
            Response.End();

            return View();
        }


    }
}