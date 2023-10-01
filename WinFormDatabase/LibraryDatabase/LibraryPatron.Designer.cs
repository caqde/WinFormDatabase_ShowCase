namespace WinForm_Database.LibraryDatabase
{
    partial class LibraryPatron
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
            PatronList = new ListBox();
            patronListBindingSource = new BindingSource(components);
            libraryPatronViewModelBindingSource = new BindingSource(components);
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            PatronName = new TextBox();
            PatronAddress = new TextBox();
            PatronCity = new TextBox();
            label5 = new Label();
            label6 = new Label();
            PatronPostalCode = new TextBox();
            PatronPhoneNumber = new TextBox();
            BorrowedBookList = new ListBox();
            patronBorrowedBooksBindingSource = new BindingSource(components);
            label7 = new Label();
            GetPatron = new Button();
            RemovePatron = new Button();
            AddPatron = new Button();
            UpdatePatron = new Button();
            ((System.ComponentModel.ISupportInitialize)patronListBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)libraryPatronViewModelBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)patronBorrowedBooksBindingSource).BeginInit();
            SuspendLayout();
            // 
            // PatronList
            // 
            PatronList.DataSource = patronListBindingSource;
            PatronList.DisplayMember = "Name";
            PatronList.FormattingEnabled = true;
            PatronList.ItemHeight = 15;
            PatronList.Location = new Point(12, 29);
            PatronList.Name = "PatronList";
            PatronList.Size = new Size(206, 334);
            PatronList.TabIndex = 0;
            PatronList.ValueMember = "Id";
            PatronList.SelectedIndexChanged += PatronList_SelectedIndexChanged;
            // 
            // patronListBindingSource
            // 
            patronListBindingSource.DataMember = "PatronList";
            patronListBindingSource.DataSource = libraryPatronViewModelBindingSource;
            // 
            // libraryPatronViewModelBindingSource
            // 
            libraryPatronViewModelBindingSource.DataSource = typeof(ShowCaseViewModel.Library.LibraryPatronViewModel);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(81, 11);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 1;
            label1.Text = "Patron List";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(250, 32);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 2;
            label2.Text = "Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(250, 61);
            label3.Name = "label3";
            label3.Size = new Size(49, 15);
            label3.TabIndex = 3;
            label3.Text = "Address";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(250, 90);
            label4.Name = "label4";
            label4.Size = new Size(28, 15);
            label4.TabIndex = 4;
            label4.Text = "City";
            // 
            // PatronName
            // 
            PatronName.DataBindings.Add(new Binding("Text", libraryPatronViewModelBindingSource, "PatronName", true));
            PatronName.Location = new Point(344, 29);
            PatronName.Name = "PatronName";
            PatronName.Size = new Size(177, 23);
            PatronName.TabIndex = 5;
            // 
            // PatronAddress
            // 
            PatronAddress.DataBindings.Add(new Binding("Text", libraryPatronViewModelBindingSource, "PatronAddress", true));
            PatronAddress.Location = new Point(344, 58);
            PatronAddress.Name = "PatronAddress";
            PatronAddress.Size = new Size(177, 23);
            PatronAddress.TabIndex = 6;
            // 
            // PatronCity
            // 
            PatronCity.DataBindings.Add(new Binding("Text", libraryPatronViewModelBindingSource, "PatronCity", true));
            PatronCity.Location = new Point(344, 87);
            PatronCity.Name = "PatronCity";
            PatronCity.Size = new Size(177, 23);
            PatronCity.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(250, 119);
            label5.Name = "label5";
            label5.Size = new Size(70, 15);
            label5.TabIndex = 8;
            label5.Text = "Postal Code";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(250, 148);
            label6.Name = "label6";
            label6.Size = new Size(88, 15);
            label6.TabIndex = 9;
            label6.Text = "Phone Number";
            // 
            // PatronPostalCode
            // 
            PatronPostalCode.DataBindings.Add(new Binding("Text", libraryPatronViewModelBindingSource, "PatronPostalCode", true));
            PatronPostalCode.Location = new Point(344, 116);
            PatronPostalCode.Name = "PatronPostalCode";
            PatronPostalCode.Size = new Size(177, 23);
            PatronPostalCode.TabIndex = 10;
            // 
            // PatronPhoneNumber
            // 
            PatronPhoneNumber.DataBindings.Add(new Binding("Text", libraryPatronViewModelBindingSource, "PatronPhoneNumber", true));
            PatronPhoneNumber.Location = new Point(344, 145);
            PatronPhoneNumber.Name = "PatronPhoneNumber";
            PatronPhoneNumber.Size = new Size(177, 23);
            PatronPhoneNumber.TabIndex = 11;
            // 
            // BorrowedBookList
            // 
            BorrowedBookList.DataSource = patronBorrowedBooksBindingSource;
            BorrowedBookList.DisplayMember = "BorrowedBook";
            BorrowedBookList.FormattingEnabled = true;
            BorrowedBookList.ItemHeight = 15;
            BorrowedBookList.Location = new Point(601, 29);
            BorrowedBookList.Name = "BorrowedBookList";
            BorrowedBookList.Size = new Size(187, 334);
            BorrowedBookList.TabIndex = 12;
            BorrowedBookList.ValueMember = "Id";
            // 
            // patronBorrowedBooksBindingSource
            // 
            patronBorrowedBooksBindingSource.DataMember = "PatronBorrowedBooks";
            patronBorrowedBooksBindingSource.DataSource = libraryPatronViewModelBindingSource;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(651, 11);
            label7.Name = "label7";
            label7.Size = new Size(93, 15);
            label7.TabIndex = 13;
            label7.Text = "Books Borrowed";
            // 
            // GetPatron
            // 
            GetPatron.DataBindings.Add(new Binding("Command", libraryPatronViewModelBindingSource, "getPatronCommand", true));
            GetPatron.Location = new Point(12, 369);
            GetPatron.Name = "GetPatron";
            GetPatron.Size = new Size(75, 23);
            GetPatron.TabIndex = 14;
            GetPatron.Text = "Get";
            GetPatron.UseVisualStyleBackColor = true;
            // 
            // RemovePatron
            // 
            RemovePatron.DataBindings.Add(new Binding("Command", libraryPatronViewModelBindingSource, "removePatronCommand", true));
            RemovePatron.Location = new Point(143, 369);
            RemovePatron.Name = "RemovePatron";
            RemovePatron.Size = new Size(75, 23);
            RemovePatron.TabIndex = 15;
            RemovePatron.Text = "Remove";
            RemovePatron.UseVisualStyleBackColor = true;
            // 
            // AddPatron
            // 
            AddPatron.DataBindings.Add(new Binding("Command", libraryPatronViewModelBindingSource, "addPatronCommand", true));
            AddPatron.Location = new Point(365, 340);
            AddPatron.Name = "AddPatron";
            AddPatron.Size = new Size(75, 23);
            AddPatron.TabIndex = 16;
            AddPatron.Text = "Add";
            AddPatron.UseVisualStyleBackColor = true;
            // 
            // UpdatePatron
            // 
            UpdatePatron.DataBindings.Add(new Binding("Command", libraryPatronViewModelBindingSource, "updatePatronCommand", true));
            UpdatePatron.Location = new Point(446, 340);
            UpdatePatron.Name = "UpdatePatron";
            UpdatePatron.Size = new Size(75, 23);
            UpdatePatron.TabIndex = 17;
            UpdatePatron.Text = "Update";
            UpdatePatron.UseVisualStyleBackColor = true;
            // 
            // LibraryPatron
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(UpdatePatron);
            Controls.Add(AddPatron);
            Controls.Add(RemovePatron);
            Controls.Add(GetPatron);
            Controls.Add(label7);
            Controls.Add(BorrowedBookList);
            Controls.Add(PatronPhoneNumber);
            Controls.Add(PatronPostalCode);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(PatronCity);
            Controls.Add(PatronAddress);
            Controls.Add(PatronName);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(PatronList);
            Name = "LibraryPatron";
            Text = "LibraryPatron";
            ((System.ComponentModel.ISupportInitialize)patronListBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)libraryPatronViewModelBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)patronBorrowedBooksBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox PatronList;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox PatronName;
        private TextBox PatronAddress;
        private TextBox PatronCity;
        private Label label5;
        private Label label6;
        private TextBox PatronPostalCode;
        private TextBox PatronPhoneNumber;
        private BindingSource patronListBindingSource;
        private BindingSource libraryPatronViewModelBindingSource;
        private ListBox BorrowedBookList;
        private BindingSource patronBorrowedBooksBindingSource;
        private Label label7;
        private Button GetPatron;
        private Button RemovePatron;
        private Button AddPatron;
        private Button UpdatePatron;
    }
}