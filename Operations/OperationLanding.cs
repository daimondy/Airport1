using Airport.Planes;
using Airport.AirportManagement;
using Airport.NotificationManagement;

namespace Airport.Operations
{
    //ОПЕРАЦИЯ ПРИЗЕМЛЕНИЯ
    class OperationLanding : IOperation
    {
        private Plane plane;
        private Runway runway;

        private int fuelUsageInterval;
        private int fuelUsageIntervalTimer;

        public OperationLanding(Plane plane, Runway runway) //призелмение самолета
        {
            this.plane = plane;
            this.runway = runway;

            if (plane.getCurrentState() == State.InAir)
            {
                NotificationManager.getInstance().addNotification("Самолет " + plane.getModelID() + " над взлетно-посадочной полосе № " + runway.getID() + ".", NotificationType.Neutral);
                plane.setCurrentState(State.Landing);
            }

            fuelUsageIntervalTimer = 0;
            fuelUsageInterval = plane.getFuelUsage();
        }

        public override Plane getPlane() { return plane; }

        public override bool execute() //может приземлиться или разбился или другие случаи
        {
            if (plane.getCurrentState() != State.Landing) return false;

            if (++fuelUsageIntervalTimer >= fuelUsageInterval) //если топлива хватает -1
            {
                plane.setCurrentFuelLevel(plane.getCurrentFuelLevel() - 1);
                fuelUsageIntervalTimer = 0;
            }

            if (plane.getCurrentFuelLevel() <= 0) //если не хватает топлива
            {
                NotificationManager.getInstance().addNotification("Самолет " + plane.getModelID() + " разбился при попытке приземлиться на взлетно-посадочной полосе № " + runway.getID() + ".", NotificationType.Negative);
                plane.setCurrentState(State.Destroyed);
                return false;
            }

            if (runway.tick())
            {
                return true;
            }
            else
            {
                NotificationManager.getInstance().addNotification("Самолет " + plane.getModelID() + " приземлился на взлето-посадочную полосу №" + runway.getID() + ".", NotificationType.Positive);
                plane.setCurrentState(State.OnRunwayAftLanding);
            }
            return false;

        }

        public override void stop() { }
    }
}
