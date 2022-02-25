using Airport.OperationManagement;
using Airport.Operations;
using Airport.Planes;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Airport.AirportManagement
{
    //ВОЗУШНОЕ ПРОСТРАНСТВО НАД АЭРОПОРТОМ
    public class Airspace
    {
        private List<Plane> airspaceContent;
        private Control handlePanel;
        private int firstColumnToDraw;
        private int columnCount;

        public Airspace(Control handlePanel, int columnCount)
        {
            this.handlePanel = handlePanel;
            airspaceContent = new List<Plane>();

            firstColumnToDraw = 0;
            this.columnCount = columnCount;
        }
        public void addToAirspace(Plane plane) //добавить самолет в воздушное прост
        {
            airspaceContent.Add(plane);
            plane.setParent(handlePanel);

            OperationManager.getInstance().addOperation(new OperationInAir(plane));
            redraw();
        }
        public void remove(Plane plane) //убрать из возд прост
        {
            airspaceContent.Remove(plane);
            plane.hide();
            redraw();
        }
        public void scrollLeft() //влево
        {
            if (firstColumnToDraw > 0)
            {
                firstColumnToDraw--;
                redraw();
            }
        }
        public void scrollRight() //вправо
        {
            if (airspaceContent.Count - columnCount > firstColumnToDraw)
            {
                firstColumnToDraw++;
                redraw();
            }
        }

        private Point getPosition(int i) //установить позицию
        {
            return new Point(Constants.interspaceSize * (i + 1) + i * Constants.planeImageSizeX,
                           10 + Constants.interspaceSize);
        }

        public void redraw() //перерисовка 
        {
            if (airspaceContent.Count == 0) return;

            int i = 0;

            int columnsToSkip = firstColumnToDraw;

            while (--columnsToSkip >= 0)
            {
               if (i >= airspaceContent.Count) return;

               airspaceContent.ElementAt(i).hide();
               i++;
            }
            
            for (int currentColumn = 0; currentColumn < columnCount; currentColumn++)
            {
                if (i >= airspaceContent.Count) return;

                airspaceContent.ElementAt(i).getPlaneImage().Location = getPosition(currentColumn);
                airspaceContent.ElementAt(i).show();

                i++;
            }

            for(; i < airspaceContent.Count; i++)
            {
                airspaceContent.ElementAt(i).hide();
            }
        }

        
        public List<Plane> getList() { return airspaceContent; }
    }
}
