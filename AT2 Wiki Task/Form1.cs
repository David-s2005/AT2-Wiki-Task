using Microsoft.VisualBasic.Devices;
using System.Collections.Generic;
using System;
using System.Drawing.Drawing2D;
using System.Security.Policy;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Microsoft.VisualBasic;

namespace AT2_Wiki_Task
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static public List<Information> InformationList = new List<Information>();

        #region event handlers
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (radioButtonLinear.Checked == false && radioButtonNonLinear.Checked == false)
            {
                MessageBox.Show("Please select a structure");
            }
            else if (textBoxDefinition.Text == null)
            {
                MessageBox.Show("Please provide a defintion");
            }
            else
            {
                populateForm();
                addItem();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Information info = new Information("Array", "Array", "Linear", "");
        }

        private void comboBoxCategory_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Enter)
            {
                comboBoxCategory.Items.Add(comboBoxCategory.Text);
                addItem();
                populateForm();
            }
        }
        private void textBoxName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Enter)
            {
                comboBoxCategory.Items.Add(comboBoxCategory.Text);
                addItem();
                populateForm();
            }
        }

        #endregion

        #region methods

        public void addItem()
        {
            bool nameOK = nameValid();

            if (nameOK == true)
            {
                string name = textBoxName.Text;
                string category = comboBoxCategory.Text;
                string structure = linearSelected();
                string definition = textBoxDefinition.Text;

                Information info = new Information(name, category, structure, definition);
                InformationList.Add(info);
            }
        }

        public void populateForm()
        {
            listViewNameCategory.Items.Clear();
            comboBoxCategory.Items.Clear();

            bool categoryOK = categoryValid();

            foreach (Information info in InformationList)
            {
                ListViewItem listViewItem = new ListViewItem(info.Name);
                listViewNameCategory.Items.Add(listViewItem); 
                listViewItem.SubItems.Add(info.Category);

                if (categoryOK == true)
                {
                    comboBoxCategory.Items.Add(info.Category);
                }
            }
        }

        public bool nameValid()
        {
            if (textBoxName.Text != "~")
            {
                foreach (Information info in InformationList)
                {
                    if (info.Name == textBoxName.Text)
                    {
                        MessageBox.Show("Item already exists in list.");
                        return false;
                    }
                    else if (info.Name == null)
                    {
                        MessageBox.Show("Name cannot be a null value");
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        public bool categoryValid() 
        {
            string category = comboBoxCategory.Text;

                foreach (Information info in InformationList) 
                {
                    if (info.Category == category)
                    {
                        return false;
                    }
                }
            return true;
        }

        public string linearSelected()
        {
            if (radioButtonLinear.Checked == true)
            {
                return "Linear";
            }
            return "Non-Linear";
        }

        public int findIndexByName(string name) 
        {
            Information searchInformation = new Information(name, "placeholder", "placeholder", "placeholder");
            InformationList.Sort();
            return InformationList.BinarySearch(searchInformation);
        }

        #endregion
    }
}