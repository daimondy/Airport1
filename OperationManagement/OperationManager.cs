using Airport.Operations;
using Airport.Planes;
using System;
using System.Windows.Forms;

namespace Airport.OperationManagement
{
    //МЕНЕДЖЕР ОПЕРАЦИЙ
    public class OperationManager
    {
        private static OperationManager instance;

        public static void init(AppWindow handleAppWindow)
        {
            instance = new OperationManager(handleAppWindow);
        }

        public static OperationManager getInstance()
        {
            if (instance == null) throw new Exception("AirportManager не был инициализирован");
            return instance;
        }

        private Timer timer;
        private OperationList operationList;
        private OperationManager(AppWindow descriptorapplication)
        {
            timer = new Timer(); 
            timer.Tick += new EventHandler(onTimerTick);
            timer.Interval = Constants.intervalTimer;
            timer.Enabled = false; // таймер должен запускаться, когда список операций не пуст

            operationList = new OperationList();
        }

        private void executeOperationChain() //выполнение список операций
        {
            if(operationList.getFirst() == null)
            {
                stopTimer();
                return;
            }
            operationList.getFirst().doingOperation(operationList);
        }

        public void addOperation(IOperation o) //добавление операции
        {
            operationList.addElement(new OperationListElement(o));
            startTimer();
        }

        private OperationListElement get(IOperation o) //получение списка операций
        {
            operationList.iteratorToStart();
            if (operationList.currentAtIterator() == null) return null;
            if (operationList.currentAtIterator().operation == o) return operationList.currentAtIterator();

            while (operationList.iteratorHasNext())
            {
                operationList.iteratorNext();
                if (operationList.currentAtIterator().operation == o) return operationList.currentAtIterator();
            }
            return null;
        }
        private IOperation get(Plane airplane)
        {
            operationList.iteratorToStart();
            if (operationList.currentAtIterator() == null) return null;
            if (operationList.currentAtIterator().operation.getPlane() == airplane) return operationList.currentAtIterator().operation;

            while (operationList.iteratorHasNext())
            {
                operationList.iteratorNext();
                if (operationList.currentAtIterator().operation.getPlane() == airplane) return operationList.currentAtIterator().operation;
       
            }
            return null;
        }

        public void stopOperation(Plane airplane) //конец операции самолета
        {
            IOperation o = get(airplane);
            stopOperation(o);
        }
        public void stopOperation(IOperation o) //конец операции
        {
            o.stop();
            OperationListElement element = get(o);
            if(element != null) operationList.removeElement(element);
            
        }
        
        public void stopTimer() //остановка таймера
        {
            timer.Enabled = false;
        }
        public void startTimer() //запуск таймера
        {
            timer.Enabled = true;
        }

        private void onTimerTick(object sender, EventArgs e) //для таймера
        {
            executeOperationChain();    //выполнение метода для каждой операции в списке
        }

    }
}
