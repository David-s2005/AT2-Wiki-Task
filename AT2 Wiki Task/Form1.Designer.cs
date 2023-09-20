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
            textBox1 = new TextBox();
            labelName = new Label();
            comboBoxCategory = new ComboBox();
            labelCategory = new Label();
            groupBoxStructure = new GroupBox();
            radioButtonLinear = new RadioButton();
            radioButtonNonLinear = new RadioButton();
            textBox2 = new TextBox();
            labelDefinition = new Label();
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
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(12, 12);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 23);
            buttonSave.TabIndex = 2;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
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
            // textBox1
            // 
            textBox1.Location = new Point(12, 112);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 4;
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
            // radioButtonLinear
            // 
            radioButtonLinear.AutoSize = true;
            radioButtonLinear.Location = new Point(6, 22);
            radioButtonLinear.Name = "radioButtonLinear";
            radioButtonLinear.Size = new Size(57, 19);
            radioButtonLinear.TabIndex = 0;
            radioButtonLinear.TabStop = true;
            radioButtonLinear.Text = "Linear";
            radioButtonLinear.UseVisualStyleBackColor = true;
            // 
            // radioButtonNonLinear
            // 
            radioButtonNonLinear.AutoSize = true;
            radioButtonNonLinear.Location = new Point(6, 47);
            radioButtonNonLinear.Name = "radioButtonNonLinear";
            radioButtonNonLinear.Size = new Size(85, 19);
            radioButtonNonLinear.TabIndex = 1;
            radioButtonNonLinear.TabStop = true;
            radioButtonNonLinear.Text = "Non-Linear";
            radioButtonNonLinear.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(171, 69);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(149, 203);
            textBox2.TabIndex = 9;
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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(629, 280);
            Controls.Add(labelDefinition);
            Controls.Add(textBox2);
            Controls.Add(groupBoxStructure);
            Controls.Add(labelCategory);
            Controls.Add(comboBoxCategory);
            Controls.Add(labelName);
            Controls.Add(textBox1);
            Controls.Add(buttonAdd);
            Controls.Add(buttonSave);
            Controls.Add(buttonLoad);
            Name = "Form1";
            Text = "x";
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
        private TextBox textBox1;
        private Label labelName;
        private ComboBox comboBoxCategory;
        private Label labelCategory;
        private GroupBox groupBoxStructure;
        private RadioButton radioButtonNonLinear;
        private RadioButton radioButtonLinear;
        private TextBox textBox2;
        private Label labelDefinition;
    }
}