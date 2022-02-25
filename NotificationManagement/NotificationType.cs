
namespace Airport.NotificationManagement
{
    /*
     
    Типы уведомлений бывают в зависимости от характера
    Пример:
        -красный, когда событие было негативным (разбился самолет)
        -белый, нейтральный
        -зеленый, хорошее событие
     
     */
    public enum NotificationType
    {
        Neutral,Positive,Negative
    };
}
