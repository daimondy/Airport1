using Airport.Operations;

namespace Airport.OperationManagement
{
    //СПИСОК ЭЛЕМЕНТОВ
    class OperationListElement
    {
        public IOperation operation;
        public OperationListElement nextElement;
        public OperationListElement previousElement;

        public OperationListElement(IOperation o)
        {
            operation = o;
            nextElement = null;
            previousElement = null;
        }

        public void doingOperation(OperationList handleOperationList) 
        {
            if (!operation.execute())
                handleOperationList.removeElement(this);
          
            if(nextElement != null) nextElement.doingOperation(handleOperationList);
        }
    }
}
