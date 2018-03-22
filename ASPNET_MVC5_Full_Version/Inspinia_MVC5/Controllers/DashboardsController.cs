using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Web.Mvc;

namespace Inspinia_MVC5.Controllers
{
    public class DashboardsController : Controller
    {
        public ActionResult ExecutiveDashboard()
        {
            //var ExportClicked = !string.IsNullOrEmpty(Request.Form["hdnExport"]) ? Request.Form["hdnExport"] : string.Empty;
            //if (ExportClicked == "Clicked")
            //{
               
            //}
            return View();
        }

      
        public ActionResult ExportExcel()
        {
            // Create a new Data Table.
            System.Data.DataTable custTable = new DataTable("Customers");
            DataColumn dtColumn;
            DataRow myDataRow;
            // Create id Column
            dtColumn = new DataColumn();
            dtColumn.DataType = System.Type.GetType("System.Int32");
            dtColumn.ColumnName = "id";
            dtColumn.Caption = "Cust ID";
            dtColumn.ReadOnly = false;
            dtColumn.Unique = true;
            // Add id column to the DataColumnCollection.
            custTable.Columns.Add(dtColumn);

            // create Name column.
            dtColumn = new DataColumn();
            dtColumn.DataType = System.Type.GetType("System.String");
            dtColumn.ColumnName = "Name";
            dtColumn.Caption = "Cust Name";
            dtColumn.AutoIncrement = false;
            dtColumn.ReadOnly = false;
            dtColumn.Unique = false;

            // Add Name Column to the table.
            custTable.Columns.Add(dtColumn);
            // Create Address column.
            dtColumn = new DataColumn();
            dtColumn.DataType = System.Type.GetType("System.String");
            dtColumn.ColumnName = "Address";
            dtColumn.Caption = "Address";
            dtColumn.ReadOnly = false;
            dtColumn.Unique = false;

            // Add Address column to the table.
            custTable.Columns.Add(dtColumn);

            // Make the ID column the primary key column.
            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = custTable.Columns["id"];
            custTable.PrimaryKey = PrimaryKeyColumns;
            // Instantiate the  DataSet variable.
            DataSet dtSet = new DataSet();
            dtSet = new DataSet("Sample");

            // Add the custTable to the DataSet.
            dtSet.Tables.Add(custTable);

            // Add rows to the custTable using NewRow method
            // I add three customers with their addresses, name and id
            myDataRow = custTable.NewRow();
            myDataRow["id"] = 1001;
            myDataRow["Address"] = "43 Lanewood Road, cito, CA";
            myDataRow["Name"] = "George Bishop";
            custTable.Rows.Add(myDataRow);
            myDataRow = custTable.NewRow();
            myDataRow["id"] = 1002;
            myDataRow["name"] = "Rock joe";
            myDataRow["Address"] = " kind of Prussia, PA";
            custTable.Rows.Add(myDataRow);
            myDataRow = custTable.NewRow();
            myDataRow["id"] = 1003;
            myDataRow["Name"] = "Miranda";
            myDataRow["Address"] = "279 P. Avenue, Bridgetown, PA";
            custTable.Rows.Add(myDataRow);
            Export(dtSet);
            return View();
        }
        public void Export(DataSet ds) //IEnumerable<ChildCareBO> model
        {
            string strPDFFileName = string.Format("Sample" + DateTime.Now.ToString("yyyyMMddhhmm") + "-" + ".csv");
            Response.Clear();
            Response.ClearHeaders();
            Response.ContentType = "text/csvv";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + strPDFFileName);
            Response.Write(GenerateCsvContent(ds)); //GenerateCsvContent(model)
            Response.Flush();
            Response.End();
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

        private string GenerateCsvContent(DataSet ds) //IEnumerable<ChildCareBO> model
        {
            StringBuilder sb = new StringBuilder();
            if (ds != null)
            {
                sb.AppendLine("ID,NAME, ADDRESS");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    sb.AppendFormat("\"{0}\",\"{1}\",\"{2}\"\r\n", dr[0].ToString(), dr[1].ToString(), dr[2].ToString());
                }
                sb.AppendLine();
                sb.AppendLine();

            }

            return sb.ToString();
        }
        public ActionResult InvoicePrint()
        {
            return View();
        }

        public ActionResult SupervisorDashboard()
        {
            return View();
        }
        public ActionResult InspectorDashboard()
        {
            return View();
        }
        public ActionResult GenerateExportExcel()
        {
            return View();
        }
    }
}