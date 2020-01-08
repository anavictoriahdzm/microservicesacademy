using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            FileSystemWatcher observador = new FileSystemWatcher(@"C:\Users\Curso\source\repos\FilesSystem");
            observador.NotifyFilter = (
                NotifyFilters.LastAccess |
                NotifyFilters.LastWrite|
                NotifyFilters.FileName |
                NotifyFilters.DirectoryName);

            observador.Changed += AlCambiar;
            observador.Created += AlCambiar;
            observador.Deleted += AlCambiar;
            observador.Renamed += AlRenombrar;
            observador.Error += AlOcurrirUnError;

            observador.EnableRaisingEvents = true;
            Console.WriteLine("Presiona enter para detener");
            Console.ReadLine(); 
        }

        private static void AlRenombrar(object sender, RenamedEventArgs e)
        {
            Console.WriteLine("El archivo {0} ahora se llama {1}", e.OldFullPath, e.FullPath);
        }

        private static void AlCambiar(object sender, FileSystemEventArgs e) 
        {
            WatcherChangeTypes tipoDeCambio = e.ChangeType;
            Console.WriteLine("El archivo {0} tuvo cambio de: {1}", e.FullPath, tipoDeCambio.ToString());
        }

        private static void AlOcurrirUnError(object source, ErrorEventArgs e)
        {
            Console.WriteLine("Error; " + e.GetException().Message);
        }
    }
}
