using Airport.Planes;
using Airport.NotificationManagement;

namespace Airport.Operations
{
    //ОПЕРАЦИЯ ВОЗДУШНАЯ
    class OperationInAir : IOperation
    {
        private Plane plane;

        private int fuelUsageInterval;
        private int fuelUsageIntervalTimer;

        public OperationInAir(Plane plane)
        {
            this.plane = plane;
            fuelUsageIntervalTimer = 0;
            fuelUsageInterval = plane.getFuelUsage();

            plane.setCurrentState(State.InAir);
        }
        
        public override Plane getPlane() { return plane; }

        public override bool execute() //операции в воздухе (разбился, летит)
        {
            if (plane.getCurrentState() != State.InAir) return false;

            if (++fuelUsageIntervalTimer >= fuelUsageInterval) //уменьшение на одну единицу топлива, пока самолет в воздухе
            {
                plane.setCurrentFuelLevel(plane.getCurrentFuelLevel() - 1);
                fuelUsageIntervalTimer = 0;
            }
            
            if (plane.getCurrentFuelLevel() <= 0) //если топлива 0
            {
                NotificationManager.getInstance().addNotification("Самолет " + plane.getModelID() + " разбился в воздушном пространстве", NotificationType.Negative);
                plane.setCurrentState(State.Destroyed);
                return false;
            }

            return true;
         }

        public override void stop() { }
    }
}
