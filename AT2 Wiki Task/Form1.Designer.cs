namespace AT2_Wiki_Task
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonLoad = new Button();
            buttonSave = new Button();
            buttonAdd = new Button();
            textBoxName = new TextBox();
            labelName = new Label();
            comboBoxCategory = new ComboBox();
            labelCategory = new Label();
            groupBoxStructure = new GroupBox();
            radioButtonNonLinear = new RadioButton();
            radioButtonLinear = new RadioButton();
            textBoxDefinition = new TextBox();
            labelDefinition = new Label();
            listViewNameCategory = new ListView();
            columnHeaderName = new ColumnHeader();
            columnHeaderCategory = new ColumnHeader();
            buttonDelete = new Button();
            buttonEdit = new Button();
            buttonSearch = new Button();
            textBoxInput = new TextBox();
            label1 = new Label();
            groupBoxStructure.SuspendLayout();
            SuspendLayout();
            // 
            // buttonLoad
            // 
            buttonLoad.Location = new Point(93, 12);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new Size(75, 23);
            buttonLoad.TabIndex = 1;
            buttonLoad.Text = "Load";
            buttonLoad.UseVisualStyleBackColor = true;
            buttonLoad.Click += buttonLoad_Click;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(12, 12);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 23);
            buttonSave.TabIndex = 2;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(12, 68);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(75, 23);
            buttonAdd.TabIndex = 3;
            buttonAdd.Text = "Add";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(12, 112);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(100, 23);
            textBoxName.TabIndex = 4;
            textBoxName.DoubleClick += textBoxName_DoubleClick;
            textBoxName.KeyPress += textBoxName_KeyPress;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(12, 94);
            labelName.Name = "labelName";
            labelName.Size = new Size(39, 15);
            labelName.TabIndex = 5;
            labelName.Text = "Name";
            // 
            // comboBoxCategory
            // 
            comboBoxCategory.FormattingEnabled = true;
            comboBoxCategory.Location = new Point(12, 156);
            comboBoxCategory.Name = "comboBoxCategory";
            comboBoxCategory.Size = new Size(121, 23);
            comboBoxCategory.TabIndex = 6;
            comboBoxCategory.KeyPress += comboBoxCategory_KeyPress;
            // 
            // labelCategory
            // 
            labelCategory.AutoSize = true;
            labelCategory.Location = new Point(12, 138);
            labelCategory.Name = "labelCategory";
            labelCategory.Size = new Size(55, 15);
            labelCategory.TabIndex = 7;
            labelCategory.Text = "Category";
            // 
            // groupBoxStructure
            // 
            groupBoxStructure.Controls.Add(radioButtonNonLinear);
            groupBoxStructure.Controls.Add(radioButtonLinear);
            groupBoxStructure.Location = new Point(12, 194);
            groupBoxStructure.Name = "groupBoxStructure";
            groupBoxStructure.Size = new Size(121, 78);
            groupBoxStructure.TabIndex = 8;
            groupBoxStructure.TabStop = false;
            groupBoxStructure.Text = "Structure";
            // 
            // radioButtonNonLinear
            // 
            radioButtonNonLinear.AutoSize = true;
            radioButtonNonLinear.Location = new Point(6, 22);
            radioButtonNonLinear.Name = "radioButtonNonLinear";
            radioButtonNonLinear.Size = new Size(85, 19);
            radioButtonNonLinear.TabIndex = 1;
            radioButtonNonLinear.TabStop = true;
            radioButtonNonLinear.Text = "Non-Linear";
            radioButtonNonLinear.UseVisualStyleBackColor = true;
            // 
            // radioButtonLinear
            // 
            radioButtonLinear.AutoSize = true;
            radioButtonLinear.Location = new Point(6, 47);
            radioButtonLinear.Name = "radioButtonLinear";
            radioButtonLinear.Size = new Size(57, 19);
            radioButtonLinear.TabIndex = 0;
            radioButtonLinear.TabStop = true;
            radioButtonLinear.Text = "Linear";
            radioButtonLinear.UseVisualStyleBackColor = true;
            // 
            // textBoxDefinition
            // 
            textBoxDefinition.Location = new Point(171, 69);
            textBoxDefinition.Multiline = true;
            textBoxDefinition.Name = "textBoxDefinition";
            textBoxDefinition.Size = new Size(149, 203);
            textBoxDefinition.TabIndex = 9;
            // 
            // labelDefinition
            // 
            labelDefinition.AutoSize = true;
            labelDefinition.Location = new Point(171, 51);
            labelDefinition.Name = "labelDefinition";
            labelDefinition.Size = new Size(59, 15);
            labelDefinition.TabIndex = 10;
            labelDefinition.Text = "Definition";
            // 
            // listViewNameCategory
            // 
            listViewNameCategory.Columns.AddRange(new ColumnHeader[] { columnHeaderName, columnHeaderCategory });
            listViewNameCategory.Location = new Point(339, 12);
            listViewNameCategory.Name = "listViewNameCategory";
            listViewNameCategory.Size = new Size(136, 260);
            listViewNameCategory.TabIndex = 35;
            listViewNameCategory.UseCompatibleStateImageBehavior = false;
            listViewNameCategory.View = View.Details;
            listViewNameCategory.SelectedIndexChanged += listViewNameCategory_SelectedIndexChanged;
            // 
            // columnHeaderName
            // 
            columnHeaderName.Text = "Name";
            // 
            // columnHeaderCategory
            // 
            columnHeaderCategory.Text = "Category";
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(12, 39);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(75, 23);
            buttonDelete.TabIndex = 36;
            buttonDelete.Text = "Delete";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // buttonEdit
            // 
            buttonEdit.Location = new Point(93, 41);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(75, 23);
            buttonEdit.TabIndex = 37;
            buttonEdit.Text = "Edit";
            buttonEdit.UseVisualStyleBackColor = true;
            buttonEdit.Click += buttonEdit_Click;
            // 
            // buttonSearch
            // 
            buttonSearch.Location = new Point(93, 70);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(75, 23);
            buttonSearch.TabIndex = 38;
            buttonSearch.Text = "Search";
            buttonSearch.UseVisualStyleBackColor = true;
            buttonSearch.Click += buttonSearch_Click;
            // 
            // textBoxInput
            // 
            textBoxInput.Location = new Point(174, 25);
            textBoxInput.Name = "textBoxInput";
            textBoxInput.Size = new Size(100, 23);
            textBoxInput.TabIndex = 39;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(174, 7);
            label1.Name = "label1";
            label1.Size = new Size(35, 15);
            label1.TabIndex = 40;
            label1.Text = "Input";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(516, 280);
            Controls.Add(label1);
            Controls.Add(textBoxInput);
            Controls.Add(buttonSearch);
            Controls.Add(buttonEdit);
            Controls.Add(buttonDelete);
            Controls.Add(listViewNameCategory);
            Controls.Add(labelDefinition);
            Controls.Add(textBoxDefinition);
            Controls.Add(groupBoxStructure);
            Controls.Add(labelCategory);
            Controls.Add(comboBoxCategory);
            Controls.Add(labelName);
            Controls.Add(textBoxName);
            Controls.Add(buttonAdd);
            Controls.Add(buttonSave);
            Controls.Add(buttonLoad);
            Name = "Form1";
            Text = "Wiki Application";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            groupBoxStructure.ResumeLayout(false);
            groupBoxStructure.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonLoad;
        private Button buttonSave;
        private Button buttonAdd;
        private TextBox textBoxName;
        private Label labelName;
        private ComboBox comboBoxCategory;
        private Label labelCategory;
        private GroupBox groupBoxStructure;
        private RadioButton radioButtonNonLinear;
        private RadioButton radioButtonLinear;
        private TextBox textBoxDefinition;
        private Label labelDefinition;
        private ListView listViewNameCategory;
        private ColumnHeader columnHeaderName;
        private ColumnHeader columnHeaderCategory;
        private Button buttonDelete;
        private Button buttonEdit;
        private Button buttonSearch;
        private TextBox textBoxInput;
        private Label label1;
    }
}