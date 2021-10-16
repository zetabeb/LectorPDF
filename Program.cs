using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectorPDF
{
    class Program
    {
        static void Main(string[] args)
        {
            var src = "pdf//0824215223865.pdf";
            var pdfDocument = new PdfDocument(new PdfReader(src));
            var strategy = new LocationTextExtractionStrategy();
            string text = string.Empty;

            //StreamWriter file = new StreamWriter("pdf//anexo.txt", true);

            for (int i = 1; i <= pdfDocument.GetNumberOfPages(); ++i)
            {
                var page = pdfDocument.GetPage(i);
                text += PdfTextExtractor.GetTextFromPage(page);
                //file.Write(text);
                //Console.WriteLine(text);
            }
            //Console.WriteLine(text);
            string[] array = text.Split('\n');
            string correo = string.Empty;
            foreach(string item in array)
            {
                if(item.ToLower().Contains("e-mail"))
                    array = item.Split(':');                
            }
            //text = string.Empty;
            foreach(string item in array)
            {
                if (!item.ToLower().Contains("e-mail"))
                    correo = item;
            }
            Console.WriteLine(correo.Trim());
            Console.ReadLine();
            //file.Close();
            //file.Dispose();


        }
    }
}
