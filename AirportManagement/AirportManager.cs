using Airport.Operations;
using Airport.Planes;
using Airport.OperationManagement;
using System.Drawing;
using System.Windows.Forms;
using System;
using Airport.NotificationManagement;
using System.Collections.Generic;
using Airport.Weathers;

namespace Airport.AirportManagement
{
    //МЕНЕДЖЕР АЭРОПОРТА
    public class AirportManager
    {
        private static AirportManager instance;

        public static void init(AppWindow handleAppWindow)
        {
            if (instance == null) instance = new AirportManager(handleAppWindow);
        }

        public static AirportManager getInstance()
        {
            if (instance == null) throw new Exception("AirportManager не был инициализирован");
            return instance;
        }

        private AppWindow handleAppWindow; //окно приложения

        private PlaneImage selectedPlane; //выбранный самолет
        private PictureBox pbSelectedPlane; //изображение выбранного самолета

        private TextBox peopleCount, cargoCount, ammoCount; //счетчики для текстбокса

        private Hangar hangar; //ангар
        private Airspace airspace; //воздушное пространство
        private List<Runway> runwayList;

        private bool acceptsIncomingPlanes; //приятие прибывающих самолетов
        private bool assistant; //ассистент

        IOperation incommingPlanes; //начало операции прибытия самолета
        IOperation automatedAssistant; //автоматический ассистент

        private AirportManager(AppWindow handleAppWindow) { 
            this.handleAppWindow = handleAppWindow;

            runwayList = new List<Runway>();
            pbSelectedPlane = new PictureBox();
            hangar = new Hangar(handleAppWindow.getPanelAirplane(), 3, 2);
            airspace = new Airspace(handleAppWindow.getPanelAirplaineInAir(), 4);

            acceptsIncomingPlanes = false;
            assistant = false;

            incommingPlanes = new OperationIncommingPlanes();
            automatedAssistant = new OperationAssistant();

            peopleCount = handleAppWindow.getPeopleCount();
            cargoCount = handleAppWindow.getCargoCount();
            ammoCount = handleAppWindow.getAmmoCount();

            initPbSelectedPlane();

            runwayList.Add(new Runway(handleAppWindow.getRunway1(), 1));
            runwayList.Add(new Runway(handleAppWindow.getRunway2(), 2));
        }

        public PlaneImage getSelectedPlane() { return selectedPlane; }
        public Hangar getHangar() { return hangar; }
        public Airspace getAirspace() { return airspace; }

        public List<Runway> getRunwayList() { return runwayList; }

        public bool isAcceptingIncommingPlanes() { return acceptsIncomingPlanes; }
        public void setAcceptingIncomingPlanes(bool acceptsIncomingPlanes) {
            if (acceptsIncomingPlanes == false && this.acceptsIncomingPlanes == true)
            {
                OperationManager.getInstance().stopOperation(incommingPlanes);
            }
            else if(acceptsIncomingPlanes == true && this.acceptsIncomingPlanes == false)
                OperationManager.getInstance().addOperation(incommingPlanes);

            this.acceptsIncomingPlanes = acceptsIncomingPlanes;
        }

        public bool isAssistantOn() { return assistant; }
        public void setAsistant(bool assistant)
        {
            if (assistant == false && this.assistant == true)
            {
                OperationManager.getInstance().stopOperation(automatedAssistant);
            }
            else if (assistant == true && this.assistant == false)
                OperationManager.getInstance().addOperation(automatedAssistant);

            this.assistant = assistant;
        }

        private void initPbSelectedPlane()
        {
            if (pbSelectedPlane == null || handleAppWindow == null) return;

            pbSelectedPlane.Image = (Image)Properties.Resources.ResourceManager.GetObject(ImageConstants.adressSelectedMark);
            pbSelectedPlane.BackColor = Color.Transparent;
            pbSelectedPlane.Location = new Point(0, 0);
            pbSelectedPlane.Enabled = false;
            pbSelectedPlane.Visible = false;
            pbSelectedPlane.Size = new Size(Constants.planeImageSizeX, Constants.planeImageSizeY);
            pbSelectedPlane.Parent = handleAppWindow;
        }

        public void refreshInformationPanelIfSelected(Plane airplane) //обновление информации о самолете, когда он выбран
        {
            if (selectedPlane is Plane && selectedPlane == airplane)
            {
                handleAppWindow.getLabelInformacje().Text = ((Plane)selectedPlane).getInformation();
            }
        }
        public void refreshButtonPanel() //изменение панели кнопок
        {
            handleAppWindow.refreshButtonPanel(selectedPlane);
        }
        public void refreshButtonPanelIfSelected(Plane airplane) //изменении панели кнопок когда выбран
        {
            if (selectedPlane is Plane && ((Plane)selectedPlane) == airplane)
            {
                handleAppWindow.refreshButtonPanel(selectedPlane);
            }
        }
        public void selectPlane(PlaneImage airplane) { //выбранный самолет
            selectedPlane = airplane;

            pbSelectedPlane.Parent = airplane.getCurrentOnTop();
            pbSelectedPlane.Location = new Point(0, 0);

            if (airplane.isVisible()) pbSelectedPlane.Visible = true;
            
            refreshButtonPanel();
        }
        public void redraw() //перерисовка при измении состоянии самолета
        {
            hangar.redraw();
            airspace.redraw();
        }

 
        //ОПЕРАЦИИ В ДАННЫЙ МОМЕНТ НА ВЫБРАННОМ  САМОЛЕТЕ

        public void fuel() //заправка
        {
            if (selectedPlane is Plane)
               fuel((Plane)selectedPlane);
        }
        public void inspectTechnically() //техосм
        {
            if (selectedPlane is Plane)
                inspectTechnically((Plane)selectedPlane);        
        }
        public void sendAway() //отправка обратно
        {
            if (selectedPlane is Plane)
                sendAway((Plane)selectedPlane);
        }
        public void takeOff() //вылет
        {
            if (selectedPlane is Plane)
                takeOff((Plane)selectedPlane);
        }
        public void land() //приземление
        {
            if (selectedPlane is Plane)
                land((Plane)selectedPlane);
        }
        public void placeOnRunway() //размещение на полосу
        {
            if (selectedPlane is Plane)
                placeOnRunway((Plane)selectedPlane);
        }
        public void placeInHangar() //размещение в ангар
        {
            if (selectedPlane is Plane)
                placeInHangar((Plane)selectedPlane);
        }
        public void delete() //удалить
        {
            if (selectedPlane is Plane)
                delete((Plane)selectedPlane);
        }

        
        //ОПЕРАЦИИ

        public void fuel(Plane plane) //заправка
        {
            OperationManager.getInstance().addOperation(new OperationFueling(plane));
        }
        public void inspectTechnically(Plane plane) //техосм
        {
            OperationManager.getInstance().addOperation(new OperationTechnicalInspection(plane));
        }
        public void sendAway(Plane plane) //отправка обратно
        {
            if(plane.getCurrentState() == State.InAir)
            {
                if (plane.getCurrentFuelLevel() < (plane.getMaxFuelLevel() / 2))
                {
                    NotificationManager.getInstance().addNotification("Самолет " + plane.getModelID() + " не может быть отправлен обратно из-за малого количества топлива", NotificationType.Negative);
                }
                else
                {
                    NotificationManager.getInstance().addNotification("Самолет " + plane.getModelID() + " покидает воздушное пространство над аэропортом", NotificationType.Positive);

                    airspace.remove(plane);
                    plane.hide();

                    if (plane == selectedPlane)
                        selectedPlane = null;

                    plane.setParent(null);
                    plane = null;
                    
                    refreshButtonPanel();
                }
            }
        }
        public void delete(Plane plane) //удаление
        {
            if (plane.getCurrentState() != State.Destroyed) return;

            airspace.remove(plane); 
            
            foreach (Runway runway in runwayList)
            {
                if (!runway.isFree() && runway.getPlane() == plane)
                {
                    runway.takeOffCurrentPlane();
                }
            }

            plane.hide();

            if (plane == selectedPlane)
                  selectedPlane = null;

            plane.setParent(null);
            plane = null;
            
            
            refreshButtonPanel();
    }
        public void takeOff(Plane plane) //взлет
        {
            if (plane.getCurrentState() != State.OnRunwayBefTakeoff) return;

            foreach (Runway runway in runwayList)
            {
                if (!runway.isFree() && runway.getPlane() == plane)
                {
                    NotificationManager.getInstance().addNotification("Самолет " + plane.getModelID() + " взлетает с взлетно-посадочной полосы №  " + runway.getID() + ".", NotificationType.Neutral);

                    plane.setCurrentState(State.Takeoff);
                    OperationManager.getInstance().addOperation(new OperationTakeoff(plane, runway));
                    return;
                }
            }
        }
        public void land(Plane plane) //приземление
        {
            if (plane.getCurrentState() != State.InAir) return;

            foreach (Runway runway in runwayList)
            {
                if (runway.isFree())
                {
                    OperationManager.getInstance().addOperation(new OperationLanding(plane, runway));
                    airspace.remove(plane);
                    runway.setPlane(plane);
                    return;
                }
            }

            if(plane == selectedPlane) NotificationManager.getInstance().addNotification("Все взлетно-посадочные полосы в заняты", NotificationType.Negative);
        }
        public void placeOnRunway(Plane plane) //размещение на полосе
        {
            if (!plane.isAfterTechnicalInspection() || !(plane.getCurrentState() == State.Hangar))
            {
                NotificationManager.getInstance().addNotification("Самолет " + plane.getModelID() + " не прошел техосмотр", NotificationType.Negative);
                return;
            }

            foreach (Runway runway in runwayList)
            {
                if (runway.isFree())
                {
                    plane.setCurrentState(State.OnRunwayBefTakeoff);
                    hangar.remove(plane);
                    runway.setPlane(plane);
                    NotificationManager.getInstance().addNotification("Самолет " + plane.getModelID() + " был размещен на взлетно-посадочной полосе № " + runway.getID() + ".", NotificationType.Neutral);
                    return;
                }
            }

            if(plane == selectedPlane) NotificationManager.getInstance().addNotification("Все взлетно-посадочные полосы заняты", NotificationType.Negative);
        }
        public void placeInHangar(Plane plane) //размещение в ангаре
        {
            if (plane.getCurrentState() == State.OnRunwayBefTakeoff || plane.getCurrentState() == State.OnRunwayAftLanding)
            {
                if (plane is PassengerPlane)
                {
                    if (((PassengerPlane)plane).getCurrentNumberOfPassengers() != 0)
                    {
                        NotificationManager.getInstance().addNotification("Самолет " + plane.getModelID() + " не может быть помещен в ангар, потому что остались пассажиры", NotificationType.Negative);
                        return;
                    }
                }

                foreach (Runway runway in runwayList)
                {
                    if (!runway.isFree() && runway.getPlane() == plane)
                    {
                        runway.takeOffCurrentPlane();
                        hangar.addToHangar(plane);
                        plane.setCurrentState(State.Hangar);
                        return;
                    }
                }
            }
        }

        //Вручную
        public void loadPeopleOperation() //посадка пассажиров
        {
            if (selectedPlane is Plane)
                loadPeopleOperation((Plane)selectedPlane);
        }
        public void loadCargoOperation() //погрузка груза
        {
            if (selectedPlane is Plane)
                loadCargoOperation((Plane)selectedPlane);
        }
        public void loadAmmoOperation() //погрузка боеприпасов
        {
            if (selectedPlane is Plane)
                loadAmmoOperation((Plane)selectedPlane);
        }
        public void unloadPeopleOperation() //разгрузка пассажиров
        {
            if (selectedPlane is Plane)
                unloadPeopleOperation((Plane)selectedPlane);
        }
        public void unloadCargoOperation() //разгрузка грузов
        {
            if (selectedPlane is Plane)
                unloadCargoOperation((Plane)selectedPlane);
        }
        public void unloadAmmoOperation() //разгрузка боеприпасов
        {
            if (selectedPlane is Plane)
                unloadAmmoOperation((Plane)selectedPlane);
        }

        //программно
        public void loadPeopleOperation(Plane plane) //погрузка пассажиров
        {
            if (plane is PassengerPlane)
            {
                if(((PassengerPlane)plane).getCurrentState() == State.Loading)
                    return;

                OperationManager.getInstance().addOperation(new OperationLoading(plane, peopleCount));
                return;
            }
               
            NotificationManager.getInstance().addNotification("Самолет " + plane.getModelID() + " не пассажирский", NotificationType.Negative);
        }
        public void loadCargoOperation(Plane plane) //погрузка груза
        {
            if (plane is TransportPlane)
            {
                if (((TransportPlane)plane).getCurrentState() == State.Loading)
                    return;

                OperationManager.getInstance().addOperation(new OperationLoading(plane, cargoCount));
                return;
            }

            NotificationManager.getInstance().addNotification("Самолет " + plane.getModelID() + " не транспортный", NotificationType.Negative);
        }
        public void loadAmmoOperation(Plane plane) //погрузка боеприпасов
        {
            if (plane is MilitaryPlane)
            {
                if (((MilitaryPlane)plane).getCurrentState() == State.Loading)
                    return;

                OperationManager.getInstance().addOperation(new OperationLoading(plane, ammoCount));
                return;
            }
            NotificationManager.getInstance().addNotification("Самолет " + plane.getModelID() + " не военный", NotificationType.Negative);
        }
       
        public void unloadPeopleOperation(Plane plane) //выгрузка пассажиров
        {
            if (plane is PassengerPlane)
            {
                if (((PassengerPlane)plane).getCurrentState() == State.Unloading)
                    return;

                OperationManager.getInstance().addOperation(new OperationUnloading(plane, peopleCount));
                return;
            }

            NotificationManager.getInstance().addNotification("Самолет " + plane.getModelID() + " не пассажирский", NotificationType.Negative);
        }
        public void unloadCargoOperation(Plane plane) //выгрузка грузка
        {
            if (plane is TransportPlane)
            {
                if (((TransportPlane)plane).getCurrentState() == State.Unloading)
                    return;

                OperationManager.getInstance().addOperation(new OperationUnloading(plane, cargoCount));
                return;
            }

            NotificationManager.getInstance().addNotification("Самолет " + plane.getModelID() + " не транспортный", NotificationType.Negative);
        }
        public void unloadAmmoOperation(Plane plane) //выгрузка боеприпасов
        {
            if (plane is MilitaryPlane)
            {
                if (((MilitaryPlane)plane).getCurrentState() == State.Unloading)
                    return;

                OperationManager.getInstance().addOperation(new OperationUnloading(plane, ammoCount));
                return;
            }
            NotificationManager.getInstance().addNotification("Самолет " + plane.getModelID() + " не военный", NotificationType.Negative);
        }

        public bool addSinglePerson() //добавить самому людей
        {
            if (selectedPlane == null)
            {
                NotificationManager.getInstance().addNotification("Сначала выберите самолет", NotificationType.Negative);
                return false;
            }
            if (!(selectedPlane is PassengerPlane))
            {
                NotificationManager.getInstance().addNotification("Самолет " + ((Plane)selectedPlane).getModelID() + " не пассажисрский", NotificationType.Negative);
                return false;
            }

            if (!(((Plane)selectedPlane).getCurrentState() == State.OnRunwayBefTakeoff))
            {
                NotificationManager.getInstance().addNotification("Пассажирам в самолет разрешается заходить только на взлетно-посадочную полосу перед взлетом", NotificationType.Negative);
                return false;
            }

            if (((PassengerPlane)selectedPlane).getCurrentNumberOfPassengers() + 1 <= ((PassengerPlane)selectedPlane).getMaxNumberOfPassengers())
            {
                ((PassengerPlane)selectedPlane).setCurrentNumberOfPassengers(((PassengerPlane)selectedPlane).getCurrentNumberOfPassengers() + 1);
                return true;
            }

            return false;
        }
        public bool addSingleAmmo() //добавить самому боеприпасы
        {
            if (selectedPlane == null)
            {
                NotificationManager.getInstance().addNotification("Сначала отметьте самолет", NotificationType.Negative);
                return false;
            }
            if (!(selectedPlane is MilitaryPlane))
            {
                NotificationManager.getInstance().addNotification("Самолет " + ((Plane)selectedPlane).getModelID() + " не военный", NotificationType.Negative);
                return false;
            }

            if (!(((Plane)selectedPlane).getCurrentState() == State.OnRunwayBefTakeoff || ((Plane)selectedPlane).getCurrentState() == State.Hangar))
            {
                NotificationManager.getInstance().addNotification("На данный момент Вы не можете зарядить оружие.", NotificationType.Negative);
                return false;
            }

            if (((MilitaryPlane)selectedPlane).getCurrentAmmo() + 1 <= ((MilitaryPlane)selectedPlane).getMaxAmmo())
            {
                ((MilitaryPlane)selectedPlane).setCurrentAmmo(((MilitaryPlane)selectedPlane).getCurrentAmmo() + 1);
                return true;
            }

            return false;
        }
        public bool addSingleCargo() //добавить самому груз
        {
            if (selectedPlane == null)
            {
                NotificationManager.getInstance().addNotification("Сначала выберите самолет", NotificationType.Negative);
                return false;
            }
            if (!(selectedPlane is TransportPlane))
            {
                NotificationManager.getInstance().addNotification("Самолет " + ((Plane)selectedPlane).getModelID() + " не транспортный", NotificationType.Negative);
                return false;
            }

            if (!(((Plane)selectedPlane).getCurrentState() == State.OnRunwayBefTakeoff || ((Plane)selectedPlane).getCurrentState() == State.Hangar))
            {
                NotificationManager.getInstance().addNotification("Не удается загрузить товар", NotificationType.Negative);
                return false;
            }

            if (((TransportPlane)selectedPlane).getCurrentStorageContent() + 1 <= ((TransportPlane)selectedPlane).getMaxStorageCapacity())
            {
                ((TransportPlane)selectedPlane).setCurrentStorageContent(((TransportPlane)selectedPlane).getCurrentStorageContent() + 1);
                return true;
            }


            return false;
        } 

    }
}
