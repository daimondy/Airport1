using Airport.AirportManagement;

namespace Airport.Planes
{
    //ПАССАЖИРСКИЙ САМОЛЕТ
    class PassengerPlane : Plane
    {
        private int maxNumberOfPassengers;
        private int currentNumberOfPassengers;

        public PassengerPlane( )
        {
            maxNumberOfPassengers = 0;
            currentNumberOfPassengers = 0;
        }
        
        public int getCurrentNumberOfPassengers() { return currentNumberOfPassengers; } //получение текущего количество пассажиров
        public int getMaxNumberOfPassengers() { return maxNumberOfPassengers; } //получение максимального значение пассажиров
        public void setCurrentNumberOfPassengers(int newNumberOfPassengers) { //установка числа текущих пассажиров
            currentNumberOfPassengers = newNumberOfPassengers;
            AirportManager.getInstance().refreshInformationPanelIfSelected(this);
        }
        public void setMaxNumberOfPassengers(int maxNumberOfPassengers) { this.maxNumberOfPassengers = maxNumberOfPassengers; } //установка максимального числа пассажиров
       
        public override string getInformation() //информация
        {
            string builtString = "";
            builtString += "Модель: " + getModel() + " (ID: " + getID() + ")\n";
            builtString += "Тип: самолет пассажирский \n";

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
                    builtString += "Состояние: " + "ввод пассажиров\n";
                    break;
                case State.Unloading:
                    builtString += "Состояние: " + "вывод пассажиров\n";
                    break;
                case State.Destroyed:
                    builtString += "Состояние: " + "разрушен\n";
                    break;

            }

            builtString += "Топливо: " + getCurrentFuelLevel() + "/" + getMaxFuelLevel() + "l\n";
            builtString += "Технический осмотр: " + (isAfterTechnicalInspection() ? "да" : "нет") + "\n";
            builtString += "Количество пассажиров: " + currentNumberOfPassengers + "/" + maxNumberOfPassengers + "\n";

            return builtString;
        }

        public override bool isEmpty() //когда пуст
        {
            if (currentNumberOfPassengers == 0) return true;
            else return false;
        }
    }
}
