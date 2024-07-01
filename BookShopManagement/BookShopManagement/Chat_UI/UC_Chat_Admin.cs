using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookShopManagement.Database;
using Google.Cloud.Firestore;
using BookShopManagement.Models;
using Guna.UI2.WinForms;
using BookShopManagement.Chat_UI;
using FireSharp.Response;
using Newtonsoft.Json;

namespace BookShopManagement.UserControls
{
    public partial class UC_Chat_Admin : UserControl
    {

        public UC_Chat_Admin()
        {
            InitializeComponent();
            currentUser = Form_Login.currentUser;

            // SetupRealtimeListener();
        }

        private async void UC_Home_Load(object sender, EventArgs e)
        {
            refresh();
            initIcon();
            setLoggedUser();

            LiveCall();
        }

        public async void LiveCall()
        {
            EventStreamResponse response = await RealTimeService.client.OnAsync("messages", (sender, args, context) =>
            {

                string responsePath = args.Path;
                string[] paths = responsePath.Split('/');
                foreach (string path in paths)
                {
                    Console.WriteLine("Path: " + path);
                }
                if (paths[paths.Length - 1] == "SenderUserId")
                {
                    string messageId = paths[paths.Length - 2];
                    DisplayMessageById(messageId);
                    Console.WriteLine("Path: " + "sender");

                }
                //Console.WriteLine("NEW MESS ARG: " + responseData);
                //  Console.WriteLine("NEW MESS: " + sender);
            });
        }

        public void initIcon()
        {
            using (var pictureBox = new Guna2PictureBox())
            {
                pictureBox.Image = Properties.Resources.anxious_face_with_sweat;
                iconLayout.Controls.Add(pictureBox);
            }
            using (var pictureBox = new Guna2PictureBox())
            {
                pictureBox.Image = Properties.Resources.disappointed_face;
                iconLayout.Controls.Add(pictureBox);
            }
            using (var pictureBox = new Guna2PictureBox())
            {
                pictureBox.Image = Properties.Resources.neutral_face;
                iconLayout.Controls.Add(pictureBox);
            }
            using (var pictureBox = new Guna2PictureBox())
            {
                pictureBox.Image = Properties.Resources.partying_face;
                iconLayout.Controls.Add(pictureBox);
            }
            using (var pictureBox = new Guna2PictureBox())
            {
                pictureBox.Image = Properties.Resources.smile;
                iconLayout.Controls.Add(pictureBox);
            }
            using (var pictureBox = new Guna2PictureBox())
            {
                pictureBox.Image = Properties.Resources.smiling_face_with_heart_eyes;
                iconLayout.Controls.Add(pictureBox);
            }
        }

        public static UserData currentChatUser { get; set; }
        public static UserData currentUser { get; set; }

        private static List<UserData> users = new List<UserData>();
        public static List<MessageData> messages = new List<MessageData>();

        public void refresh()
        {
            SearchUsers();
            AddUsersToListBox();
            //SearchMessages();
            //AddMessageToListBox();
        }
        private void AddUsersToListBox()
        {
            // Setup list user chat
            listBoxUsers.Controls.Clear();
            users.ForEach(user =>
            {
                UC_UserListItem control = new UC_UserListItem();
                control.setProp(name: user.Name,
                    imageUrl: user.ImageUrl,
                    mess: "Hello", timeDisplay: "Just now",
                    messCount: "3");
                control.user = user;
                control.uC_Chat_Admin = this;
                listBoxUsers.Controls.Add(control);
            });
        }

        private void AddControlToChatLayout(Control control)
        {
            if (chatLayout.InvokeRequired)
            {
                chatLayout.Invoke(new MethodInvoker(delegate
                {
                    chatLayout.Controls.Add(control);
                }));
            }
            else
            {
                chatLayout.Controls.Add(control);
            }
            //   chatLayout.ScrollControlIntoView(control);
            //  chatLayout.AutoScrollPosition = new Point(0, chatLayout.DisplayRectangle.Height);

        }

        public async void DisplayMessageById(string id)
        {
            FirebaseResponse response = await RealTimeService.client.GetAsync("messages/" + id);
            MessageData message = response.ResultAs<MessageData>();

            if (currentChatUser != null)
            {
                if (message != null)
                {
                    await Task.Run(() =>
                    {
                        // Simulate fetching data in the background
                        System.Threading.Thread.Sleep(2000); // Simulate a delay

                        if (message.MessageType == "TEXT")
                        {
                            if (message.SenderUserId == currentUser.Email)
                            {
                                UC_Sender control = new UC_Sender();
                                control.setProp(currentUser.ImageUrl, message.MessageText, message.CreatedAt);
                                control.senderUser = currentUser;
                                control.Margin = new Padding(240, 0, 0, 0);
                                // control.Margin = new Padding(chatLayout.Width - control.Width, 0, 0, 0);
                                // chatLayout.Controls.Add(control);
                                AddControlToChatLayout(control);

                            }
                            else if (message.SenderUserId == currentChatUser.Email)
                            {
                                UC_Receiver control = new UC_Receiver();
                                control.setProp(currentChatUser.ImageUrl, message.MessageText, message.CreatedAt);
                                control.receiverUser = currentChatUser;
                                //  chatLayout.Controls.Add(control);
                                AddControlToChatLayout(control);

                            }
                        }
                        else if (message.MessageType == "METADATA")
                        {
                            if (message.SenderUserId == currentUser.Email)
                            {
                                UC_SenderMetaData control = new UC_SenderMetaData();
                                control.setProp(currentUser.ImageUrl, message.MessageText, message.CreatedAt);
                                control.Margin = new Padding(240, 0, 0, 0);
                                //control.Margin = new Padding(chatLayout.Width - control.Width, 0, 0, 0);
                                // chatLayout.Controls.Add(control);
                                AddControlToChatLayout(control);

                            }
                            else if (message.SenderUserId == currentChatUser.Email)
                            {
                                UC_ReceiverMetaData control = new UC_ReceiverMetaData();
                                control.setProp(currentChatUser.ImageUrl, message.MessageText, message.CreatedAt);
                                // chatLayout.Controls.Add(control);
                                AddControlToChatLayout(control);

                            }
                        }


                    });

                }
                else
                {

                }
            }


        }

        public void AddMessageToListBox()
        {
            chatLayout.Controls.Clear();
            messages.ForEach(message =>
            {
                if (message.MessageType == "TEXT")
                {
                    if (message.SenderUserId == currentUser.Email)
                    {
                        UC_Sender control = new UC_Sender();
                        control.setProp(currentUser.ImageUrl, message.MessageText, message.CreatedAt);
                        control.senderUser = currentUser;
                        control.Margin = new Padding(chatLayout.Width - control.Width, 0, 0, 0);
                        chatLayout.Controls.Add(control);
                    }
                    else if (message.SenderUserId == currentChatUser.Email)
                    {
                        UC_Receiver control = new UC_Receiver();
                        control.setProp(currentChatUser.ImageUrl, message.MessageText, message.CreatedAt);
                        control.receiverUser = currentChatUser;
                        chatLayout.Controls.Add(control);
                    }
                }
                else if (message.MessageType == "METADATA")
                {
                    if (message.SenderUserId == currentUser.Email)
                    {
                        UC_SenderMetaData control = new UC_SenderMetaData();
                        control.setProp(currentUser.ImageUrl, message.MessageText, message.CreatedAt);
                        control.Margin = new Padding(chatLayout.Width - control.Width, 0, 0, 0);
                        chatLayout.Controls.Add(control);
                    }
                    else if (message.SenderUserId == currentChatUser.Email)
                    {
                        UC_ReceiverMetaData control = new UC_ReceiverMetaData();
                        control.setProp(currentChatUser.ImageUrl, message.MessageText, message.CreatedAt);
                        chatLayout.Controls.Add(control);
                    }
                }
            });

            chatLayout.AutoScrollPosition = new Point(0, chatLayout.DisplayRectangle.Height);
        }

        public static long GetMillisecondsSinceEpoch(DateTime dateTime)
        {
            // Define the Unix epoch start time
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            // Calculate the difference between the current date and the epoch start time
            TimeSpan elapsedTime = dateTime - epoch;

            // Convert the elapsed time to milliseconds
            return (long)elapsedTime.TotalMilliseconds;
        }

        public async void CreateMessage(MessageData message)
        {

            // insert message
            DateTime now = DateTime.UtcNow;

            // Calculate the milliseconds since the Unix epoch (January 1, 1970)
            long millisecondsSinceEpoch = GetMillisecondsSinceEpoch(now);

            var newRecord = new MessageData
            {
                SenderUserId = message.SenderUserId,
                ReceiverUserId = message.ReceiverUserId,
                MessageText = message.MessageText,
                CreatedAt = message.CreatedAt,
                MessageType = message.MessageType,
                MessageId = millisecondsSinceEpoch.ToString(),
            };

            // Add the new record to the database
            SetResponse response = await RealTimeService.client.SetAsync($"messages/{newRecord.MessageId}", newRecord);
            Console.WriteLine("Data inserted with status: " + response.StatusCode);

            //SearchMessages();
            //AddMessageToListBox();
        }

        private async void SearchUsers()
        {
            users.Clear();

            var db = FirebaseHelper.Database;
            Query userQue = db.Collection("UserData");
            QuerySnapshot snap = await userQue.GetSnapshotAsync();
            foreach (DocumentSnapshot doc in snap)
            {
                if (doc.Exists)
                {
                    UserData user = doc.ConvertTo<UserData>();
                    if (user.Email == "admin@gmail.com")
                        continue;
                    user.UserId = doc.Id;
                    users.Add(user);
                }
            }
            AddUsersToListBox();
        }

        public async void SearchMessages()
        {
            messages.Clear();
            chatLayout.Controls.Clear();
            // Replace these with your actual parameters
            string sender1 = currentUser.Email;
            string receiver1 = currentChatUser.Email;
            string sender2 = currentChatUser.Email;
            string receiver2 = currentUser.Email;

            FirebaseResponse response = await RealTimeService.client.GetAsync("messages");
            Dictionary<string, MessageData> data = JsonConvert.DeserializeObject<Dictionary<string, MessageData>>(response.Body);

            // Filter
            if (data != null)
            {
                var filterMessages = data.Values.Where(mess => (mess.SenderUserId == sender1 && mess.ReceiverUserId == receiver1) || (mess.SenderUserId == sender2 && mess.ReceiverUserId == receiver2)).ToList();
                if (filterMessages.Count > 0)
                {
                    messages.AddRange(filterMessages);
                    //AddMessageToListBox();
                    chatLayout.Controls.Clear();
                    messages.ForEach(message =>
                    {
                        if (message.MessageType == "TEXT")
                        {
                            if (message.SenderUserId == currentUser.Email)
                            {
                                UC_Sender control = new UC_Sender();
                                control.setProp(currentUser.ImageUrl, message.MessageText, message.CreatedAt);
                                control.senderUser = currentUser;
                                control.Margin = new Padding(240, 0, 0, 0);
                                // control.Margin = new Padding(chatLayout.ClientSize.Width - control.ClientSize.Width - 10, 0, 0, 0);
                                chatLayout.Controls.Add(control);
                            }
                            else if (message.SenderUserId == currentChatUser.Email)
                            {
                                UC_Receiver control = new UC_Receiver();
                                control.setProp(currentChatUser.ImageUrl, message.MessageText, message.CreatedAt);
                                control.receiverUser = currentChatUser;
                                chatLayout.Controls.Add(control);
                            }
                        }
                        else if (message.MessageType == "METADATA")
                        {
                            if (message.SenderUserId == currentUser.Email)
                            {
                                UC_SenderMetaData control = new UC_SenderMetaData();
                                control.setProp(currentUser.ImageUrl, message.MessageText, message.CreatedAt);
                                control.Margin = new Padding(240, 0, 0, 0);
                                // control.Margin = new Padding(chatLayout.Width - control.Width, 0, 0, 0);
                                chatLayout.Controls.Add(control);
                            }
                            else if (message.SenderUserId == currentChatUser.Email)
                            {
                                UC_ReceiverMetaData control = new UC_ReceiverMetaData();
                                control.setProp(currentChatUser.ImageUrl, message.MessageText, message.CreatedAt);
                                chatLayout.Controls.Add(control);
                            }
                        }
                    });

                    chatLayout.AutoScrollPosition = new Point(0, chatLayout.DisplayRectangle.Height);
                }
            }
        }

        public void setCurrentUserChat(string imageUrl, string name)
        {
            pictureBoxCurrentChatUser.ImageLocation = imageUrl;
            lbNameCurrentChatUser.Text = name;
        }
        public void setLoggedUser()
        {
            UserData user = currentUser;
            pictureBoxBigAva.ImageLocation = user.ImageUrl;
            pictureBoxCurrentChatUser.ImageLocation = user.ImageUrl;
            lbName.Text = user.Name;
            lbEmail.Text = user.Email;
            lbPhone.Text = user.Phone;
        }
        private void sendBtn_Click(object sender, EventArgs e)
        {
            if (messageBox.Text != "" && currentChatUser != null)
            {
                MessageData message = new MessageData();
                message.SenderUserId = currentUser.Email;
                message.ReceiverUserId = currentChatUser.Email;
                message.MessageId = "0";
                message.MessageText = messageBox.Text;
                message.CreatedAt = DateTime.Now.ToString();
                message.MessageType = "TEXT";
                CreateMessage(message);
                messageBox.Text = "";
            }
            else
            {
                MessageBox.Show("Something Error");
            }

        }

        private void sendVideoBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string fileName in openFileDialog.FileNames)
                {
                    MessageData message = new MessageData();
                    message.SenderUserId = currentUser.Email;
                    message.ReceiverUserId = currentChatUser.Email;
                    message.MessageId = "0";
                    message.MessageText = fileName;
                    message.CreatedAt = DateTime.Now.ToString();
                    message.MessageType = "METADATA";
                    CreateMessage(message);
                }
                refresh();
            }
        }

        private void sendIconBtn_Click(object sender, EventArgs e)
        {
            IconForm form = new IconForm();
            form.uC_Chat_Admin = this;

            form.ShowDialog();
        }
    }
}
