/*
 Разработать в среде Visual Studio в соответствии со своим вариантом
консольную программу, которая предоставляет модуль с необходимыми
функциями для работы с динамической структурой данных, элементом
которой является структура, в соответствии с номером варианта:
Динамическая структура данных содержит информацию о

--------------------------------------------------------------------

Заявки на авиабилеты:
• Пункт назначения;
• Номер рейса;
• Сведения о пассажире: фамилия, имя, отчество и номер паспорта
(как отдельные свойства структуры Пассажир);
• Желаемая дата вылета.
Модуль должен иметь возможность: хранить и выводить все
заявки в виде очереди, добавлять новую заявку, удалять заявку,
выводить все заявки по заданному номеру рейса и дате вылета.
 
 
 */



using FlightBookingSystem;


namespace FlightBookingSystem
{
    public struct Passenger
    {
        public string LastName;
        public string FirstName;
        public string MiddleName;
        public string PassportNumber;
    }

    public struct FlightRequest
    {
        public string Destination;
        public string FlightNumber;
        public Passenger passenger;
        public DateTime DepartureDate;
    }

    public class FlightRequestQueue
    {
        private Queue<FlightRequest> requests = new Queue<FlightRequest>();

        // Добавить новую заявку
        public void AddRequest(FlightRequest request)
        {
            requests.Enqueue(request);
            Console.WriteLine("Заявка добавлена.");
        }

        // Удалить заявку (извлекает из начала очереди)
        public void RemoveRequest()
        {
            if (requests.Count > 0)
            {
                var removedRequest = requests.Dequeue();
                Console.WriteLine($"Заявка на рейс {removedRequest.FlightNumber} удалена.");
            }
            else
            {
                Console.WriteLine("Очередь пуста. Невозможно удалить заявку.");
            }
        }

        // Вывод всех заявок
        public void DisplayAllRequests()
        {
            if (requests.Count == 0)
            {
                Console.WriteLine("Нет заявок для отображения.");
                return;
            }

            Console.WriteLine("Все заявки:");
            foreach (var request in requests)
            {
                Console.WriteLine($"Рейс: {request.FlightNumber}, Пункт назначения: {request.Destination}, " +
                    $"Пассажир: {request.passenger.LastName} {request.passenger.FirstName} {request.passenger.MiddleName}, " +
                    $"Номер паспорта: {request.passenger.PassportNumber}, Дата вылета: {request.DepartureDate.ToShortDateString()}");
            }
        }

        // Вывод заявок по номеру рейса и дате
        public void DisplayRequestsByFlightAndDate(string flightNumber, DateTime date)
        {
            var foundRequests = new List<FlightRequest>();

            foreach (var request in requests)
            {
                if (request.FlightNumber == flightNumber && request.DepartureDate.Date == date.Date)
                {
                    foundRequests.Add(request);
                }
            }

            if (foundRequests.Count == 0)
            {
                Console.WriteLine("Заявки не найдены.");
                return;
            }

            Console.WriteLine("Найденные заявки:");
            foreach (var request in foundRequests)
            {
                Console.WriteLine($"Рейс: {request.FlightNumber}, Пункт назначения: {request.Destination}, " +
                    $"Пассажир: {request.passenger.LastName} {request.passenger.FirstName} {request.passenger.MiddleName}, " +
                    $"Номер паспорта: {request.passenger.PassportNumber}, Дата вылета: {request.DepartureDate.ToShortDateString()}");
            }
        }
    }
}


class Program
{
    static void Main(string[] args)
    {
        FlightRequestQueue queue = new FlightRequestQueue();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1. Добавить заявку");
            Console.WriteLine("2. Удалить заявку");
            Console.WriteLine("3. Показать все заявки");
            Console.WriteLine("4. Показать заявки по номеру рейса и дате");
            Console.WriteLine("0. Выход");
            Console.Write("Выберите действие: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    FlightRequest request = new FlightRequest();

                    Console.Write("Введите пункт назначения: ");
                    request.Destination = Console.ReadLine();

                    Console.Write("Введите номер рейса: ");
                    request.FlightNumber = Console.ReadLine();

                    Console.Write("Введите фамилию пассажира: ");
                    request.passenger.LastName = Console.ReadLine();

                    Console.Write("Введите имя пассажира: ");
                    request.passenger.FirstName = Console.ReadLine();

                    Console.Write("Введите отчество пассажира: ");
                    request.passenger.MiddleName = Console.ReadLine();

                    Console.Write("Введите номер паспорта: ");
                    request.passenger.PassportNumber = Console.ReadLine();

                    Console.Write("Введите желаемую дату вылета (yyyy-mm-dd): ");
                    if (DateTime.TryParse(Console.ReadLine(), out DateTime departureDate))
                    {
                        request.DepartureDate = departureDate;
                        queue.AddRequest(request);
                    }
                    else
                    {
                        Console.WriteLine("Неверный формат даты.");
                    }
                    break;

                case "2":
                    queue.RemoveRequest();
                    break;

                case "3":
                    queue.DisplayAllRequests();
                    break;

                case "4":
                    Console.Write("Введите номер рейса: ");
                    string flightNum = Console.ReadLine();

                    Console.Write("Введите дату вылета (yyyy-mm-dd): ");
                    if (DateTime.TryParse(Console.ReadLine(), out DateTime searchDate))
                    {
                        queue.DisplayRequestsByFlightAndDate(flightNum, searchDate);
                    }
                    else
                    {
                        Console.WriteLine("Неверный формат даты.");
                    }
                    break;

                case "0":
                    running = false;
                    Console.WriteLine("Выход из программы.");
                    break;

                default:
                    Console.WriteLine("Некорректный выбор. Пожалуйста, попробуйте еще раз.");
                    break;
            }
        }
    }
}