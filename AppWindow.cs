using System;
using System.Windows.Forms;
using Airport.Planes;
using Airport.OperationManagement;
using Airport.AirportManagement;
using System.Drawing;
using Airport.NotificationManagement;
using Airport.Weathers;

namespace Airport
{
    public partial class AppWindow : Form
    {
        WeatherForecast forecast;
        ImageController imageController;

        bool operationModeOn;
        public AppWindow()
        {
            InitializeComponent();
            operationModeOn = true;

            peopleCount.Text = "50";
            cargoCount.Text = "400";
            ammoCount.Text = "200";

            NotificationManager.getInstance().setPanel(groupBoxNotification);

            labelInfo.Parent = panelInfo;
            labelInfo.AutoSize = false;
            labelInfo.Size = new Size(labelInfo.Parent.Size.Width, labelInfo.Size.Height);

            labelAirInAir.Parent = panelAirplaneInAir;
            labelAirInAir.AutoSize = false;
            labelAirInAir.Size = new Size(labelAirInAir.Parent.Size.Width, labelAirInAir.Size.Height);
            
            labelInformacje.Parent = panelInfo;

            labelHangar.Parent = panelAngAir;
            labelHangar.AutoSize = false;
            labelHangar.Size = new Size(labelHangar.Parent.Size.Width, labelHangar.Size.Height);

            panelRunway1.Size = new Size(panelRunway1.Size.Width,2*Constants.interspaceSize+Constants.imageSize+30); // подъем от 0 до 30 пикселей
            panelRunway1.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("passtart");
            panelRunway1.BackColor = Color.Transparent;

            panelRunway2.Size = new Size(panelRunway1.Size.Width, 2 * Constants.interspaceSize + Constants.imageSize + 30); // подъем от 0 до 30 пикселей
            panelRunway2.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("passtart");
            panelRunway2.BackColor = Color.Transparent;

            hideAllButtons();
            pictureBox1.Show();

            forecast = new WeatherForecast();
            imageController = new ImageController(pictureBox1, forecast);
            imageController.setWeather();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public Panel getPanelAirplaineInAir() { return panelAirplaneInAir; }
        public Panel getPanelAirplane() { return panelAngAir;  }
        public Label getLabelInformacje() { return labelInformacje;  }
        public Panel getRunway1() { return panelRunway1; }
        public Panel getRunway2() { return panelRunway2; }

        public TextBox getPeopleCount() { return peopleCount; }
        public TextBox getCargoCount() { return cargoCount; }
        public TextBox getAmmoCount() { return ammoCount; }

        public void refreshButtonPanel(PlaneImage currrentSelected)
        {
            hideAllButtons();

            if (!(currrentSelected is Plane) )
                return;
            
            Plane currentSelectedPlane = (Plane)currrentSelected;
            
            State currentSelectedPlaneState = currentSelectedPlane.getCurrentState();
            
            if (currentSelectedPlaneState == State.Fueling || currentSelectedPlaneState == State.TechnicalInspection
                || currentSelectedPlaneState == State.Loading || currentSelectedPlaneState == State.Unloading )
            {
                btnCancelOperation.Visible = true;
            }
            else if(currentSelectedPlaneState == State.Hangar)
            {
                btnTechnicalInspection.Visible = true;
                btnOnRunway.Visible = true;
                btnFuel.Visible = true;

                if (currentSelectedPlane.isTanked())
                    btnFuel.BackColor = Color.YellowGreen;
                else
                    btnFuel.BackColor = Color.White;

                if (currentSelectedPlane.isAfterTechnicalInspection())
                    btnTechnicalInspection.BackColor = Color.YellowGreen;
                else
                    btnTechnicalInspection.BackColor = Color.White;

            }
            else if (currentSelectedPlaneState == State.InAir)
            {
                btnLand.Visible = true;
                btnSendAway.Visible = true;
            }
            else if (currentSelectedPlaneState == State.OnRunwayBefTakeoff)
            {
                btnStart.Visible = true;
                btnToHangar.Visible = true;
                btnUnload.Visible = true;
            }
            else if(currentSelectedPlaneState == State.OnRunwayAftLanding)
            {
                btnToHangar.Visible = true;
                btnUnload.Visible = true;
            }
            else if (currentSelectedPlaneState == State.Destroyed)
            {
                btnDelete.Visible = true;
            }
        }

        private void hideAllButtons()
        {
            btnTechnicalInspection.Visible = false;
            btnOnRunway.Visible = false;
            btnFuel.Visible = false;
            btnCancelOperation.Visible = false;
            btnStart.Visible = false;
            btnToHangar.Visible = false;
            btnLand.Visible = false;
            btnSendAway.Visible = false;
            btnUnload.Visible = false;
            btnDelete.Visible = false;
        }

        
        private void btnFuel_click(object sender, EventArgs e)
        {
            AirportManager.getInstance().fuel();
        }
       
        private void btnCancelOperation_click(object sender, EventArgs e)
        {
           if(AirportManager.getInstance().getSelectedPlane() is Plane)
                OperationManager.getInstance().stopOperation((Plane)AirportManager.getInstance().getSelectedPlane());
        }

        private void btnTechnicalInspection_click(object sender, EventArgs e)
        {
            AirportManager.getInstance().inspectTechnically();
        }
        
        private void btnOnRunway_click(object sender, EventArgs e)
        {
            AirportManager.getInstance().placeOnRunway();
        }

        private void btnLand_click(object sender, EventArgs e)
        {
            AirportManager.getInstance().land();
        }

        private void btnTakeoff_click(object sender, EventArgs e)
        {
            AirportManager.getInstance().takeOff();
        }

        private void btnSendAway_click(object sender, EventArgs e)
        {
            AirportManager.getInstance().sendAway();
        }
        
        private void btnToHangar_click(object sender, EventArgs e)
        {
            AirportManager.getInstance().placeInHangar();
        }

   
        private void btnLeft_click(object sender, EventArgs e)
        {
            AirportManager.getInstance().getAirspace().scrollLeft();
        }

        private void btnRight_click(object sender, EventArgs e)
        {
            AirportManager.getInstance().getAirspace().scrollRight();
        }

        private void btnDown_click(object sender, EventArgs e)
        {
            AirportManager.getInstance().getHangar().scrollDown();
        }

        private void btnUp_click(object sender, EventArgs e)
        {
            AirportManager.getInstance().getHangar().scrollUp();
        }

        
        private void peoplePanel_Click(object sender, EventArgs e)
        {
            if (Int32.Parse(peopleCount.Text) < 1)
            {
                NotificationManager.getInstance().addNotification("Больше нет пассажиров в аэропорту", NotificationType.Negative);
                return;
            }

            if (!operationModeOn)
            {
                if (AirportManager.getInstance().addSinglePerson())
                    peopleCount.Text = (Int32.Parse(peopleCount.Text) - 1).ToString();
            }
            else
                AirportManager.getInstance().loadPeopleOperation();
        }
        private void cargoPanel_Click(object sender, EventArgs e)
        {
            if (Int32.Parse(cargoCount.Text) < 1)
            {
                NotificationManager.getInstance().addNotification("Больше нет товара на складе", NotificationType.Negative);
                return;
            }

            if (!operationModeOn)
            {
                if (AirportManager.getInstance().addSingleCargo())
                    cargoCount.Text = (Int32.Parse(cargoCount.Text) - 1).ToString();
            }
            else
                AirportManager.getInstance().loadCargoOperation();
        }
        private void ammoPanel_Click(object sender, EventArgs e)
        {
            if(Int32.Parse(ammoCount.Text) < 1)
            {
                NotificationManager.getInstance().addNotification("Боеприпасов на складе больше нет", NotificationType.Negative);
                return;
            }

            if (!operationModeOn)
            {
                if (AirportManager.getInstance().addSingleAmmo())
                    ammoCount.Text = (Int32.Parse(ammoCount.Text) - 1).ToString();
            }
            else
                AirportManager.getInstance().loadAmmoOperation();
        }
        
        private void btnUnload_Click(object sender, EventArgs e)
        {
            Plane selectedPlane = (Plane)AirportManager.getInstance().getSelectedPlane();

            if(selectedPlane is PassengerPlane)
            {
                AirportManager.getInstance().unloadPeopleOperation();
            }
            else if(selectedPlane is MilitaryPlane)
            {
                AirportManager.getInstance().unloadAmmoOperation();
            }
            else if(selectedPlane is TransportPlane)
            {
                AirportManager.getInstance().unloadCargoOperation();
            }
        }
        
        private void switchAcceptingIncomingPlanes_click(object sender, EventArgs e)
        {
            if (AirportManager.getInstance().isAcceptingIncommingPlanes())
            {
                AirportManager.getInstance().setAcceptingIncomingPlanes(false);
                switchAcceptingIncomingPlanes.BackColor = Color.FromArgb(252, 113, 113);
            }
            else
            {
                AirportManager.getInstance().setAcceptingIncomingPlanes(true);
                switchAcceptingIncomingPlanes.BackColor = Color.FromArgb(162, 252, 140);
            }
        }

        private void notificationListClear_Click(object sender, EventArgs e)
        {
            NotificationManager.getInstance().clear();
        }

        private void switchOperationSingle_Click(object sender, EventArgs e)
        {
            if (operationModeOn)
            {
                operationModeOn = false;
                switchOperationSingle.Text = "Автоматически";
                switchOperationSingle.BackColor = Color.Bisque;

            }
            else
            {
                operationModeOn = true;
                switchOperationSingle.Text = "Автоматически";
                switchOperationSingle.BackColor = Color.Aquamarine;
            }
                
        }

        private void switchAssistant_click(object sender, EventArgs e)
        {
            if (AirportManager.getInstance().isAssistantOn())
            {
                AirportManager.getInstance().setAsistant(false);
                switchAssistant.BackColor = Color.FromArgb(252, 113, 113);
            }
            else
            {
                AirportManager.getInstance().setAsistant(true);
                switchAssistant.BackColor = Color.FromArgb(162, 252, 140);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            AirportManager.getInstance().delete();
        }

        private void panelInformacji_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AppWindow_Load(object sender, EventArgs e)
        {

        }
    }
}
