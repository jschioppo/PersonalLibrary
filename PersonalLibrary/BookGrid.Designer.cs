namespace PersonalLibrary
{
    partial class BookGrid
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
            this.bookGridView = new System.Windows.Forms.DataGridView();
            this.isbnTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BookSearchBtn = new System.Windows.Forms.Button();
            this.deleteBookBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bookGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // bookGridView
            // 
            this.bookGridView.AllowUserToAddRows = false;
            this.bookGridView.AllowUserToDeleteRows = false;
            this.bookGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.bookGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.bookGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.bookGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bookGridView.Location = new System.Drawing.Point(16, 12);
            this.bookGridView.Name = "bookGridView";
            this.bookGridView.Size = new System.Drawing.Size(635, 441);
            this.bookGridView.TabIndex = 0;
            // 
            // isbnTextBox
            // 
            this.isbnTextBox.Location = new System.Drawing.Point(12, 487);
            this.isbnTextBox.Name = "isbnTextBox";
            this.isbnTextBox.Size = new System.Drawing.Size(235, 20);
            this.isbnTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 468);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "ISBN:";
            // 
            // BookSearchBtn
            // 
            this.BookSearchBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BookSearchBtn.Location = new System.Drawing.Point(271, 484);
            this.BookSearchBtn.Name = "BookSearchBtn";
            this.BookSearchBtn.Size = new System.Drawing.Size(75, 23);
            this.BookSearchBtn.TabIndex = 3;
            this.BookSearchBtn.Text = "Search";
            this.BookSearchBtn.UseVisualStyleBackColor = true;
            this.BookSearchBtn.Click += new System.EventHandler(this.BookSearchBtn_Click);
            // 
            // deleteBookBtn
            // 
            this.deleteBookBtn.Location = new System.Drawing.Point(378, 483);
            this.deleteBookBtn.Name = "deleteBookBtn";
            this.deleteBookBtn.Size = new System.Drawing.Size(75, 23);
            this.deleteBookBtn.TabIndex = 4;
            this.deleteBookBtn.Text = "Delete";
            this.deleteBookBtn.UseVisualStyleBackColor = true;
            this.deleteBookBtn.Click += new System.EventHandler(this.BookDeleteBtn_Click);
            // 
            // BookGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 519);
            this.Controls.Add(this.deleteBookBtn);
            this.Controls.Add(this.BookSearchBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.isbnTextBox);
            this.Controls.Add(this.bookGridView);
            this.Name = "BookGrid";
            this.ShowIcon = false;
            ((System.ComponentModel.ISupportInitialize)(this.bookGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView bookGridView;
        private System.Windows.Forms.TextBox isbnTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BookSearchBtn;
        private System.Windows.Forms.Button deleteBookBtn;
    }
}

