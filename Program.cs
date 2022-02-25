using System;
using System.Windows.Forms;
using Airport.Planes;
using Airport.AirportManagement;
using Airport.OperationManagement;
using System.Xml;
using Airport.Properties;

namespace Airport
{
    //ОСНОВНОЕ ТЕЛО ПРОГРАММЫ
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AppWindow appWindow = new AppWindow();
            

            ImageConstants.init();
            AirportManager.init(appWindow);
            OperationManager.init(appWindow);

            Application.Run(appWindow);
        }

        static public int howManyInFile() //чтение данных о самолете из файла
        {
            XmlDocument xDoc = new XmlDocument();

            xDoc.LoadXml(Resources.DefinedPlanes);
            return Int32.Parse(xDoc.SelectSingleNode("Planes/NumberOfPlanes").InnerText);
        }


        // Считывает самолет с заданным идентификатором из xml-файла с самолетами
        static public Plane readFromFile(int id)
        {
            XmlDocument xDoc = new XmlDocument();
            
            xDoc.LoadXml(Resources.DefinedPlanes);

            Plane loadedPlane;

            XmlNodeList planeNodes = xDoc.SelectNodes("Planes/Plane");
            foreach(XmlNode node in planeNodes)
            {
                if(Int32.Parse(node.Attributes.GetNamedItem("id").Value) == id)
                {
                    string type = node.SelectSingleNode("Type").InnerText;

                    if (type == "PassengerPlane")
                    {
                        loadedPlane = new PassengerPlane();
                        ((PassengerPlane)loadedPlane).setMaxNumberOfPassengers(Int32.Parse(node.SelectSingleNode("MaxPassengers").InnerText));
                    }
                    else if (type == "MilitaryPlane")
                    {
                        loadedPlane = new MilitaryPlane();
                        ((MilitaryPlane)loadedPlane).setMaxAmmo(Int32.Parse(node.SelectSingleNode("MaxAmmo").InnerText));
                        ((MilitaryPlane)loadedPlane).setWeaponType(node.SelectSingleNode("WeaponType").InnerText);

                    }
                    else if (type == "TransportPlane")
                    {
                        loadedPlane = new TransportPlane();
                        ((TransportPlane)loadedPlane).setMaxStorageCapacity(Int32.Parse(node.SelectSingleNode("MaxStorage").InnerText));
                    }
                    else return null;

                    loadedPlane.setModel(node.SelectSingleNode("Model").InnerText);
                    loadedPlane.setMaxFuelLevel(Int32.Parse(node.SelectSingleNode("MaxFuelLevel").InnerText));
                    loadedPlane.setFuelUsage(Int32.Parse(node.SelectSingleNode("FuelUsage").InnerText));
                    loadedPlane.setTakeoffTime(Int32.Parse(node.SelectSingleNode("TakeoffInterval").InnerText));
                    loadedPlane.setPlaneImage(node.SelectSingleNode("Image").InnerText);

                    return loadedPlane;
                }
                

            }

            return null;
            
        }
        
    }
}
