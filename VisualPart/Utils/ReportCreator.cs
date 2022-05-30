using System;
using System.IO;
using FastReport;
using FastReport.Export.Image;
using FastReport.Export.PdfSimple;

namespace SmetaCreator.Utils
{
    public class ReportCreator
    {
        public static void CreateReport(string path)
        {
            Report r = new Report();
            r.Load($"C:/Users/{Environment.UserName}/Desktop/Study/Untitled.frx");
            PDFSimpleExport p = new PDFSimpleExport();
            r.Prepare();
            p.Export(r, Path.Combine(path, "smeta.pdf"));
        }
    }
}
