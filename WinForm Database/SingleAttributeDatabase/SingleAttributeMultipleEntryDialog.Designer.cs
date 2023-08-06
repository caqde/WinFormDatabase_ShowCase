namespace WinForm_Database
{
    partial class SingleAttributeMultipleEntryDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            SaveButton = new Button();
            mainAddMultipleViewModelBindingSource = new BindingSource(components);
            SaveCloseButton = new Button();
            button3 = new Button();
            dataGridView1 = new DataGridView();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            newItemsBindingSource = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)mainAddMultipleViewModelBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)newItemsBindingSource).BeginInit();
            SuspendLayout();
            // 
            // SaveButton
            // 
            SaveButton.DataBindings.Add(new Binding("Command", mainAddMultipleViewModelBindingSource, "MultiSaveCommand", true));
            SaveButton.Location = new Point(508, 367);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(75, 23);
            SaveButton.TabIndex = 1;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = true;
            // 
            // mainAddMultipleViewModelBindingSource
            // 
            mainAddMultipleViewModelBindingSource.DataSource = typeof(ShowCaseViewModel.SingleAttributeDatabaseMultipleViewModel);
            // 
            // SaveCloseButton
            // 
            SaveCloseButton.DataBindings.Add(new Binding("Command", mainAddMultipleViewModelBindingSource, "MultiSaveCloseCommand", true));
            SaveCloseButton.Location = new Point(589, 367);
            SaveCloseButton.Name = "SaveCloseButton";
            SaveCloseButton.Size = new Size(105, 23);
            SaveCloseButton.TabIndex = 2;
            SaveCloseButton.Text = "Save and Close";
            SaveCloseButton.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.DataBindings.Add(new Binding("Command", mainAddMultipleViewModelBindingSource, "CancelCommand", true));
            button3.Location = new Point(700, 367);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 3;
            button3.Text = "Cancel";
            button3.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowDrop = true;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { nameDataGridViewTextBoxColumn });
            dataGridView1.DataBindings.Add(new Binding("DataContext", newItemsBindingSource, "Name", true));
            dataGridView1.DataSource = newItemsBindingSource;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(776, 349);
            dataGridView1.TabIndex = 4;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            nameDataGridViewTextBoxColumn.HeaderText = "Name";
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // newItemsBindingSource
            // 
            newItemsBindingSource.DataMember = "NewItems";
            newItemsBindingSource.DataSource = mainAddMultipleViewModelBindingSource;
            // 
            // MainAddMultipleDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Controls.Add(button3);
            Controls.Add(SaveCloseButton);
            Controls.Add(SaveButton);
            Name = "MainAddMultipleDialog";
            Text = "Add Multiple Items";
            ((System.ComponentModel.ISupportInitialize)mainAddMultipleViewModelBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)newItemsBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button SaveButton;
        private Button SaveCloseButton;
        private Button button3;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private BindingSource newItemsBindingSource;
        private BindingSource mainAddMultipleViewModelBindingSource;
    }
}