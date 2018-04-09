using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VRVSS_PCS_WebMVC.ServiceReference1;

namespace VRVSS_PCS_WebMVC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client client = new
                ServiceReference1.Service1Client();
           // string returnString;

            //returnString = client.GetData(textBox1.Text);
            InspectionBO inspectionInput = new InspectionBO();
            List<InspectionBO> inspectionList = client.GetInspectionData(inspectionInput);
            label1.Text = inspectionList[1].lname;
        }
    }
}
