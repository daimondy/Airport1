namespace Airport.OperationManagement
{
    //СПИСОК ОПЕРАЦИЙ
    class OperationList
    {
        private OperationListElement first;
        private OperationListElement last;
        private OperationListElement iterator;

        public OperationList() //определение первой и последней операции
        {
            first = null;
            last = null;
        }
        public void iteratorToStart() //начало итерации
        {
            iterator = first;
        }
        public void iteratorNext() //следущая итерация
        {
            if (iterator.nextElement == null)
                iterator = first;
            else iterator = iterator.nextElement;
        }

        public OperationListElement getFirst() //получение первой операции из списка
        {
            return first;
        }

        public bool iteratorHasNext() //предыдущая итерация
        {
            if (iterator.nextElement == null) return false;
            return true;
        }
        public OperationListElement currentAtIterator() //текущая итерация
        {
            if (iterator == null) return null;
            return iterator;
        }
       
        public void addElement(OperationListElement element) //добавить элемент
        {
            if (first == null)
            {
                first = element;
                last = first;
            }
            else
            {
                last.nextElement = element;
                element.previousElement = last;
                last = element;
            }
        }

        public void removeElement(OperationListElement element) //убрать элемент
        {
            if(first == element)
            {
                element.operation.stop();

                if(first.nextElement == null)
                {
                    first = null;
                    last = null;
                    return;
                }

                first.nextElement.previousElement = null;
                first = first.nextElement;
                
                return;
            }

            OperationListElement iterator = first;

            while(iterator.nextElement != null)
            {
                iterator = iterator.nextElement;

                if(iterator == element)
                {
                    iterator.operation.stop();

                    if (iterator.nextElement == null)
                    {
                        last = iterator.previousElement;
                        iterator.previousElement.nextElement = null;
                        return;
                    }

                    iterator.nextElement.previousElement = iterator.previousElement;
                    iterator.previousElement.nextElement = iterator.nextElement;

                    return;

                }
            }
        }




    }
}
