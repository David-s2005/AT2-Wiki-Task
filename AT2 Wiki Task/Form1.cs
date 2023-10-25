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
                if (categoryValid() == true) 
                {
                    comboBoxCategory.Items.Add(comboBoxCategory.Text);
                }

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
        // simple event that returns true in the name textbox is changed.
        private bool textBoxName_TextChanged()
        {
            return true;
        }
        // Search button event that will search for a item in the global list using the input as a field. It will the findIndexByName method
        // to return a index. If the item is found a message will be shown displaying the location of the item via its index in the global
        // list, otherwise a message will show saying the item wasnt found.
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
        // Loading the form will call the loadData and populateForm methods.
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            Wiki.Clear();

            loadData();
            populateForm();
            populateComboBox();
        }
        // double clicking the name textbox will result in the resetForm method being called. this will clear the input fields.
        private void textBoxName_DoubleClick(object sender, EventArgs e)
        {
            resetForm();
        }

        #endregion

        #region methods
        // addItem method that will create a new Information object and append it to the global list. Before doing this the method
        // will make sure the name is valid by checking if there are any duplicate names already in the Information objects. The item
        // is then added and sorted.
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
        // populateForm method that populate the listView with all the items in the global list. The listview and combobox are cleared
        // before the global list is sorted and each item being appended to the listview. It will also check is the category already exists
        // in the combobox, if so the category will not be added to the combobox, otherwise it will.
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
        // ValidName method will check if the input given already exists within the global list. It does this via using the .Exists
        // method which will check if any of the objects inside of the global list already has the name given. If There is a duplicate
        // name then the method will return false, otherwise it will return true. This method will also check if the input is null.
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
        // categoryValid method return a boolean depending on if the input category already exists in the combobox, it will iterate through
        // each item in the combobox until it finds a duplicate or otherwise.
        public bool categoryValid()
        {
            foreach (string category in comboBoxCategory.Items)
            {
                string iterationItem = category.ToString();

                if (iterationItem.Equals(category))
                {
                    return false;
                }
            }
            return true;
        }
        // simple linearSelected method that will return the selected radiobutton as a string (e.g. if linear is selected then "Linear" is returned.)
        public string linearSelected()
        {
            if (radioButtonLinear.Checked == true)
            {
                return "Linear";
            }
            return "Non-Linear";
        }
        // This method will check a radio button using its index within the groupbox.
        public void checkRadioButtonWithIndex(int index)
        {
            RadioButton selectedRadioButton = (RadioButton)groupBoxStructure.Controls[index];
            selectedRadioButton.Checked = true;
        }
        // findIndexByName method that will return the index is the passed value in the global list using the BinarySearch method after it
        // is sorted and a new placeholder object is created to allow a comparison to occur.
        public int findIndexByName(string name)
        {
            Information searchInformation = new Information(name, "placeholder", "placeholder", "placeholder");
            Wiki.Sort();
            return Wiki.BinarySearch(searchInformation);
        }
        // resetForm method that simply clears all the the input fields.
        public void resetForm()
        {
            textBoxName.Text = "";
            textBoxInput.Text = "";
            textBoxDefinition.Text = "";
            comboBoxCategory.Text = "";
            radioButtonLinear.Checked = false;
            radioButtonNonLinear.Checked = false;
        }
        // saveData method that will use fileStream and BinaryWriter to write all the objects inside of the global list into a .dat file.
        // a dialog box is used to allow the user to save the .dat file to a custom spot with a custom name.
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
        // loadData method that will read from a .dat file and append all the information into new Information that are created every iteration.
        // The user can select a custom .dat they wish to load from a dialog box.
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
        // populateComboBox that reads from a text file in the programs working directory that contains all the categorys from the matrix.
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