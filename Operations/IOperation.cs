using Airport.Planes;

namespace Airport.Operations
{
    public abstract class IOperation // алгоритм, который запускает каждый тик таймера. false после последнего выполнения
    {
  
        public abstract bool execute(); // алгоритм для выполнения при нестандартной остановке операции
    
        public abstract void stop(); //остановка операции
        
        public abstract Plane getPlane();
    }
}
