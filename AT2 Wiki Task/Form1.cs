using Microsoft.VisualBasic.Devices;
using System.Collections.Generic;
using System;
using System.IO;
using System.Drawing.Drawing2D;
using System.Security.Policy;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Microsoft.VisualBasic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics.Contracts;

namespace AT2_Wiki_Task
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // Global list with Information type that contains all Information objects.
        static public List<Information> Wiki = new List<Information>();

        #region event handlers
        // Button add event that will add a new Information object to the global list. It will check if either of the radio buttons are checked
        // addItem and populateForm methods are then called.
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
                addItem();
                populateForm();
            }
        }
        // form load event that handles what happens when the form is loaded. populateForm and populateComboBox methods are called.
        private void Form1_Load(object sender, EventArgs e)
        {
            populateForm();
            populateComboBox();
        }
        // comboBoxCategory_KeyPress event that will create a new information object to the global list if the enter key is pressed.
        private void comboBoxCategory_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Enter)
            {
                comboBoxCategory.Items.Add(comboBoxCategory.Text);
                addItem();
                populateForm();
            }
        }
        // textBoxName_KeyPress event that occurs when the enter key is pressed when the name textbox is selected. Pretty much the same
        // as the comboBoxCategory_KeyPress method.
        private void textBoxName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Enter)
            {
                comboBoxCategory.Items.Add(comboBoxCategory.Text);
                addItem();
                populateForm();
            }
        }
        // This method is responsible for populating the input field textboxes with the selected item from the listview.
        private void listViewNameCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewNameCategory.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listViewNameCategory.SelectedItems[0];
                string selectedItemName = selectedItem.Text;

                int itemIndex = findIndexByName(selectedItemName);

                textBoxName.Text = selectedItemName;
                textBoxDefinition.Text = Wiki[itemIndex].getDefinition;
                comboBoxCategory.Text = Wiki[itemIndex].getCategory;

                if (Wiki[itemIndex].getStructure == "Linear")
                {
                    radioButtonLinear.Checked = true;
                    radioButtonNonLinear.Checked = false;
                }
                else
                {
                    radioButtonNonLinear.Checked = true;
                    radioButtonLinear.Checked = false;
                }
            }
        }
        // the save button will call the saveData method when clicked.
        private void buttonSave_Click(object sender, EventArgs e)
        {
            saveData();
        }
        // The delete button event will remove the selected item from the global array using the selected listview items index
        // and will repopulate the form once completed. also has a dialog box to confirm the users choice.
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listViewNameCategory.SelectedItems.Count > 0)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to remove this entry?", "Delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    ListViewItem selectedItem = listViewNameCategory.SelectedItems[0];
                    string selectedItemName = selectedItem.Text;
                    int itemIndex = findIndexByName(selectedItemName);
                    Wiki.RemoveAt(itemIndex);

                    populateForm();
                }
            }
            else
            {
                MessageBox.Show("Please select a item you want to delete.");
            }
        }
        // Closing the form will result in the saveData method being called.
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            saveData();
        }
        // The edit button event will result in the selected item from the listview being used to find the selected item via its index,
        // and change the selected object in the global list using its index and the input fields. This method will also make sure the 
        // user doesnt add a second already existing category.
        private void buttonEdit_Click(object sender, EventArgs e)
        {

            if (listViewNameCategory.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listViewNameCategory.SelectedItems[0];
                string selectedItemName = selectedItem.Text;
                int selectedItemIndex = findIndexByName(selectedItemName);


                if (textBoxName_TextChanged() == true)
                {
                    Wiki[selectedItemIndex].Category = comboBoxCategory.Text;
                    Wiki[selectedItemIndex].Structure = linearSelected();
                    Wiki[selectedItemIndex].Definiton = textBoxDefinition.Text;

                    if (validName(textBoxName.Text) == true)
                    {
                        Wiki[selectedItemIndex].Name = textBoxName.Text;
                    }
                }
                populateForm();
            }
            else MessageBox.Show("Please select a item from the list.");
        }

        private bool textBoxName_TextChanged()
        {
            return true;
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            int index = findIndexByName(textBoxInput.Text);

            if (index >= 0)
            {
                MessageBox.Show($"{textBoxName.Text} was found at index: {index}");
                listViewNameCategory.Items[index].Selected = true;
                textBoxInput.Text = "";
            }
            else MessageBox.Show($"{textBoxName.Text} was not found");
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            loadData();
            populateForm();
        }

        private void textBoxName_DoubleClick(object sender, EventArgs e)
        {
            resetForm();
        }

        #endregion

        #region methods

        public void addItem()
        {
            bool nameOK = validName(textBoxName.Text);

            if (nameOK == true)
            {
                string name = textBoxName.Text;
                string category = comboBoxCategory.Text;
                string structure = linearSelected();
                string definition = textBoxDefinition.Text;

                Information info = new Information(name, category, structure, definition);
                Wiki.Add(info);
                Wiki.Sort();
            }
            else MessageBox.Show("The name cannot be a duplicate value.");
        }

        public void populateForm()
        {
            listViewNameCategory.Items.Clear();
            comboBoxCategory.Items.Clear();

            Wiki.Sort();

            foreach (Information info in Wiki)
            {
                ListViewItem listViewItem = new ListViewItem(info.Name);
                listViewNameCategory.Items.Add(listViewItem);
                listViewItem.SubItems.Add(info.Category);

                bool categoryOK = categoryValid();

                if (categoryOK == true)
                {
                    comboBoxCategory.Items.Add(info.Category);
                }
            }
        }

        public bool validName(string nameInput)
        {
            if (Wiki.Exists(name => name.Name == nameInput))
            {
                int itemIndex = findIndexByName(nameInput);

                listViewNameCategory.SelectedItems.Clear();
                listViewNameCategory.Items[itemIndex].Selected = true;
                listViewNameCategory.Focus();
                return false;
            }
            else if (nameInput == null)
            {
                MessageBox.Show("Name cannot be a null value");
                return false;
            }
            return true;
        }

        public bool categoryValid()
        {
            foreach (string category in comboBoxCategory.Items)
            {
                string iterationItem = category.ToString();

                if (iterationItem.Equals(comboBoxCategory.Text))
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

        public void checkRadioButtonWithIndex(int index)
        {
            RadioButton selectedRadioButton = (RadioButton)groupBoxStructure.Controls[index];
            selectedRadioButton.Checked = true;
        }

        public int findIndexByName(string name)
        {
            Information searchInformation = new Information(name, "placeholder", "placeholder", "placeholder");
            Wiki.Sort();
            return Wiki.BinarySearch(searchInformation);
        }

        public void resetForm()
        {
            textBoxName.Text = "";
            textBoxInput.Text = "";
            textBoxDefinition.Text = "";
            comboBoxCategory.Text = "";
            comboBoxCategory.Items.Clear();
            radioButtonLinear.Checked = false;
            radioButtonNonLinear.Checked = false;
        }

        public void saveData()
        {
            try
            {
                Wiki.Sort();
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "DAT Files (*.dat)|*.dat|All Files (*.*)|*.*";
                saveFileDialog.DefaultExt = "dat";
                saveFileDialog.FileName = "InformationWiki.dat";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                    using (BinaryWriter writer = new BinaryWriter(fileStream))
                    {
                        writer.Write(Wiki.Count);

                        foreach (Information info in Wiki)
                        {
                            writer.Write(info.Name);
                            writer.Write(info.Category);
                            writer.Write(info.Structure);
                            writer.Write(info.Definiton);
                        }
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Failed to write to file!");
            }
        }

        public void loadData()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "DAT Files (*.dat)|*.dat|All Files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                using (BinaryReader reader = new BinaryReader(fileStream))
                {
                    int linesNumber = reader.ReadInt32();

                    for (int i = 0; i < linesNumber; i++)
                    {
                        string name = reader.ReadString();
                        string category = reader.ReadString();
                        string structure = reader.ReadString();
                        string definition = reader.ReadString();

                        Information info = new Information(name, category, structure, definition);
                        Wiki.Add(info);
                    }
                }
            }
        }

        public void populateComboBox()
        {
            string filePath = "Categories.txt";

            try
            {
                if (File.Exists(filePath))
                {
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string category;

                        while ((category = reader.ReadLine()) != null)
                        {
                            comboBoxCategory.Items.Add(category);
                        }
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Failed to read file!");
            }
        }

        #endregion
    }
}