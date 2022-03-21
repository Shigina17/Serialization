using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Serialization
{
    [System.Xml.Serialization.XmlRoot("AquaPark")]
    public class AquaPark
    {
        [System.Xml.Serialization.XmlElement("employees")]
        public Employees Employees { get; set; }
        [System.Xml.Serialization.XmlElement("clients")]
        public Clients Clients { get; set; }
        [System.Xml.Serialization.XmlElement("comments")]
        public Comments Comments { get; set; }
    }
    public class Employees
    {
        [System.Xml.Serialization.XmlElement("employee")]
        public Employee[] EmployeesArray { get; set; }
    }
    public class Employee
    {
        [System.Xml.Serialization.XmlAttribute("ID", Namespace = "")]
             public int ID { get; set; }
        [System.Xml.Serialization.XmlElement("name", Namespace = "")]
             public string Name { get; set; }
        [System.Xml.Serialization.XmlElement("age", Namespace = "")]
            public int Age { get; set; }
    }
    public class Clients
    {
        [System.Xml.Serialization.XmlElement("client")]
        public Client[] ClientsArray { get; set; }
    }
    public class Client
    {
        [System.Xml.Serialization.XmlElement("name", Namespace = "")]
        public string Name { get; set; }
        [System.Xml.Serialization.XmlElement("age", Namespace = "")]
        public int Age { get; set; }
        [System.Xml.Serialization.XmlAttribute("ID", Namespace = "")]
        public int ID { get; set; }
    }
    public class Comments
    {
        [System.Xml.Serialization.XmlElement("comment")]
        public Comment[] CommentsArray { get; set; }
    }
    public class Comment
    {
        [System.Xml.Serialization.XmlElement("feedback", Namespace = "")]
        public string Feedback { get; set; }
        [System.Xml.Serialization.XmlElement("count", Namespace = "")]
        public int Count { get; set; }
        [System.Xml.Serialization.XmlAttribute("ID", Namespace = "")]
        public int ID { get; set; }
    }
}
