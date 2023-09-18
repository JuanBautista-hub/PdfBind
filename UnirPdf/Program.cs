// See htusing System;
using System.IO;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using iTextSharp.text;
using iTextSharp.text.pdf;
using UnirPdf;

class Program
{
    static void Main()
    {

        try
        {

            Procesos();

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine("INGRESA UNA RUTA VALIDA");
            Procesos();
         
        }
    }

    static void Procesos()
    {
        var logica = new logica();


        var folder = logica.PedirRutaFolder() + "\\";
        string outputFile = logica.PreguntarMismoFolder();

        if (outputFile == "2")
        {
            outputFile = logica.PedirRutaFolderResultado();
        }
        else
        {
            outputFile = folder;
        }

        string[] pdfFiles = ConvinarPdf.obtenerArchivosPdf(folder);


        Console.Write("Deseas continuar?  \n");
        Console.Write("Elige una opcion\n");
        Console.Write("1: SI \n");
        Console.Write("2: NO\n");
        Console.Write("3: Reiniciar\n");
        var continuar = Console.ReadLine().Replace(" ", "");
        if (continuar == "1")
        {
            IniciarProceso(pdfFiles, outputFile);
        }
        if (continuar == "3")
        {
            Procesos();
        }
    }

    static void IniciarProceso(string[] pdfFiles, string outputFile)
    {
        Guid uuid = Guid.NewGuid();

        ConvinarPdf.MergePDFs(pdfFiles, outputFile + $"{uuid.ToString()}.pdf");

        Console.WriteLine("PDFs unidos exitosamente.");
    }

}
