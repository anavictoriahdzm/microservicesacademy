using System;
using System.IO;

namespace EmailCore
{
    class Program
    {
        static void Main(string[] args)
        {
            FileSystemWatcher watcher = new FileSystemWatcher(@"C:\Users\Curso\Desktop\Test");

            watcher.EnableRaisingEvents = true;
            watcher.IncludeSubdirectories = true;

            //add event hanlders
            watcher.Renamed += watcher_Renamed;
            Console.Read();
        }

        private static void watcher_Renamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine("se enviara correo");
            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();

            mmsg.To.Add("softtekt4@gmail.com");
            mmsg.Subject = log.mensaje;
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;

            mmsg.Body = log.mensaje;
            mmsg.BodyEncoding = System.Text.Encoding.UTF8;
            mmsg.IsBodyHtml = true;
            mmsg.From = new System.Net.Mail.MailAddress("softtekt4@gmail.com");

            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();
            cliente.Credentials = new System.Net.NetworkCredential("softtekt4@gmail.com", "Soporte01");

            cliente.Port = 587;
            cliente.EnableSsl = true;
            cliente.Host = "smtp.gmail.com";

            try
            {
                cliente.Send(mmsg);
            }
            catch (Exception i)
            {

                Console.WriteLine("Error: " + i);
            }

        }
    }
}
