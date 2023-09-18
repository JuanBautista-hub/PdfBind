using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnirPdf
{
    public class logica
    {
        private string folderOrigen{get; set;}
        private string folderDestino { get; set; }
        public string PedirRutaFolder()
        {
            Console.Write("Ingresa un ruta donde estan tus archivos pdf \n ");
            folderOrigen = Console.ReadLine().Replace(" ", "");
            while (folderOrigen == string.Empty)
            {
                Console.Write("Ingresa un ruta donde estan tus archivos pdf  \n");
                folderOrigen = Console.ReadLine().Replace(" ", "");
            }
           
        

            return folderOrigen;

        }

        public string PreguntarMismoFolder()
        {
            Console.Write("¿Desea guardar en la misma ruta el resultado? \n");
            Console.Write("Elige una opcion\n");
            Console.Write("1: SI \n");
            Console.Write("2: NO\n");
            var  eleccion = Console.ReadLine().Replace(" ", "");

            return eleccion;
        }

        public string PedirRutaFolderResultado()
        {
            Console.Write("Ingresa un ruta donde quieres guardar el resultado pdf  \n");
             folderDestino = Console.ReadLine().Replace(" ", "");
            while (folderDestino == string.Empty)
            {
                Console.Write("Ingresa un ruta donde quieres guardar el resultado pdf\n ");
                folderDestino = Console.ReadLine().Replace(" ", "");
            }


            return folderDestino;
        }

    
    }
}
