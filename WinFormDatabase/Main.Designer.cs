namespace WinForm_Database
{
    partial class Main
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
            menuPanel = new Panel();
            LibraryDatabaseButton = new Button();
            mainViewModelBindingSource = new BindingSource(components);
            SingleDatabaseButton = new Button();
            formPanel = new Panel();
            menuPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)mainViewModelBindingSource).BeginInit();
            SuspendLayout();
            // 
            // menuPanel
            // 
            menuPanel.BackColor = SystemColors.ControlDark;
            menuPanel.Controls.Add(LibraryDatabaseButton);
            menuPanel.Controls.Add(SingleDatabaseButton);
            menuPanel.Dock = DockStyle.Left;
            menuPanel.Location = new Point(0, 0);
            menuPanel.Name = "menuPanel";
            menuPanel.Size = new Size(200, 531);
            menuPanel.TabIndex = 0;
            // 
            // LibraryDatabaseButton
            // 
            LibraryDatabaseButton.DataBindings.Add(new Binding("Command", mainViewModelBindingSource, "LoadLibraryViewCommand", true));
            LibraryDatabaseButton.Location = new Point(3, 86);
            LibraryDatabaseButton.Name = "LibraryDatabaseButton";
            LibraryDatabaseButton.RightToLeft = RightToLeft.No;
            LibraryDatabaseButton.Size = new Size(194, 68);
            LibraryDatabaseButton.TabIndex = 0;
            LibraryDatabaseButton.Text = "Library Demo";
            LibraryDatabaseButton.UseVisualStyleBackColor = true;
            // 
            // mainViewModelBindingSource
            // 
            mainViewModelBindingSource.DataSource = typeof(ShowCaseViewModel.MainViewModel);
            // 
            // SingleDatabaseButton
            // 
            SingleDatabaseButton.DataBindings.Add(new Binding("Command", mainViewModelBindingSource, "LoadMainViewCommand", true));
            SingleDatabaseButton.Location = new Point(3, 12);
            SingleDatabaseButton.Name = "SingleDatabaseButton";
            SingleDatabaseButton.Size = new Size(194, 68);
            SingleDatabaseButton.TabIndex = 0;
            SingleDatabaseButton.Text = "Single Attribute Database Demo";
            SingleDatabaseButton.UseVisualStyleBackColor = true;
            // 
            // formPanel
            // 
            formPanel.AutoSize = true;
            formPanel.BackColor = SystemColors.Control;
            formPanel.BorderStyle = BorderStyle.Fixed3D;
            formPanel.Dock = DockStyle.Fill;
            formPanel.Location = new Point(200, 0);
            formPanel.Margin = new Padding(2);
            formPanel.Name = "formPanel";
            formPanel.Size = new Size(798, 531);
            formPanel.TabIndex = 1;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(998, 531);
            Controls.Add(formPanel);
            Controls.Add(menuPanel);
            Name = "Main";
            Text = "Main";
            menuPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)mainViewModelBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel menuPanel;
        private Button SingleDatabaseButton;
        private Panel formPanel;
        private BindingSource mainViewModelBindingSource;
        private Button LibraryDatabaseButton;
    }
}