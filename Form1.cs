using System.Net;

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
            Read_Bookmark();
            Read_History();

            win1.addTail(tab1);
            listWindow.addTail(win1);

            InitializeComponent();

            Create_Button_Bookmark();
            Create_Button_History();

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
                listWindow.currentWindow.window.currentTab.tab.AddNewPage(address);

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
            for (int i = 0; i < 3; i++)
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
                    listWindow.currentWindow.window.currentTab.tab.AddNewPage(address);

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

            if (listBookmark.Exist(address))
            {
                return;
            }

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
                    listWindow.currentWindow.window.currentTab.tab.AddNewPage(address);
                    textBox_Search.Clear();

                    // Thêm lịch sử
                    listHistory.addTail(address);

                    // Cập nhật lại text của tab hiện tại
                    currentButton.Text = listWindow.currentWindow.window.currentTab.tab.currentPage.url + "";

                    // Thêm button vào danh sách hiện lịch sử
                    Button his = new Button();
                    his.Name = "button_His_";
                    his.Size = new Size(360, 51);
                    his.TabIndex = 3;
                    his.UseVisualStyleBackColor = true;
                    his.MouseUp += Button_His_Click;
                    his.Text = listHistory.tail.his + " " + listHistory.tail.date;
                    flowLayoutPanel5.Controls.Add(his);

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

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Bookmark
            try
            {
                //Pass the filepath and filename to the StreamWriter Constructor
                //D:\DSA\Project_Browser\bin\Debug\net7.0-windows
                StreamWriter sw = new StreamWriter("Bookmark.txt");

                for (NodeBookmark p = listBookmark.head; p != null; p = p.next)
                {
                    sw.WriteLine(p.url);
                }

                //Close the file
                sw.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }

            // History
            try
            {
                //Pass the filepath and filename to the StreamWriter Constructor
                //D:\DSA\Project_Browser\bin\Debug\net7.0-windows
                StreamWriter sw = new StreamWriter("History.txt");

                for (NodeHistory p = listHistory.head; p != null; p = p.next)
                {
                    sw.WriteLine(p.his + " " + p.date.Month + " " + p.date.Day + " " + p.date.Year + " " + p.date.Hour + " " + 
                        p.date.Minute + " " + p.date.Second);
                }

                //Close the file
                sw.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }

            Application.Exit();
        }

        private void Read_Bookmark()
        {
            string line;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("Bookmark.txt");
                //Read the first line of text
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null && line != "")
                {
                    listBookmark.addTail(line);
                    //Read the next line
                    line = sr.ReadLine();
                }
                //close the file
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }

        private void Create_Button_Bookmark()
        {
            if (listBookmark.isEmpty())
                return;

            for (NodeBookmark p = listBookmark.head; p != null; p = p.next)
            {
                Button button = new Button();
                button.Name = "button_Bookmark_" + p.index;
                button.Size = new Size(112, 51);
                button.TabIndex = 3;
                button.UseVisualStyleBackColor = true;
                button.MouseUp += Button_Bookmark_Click;
                button.Text = p.url;

                flowLayoutPanel4.Controls.Add(button);
            }    
            
        }
        
        private void Read_History()
        {
            
            string line;
            try
            {
                
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("History.txt");
                //Read the first line of text
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null && line != "")
                {
                    // Split the string by space
                    string[] parts = line.Split(' ');

                    // Extract values from the array and convert to the desired types
                    string url = parts[0];
                    int month = int.Parse(parts[1]);
                    int day = int.Parse(parts[2]);
                    int year = int.Parse(parts[3]);
                    int hour = int.Parse(parts[4]);
                    int minute = int.Parse(parts[5]);
                    int second = int.Parse(parts[6]);

                    listHistory.addTail(url, month, day, year, hour, minute, second);
                    //Read the next line
                    line = sr.ReadLine();
                }
                //close the file
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }

        }

        private void Create_Button_History()
        {
            for (NodeHistory p = listHistory.head; p != null; p = p.next)
            {
                // Thêm button vào danh sách hiện lịch sử
                Button button = new Button();
                button.Name = "button_His_";
                button.Size = new Size(360, 51);
                button.TabIndex = 3;
                button.UseVisualStyleBackColor = true;
                button.MouseUp += Button_His_Click;
                button.Text = p.his + " " + p.date;
                flowLayoutPanel5.Controls.Add(button);
            }
        }
    }
}
