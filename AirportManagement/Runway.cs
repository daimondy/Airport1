using Airport.Planes;
using System.Drawing;
using System.Windows.Forms;

namespace Airport.AirportManagement
{
    //посадочная полоса
    public class Runway
    {
        private Plane plane;

        private int maxX;
        private int maxY;
        private int xMoveIntervalTimer;
        private int xMoveInterval;
        private int yMoveIntervalTimer;
        private int yMoveInterval;
        private int dx, dy;
        private Control handlePanel;
        private int ID;

        public Runway(Control handlePanel, int ID)
        {
            this.handlePanel = handlePanel;
            maxX = this.handlePanel.Size.Width - Constants.planeImageSizeX;
            maxY = 40;
            this.ID = ID;
        }

        public int getID() { return ID; } //получаем ID самолета
        public void setPlane(Plane plane) //установка самолета в начале посадочной полосы
        {
            this.plane = plane;

            if (plane.getCurrentState() == State.OnRunwayBefTakeoff)
                plane.getPlaneImage().Location = new Point(0, 40);
            else if (plane.getCurrentState() == State.Landing)
                plane.getPlaneImage().Location = new Point(0, 0);

            xMoveInterval = plane.getTakeoffInterval();
            yMoveInterval = plane.getTakeoffInterval() * 3;
            xMoveIntervalTimer = 0;
            yMoveIntervalTimer = 0;

            this.plane.setParent(handlePanel);
            this.plane.show();
        }

        public void takeOffCurrentPlane() //взлет с текущего самолета
        {
            plane = null;
        }

        public bool tick() //счетчик и перемещение самолета
        {
            dx = 0;
            dy = 0;

            if (++xMoveIntervalTimer >= xMoveInterval)
            {
                if (plane.getPlaneImage().Location.X + 1 <= maxX)
                {
                    dx = 1;
                }
                else
                {
                    if (plane.getCurrentState() == State.Takeoff) takeOffCurrentPlane();
                    return false;
                }

                xMoveIntervalTimer = 0;
            }

            if (plane.getPlaneImage().Location.X >= maxX/2 && ++yMoveIntervalTimer >= yMoveInterval)
            {
                if (plane.getCurrentState() == State.Takeoff && plane.getPlaneImage().Location.Y - 1 >= 0) dy = -1;
                else if ((plane.getCurrentState() == State.Landing && plane.getPlaneImage().Location.Y + 1 <= maxY)) dy = 1;

                yMoveIntervalTimer = 0;
            }



            if (dx == 1 || dy == 1 || dy == -1)
                plane.getPlaneImage().Location = new Point(plane.getPlaneImage().Location.X + dx, plane.getPlaneImage().Location.Y + dy);

            return true;
        }

        public Plane getPlane() { return plane; } //появление самолета


        public bool isFree() //если свободно
        {
            if (plane == null) return true;
            else return false;
        }

    }
}
  