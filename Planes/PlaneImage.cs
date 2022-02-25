using System;
using System.Windows.Forms;
using System.Drawing;
using Airport.AirportManagement;

namespace Airport.Planes
{
    //ИЗОБРАЖЕНИЯ САМОЛЕТОВ
    public class PlaneImage
    {
        private PictureBox currentPlaneImage;
        private PictureBox currentStateImage;
        private Control currentOnTop;
        
        public PlaneImage(Control parentControl = null, String imageName = "airplane1")
        {

            currentPlaneImage = new PictureBox();
            currentStateImage = new PictureBox();

            currentPlaneImage.Parent = parentControl;
            currentPlaneImage.Size = new Size(Constants.planeImageSizeX, Constants.planeImageSizeY);
            currentPlaneImage.Image = (Image)Properties.Resources.ResourceManager.GetObject(imageName);
            hide();
            currentPlaneImage.Click += new EventHandler(onClick);

            currentStateImage.Parent = currentPlaneImage;
            currentStateImage.Location = new Point(0, 0);
            currentStateImage.Size = new Size(Constants.planeImageSizeX, Constants.planeImageSizeY);
            currentStateImage.Visible = false;
            currentStateImage.Enabled = false;
            currentStateImage.BackColor = Color.Transparent;
            currentStateImage.Click += new EventHandler(onClick);

            currentOnTop = currentPlaneImage;
        }

        public void setPlaneImage(string adress) //установка картинки самолету
        {
            currentPlaneImage.Image = (Image)Properties.Resources.ResourceManager.GetObject(adress);
        }

        public PictureBox getPlaneImage() { return currentPlaneImage; }
        public Control getCurrentOnTop() { return currentOnTop; }

        // Нажатие на изображение самолета выделяется этот самолет
        private void onClick(object sender, EventArgs e)
        {
            AirportManager.getInstance().selectPlane(this);
        }
        public void show() //показать самолет
        {
            currentPlaneImage.Visible = true;
            currentPlaneImage.Enabled = true;
        } 
        public void hide() //спрятать
        {
            currentPlaneImage.Visible = false;
            currentPlaneImage.Enabled = false;
        }
        public void setParent(Control parent) //родитель
        {
            currentPlaneImage.Parent = parent;
        }

        // Обновляет наложение состояния, если для данного состояния нет наложения, убирает и изменяет переменную currentOnTop
        public void setStateImage(State newState)
        {
            if (newState == State.TechnicalInspection)
            {
                currentStateImage.Image = Properties.Resources.controltech;
                currentStateImage.Visible = true;
                currentStateImage.Enabled = true;
                currentOnTop = currentStateImage;
            }
            else if (newState == State.Fueling)
            {
                currentStateImage.Image = Properties.Resources.refueling;
                currentStateImage.Visible = true;
                currentStateImage.Enabled = true;
                currentOnTop = currentStateImage;
            }
            else if (newState == State.Destroyed)
            {
                currentStateImage.Image = Properties.Resources.destroyed;
                currentStateImage.Visible = true;
                currentStateImage.Enabled = true;
                currentOnTop = currentStateImage;
            }
            else if (newState == State.Takeoff || newState == State.Landing || newState == State.Hangar
                || newState == State.OnRunwayAftLanding || newState == State.OnRunwayBefTakeoff)
            {
                if (this is PassengerPlane)
                {
                    currentStateImage.Image = Properties.Resources.passwheels;
                    currentStateImage.Visible = true;
                    currentStateImage.Enabled = true;
                    currentOnTop = currentStateImage;
                }
                else if (this is TransportPlane)
                {
                    currentStateImage.Image = Properties.Resources.cargowheels;
                    currentStateImage.Visible = true;
                    currentStateImage.Enabled = true;
                    currentOnTop = currentStateImage;
                }
                else
                {
                    currentStateImage.Image = Properties.Resources.militarywheels;
                    currentStateImage.Visible = true;
                    currentStateImage.Enabled = true;
                    currentOnTop = currentStateImage;
                }
            }
            else if(newState == State.Loading || newState == State.Unloading)
            {
                if (this is PassengerPlane)
                {
                    currentStateImage.Image = Properties.Resources.passengerentry;
                    currentStateImage.Visible = true;
                    currentStateImage.Enabled = true;
                    currentOnTop = currentStateImage;
                }
                else if (this is TransportPlane)
                {
                    currentStateImage.Image = Properties.Resources.passengerwithdrawal;
                    currentStateImage.Visible = true;
                    currentStateImage.Enabled = true;
                    currentOnTop = currentStateImage;
                }
                else
                {
                    currentStateImage.Image = Properties.Resources.militarywheels;
                    currentStateImage.Visible = true;
                    currentStateImage.Enabled = true;
                    currentOnTop = currentStateImage;
                }
            }
            else
            {
                currentStateImage.Visible = false;
                currentStateImage.Enabled = false;
                currentOnTop = currentPlaneImage;
            }

            
            AirportManager.getInstance().redraw();

        }

        public bool isVisible()
        {
            return currentPlaneImage.Visible;
        }

    }
}
