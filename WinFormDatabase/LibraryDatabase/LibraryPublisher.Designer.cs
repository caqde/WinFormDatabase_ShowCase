namespace WinForm_Database.LibraryDatabase
{
    partial class LibraryPublisher
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
            PublisherList = new ListBox();
            publisherListBindingSource = new BindingSource(components);
            libraryPublisherViewModelBindingSource = new BindingSource(components);
            label1 = new Label();
            textBox1 = new TextBox();
            PublisherName = new Label();
            label3 = new Label();
            label4 = new Label();
            richTextBox1 = new RichTextBox();
            GetPublisher = new Button();
            RemovePublisher = new Button();
            AddPublisher = new Button();
            UpdatePublisher = new Button();
            listBox1 = new ListBox();
            publisherBooksBindingSource = new BindingSource(components);
            statusStrip1 = new StatusStrip();
            PublisherStatus = new ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)publisherListBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)libraryPublisherViewModelBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)publisherBooksBindingSource).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // PublisherList
            // 
            PublisherList.DataSource = publisherListBindingSource;
            PublisherList.DisplayMember = "Name";
            PublisherList.FormattingEnabled = true;
            PublisherList.ItemHeight = 15;
            PublisherList.Location = new Point(12, 27);
            PublisherList.Name = "PublisherList";
            PublisherList.Size = new Size(204, 334);
            PublisherList.TabIndex = 0;
            PublisherList.ValueMember = "Id";
            PublisherList.SelectedIndexChanged += PublisherList_SelectedIndexChanged;
            // 
            // publisherListBindingSource
            // 
            publisherListBindingSource.DataMember = "PublisherList";
            publisherListBindingSource.DataSource = libraryPublisherViewModelBindingSource;
            // 
            // libraryPublisherViewModelBindingSource
            // 
            libraryPublisherViewModelBindingSource.DataSource = typeof(ShowCaseViewModel.Library.LibraryPublisherViewModel);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(71, 9);
            label1.Name = "label1";
            label1.Size = new Size(77, 15);
            label1.TabIndex = 1;
            label1.Text = "Publisher List";
            // 
            // textBox1
            // 
            textBox1.DataBindings.Add(new Binding("Text", libraryPublisherViewModelBindingSource, "PublisherName", true));
            textBox1.Location = new Point(312, 27);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(238, 23);
            textBox1.TabIndex = 2;
            // 
            // PublisherName
            // 
            PublisherName.AutoSize = true;
            PublisherName.Location = new Point(267, 30);
            PublisherName.Name = "PublisherName";
            PublisherName.Size = new Size(39, 15);
            PublisherName.TabIndex = 5;
            PublisherName.Text = "Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(239, 59);
            label3.Name = "label3";
            label3.Size = new Size(67, 15);
            label3.TabIndex = 6;
            label3.Text = "Description";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(632, 9);
            label4.Name = "label4";
            label4.Size = new Size(91, 15);
            label4.TabIndex = 7;
            label4.Text = "Publisher Books";
            // 
            // richTextBox1
            // 
            richTextBox1.DataBindings.Add(new Binding("Text", libraryPublisherViewModelBindingSource, "PublisherDescription", true));
            richTextBox1.Location = new Point(312, 56);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(238, 183);
            richTextBox1.TabIndex = 8;
            richTextBox1.Text = "";
            // 
            // GetPublisher
            // 
            GetPublisher.DataBindings.Add(new Binding("Command", libraryPublisherViewModelBindingSource, "getPublisherCommand", true));
            GetPublisher.Location = new Point(12, 367);
            GetPublisher.Name = "GetPublisher";
            GetPublisher.Size = new Size(75, 23);
            GetPublisher.TabIndex = 9;
            GetPublisher.Text = "Get";
            GetPublisher.UseVisualStyleBackColor = true;
            // 
            // RemovePublisher
            // 
            RemovePublisher.DataBindings.Add(new Binding("Command", libraryPublisherViewModelBindingSource, "removePublisherCommand", true));
            RemovePublisher.Location = new Point(141, 367);
            RemovePublisher.Name = "RemovePublisher";
            RemovePublisher.Size = new Size(75, 23);
            RemovePublisher.TabIndex = 10;
            RemovePublisher.Text = "Remove";
            RemovePublisher.UseVisualStyleBackColor = true;
            // 
            // AddPublisher
            // 
            AddPublisher.DataBindings.Add(new Binding("Command", libraryPublisherViewModelBindingSource, "addPublisherCommand", true));
            AddPublisher.Location = new Point(312, 338);
            AddPublisher.Name = "AddPublisher";
            AddPublisher.Size = new Size(75, 23);
            AddPublisher.TabIndex = 11;
            AddPublisher.Text = "Add";
            AddPublisher.UseVisualStyleBackColor = true;
            // 
            // UpdatePublisher
            // 
            UpdatePublisher.DataBindings.Add(new Binding("Command", libraryPublisherViewModelBindingSource, "updatePublisherCommand", true));
            UpdatePublisher.Location = new Point(393, 338);
            UpdatePublisher.Name = "UpdatePublisher";
            UpdatePublisher.Size = new Size(75, 23);
            UpdatePublisher.TabIndex = 12;
            UpdatePublisher.Text = "Update";
            UpdatePublisher.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            listBox1.DataSource = publisherBooksBindingSource;
            listBox1.DisplayMember = "Title";
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(556, 27);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(232, 334);
            listBox1.TabIndex = 13;
            listBox1.ValueMember = "Id";
            // 
            // publisherBooksBindingSource
            // 
            publisherBooksBindingSource.DataMember = "PublisherBooks";
            publisherBooksBindingSource.DataSource = libraryPublisherViewModelBindingSource;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { PublisherStatus });
            statusStrip1.Location = new Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 22);
            statusStrip1.TabIndex = 14;
            statusStrip1.Text = "statusStrip1";
            // 
            // PublisherStatus
            // 
            PublisherStatus.Name = "PublisherStatus";
            PublisherStatus.Size = new Size(0, 17);
            // 
            // LibraryPublisher
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(statusStrip1);
            Controls.Add(listBox1);
            Controls.Add(UpdatePublisher);
            Controls.Add(AddPublisher);
            Controls.Add(RemovePublisher);
            Controls.Add(GetPublisher);
            Controls.Add(richTextBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(PublisherName);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(PublisherList);
            Name = "LibraryPublisher";
            Text = "LibraryPublisher";
            ((System.ComponentModel.ISupportInitialize)publisherListBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)libraryPublisherViewModelBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)publisherBooksBindingSource).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox PublisherList;
        private Label label1;
        private TextBox textBox1;
        private Label PublisherName;
        private Label label3;
        private Label label4;
        private RichTextBox richTextBox1;
        private Button GetPublisher;
        private Button RemovePublisher;
        private Button AddPublisher;
        private Button UpdatePublisher;
        private BindingSource libraryPublisherViewModelBindingSource;
        private BindingSource publisherListBindingSource;
        private ListBox listBox1;
        private BindingSource publisherBooksBindingSource;
        private StatusStrip statusStrip1;
        public ToolStripStatusLabel PublisherStatus;
    }
}