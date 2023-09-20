using Microsoft.VisualBasic.Devices;
using System.Collections.Generic;
using System;
using System.Drawing.Drawing2D;
using System.Security.Policy;
using System.Windows.Forms;
using System.Xml.Linq;
namespace AT2_Wiki_Task
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public List<Information> InformationList = new List<Information>();

        #region event handlers
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Information info = new Information("Array", "Linear", "Array", "An array data structure consists of a collection of elements(values or variables), each identified by at least one array index or key.An array is stored such that the position of each element can be computed from its index tuple by a mathematical formula.");
            InformationList.Add(info);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxCategory.Items.Add("Array");
            comboBoxCategory.Items.Add("List");
            comboBoxCategory.Items.Add("Tree");
            comboBoxCategory.Items.Add("Graphs");
            comboBoxCategory.Items.Add("Abstract");
            comboBoxCategory.Items.Add("Hash");
        }

        private void comboBoxCategory_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Enter)
            {
                comboBoxCategory.Items.Add(comboBoxCategory.Text);
            }

            // append the new object into list after.
        }

        #endregion

        #region methods

        public void addItem()
        {
            // String name = 
        }

        public bool validName() 
        {
            foreach (Information info in InformationList)
            {
                if (InformationList.Exists(info => info.getName == Name))
                {

                }
            }
        }

        #endregion

    }
}