using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Planes
{
    /*
     
     Класс, описывающий состояние самолета

     */
    public enum State
    {
        Hangar, TechnicalInspection, Fueling, Takeoff, InAir,
        Destroyed, OnRunwayBefTakeoff, Landing, OnRunwayAftLanding,
        Loading, Unloading
    };
}