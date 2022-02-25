using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport

{
    //КОНСТАНТЫ С ИЗОБРАЖЕНИЯМИ
    public static class ImageConstants
    {
        public static List<string> passengerPlaneNames;
        public static List<string> transportPlaneNames;
        public static List<string> militaryPlaneNames;

        public const string adressSelectedMark = "selection";
        public const string adressFueling = "btnFuel";
        public const string adressTechnicalInspection = "techmanag";

        public static void init()
        {
            passengerPlaneNames = new List<string>();
            transportPlaneNames = new List<string>();
            militaryPlaneNames = new List<string>();

            passengerPlaneNames.Add("p1");
            passengerPlaneNames.Add("p2");
            passengerPlaneNames.Add("p3");
            passengerPlaneNames.Add("p4");
            passengerPlaneNames.Add("p5");
            passengerPlaneNames.Add("p6");
 //           passengerPlaneNames.Add("p7");

            transportPlaneNames.Add("t1");
            transportPlaneNames.Add("t2");
            transportPlaneNames.Add("t3");

            militaryPlaneNames.Add("m1");
            militaryPlaneNames.Add("m2");
            militaryPlaneNames.Add("m3");
        }
    }
}
