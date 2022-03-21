using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Serialization
{
    public partial class Form1 : Form
    {
        private AquaPark result;
        private void AddRowsToCommentsDataGreedView()
        {
            DataGridViewRow row;
            for (int i = 0; i < result.Comments.CommentsArray.Length; i++)
            {
                Comment comment = result.Comments.CommentsArray[i];
                row = new DataGridViewRow();
                row.CreateCells(commentDataGridView);
                row.Cells[0].Value = comment.ID;
                row.Cells[1].Value = comment.Feedback;
                row.Cells[2].Value = comment.Count;
                commentDataGridView.Rows.Add(row);
            }
        }
        private void AddRowsToClientsDataGreedView()
        {
            DataGridViewRow row;
            for (int i = 0; i < result.Clients.ClientsArray.Length; i++)
            {
                Client client = result.Clients.ClientsArray[i];
                row = new DataGridViewRow();
                row.CreateCells(clientDataGridView);
                row.Cells[0].Value = client.ID;
                row.Cells[1].Value = client.Name;
                row.Cells[2].Value = client.Age;
                clientDataGridView.Rows.Add(row);
            }
        }
        private void AddRowsToEmployeesDataGreedView()
        {
            DataGridViewRow row;
            for (int i = 0; i < result.Employees.EmployeesArray.Length; i++)
            {
                Employee employee = result.Employees.EmployeesArray[i];
                row = new DataGridViewRow();
                row.CreateCells(employeeDataGridView);
                row.Cells[0].Value = employee.ID;
                row.Cells[1].Value = employee.Name;
                row.Cells[2].Value = employee.Age;
                employeeDataGridView.Rows.Add(row);
            }
        }
        public AquaPark LoadXML(string path)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            if (!File.Exists(path))
            {
                Console.WriteLine("Нет доступа к файлу");
                return null;
            }
            Console.WriteLine("Идет обработка данных");

            try
            {
                MemoryStream rawData = new MemoryStream(File.ReadAllBytes(path));
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(AquaPark));
                var xmlList = (AquaPark)xmlSerializer.Deserialize(rawData);
                return xmlList;
            }
            catch(Exception e)
            {
                Console.WriteLine("Не удалось обработать XML файл. Ошибка");
                MessageBox.Show(e.Message);
                return null;
            }
        }
        public Form1()
        {
            string path = @".\..\..\xmltext.xml";
            result = LoadXML(path);
            if (result == null)
            {
                Close();
                MessageBox.Show("Ошибка");
            }
            InitializeComponent();
            AddRowsToCommentsDataGreedView();
            AddRowsToClientsDataGreedView();
            AddRowsToEmployeesDataGreedView();
        }
    }
}
