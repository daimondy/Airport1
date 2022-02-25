using Airport.Planes;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Airport.AirportManagement
{
    //АНГАР
    public class Hangar
    {
        private List<Plane> hangarContent;
        private Control handlePanel;
        private int firstRowToDraw;
        private int rowCount;
        private int columnCount;

        public Hangar(Control handlePanel, int rowCount, int columnCount) {
            this.handlePanel = handlePanel;
            hangarContent = new List<Plane>();
            firstRowToDraw = 0;
            this.rowCount = rowCount;
            this.columnCount = columnCount;
        }

        public List<Plane> getList() { return hangarContent; }

        public void addToHangar(Plane plane) //добавление самолета в ангра
        {
            hangarContent.Add(plane);
            plane.setParent(handlePanel);
            redraw();
        }

        public void remove(Plane plane) //убрать самолет из ангара
        {
            hangarContent.Remove(plane);
            plane.hide();

            if (hangarContent.Count / columnCount - rowCount + 1 <= firstRowToDraw)
            {
                firstRowToDraw = hangarContent.Count / columnCount - rowCount;
            }

            redraw();
        }

        public void scrollUp() //поднять вверх панель ангара
        {
            if(firstRowToDraw > 0)
            {
                firstRowToDraw--;
                redraw();
            }
        }

        public void scrollDown() //опустить вниз панель ангара
        {
            if(hangarContent.Count / columnCount - rowCount + 1 > firstRowToDraw)
            {
                firstRowToDraw++;
                redraw();
            }
        }

        private Point getPosition(int i, int j) //установка позииции
        {
            return new Point(Constants.interspaceSize * (j + 1)
                            + j * Constants.planeImageSizeX,
                          10 + Constants.interspaceSize * (i + 1)
                          + i * Constants.planeImageSizeY);
        }

        public void redraw() //перерисовка
        {
            if (hangarContent.Count == 0) return;

            int i = 0, rowsToSkip = firstRowToDraw;

            while(--rowsToSkip >= 0)
            {
                for(int k = 0; k < columnCount; k++)
                {
                    if (i >= hangarContent.Count) return;
                    hangarContent.ElementAt(i).hide();
                    i++;
                }
            }

            int currentRow = 0, currentColumn = 0;
            for(;currentRow < rowCount; currentRow++)
            {
                for (currentColumn = 0; currentColumn < columnCount; currentColumn++)
                {
                    if (i >= hangarContent.Count) return;

                    hangarContent.ElementAt(i).getPlaneImage().Location = getPosition(currentRow, currentColumn);
                    hangarContent.ElementAt(i).show();
                    
                    i++;
                }
            }
        }
    }
}
