using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnirPdf
{
    static class ConvinarPdf
    {

        public static void MergePDFs(string[] pdfFiles, string outputFile)
        {
            using (FileStream fs = new FileStream(outputFile, FileMode.Create))
            {
                iTextSharp.text.Document document = new iTextSharp.text.Document();
                PdfCopy copy = new PdfCopy(document, fs);
                document.Open();

                foreach (string pdfFile in pdfFiles)
                {
                    Console.WriteLine($"Uniendo pdf {pdfFile} espere....");
                    using (PdfReader reader = new PdfReader(pdfFile))
                    {

                        for (int i = 1; i <= reader.NumberOfPages; i++)
                        {

                            PdfImportedPage page = copy.GetImportedPage(reader, i);
                            copy.AddPage(page);
                        }
                    }
                }

                document.Close();
            }
        }


        public static string[] obtenerArchivosPdf(string folderOrigen)
        {
            try
            {
                // Obtiene la lista de archivos en la carpeta especificada
                string[] archivos = Directory.GetFiles(folderOrigen);

                // Itera a través de los nombres de los archivos y los muestra
                foreach (string archivo in archivos.Where(archivo => Path.GetExtension(archivo).Equals(".pdf", StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine(Path.GetFileName(archivo));
                }

                return archivos.Where(archivo => Path.GetExtension(archivo).Equals(".pdf", StringComparison.OrdinalIgnoreCase))
                .ToArray();
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine("La carpeta especificada no existe.");
                throw new Exception("La carpeta especificada no existe." +e.Message);
            }
            catch (IOException e)
            {
                throw new Exception("Error de E/S: " + e.Message);
            }

            return new string[0];
        }


    }
}