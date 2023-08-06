namespace WinForm_Database
{
    partial class SingleAttributeDatabase
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
            components = new System.ComponentModel.Container();
            txtName = new TextBox();
            MainDataSource = new BindingSource(components);
            lblName = new Label();
            btnPrevious = new Button();
            btnNext = new Button();
            btnSave = new Button();
            statusStrip1 = new StatusStrip();
            tbStatuslbl = new ToolStripStatusLabel();
            btnAdd = new Button();
            btnDelete = new Button();
            btnAddMany = new Button();
            ((System.ComponentModel.ISupportInitialize)MainDataSource).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.DataBindings.Add(new Binding("Text", MainDataSource, "DbName", true));
            txtName.Location = new Point(168, 55);
            txtName.Name = "txtName";
            txtName.Size = new Size(181, 23);
            txtName.TabIndex = 0;
            // 
            // MainDataSource
            // 
            MainDataSource.DataSource = typeof(ShowCaseViewModel.SingleAttributeDatabaseViewModel);
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(110, 58);
            lblName.Name = "lblName";
            lblName.Size = new Size(45, 15);
            lblName.TabIndex = 1;
            lblName.Text = "Name :";
            // 
            // btnPrevious
            // 
            btnPrevious.DataBindings.Add(new Binding("Command", MainDataSource, "PreviousCommand", true));
            btnPrevious.Location = new Point(110, 95);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(75, 23);
            btnPrevious.TabIndex = 2;
            btnPrevious.Text = "Previous";
            btnPrevious.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            btnNext.DataBindings.Add(new Binding("Command", MainDataSource, "NextCommand", true));
            btnNext.Location = new Point(193, 95);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(75, 23);
            btnNext.TabIndex = 3;
            btnNext.Text = "Next";
            btnNext.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.DataBindings.Add(new Binding("Command", MainDataSource, "SaveCommand", true));
            btnSave.Location = new Point(274, 95);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 4;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { tbStatuslbl });
            statusStrip1.Location = new Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 22);
            statusStrip1.TabIndex = 5;
            statusStrip1.Text = "statusStrip1";
            // 
            // tbStatuslbl
            // 
            tbStatuslbl.Name = "tbStatuslbl";
            tbStatuslbl.Size = new Size(39, 17);
            tbStatuslbl.Text = "Status";
            // 
            // btnAdd
            // 
            btnAdd.DataBindings.Add(new Binding("Command", MainDataSource, "AddCommand", true));
            btnAdd.Location = new Point(274, 153);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "Add New ";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.DataBindings.Add(new Binding("Command", MainDataSource, "DeleteCommand", true));
            btnDelete.Location = new Point(274, 124);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 7;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnAddMany
            // 
            btnAddMany.DataBindings.Add(new Binding("Command", MainDataSource, "AddMultiCommand", true));
            btnAddMany.Location = new Point(110, 153);
            btnAddMany.Name = "btnAddMany";
            btnAddMany.Size = new Size(158, 23);
            btnAddMany.TabIndex = 8;
            btnAddMany.Text = "Add Many New";
            btnAddMany.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnAddMany);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(statusStrip1);
            Controls.Add(btnSave);
            Controls.Add(btnNext);
            Controls.Add(btnPrevious);
            Controls.Add(lblName);
            Controls.Add(txtName);
            Name = "Main";
            Text = "Main";
            ((System.ComponentModel.ISupportInitialize)MainDataSource).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtName;
        private Label lblName;
        private Button btnPrevious;
        private BindingSource MainDataSource;
        private Button btnNext;
        private Button btnSave;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel tbStatuslbl;
        private Button btnAdd;
        private Button btnDelete;
        private Button btnAddMany;
    }
}