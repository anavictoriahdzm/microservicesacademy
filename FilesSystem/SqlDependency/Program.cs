using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base.Enums;
using TableDependency.SqlClient.Base.EventArgs;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Linq;

namespace SqlDependency
{
    class Program
    {
        public static void SerializeToXml<T>(T obj, string fileName)
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));
            //Create a filestream object connected to the target file

            FileStream fileStream = new FileStream(fileName, FileMode.Create);
            ser.Serialize(fileStream, obj);
            fileStream.Close();
        }

        public static T DeserializeFromXml<T>(string xml)
        {
            T result;
            XmlSerializer ser = new XmlSerializer(typeof(T));
            using (TextReader tr = new StringReader(xml))
            {
                result = (T)ser.Deserialize(tr);
            }
            return result;
        }
        static void Main(string[] args)
        {
            string connectionString = @"data source =LSTK231296\SQLEXPRESS ; initial catalog=prueba ; integrated security = True";
            using (TableDependency.SqlClient.SqlTableDependency<Customers> dep = new TableDependency.SqlClient.SqlTableDependency<Customers>(connectionString))
            {
                dep.OnChanged += Dep_OnChanged;

                dep.Start();
                Console.WriteLine("Waiting for receiving notificatiions...");
                Console.WriteLine("Press a key to stop");
                Console.ReadKey();
                dep.Stop();
            }
        }

        static void Dep_OnChanged(object sender, RecordChangedEventArgs<Customers> e)
        {
            //Si es INSERT
            if (e.ChangeType.ToString() == "Insert")
            {
                List<Customers> ListaCustomers = new List<Customers>();
                if (File.Exists(@"C:\Users\Curso\source\repos\FilesSystem\Customers.xml"))
                {
                    XmlDocument Doc = new XmlDocument();
                    Doc.Load(@"C:\Users\Curso\source\repos\FilesSystem\Customers.xml");
                    ListaCustomers.AddRange(DeserializeFromXml<List<Customers>>(Doc.OuterXml));
                }

                Customers lCustomers = new Customers();
                lCustomers.Id = e.Entity.Id;
                lCustomers.Name = e.Entity.Name;
                lCustomers.Surname = e.Entity.Surname;

                ListaCustomers.Add(lCustomers);
                SerializeToXml(ListaCustomers, @"C:\Users\Curso\source\repos\FilesSystem\Customers.xml");
                //SerializeToXml<List<Customers>>(ListaCustomers, @"C:\Users\Curso\source\repos\FilesSystem\Customers.xml");

                Console.WriteLine(Environment.NewLine);
            }

            //Si es Delete
            if (e.ChangeType.ToString() == "Delete")
            {
                XElement Doc = XElement.Load(@"C:\Users\Curso\source\repos\FilesSystem\Customers.xml");

                foreach (XNode item in Doc.Nodes())
                {
                    var idAttribute = ((XElement)item).Attributes("Id").FirstOrDefault().Value;
                    if (idAttribute == e.Entity.Id.ToString())
                    {
                        item.Remove();
                        Doc.Save(@"C:\Users\Curso\source\repos\FilesSystem\Customers.xml");
                    }
                }
            }

            //Si es Update
            if (e.ChangeType.ToString() == "Update")
            {
                XElement Doc = XElement.Load(@"C:\Users\Curso\source\repos\FilesSystem\Customers.xml");

                foreach (XElement item in Doc.Nodes())
                {
                    var idAttribute = item.Attributes("Id").FirstOrDefault().Value;
                    if (idAttribute == e.Entity.Id.ToString())
                    {
                        item.SetElementValue("Name", e.Entity.Name.ToString());
                        item.SetElementValue("Surname", e.Entity.Surname.ToString());

                        Doc.Save(@"C:\Users\Curso\source\repos\FilesSystem\Customers.xml");
                    }
                }
            }

            //si hubo un cambio en la tabla
            if (e.ChangeType != ChangeType.None)
            {
                Console.WriteLine("DML operation: " + e.ChangeType);
                Console.WriteLine(e.Entity.Id);
                Console.WriteLine(e.Entity.Name);
                Console.WriteLine(e.Entity.Surname);
                Console.WriteLine(Environment.NewLine);
            }
        }
    }
}
