namespace Project_Browser
{
    public partial class Form1 : Form
    {
        public ListBookmark listBookmark = new ListBookmark();
        public ListHistory listHistory = new ListHistory();
        public ListWindow listWindow = new ListWindow();
        public Win win1 = new Win();
        public Tab tab1 = new Tab();
        public Button currentButton;

        public Form1()
        {
            win1.addTail(tab1);
            listWindow.addTail(win1);

            InitializeComponent();

            currentButton = button_Tab_0;
        }

        private void check_Back_Next_Button()
        {
            if (listWindow.currentWindow.window.currentTab.tab.currentPage.prev != null)
            {
                button_BackPage.Enabled = true;
            }
            else
            {
                button_BackPage.Enabled = false;
            }
            if (listWindow.currentWindow.window.currentTab.tab.currentPage.next != null)
            {
                button_NextPage.Enabled = true;
            }
            else
            {
                button_NextPage.Enabled = false;
            }
        }

        private void button_Search_Click(object sender, EventArgs e)
        {
            string address = textBox_Search.Text;
            if (address == "")
            {
                MessageBox.Show("The URL cannot be null !!!");
            }
            else
            {
                // Cập nhật thông tin cho textBox_URL
                textBox_URL.Text = address;

                // Thêm page mới vào tab hiện tại
                listWindow.currentWindow.window.currentTab.tab.addTail(address);

                // Thêm lịch sử
                listHistory.addTail(address);

                // Thêm button vào danh sách hiện lịch sử
                Button button = new Button();
                button.Name = "button_His_";
                button.Size = new Size(360, 51);
                button.TabIndex = 3;
                button.UseVisualStyleBackColor = true;
                button.MouseUp += Button_His_Click;
                button.Text = listHistory.currentHistory.his + " " + listHistory.currentHistory.date;
                flowLayoutPanel5.Controls.Add(button);

                check_Back_Next_Button();

                // Cập nhật lại text của tab hiện tại
                currentButton.Text = listWindow.currentWindow.window.currentTab.tab.currentPage.url + "";

                textBox_Search.Clear();
            }
        }

        private void Button_His_Click(object? sender, MouseEventArgs e)
        {
            Button button = sender as Button;

            // Lấy ra nội dung của lịch sử bằng cách bỏ đi thành phần ngày tháng
            string originalText = button.Text;
            for (int i =  0; i < 3; i++)
            {
                // Find the index of the space before the date and time part
                int spaceIndex = originalText.LastIndexOf(' ');
                // Extract the "Hello World" part
                originalText = originalText.Substring(0, spaceIndex);
            }
            string address = originalText;

            if (e.Button == MouseButtons.Left)
            {
                if (address == "")
                {
                    MessageBox.Show("The URL cannot be null !!!");
                }
                else
                {
                    // Update thông tin
                    textBox_URL.Text = address;

                    // Thêm page mới vào tab hiện tại
                    listWindow.currentWindow.window.currentTab.tab.addTail(address);

                    flowLayoutPanel5.Visible = false;

                    // Cập nhật lại text của tab hiện tại
                    currentButton.Text = listWindow.currentWindow.window.currentTab.tab.currentPage.url + "";

                    check_Back_Next_Button();
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                listHistory.deleteHis(address);
                button.Visible = false;
            }
        }

        private void button_BackPage_Click(object sender, EventArgs e)
        {
            bool check = listWindow.currentWindow.window.currentTab.tab.moveBack();
            textBox_URL.Text = listWindow.currentWindow.window.currentTab.tab.currentPage.url;

            // Cập nhật lại text của tab hiện tại
            currentButton.Text = listWindow.currentWindow.window.currentTab.tab.currentPage.url + "";

            check_Back_Next_Button();
        }

        private void button_NextPage_Click(object sender, EventArgs e)
        {
            bool check = listWindow.currentWindow.window.currentTab.tab.moveNext();
            textBox_URL.Text = listWindow.currentWindow.window.currentTab.tab.currentPage.url;

            // Cập nhật lại text của tab hiện tại
            currentButton.Text = listWindow.currentWindow.window.currentTab.tab.currentPage.url + "";

            check_Back_Next_Button();
        }

        private void button_NewWin_Click(object sender, EventArgs e)
        {
            Form1 form2 = new Form1();
            form2.Show();
        }

        private void button_NewTab_Click(object sender, EventArgs e)
        {
            Tab tab = new Tab();

            // Thêm tab mới vào window hiện tại
            listWindow.currentWindow.window.addTail(tab);

            // Tạo button tab để thêm vào thanh danh sách tab
            Button button = new Button();
            button.Name = "button_Tab_" + listWindow.currentWindow.window.currentTab.index;
            button.Size = new Size(112, 51);
            button.TabIndex = 3;
            button.UseVisualStyleBackColor = true;
            button.MouseUp += Button_Click;
            button.Text = listWindow.currentWindow.window.currentTab.index + "";

            currentButton = button;

            // Update thông tin
            textBox_CurrentTab.Text = "Tab " + listWindow.currentWindow.window.currentTab.index;
            textBox_URL.Text = "";

            check_Back_Next_Button();

            flowLayoutPanel2.Controls.Add(button);
        }

        private void Button_Click(object? sender, MouseEventArgs e)
        {
            Button button = sender as Button;

            string name = button.Name;

            // Find the index of the space before the date and time part
            int spaceIndex = name.LastIndexOf('_');
            // Extract the "Hello World" part
            name = name.Substring(spaceIndex + 1);

            int index = int.Parse(name);

            listWindow.currentWindow.window.changeCurrentTab(index);

            if (e.Button == MouseButtons.Left)
            {
                textBox_CurrentTab.Text = "Tab " + listWindow.currentWindow.window.currentTab.index;
                textBox_URL.Text = listWindow.currentWindow.window.currentTab.tab.currentPage.url;

                currentButton = button;

                check_Back_Next_Button();
            }
            else if (e.Button == MouseButtons.Right)
            {
                // Kiểm tra không cho phép xoá tab duy nhất
                if (listWindow.currentWindow.window.currentTab.prev == null
                    && listWindow.currentWindow.window.currentTab.next == null)
                {
                    MessageBox.Show("You cannot delete the only Tab in this Window !!!");
                }
                else
                {
                    listWindow.currentWindow.window.deleteCurrent();

                    /*
                    // Di chuyển Tab hiện tại
                    if (listWindow.currentWindow.window.currentTab.next != null)
                    {
                        listWindow.currentWindow.window.currentTab = listWindow.currentWindow.window.currentTab.next;
                    }
                    else if (listWindow.currentWindow.window.currentTab.prev != null)
                    {
                        listWindow.currentWindow.window.currentTab = listWindow.currentWindow.window.currentTab.prev;
                    }

                    // Xoá Tab
                    listWindow.currentWindow.window.deleteTab(index);
                    */

                    // Update thông tin
                    textBox_CurrentTab.Text = "Tab " + listWindow.currentWindow.window.currentTab.index;
                    textBox_URL.Text = listWindow.currentWindow.window.currentTab.tab.currentPage.url;

                    button.Visible = false;

                    check_Back_Next_Button();
                }
            }
        }

        private void button_Bookmark_Click(object sender, EventArgs e)
        {
            if (textBox_URL.Text == "")
                return;

            string address = textBox_URL.Text;
            listBookmark.addTail(address);

            Button button = new Button();
            button.Name = "button_Bookmark_" + listBookmark.currentPage.index;
            button.Size = new Size(112, 51);
            button.TabIndex = 3;
            button.UseVisualStyleBackColor = true;
            button.MouseUp += Button_Bookmark_Click;
            button.Text = address;

            flowLayoutPanel4.Controls.Add(button);
        }

        private void Button_Bookmark_Click(object? sender, MouseEventArgs e)
        {
            Button button = sender as Button;
            string address = button.Text;

            if (e.Button == MouseButtons.Left)
            {
                if (address == "")
                {
                    MessageBox.Show("The URL cannot be null !!!");
                }
                else
                {
                    textBox_URL.Text = address;
                    listWindow.currentWindow.window.currentTab.tab.addTail(address);
                    textBox_Search.Clear();

                    check_Back_Next_Button();
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                listBookmark.deleteBookmark(address);

                button.Visible = false;
            }
        }

        private void button_History_Click(object sender, EventArgs e)
        {
            if (flowLayoutPanel5.Visible == true)
            {
                flowLayoutPanel5.Visible = false;
            }
            else
            {
                flowLayoutPanel5.Visible = true;
            }
        }
    }
}
