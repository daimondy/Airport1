using System;
using Airport.Planes;
using System.Windows.Forms;
using Airport.NotificationManagement;

namespace Airport.Operations
{
    //ОПЕРАЦИЯ ПОГРУЗКИ
    class OperationLoading : IOperation
    {
        private Plane plane;
        private TextBox containerCount;
        private State previousState;
        private int intervalTimer;

        public OperationLoading(Plane plane, TextBox containerCount)
        {
            this.plane = plane;
            this.containerCount = containerCount;
            previousState = plane.getCurrentState();
            intervalTimer = 0;
            

            if(plane is PassengerPlane)
            {
                if(plane.getCurrentState() != State.OnRunwayBefTakeoff)
                {
                    NotificationManager.getInstance().addNotification("Пассажиры самолета могут выйти на взлетно-посадочную полосу только перед взлетом.", NotificationType.Negative);
                    return;
                }

                if(((PassengerPlane)plane).getCurrentNumberOfPassengers() == ((PassengerPlane)plane).getMaxNumberOfPassengers())
                {
                    NotificationManager.getInstance().addNotification("Самолет уже полон", NotificationType.Negative);
                    return;
                }

                plane.setCurrentState(State.Loading);
                NotificationManager.getInstance().addNotification("Пассажиры садятся в самолет " + plane.getModelID(), NotificationType.Neutral);
            }
            else if(plane is TransportPlane)
            {
                if(!(plane.getCurrentState() == State.Hangar || plane.getCurrentState() == State.OnRunwayBefTakeoff))
                {
                    NotificationManager.getInstance().addNotification("Товар не может быть загружен", NotificationType.Negative);
                    return;
                }

                if (((TransportPlane)plane).getCurrentStorageContent() == ((TransportPlane)plane).getMaxStorageCapacity())
                {
                    NotificationManager.getInstance().addNotification("Самолет уже загружен до предела", NotificationType.Negative);
                    return;
                }

                plane.setCurrentState(State.Loading);
                NotificationManager.getInstance().addNotification("Началась загрузка самолета грузом " + plane.getModelID(), NotificationType.Neutral);
            }
            else
            {
                if (!(plane.getCurrentState() == State.Hangar || plane.getCurrentState() == State.OnRunwayBefTakeoff))
                {
                    NotificationManager.getInstance().addNotification("Самолет нельзя вооружить " + plane.getModelID(), NotificationType.Negative);
                    return;
                }

                if (((MilitaryPlane)plane).getCurrentAmmo() == ((MilitaryPlane)plane).getMaxAmmo())
                {
                    NotificationManager.getInstance().addNotification("Самолет " + plane.getModel() + " уже вооружен", NotificationType.Negative);
                    return;
                }

                plane.setCurrentState(State.Loading);
                NotificationManager.getInstance().addNotification("Начато пополнение боеприпасов самолета " + plane.getModelID(), NotificationType.Neutral);
            }
        }


        public override bool execute()
        {
            if (plane.getCurrentState() != State.Loading) return false;

            if (++intervalTimer < Constants.intervalLoading) return true;

            intervalTimer = 0;

            if(plane is PassengerPlane)
            {
                if(((PassengerPlane)plane).getCurrentNumberOfPassengers() == ((PassengerPlane)plane).getMaxNumberOfPassengers())
                {
                    NotificationManager.getInstance().addNotification("В пассажирском самолете " + plane.getModelID() + " больше нет мест", NotificationType.Neutral);
                    plane.setCurrentState(previousState);
                    return false;
                }

                if(Int32.Parse(containerCount.Text) < 1)
                {
                    NotificationManager.getInstance().addNotification("В аэропорту больше нет пассажиров", NotificationType.Neutral);
                    plane.setCurrentState(previousState);
                    return false;
                }

                ((PassengerPlane)plane).setCurrentNumberOfPassengers(((PassengerPlane)plane).getCurrentNumberOfPassengers() + 1);
                containerCount.Text = (Int32.Parse(containerCount.Text) - 1).ToString();
            }
            else if(plane is TransportPlane)
            {
                if (((TransportPlane)plane).getCurrentStorageContent() == ((TransportPlane)plane).getMaxStorageCapacity())
                {
                    NotificationManager.getInstance().addNotification("Транспортный самолет " + plane.getModelID() + " уже заполнен грузом", NotificationType.Neutral);
                    plane.setCurrentState(previousState);
                    return false;
                }

                if (Int32.Parse(containerCount.Text) < 1)
                {
                    NotificationManager.getInstance().addNotification("Больше нет товаров для погрузки", NotificationType.Neutral);
                    plane.setCurrentState(previousState);
                    return false;
                }

                ((TransportPlane)plane).setCurrentStorageContent(((TransportPlane)plane).getCurrentStorageContent() + 1);
                containerCount.Text = (Int32.Parse(containerCount.Text) - 1).ToString();
            }
            else if(plane is MilitaryPlane)
            {
                if (((MilitaryPlane)plane).getCurrentAmmo() == ((MilitaryPlane)plane).getMaxAmmo())
                {
                    NotificationManager.getInstance().addNotification("Боевой самолет " + plane.getModelID() + " был вооружен", NotificationType.Neutral);
                    plane.setCurrentState(previousState);
                    return false;
                }

                if (Int32.Parse(containerCount.Text) < 1)
                {
                    NotificationManager.getInstance().addNotification("Боеприпасов для вооружения самолета больше нет " + plane.getModelID(), NotificationType.Neutral);
                    plane.setCurrentState(previousState);
                    return false;
                }

                ((MilitaryPlane)plane).setCurrentAmmo(((MilitaryPlane)plane).getCurrentAmmo() + 1);
                containerCount.Text = (Int32.Parse(containerCount.Text) - 1).ToString();
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
