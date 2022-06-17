using System;
using System.IO;
using FastReport;
using System.Data;
using FastReport.Export.Image;
using FastReport.Export.PdfSimple;
using FastReport.Export;
using FastReport.Export.Html;

namespace SmetaCreator.Utils
{
    public class ReportCreator
    {
        public static void CreateReport(string path)
        {
            Report r = new Report();
            r.Load(Path.Combine(Environment.CurrentDirectory.ToString(), "blankReport.frx"));
            PDFSimpleExport p = new PDFSimpleExport();
            r.Prepare();
            p.Export(r, Path.Combine(path, "smeta.pdf"));
        }

        public static void CreateReport(Stream stream, int index)
        {
            Report r = new Report();
            r.Load(Path.Combine(Environment.CurrentDirectory.ToString(), "blankReport.frx"));
            ExportBase p;
            switch(index) 
            {
                case 1:
                    p = new PDFSimpleExport();
                    break;
                case 2:
                    p = new HTMLExport();
                    (p as HTMLExport)!.EmbedPictures = true;
                    break;
                case 3:
                    p = new ImageExport();
                    (p as ImageExport)!.ImageFormat = ImageExportFormat.Png;
                    break;
                case 4:
                    p = new ImageExport();
                    (p as ImageExport)!.ImageFormat = ImageExportFormat.Jpeg;
                    break;
                default:
                    throw new ArgumentException("Неверный формат");
            }
            //var dataSet = new DataSet();
            //dataSet.ReadXml("smeta.xml");
            //r.RegisterData(dataSet);
            r.Prepare();
            p.Export(r, stream);
        }
    }
}
