using System;

namespace EventNotifications
{
    
    public interface INotification
    {
        void Send(string message);
    }

    
    public class SMSNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine($"Sending SMS: {message}");
        }
    }

    public class EmailNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine($"Sending Email: {message}");
        }
    }

    public class PushNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine($"Sending Push Notification: {message}");
        }
    }

    
    public class NotificationFactory
    {
        public static INotification CreateNotification(string type)
        {
            return type switch
            {
                "SMS" => new SMSNotification(),
                "Email" => new EmailNotification(),
                "Push" => new PushNotification(),
                _ => throw new ArgumentException("Unknown notification type.")
            };
        }
    }

    
    public class EventController
    {
        public void NotifyUsers(string message, string type)
        {
            try
            {
                INotification notification = NotificationFactory.CreateNotification(type);
                notification.Send(message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var controller = new EventController();
            controller.NotifyUsers("Evento próximo", "SMS");
            controller.NotifyUsers("Recordatorio de Evento", "Email");
            controller.NotifyUsers("Evento en curso", "Push");
        }
    }
}
