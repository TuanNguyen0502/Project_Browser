namespace Project_Browser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            flowLayoutPanel1 = new FlowLayoutPanel();
            button_NewWin = new Button();
            button_NewTab = new Button();
            button_History = new Button();
            flowLayoutPanel5 = new FlowLayoutPanel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            button_Tab_0 = new Button();
            flowLayoutPanel3 = new FlowLayoutPanel();
            button_BackPage = new Button();
            button_NextPage = new Button();
            textBox_URL = new TextBox();
            button_Bookmark = new Button();
            textBox_Search = new TextBox();
            button_Search = new Button();
            flowLayoutPanel4 = new FlowLayoutPanel();
            textBox_CurrentTab = new TextBox();
            pictureBox1 = new PictureBox();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(button_NewWin);
            flowLayoutPanel1.Controls.Add(button_NewTab);
            flowLayoutPanel1.Controls.Add(button_History);
            flowLayoutPanel1.Dock = DockStyle.Top;
            flowLayoutPanel1.ForeColor = Color.LightPink;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(978, 60);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // button_NewWin
            // 
            button_NewWin.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            button_NewWin.ForeColor = Color.Red;
            button_NewWin.Location = new Point(3, 3);
            button_NewWin.Name = "button_NewWin";
            button_NewWin.Size = new Size(161, 51);
            button_NewWin.TabIndex = 3;
            button_NewWin.Text = "New Window";
            button_NewWin.UseVisualStyleBackColor = true;
            button_NewWin.Click += button_NewWin_Click;
            // 
            // button_NewTab
            // 
            button_NewTab.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            button_NewTab.ForeColor = Color.Red;
            button_NewTab.Location = new Point(170, 3);
            button_NewTab.Name = "button_NewTab";
            button_NewTab.Size = new Size(112, 51);
            button_NewTab.TabIndex = 4;
            button_NewTab.Text = "New Tab";
            button_NewTab.UseVisualStyleBackColor = true;
            button_NewTab.Click += button_NewTab_Click;
            // 
            // button_History
            // 
            button_History.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            button_History.ForeColor = Color.Red;
            button_History.Location = new Point(288, 3);
            button_History.Name = "button_History";
            button_History.Size = new Size(140, 51);
            button_History.TabIndex = 7;
            button_History.Text = "History";
            button_History.UseVisualStyleBackColor = true;
            button_History.Click += button_History_Click;
            // 
            // flowLayoutPanel5
            // 
            flowLayoutPanel5.AutoScroll = true;
            flowLayoutPanel5.AutoSize = true;
            flowLayoutPanel5.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel5.FlowDirection = FlowDirection.BottomUp;
            flowLayoutPanel5.Location = new Point(595, 65);
            flowLayoutPanel5.MaximumSize = new Size(380, 580);
            flowLayoutPanel5.MinimumSize = new Size(380, 580);
            flowLayoutPanel5.Name = "flowLayoutPanel5";
            flowLayoutPanel5.Size = new Size(380, 580);
            flowLayoutPanel5.TabIndex = 10;
            flowLayoutPanel5.Visible = false;
            flowLayoutPanel5.WrapContents = false;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.AutoScroll = true;
            flowLayoutPanel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel2.Controls.Add(button_Tab_0);
            flowLayoutPanel2.Dock = DockStyle.Top;
            flowLayoutPanel2.ForeColor = Color.LightPink;
            flowLayoutPanel2.Location = new Point(0, 60);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(978, 57);
            flowLayoutPanel2.TabIndex = 1;
            // 
            // button_Tab_0
            // 
            button_Tab_0.ForeColor = Color.Black;
            button_Tab_0.Location = new Point(3, 3);
            button_Tab_0.Name = "button_Tab_0";
            button_Tab_0.Size = new Size(112, 51);
            button_Tab_0.TabIndex = 3;
            button_Tab_0.Text = "0";
            button_Tab_0.UseVisualStyleBackColor = true;
            button_Tab_0.MouseUp += Button_Click;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.Controls.Add(button_BackPage);
            flowLayoutPanel3.Controls.Add(button_NextPage);
            flowLayoutPanel3.Controls.Add(textBox_URL);
            flowLayoutPanel3.Controls.Add(button_Bookmark);
            flowLayoutPanel3.Dock = DockStyle.Top;
            flowLayoutPanel3.ForeColor = Color.LightPink;
            flowLayoutPanel3.Location = new Point(0, 117);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(978, 63);
            flowLayoutPanel3.TabIndex = 2;
            // 
            // button_BackPage
            // 
            button_BackPage.BackColor = Color.LightSkyBlue;
            button_BackPage.Enabled = false;
            button_BackPage.FlatStyle = FlatStyle.Flat;
            button_BackPage.ForeColor = Color.LightSkyBlue;
            button_BackPage.Image = Properties.Resources.icons8_back_arrow_64;
            button_BackPage.Location = new Point(3, 3);
            button_BackPage.Name = "button_BackPage";
            button_BackPage.Size = new Size(66, 59);
            button_BackPage.TabIndex = 3;
            button_BackPage.UseVisualStyleBackColor = false;
            button_BackPage.Click += button_BackPage_Click;
            // 
            // button_NextPage
            // 
            button_NextPage.Enabled = false;
            button_NextPage.FlatStyle = FlatStyle.Flat;
            button_NextPage.ForeColor = Color.LightSkyBlue;
            button_NextPage.Image = (Image)resources.GetObject("button_NextPage.Image");
            button_NextPage.Location = new Point(75, 3);
            button_NextPage.Name = "button_NextPage";
            button_NextPage.Size = new Size(66, 59);
            button_NextPage.TabIndex = 4;
            button_NextPage.UseVisualStyleBackColor = true;
            button_NextPage.Click += button_NextPage_Click;
            // 
            // textBox_URL
            // 
            textBox_URL.BorderStyle = BorderStyle.None;
            textBox_URL.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            textBox_URL.Location = new Point(147, 3);
            textBox_URL.Name = "textBox_URL";
            textBox_URL.ReadOnly = true;
            textBox_URL.Size = new Size(755, 38);
            textBox_URL.TabIndex = 5;
            textBox_URL.TextAlign = HorizontalAlignment.Center;
            // 
            // button_Bookmark
            // 
            button_Bookmark.BackColor = Color.White;
            button_Bookmark.FlatStyle = FlatStyle.Flat;
            button_Bookmark.Image = Properties.Resources.icons8_hand_drawn_star_48;
            button_Bookmark.Location = new Point(908, 3);
            button_Bookmark.Name = "button_Bookmark";
            button_Bookmark.Size = new Size(66, 59);
            button_Bookmark.TabIndex = 6;
            button_Bookmark.UseVisualStyleBackColor = false;
            button_Bookmark.Click += button_Bookmark_Click;
            // 
            // textBox_Search
            // 
            textBox_Search.BorderStyle = BorderStyle.None;
            textBox_Search.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            textBox_Search.Location = new Point(239, 561);
            textBox_Search.Name = "textBox_Search";
            textBox_Search.Size = new Size(486, 38);
            textBox_Search.TabIndex = 6;
            textBox_Search.TextAlign = HorizontalAlignment.Center;
            // 
            // button_Search
            // 
            button_Search.BackColor = Color.White;
            button_Search.FlatStyle = FlatStyle.Flat;
            button_Search.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            button_Search.Location = new Point(731, 561);
            button_Search.Name = "button_Search";
            button_Search.Size = new Size(107, 45);
            button_Search.TabIndex = 7;
            button_Search.Text = "Search";
            button_Search.UseVisualStyleBackColor = false;
            button_Search.Click += button_Search_Click;
            // 
            // flowLayoutPanel4
            // 
            flowLayoutPanel4.Dock = DockStyle.Top;
            flowLayoutPanel4.ForeColor = Color.Black;
            flowLayoutPanel4.Location = new Point(0, 180);
            flowLayoutPanel4.Name = "flowLayoutPanel4";
            flowLayoutPanel4.Size = new Size(978, 60);
            flowLayoutPanel4.TabIndex = 8;
            // 
            // textBox_CurrentTab
            // 
            textBox_CurrentTab.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox_CurrentTab.Location = new Point(75, 560);
            textBox_CurrentTab.Name = "textBox_CurrentTab";
            textBox_CurrentTab.ReadOnly = true;
            textBox_CurrentTab.Size = new Size(150, 39);
            textBox_CurrentTab.TabIndex = 9;
            textBox_CurrentTab.Text = "Tab 0";
            textBox_CurrentTab.TextAlign = HorizontalAlignment.Center;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Google_wordmark;
            pictureBox1.Location = new Point(75, 245);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(790, 309);
            pictureBox1.TabIndex = 11;
            pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSkyBlue;
            ClientSize = new Size(978, 644);
            Controls.Add(flowLayoutPanel5);
            Controls.Add(pictureBox1);
            Controls.Add(textBox_CurrentTab);
            Controls.Add(flowLayoutPanel4);
            Controls.Add(button_Search);
            Controls.Add(textBox_Search);
            Controls.Add(flowLayoutPanel3);
            Controls.Add(flowLayoutPanel2);
            Controls.Add(flowLayoutPanel1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "WEB BROWSER";
            FormClosed += Form1_FormClosed;
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Button button_NewWin;
        private Button button_NewTab;
        private FlowLayoutPanel flowLayoutPanel2;
        private Button button_Tab_0;
        private FlowLayoutPanel flowLayoutPanel3;
        private Button button_BackPage;
        private Button button_NextPage;
        private TextBox textBox_URL;
        private Button button_Bookmark;
        private TextBox textBox_Search;
        private Button button_Search;
        private FlowLayoutPanel flowLayoutPanel4;
        private TextBox textBox_CurrentTab;
        private Button button_History;
        private FlowLayoutPanel flowLayoutPanel5;
        private PictureBox pictureBox1;
    }
}
