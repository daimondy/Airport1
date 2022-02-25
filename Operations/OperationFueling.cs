using Airport.Planes;
using Airport.NotificationManagement;

namespace Airport.Operations
{
    //ОПЕРАЦИЯ С ЗАПРАВКОЙ САМОЛЕТА

    class OperationFueling : IOperation
    {
        private Plane plane;
        private int intervalTimer;
        public OperationFueling(Plane plane)
        {
            this.plane = plane;
            intervalTimer = 0;

            if (plane.isTanked()) //уведомление, если самолет уже с полным баком
            {
                NotificationManager.getInstance().addNotification("Самолет " + plane.getModelID() + " уже с полным баком", NotificationType.Neutral);
                return;
            }

            if (plane.getCurrentState() == State.Hangar) //если самолет в ангаре -> заправляется
                plane.setCurrentState(State.Fueling);
        }
   
        public override bool execute() //заправка самолета топливом
        {
            if (plane.getCurrentState() != State.Fueling) return false;
            
            if (++intervalTimer < Constants.intervalFueling) return true; //на одну единицу

            intervalTimer = 0;
                    
            plane.setCurrentFuelLevel(plane.getCurrentFuelLevel() + Constants.fuelingSpeed);

            if (plane.getCurrentFuelLevel() >= plane.getMaxFuelLevel()) //когда самолет заправился
            {
                plane.setCurrentFuelLevel(plane.getMaxFuelLevel());
                NotificationManager.getInstance().addNotification("Самолет " + plane.getModelID() + " был заправлен", NotificationType.Positive);
                plane.setCurrentState(State.Hangar);
                return false;
            }

            return true; 
        }

        public override void stop() //остановка операции заправки
        {
            plane.setCurrentState(State.Hangar);
        }

        public override Plane getPlane() { return plane; }
    }
}
