using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SqlDependency
{
    public class Customers
    {
        [XmlAttribute]
        public int Id { get; set; }

        public string  Name { get; set; }

        public string Surname { get; set; }

        //Properties not prsent in db table are ignored

        public string City { get; set; }

        public DateTime Born { get; set; }
    }
}
