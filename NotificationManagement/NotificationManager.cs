using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace Airport.NotificationManagement
{
    //МЕНЕДЖЕР УВЕДОМЛЕНИЙ
    public class NotificationManager
    {
        private static NotificationManager instance;
        
        public static NotificationManager getInstance()
        {
            if (instance != null) return instance;

            instance = new NotificationManager();
            return instance;
        }

        private List<Notification> listNotification;
        GroupBox handlePanel;

        private NotificationManager()
        {
            listNotification = new List<Notification>();
            
        }
        public void setPanel(GroupBox handePanel) { handlePanel = handePanel; } //установка панели
        
        public void addNotification(String text, NotificationType notificationType) //добавление уведомлений
        {
            listNotification.Insert(0, new Notification(text,notificationType));
            redraw();
        }

        public void removeNotification(Notification notification) //стирание уведомления
        {
            listNotification.Remove(notification);
            redraw();
        }

        public GroupBox getPanel() { return handlePanel; }

        public void clear() //полная чистка
        {
            foreach (Notification p in listNotification)
                p.remove();
          
            listNotification.Clear();
            redraw();
        }

        private void redraw() //прорисовка самолета в воздухе
        {
            int x = 0;
            int y = 3*Constants.interspaceSize;

            int i = 0;

            for(; i < listNotification.Count; i++)
            {
                if(y + listNotification.ElementAt(i).getHeight() > handlePanel.Size.Height)
                {
                    break;
                }
                listNotification.ElementAt(i).show(new Point(x, y));
                y += Constants.interspaceSize + listNotification.ElementAt(i).getHeight();
            }
            for(; i < listNotification.Count; i++)
            {
                listNotification.ElementAt(i).hide();
            }
        }
        
    }
}
