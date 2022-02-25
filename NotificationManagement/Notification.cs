using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace Airport.NotificationManagement
{
    //УВЕДОМЛЕНИЯ
    public class Notification
    {
        Label textBox;
        Panel panel;
        NotificationType notificationType;
        public Notification(String text, NotificationType notificationType) //тело уведомления
        {
            textBox = new Label();
            textBox.BorderStyle = BorderStyle.None;
            textBox.Location = new Point(3, 3);
            textBox.MaximumSize = new Size(Constants.notificationmax, 0);
            textBox.AutoSize = true;
            textBox.Text = text + "\n" + DateTime.Now.ToString
                ("                                    HH:mm:ss", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            textBox.Click += onClick;


            panel = new Panel();
            hide();
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Controls.Add(textBox);
            panel.Size = new Size(Constants.notificationmax, textBox.Size.Height+6);
            panel.Parent = NotificationManager.getInstance().getPanel();
            panel.Click += onClick;
            this.notificationType = notificationType;
        }
        public int getHeight() { return panel.Size.Height; }

        public void hide() //скрывает панель уведомлений
        {
            panel.Visible = false;
            panel.Enabled = false;
        }

        private void onClick(object sender, EventArgs e) //убирает уведомления кликом мыши
        {
            remove();
            NotificationManager.getInstance().removeNotification(this);
        }

        public void show(Point position) // показывает уведомление в указанном месте
        {
            panel.Location = position;
            
            switch (notificationType) //в зависимости от типа уведомлений
            {
                    case NotificationType.Neutral:
                        panel.BackColor = Color.White;
                        break;
                    case NotificationType.Positive:
                        panel.BackColor = Color.FromArgb(162,252,140);
                        break;
                    case NotificationType.Negative:
                        panel.BackColor = Color.FromArgb(252, 113, 113);
                        break;
            }

            panel.Visible = true;
            panel.Enabled = true;
        }

        public void remove() //убирает всю панель
        {
            panel.Visible = false;
            panel.Enabled = false;

            textBox.Visible = false;
            textBox.Enabled = false;

            textBox.Parent.Controls.Remove(textBox);
            panel.Parent.Controls.Remove(panel);
        }

    }
}
