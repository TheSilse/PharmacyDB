using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;
using PharmacyDBCore.Database;
using PharmacyDBCore.Database.Models;

namespace PharmacyDBCore.Services
{
    public class DbInitializer
    {
        private static DatabaseContext _db;
        private static List<Appointment> _appointments;
        private static List<Client> _clients;
        private static List<Drug> _drugs;
        private static List<Employee> _employees;
        private static List<Order> _orders;
        private static List<Supplier> _suppliers;
        private static List<User> _users;
        static DbInitializer()
        {
            _db = new DatabaseContext();
        }

        public static void Init()
        {
            if (_db.Users.Count() != 0)
            {
                return;
            }
             _appointments = new List<Appointment>()
            {
                new Appointment()
                {
                    Id = 1,
                    Group = "H1-гистаминовых рецепторов блокатор",
                    Description = "Противоаллергический препарат. Блокатор гистаминовых H1-рецепторов, конкурентный антагонист гистамина, метаболит гидроксизина. Предупреждает развитие и облегчает течение аллергических реакций, обладает противозудным и антиэкссудативным действием."
                },
                new Appointment()
                {
                    Id = 2,
                    Group = "НПВП",
                    Description = "НПВС, производное фенилпропионовой кислоты. Оказывает противовоспалительное, анальгезирующее и жаропонижающее действие."
                },
                new Appointment()
                {
                    Id = 3,
                    Group = "Препарат для симптоматической терапии острых респираторных заболеваний",
                    Description = "Средство для устранения симптомов ОРЗ и \"простуды\" (анальгезирующее ненаркотическое средство+H1-гистаминовых рецепторов блокатор+витамин)"
                },
            };
             _clients = new List<Client>()
            {
                new Client()
                {
                    Id = 1,
                    Country = "Россия",
                    Address = "Москва, Павлова 35",
                    Name = "Виктор Сергеевич",
                    Telephone = "123-123-123"
                },
                new Client()
                {
                    Id = 2,
                    Country = "Россия",
                    Address = "Воронеж, Пушкина 31",
                    Name = "Михаил Павлович",
                    Telephone = "123-123-321"
                },
                new Client()
                {
                    Id = 3,
                    Country = "Россия",
                    Address = "Москва, Гагарина 35",
                    Name = "Евгений Александрович",
                    Telephone = "123-321-231"
                },
                new Client()
                {
                    Id = 4,
                    Country = "Россия",
                    Address = "Калининград, Маркова 15",
                    Name = "Юлия Дмитриевна",
                    Telephone = "121-222-123"
                },
                new Client()
                {
                    Id = 5,
                    Country = "Россия",
                    Address = "Владивосток, Мичурина 45",
                    Name = "Арсений Владиславович",
                    Telephone = "333-111-222"
                },
            };
            _suppliers = new List<Supplier>()
            {
                new Supplier()
                {
                    Id = 1,
                    Address = "Гагарина 131",
                    City = "Москва",
                    Country = "Россия",
                    Name = "Евгений",
                    Representative = "ООО Фармо-склад",
                    TelephoneNumber = "444-555-444"

                },
                new Supplier()
                {
                    Id = 2,
                    Address = "Фрунзе 12",
                    City = "Ростов на Дону",
                    Country = "Россия",
                    Name = "Виктор",
                    Representative = "ООО Лекарства на Дону",
                    TelephoneNumber = "444-111-444"

                }
            };
            _drugs = new List<Drug>()
            {
                new Drug()
                {
                    Id = 1,
                    AppointmentId = 1,
                    Appointment = _appointments[0],
                    Count = 2,
                    Name = "Зиртек",
                    Price = 331,
                    Supplier = _suppliers[0],
                    SupplierId = 1
                },
                new Drug()
                {
                    Id = 2,
                    AppointmentId = 1,
                    Appointment = _appointments[0],
                    Count = 2,
                    Name = "Зодак",
                    Price = 123,
                    Supplier = _suppliers[0],
                    SupplierId = 1
                },
                new Drug()
                {
                    Id = 3,
                    AppointmentId = 1,
                    Appointment = _appointments[0],
                    Count = 3,
                    Name = "Эриус",
                    Price = 123,
                    Supplier = _suppliers[1],
                    SupplierId = 2
                },
                new Drug()
                {
                    Id = 4,
                    AppointmentId = 1,
                    Appointment = _appointments[0],
                    Count = 5,
                    Name = "Супрастин",
                    Price = 123,
                    Supplier = _suppliers[1],
                    SupplierId = 2
                },
                new Drug()
                {
                    Id = 5,
                    AppointmentId = 2,
                    Appointment = _appointments[1],
                    Count = 5,
                    Name = "Нурофен",
                    Price = 300,
                    Supplier = _suppliers[0],
                    SupplierId = 1
                },
                new Drug()
                {
                    Id = 6,
                    AppointmentId = 2,
                    Appointment = _appointments[1],
                    Count = 1,
                    Name = "Ибупрофен",
                    Price = 441,
                    Supplier = _suppliers[0],
                    SupplierId = 1
                },
                new Drug()
                {
                    Id = 7,
                    AppointmentId = 2,
                    Appointment = _appointments[1],
                    Count = 3,
                    Name = "Миг",
                    Price = 501,
                    Supplier = _suppliers[1],
                    SupplierId = 2
                },
                new Drug()
                {
                    Id = 8,
                    AppointmentId = 3,
                    Appointment = _appointments[2],
                    Count = 2,
                    Name = "АнтиФлу",
                    Price = 712,
                    Supplier = _suppliers[0],
                    SupplierId = 1
                },
                new Drug()
                {
                    Id = 9,
                    AppointmentId = 3,
                    Appointment = _appointments[2],
                    Count = 2,
                    Name = "Антигриппин",
                    Price = 212,
                    Supplier = _suppliers[0],
                    SupplierId = 1
                },
                new Drug()
                {
                    Id = 10,
                    AppointmentId = 3,
                    Appointment = _appointments[2],
                    Count = 3,
                    Name = "ДезГриппин",
                    Price = 312,
                    Supplier = _suppliers[1],
                    SupplierId = 2
                },
            };
            _employees = new List<Employee>()
            {
                new Employee()
                {
                    Id = 1,
                    Name = "Евгений",
                    SecondName = "Ермолов",
                    MiddleName = "Анатольевич",
                    Telephone = "111-111-567",
                    Position = "Аптекарь",
                    Salary = 15000
                },
                new Employee()
                {
                    Id = 2,
                    Name = "Лидия",
                    SecondName = "Петрова",
                    MiddleName = "Валериевна",
                    Telephone = "121-999-567",
                    Position = "Уборщик",
                    Salary = 11000
                },
            };
            _orders = new List<Order>()
            {
                new Order()
                {
                    Id = 1,
                    Recipient = "Виктор Евгеньевич",
                    RecipientCountry = "Россия",
                    RecipientCity = "Москва",
                    RecipientAddress = "Кирова 13",
                    Date = "13.12.2019",
                    DeliveryCost = 1231,
                    Client = _clients[0],
                    ClientId = 1,
                    Employee = _employees[0],
                    EmployeeId = 1
                },
                new Order()
                {
                    Id = 2,
                    Recipient = "Иван Федорович",
                    RecipientCountry = "Россия",
                    RecipientCity = "Сыктывкар",
                    RecipientAddress = "Гагарина 13",
                    Date = "23.11.2019",
                    DeliveryCost = 3221,
                    Client = _clients[1],
                    ClientId = 2,
                    Employee = _employees[0],
                    EmployeeId = 1
                },
                new Order()
                {
                    Id = 3,
                    Recipient = "Василий Николаевич",
                    RecipientCountry = "Россия",
                    RecipientCity = "Москва",
                    RecipientAddress = "Ленина 54",
                    Date = "11.9.2019",
                    DeliveryCost = 551,
                    Client = _clients[2],
                    ClientId = 3,
                    Employee = _employees[0],
                    EmployeeId = 1
                },
            };
            _users = new List<User>()
            {
                new User()
                {
                    Id = 1,
                    Login = "admin",
                    Password = "21232f297a57a5a743894a0e4a801fc3"
                }
            };
            foreach (var item in _appointments)
            {
                _db.Appointments.Add(item);
            }
            foreach (var item in _clients)
            {
                _db.Clients.Add(item);
            }
            foreach (var item in _suppliers)
            {
                _db.Suppliers.Add(item);
            }
            foreach (var item in _drugs)
            {
                _db.Drugs.Add(item);
            }
            foreach (var item in _employees)
            {
                _db.Employees.Add(item);
            }
            foreach (var item in _orders)
            {
                _db.Orders.Add(item);
            }
            foreach (var item in _users)
            {
                _db.Users.Add(item);
            }
            _db.SaveChanges();
        }
    }
}
