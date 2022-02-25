using System;
using Airport.Planes;
using System.Windows.Forms;
using Airport.NotificationManagement;

namespace Airport.Operations
{
    //ОПЕРАЦИЯ ВЫГРУЗКИ
    class OperationUnloading : IOperation
    {
        private Plane plane;
        private TextBox containerCount;
        private State previousState;
        private int intervalTimer;

        public OperationUnloading(Plane plane, TextBox containerCount)
        {
            this.plane = plane;
            this.containerCount = containerCount;
            previousState = plane.getCurrentState();
            intervalTimer = 0;


            if (plane is PassengerPlane)
            {
                if (!(plane.getCurrentState() == State.OnRunwayBefTakeoff || plane.getCurrentState() == State.OnRunwayAftLanding))
                {
                    NotificationManager.getInstance().addNotification("Пассажиры самолета могут выйти только на взлетно-посадочную полосу", NotificationType.Negative);
                    return;
                }

                if (((PassengerPlane)plane).getCurrentNumberOfPassengers() == 0)
                {
                    NotificationManager.getInstance().addNotification("Самолет " + plane.getModelID() + " пустой", NotificationType.Neutral);
                    return;
                }

                plane.setCurrentState(State.Unloading);
                NotificationManager.getInstance().addNotification("Пассажиры покидают самолет " + plane.getModelID(), NotificationType.Neutral);
            }
            else if (plane is TransportPlane)
            {
                if (!(plane.getCurrentState() == State.Hangar || plane.getCurrentState() == State.OnRunwayBefTakeoff || plane.getCurrentState() == State.OnRunwayAftLanding))
                {
                    NotificationManager.getInstance().addNotification("Теперь товар не может быть выгружен", NotificationType.Negative);
                    return;
                }

                if (((TransportPlane)plane).getCurrentStorageContent() == 0)
                {
                    NotificationManager.getInstance().addNotification("Самолет разгружен", NotificationType.Neutral);
                    return;
                }

                plane.setCurrentState(State.Unloading);
                NotificationManager.getInstance().addNotification("Началась разгрузка самолета " + plane.getModelID(), NotificationType.Neutral);
            }
            else
            {
                if (!(plane.getCurrentState() == State.Hangar || plane.getCurrentState() == State.OnRunwayBefTakeoff || plane.getCurrentState() == State.OnRunwayAftLanding))
                {
                    NotificationManager.getInstance().addNotification("Теперь самолет нельзя разоружить " + plane.getModelID(), NotificationType.Negative);
                    return;
                }

                if (((MilitaryPlane)plane).getCurrentAmmo() == 0)
                {
                    NotificationManager.getInstance().addNotification("Самолет " + plane.getModel() + " уже обезаружен", NotificationType.Neutral);
                    return;
                }

                plane.setCurrentState(State.Unloading);
                NotificationManager.getInstance().addNotification("Разогружение самолета началось " + plane.getModelID(), NotificationType.Neutral);
            }
        }


        public override bool execute()
        {
            if (plane.getCurrentState() != State.Unloading) return false;

            if (++intervalTimer < Constants.intervalLoading) return true;

            intervalTimer = 0;

            if (plane is PassengerPlane)
            {
                if (((PassengerPlane)plane).getCurrentNumberOfPassengers() == 0)
                {
                    NotificationManager.getInstance().addNotification("Из пассажирского самолета " + plane.getModelID() + " вышли все пассажиры", NotificationType.Positive);
                    plane.setCurrentState(previousState);
                    return false;
                }
                
                ((PassengerPlane)plane).setCurrentNumberOfPassengers(((PassengerPlane)plane).getCurrentNumberOfPassengers() - 1);
                containerCount.Text = (Int32.Parse(containerCount.Text) + 1).ToString();
            }
            else if (plane is TransportPlane)
            {
                if (((TransportPlane)plane).getCurrentStorageContent() == 0)
                {
                    NotificationManager.getInstance().addNotification("Транспортный самолет " + plane.getModelID() + "пуст", NotificationType.Positive);
                    plane.setCurrentState(previousState);
                    return false;
                }
                
                ((TransportPlane)plane).setCurrentStorageContent(((TransportPlane)plane).getCurrentStorageContent() - 1);
                containerCount.Text = (Int32.Parse(containerCount.Text) + 1).ToString();
            }
            else if (plane is MilitaryPlane)
            {
                if (((MilitaryPlane)plane).getCurrentAmmo() == 0)
                {
                    NotificationManager.getInstance().addNotification("Боевой самолет " + plane.getModelID() + " разоружен", NotificationType.Positive);
                    plane.setCurrentState(previousState);
                    return false;
                }
                
                ((MilitaryPlane)plane).setCurrentAmmo(((MilitaryPlane)plane).getCurrentAmmo() - 1);
                containerCount.Text = (Int32.Parse(containerCount.Text) + 1).ToString();
            }

            return true;
        }

        public override Plane getPlane()
        {
            return plane;
        }

        public override void stop()
        {
            plane.setCurrentState(previousState);
        }
    }
}
