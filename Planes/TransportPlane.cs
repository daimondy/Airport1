using System;
using Airport.AirportManagement;

namespace Airport.Planes
{
    //ТРАНСПОРТНЫЙ САМОЛЕТ
    class TransportPlane : Plane
    {
        private int maxStorageCapacity;
        private int currentStorageContent;
        

        public TransportPlane()
        { }

        public int getMaxStorageCapacity() { return maxStorageCapacity; }
        public void setMaxStorageCapacity(int maxStorageCapacity) { this.maxStorageCapacity = maxStorageCapacity; }

        public int getCurrentStorageContent() { return currentStorageContent;}
        public void setCurrentStorageContent(int storageContent) {
            currentStorageContent = storageContent;
            AirportManager.getInstance().refreshInformationPanelIfSelected(this);
        }

        
        public override string getInformation() //информация
        {
            string builtString = "";

            builtString += "Модель: " + getModel() + " (ID: " + getID() + ")\n";
            builtString += "Тип: самолет транспортный\n";

            switch (getCurrentState())
            {
                case State.Hangar:
                    builtString += "Состояние: " + "в ангаре\n";
                    break;
                case State.Fueling:
                    builtString += "Состояние: " + "заправка\n";
                    break;
                case State.TechnicalInspection:
                    builtString += "Состояние: " + "во время технического осмотра\n";
                    break;
                case State.InAir:
                    builtString += "Состояние: " + "в полете над аэропортом\n";
                    break;
                case State.Landing:
                    builtString += "Состояние: " + "посадка\n";
                    break;
                case State.OnRunwayAftLanding:
                    builtString += "Состояние: " + "после посадки\n";
                    break;
                case State.OnRunwayBefTakeoff:
                    builtString += "Состояние: " + "перед полетом\n";
                    break;
                case State.Takeoff:
                    builtString += "Состояние: " + "в полете\n";
                    break;
                case State.Loading:
                    builtString += "Состояние: " + "погрузка товаров\n";
                    break;
                case State.Unloading:
                    builtString += "Состояние: " + "выгрузка пассажиров\n";
                    break;
                case State.Destroyed:
                    builtString += "Состояние: " + "разрушен\n";
                    break;
            }

            builtString += "Топливо: " + getCurrentFuelLevel() + "/" + getMaxFuelLevel() + "l\n";
            builtString += "Технический осмотр: " + (isAfterTechnicalInspection() ? "да" : "нет") + "\n";
            builtString += "Загруженность: " + currentStorageContent + "/" + maxStorageCapacity + "кг\n";

            return builtString;
        }

        public override bool isEmpty()
        {
            if (currentStorageContent == 0) return true;
            else return false;
        }
    }
}
