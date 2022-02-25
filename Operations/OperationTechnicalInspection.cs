using Airport.Planes;
using Airport.NotificationManagement;

namespace Airport.Operations
{
    //ОПЕРАЦИЯ ТЕХНИЧЕСКОГО ОСМОТРА
    class OperationTechnicalInspection : IOperation
    {
        private Plane plane;
        
        public OperationTechnicalInspection(Plane plane) // -1 - первый попадание в техосмт
        {
            this.plane = plane;

            if (plane.isAfterTechnicalInspection()) //когда уже прошел
            {
                NotificationManager.getInstance().addNotification("Самолет " + plane.getModelID() + " уже прошел технический осмотр", NotificationType.Neutral);
                return;
            }
            if (plane.getCurrentState() == State.Hangar)
                plane.setCurrentState(State.TechnicalInspection);
        }

        public override bool execute() //другие случаи при техническом осмотре
        {
            if (plane.getCurrentState() != State.TechnicalInspection) return false;

            plane.setCurrentTechnicalInspectionProgress(plane.getCurrentTechnicalInspectionProgress() + 1);

            if (plane.getCurrentTechnicalInspectionProgress() >= plane.getTechnicalInspectionTime())
            {
                plane.setCurrentTechnicalInspectionProgress(0);

                if (plane.isTanked())
                {
                    plane.setAfterTechnicalInspection(true);
                    NotificationManager.getInstance().addNotification("Самолет " + plane.getModelID() + " прошел техосмотр", NotificationType.Positive);
                }
                else
                {
                    plane.setAfterTechnicalInspection(false);
                    NotificationManager.getInstance().addNotification("Самолет " + plane.getModelID() + " не прошел техосмотр", NotificationType.Negative);
                }

                plane.setCurrentState(State.Hangar);
                return false;
            }

            return true;
        }

        public override void stop() //остановка операции
        {
            plane.setCurrentTechnicalInspectionProgress(0);
            plane.setCurrentState(State.Hangar);
        }

        public override Plane getPlane() { return plane; }
    }
}
