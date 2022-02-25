using Airport.AirportManagement;

namespace Airport.Planes
{
    //ВОЕННЫЙ САМОЛЕТ
    class MilitaryPlane : Plane
    {
        private string weaponType;
        private int maxAmmo;
        private int currentAmmo;

        public MilitaryPlane()
        { }
        public void setWeaponType(string weaponType) { this.weaponType = weaponType; } //установка типа оружия

        public int getMaxAmmo() { return maxAmmo; } //максимальное число боеприпасов
        public void setMaxAmmo(int maxAmmo) { this.maxAmmo = maxAmmo; } //установка максимального числа боеприпасов

        public int getCurrentAmmo() { return currentAmmo; } //текущее число боеприпасов
        public void setCurrentAmmo(int currentAmmo) { //установка текущего числа боеприпасов
            this.currentAmmo = currentAmmo;
            AirportManager.getInstance().refreshInformationPanelIfSelected(this);
        }


        public override string getInformation() //информация о самолете
        {
            string builtString = "";

            builtString += "Модель: " + getModel() + " (ID: " + getID() + ")\n";
            builtString += "Тип: военный самолет\n";

            switch (getCurrentState())
            {
                case State.Hangar:
                    builtString += "Состояние: " + "в ангаре\n";
                    break;
                case State.Fueling:
                    builtString += "Состояние: " + "заправляется\n";
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
                    builtString += "Состояние: " + "погрузка\n";
                    break;
                case State.Unloading:
                    builtString += "Состояние: " + "разгрузка\n";
                    break;
                case State.Destroyed:
                    builtString += "Состояние: " + "унижтожен\n";
                    break;

            }

            builtString += "Количество топлива: " + getCurrentFuelLevel() + "/" + getMaxFuelLevel() + "l\n";
            builtString += "Технический осмотр: " + (isAfterTechnicalInspection() ? "да" : "нет") + "\n";
            builtString += "Тип оружия: " + weaponType + "\n";
            builtString += "Количество боеприпасов: " + currentAmmo + "/" + maxAmmo + "\n";

            return builtString;
        }
        
        public override bool isEmpty() //когда пуст
        {
            if (currentAmmo == 0) return true;
            else return false;
        }
    }
}
