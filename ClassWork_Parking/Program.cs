using Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            var parkings = new List<Parking> { new Parking(), new Parking(), new Parking() };

            var sumCars = parkings.Sum(p => p.ClientList.Sum(c => c.OwnedCars.Count));

            var sumEngineCapacity = parkings
                .Sum(p => p.ClientList
                .Sum(cl => cl.OwnedCars
                .Sum(oc => oc.Engine.EngineCapacity)));

            var sumEngineCapacityBMW = parkings
                .Sum(p => p.ClientList
                .Sum(cl => cl.OwnedCars
                .Where(oc => oc.Manufacturer == Manufacturer.BMW).Sum(ec => ec.Engine.EngineCapacity)));


            var sumEngineHoursePowAudi = parkings
                .Sum(p => p.ClientList
                .Sum(cl => cl.OwnedCars
                .Where(oc => oc.Manufacturer == Manufacturer.Audi).Sum(eh => eh.Engine.HoursePower)));

            var ownersNamesFord = parkings
                .Where(p => (p.ClientList.Select Where(cl => cl.OwnedCars.Where(oc => oc.Manufacturer == Manufacturer.Ford).

            Console.WriteLine($"Sum of Engine Hourse Powers (Audi): {sumEngineHoursePowAudi}");

            Console.WriteLine($"Summary of Engine Capacity (BMW): {sumEngineCapacityBMW}");

            Console.WriteLine($"Sum of all Engine Capacity: {sumEngineCapacity}");

            Console.WriteLine($"Sum of all Cars: {sumCars}");

            Console.ReadKey();

        }

        public class Car
        {
            public Car()
            {
                Name = PredefinedCars.GetRandom();
                Manufacturer = (Manufacturer)Helper.Helper.GetRandomIndex(0, Enum.GetNames(typeof(Manufacturer)).Length);
                Engine = new Engine();
                ManufactureDate = DateTime.Now - TimeSpan.FromSeconds(Helper.Helper.GetRandomIndex(0, 10));
            }

            private string[] PredefinedCars = { "A7", "101", "CV7", "RX8", "XS6", "Trail4", "Skyline" };

            public string Name { get; set; }

            public Engine Engine { get; set; }

            public DateTime ManufactureDate { get; set; }

            public Manufacturer Manufacturer { get; set; }
        }

        public class Parking
        {
            private string[] PredefinedAddress = new[] { "Address1", "Address2", "Address3", "Address4" };
            private int[] PredefinedIds = { 0, 1, 2, 3, 4, 5, 6, 7 };
            private const int MinClientNumber = 100;

            public Parking()
            {
                Id = PredefinedIds.GetRandom();
                Address = PredefinedAddress.GetRandom();
                ClientList = new List<Person>();
                for (int i = 0; i < MinClientNumber; i++)
                {
                    ClientList.Add(new Person(i%20 != 0));
                }
            }


            public int Id { get; set; }

            public string Address { get; set; }

            public ICollection<Person> ClientList { get; set; }
        }

        public class Engine
        {
            public Engine()
            {
                Type = (EngineType)Helper.Helper.GetRandomIndex(0, Enum.GetNames(typeof(EngineType)).Length);
                HoursePower = (short)Helper.Helper.GetRandomIndex(100, 400);
                EngineCapacity = Helper.Helper.GetRandomIndex(1, 5);
            }

            public short HoursePower { get; set; }

            public EngineType Type { get; set; }

            public float EngineCapacity { get; set; }
        }

        public class Person
        {
            private string[] PredefinedNames = { "Bob", "Jim", "Bim", "Sam", "Roy", "Tim", "Joe" };
            private int[] PredefinedAges = { 21, 33, 19, 18, 66, 45, 43, 26 };

            public Person(bool hasOneCar = true)
            {
                Name = PredefinedNames[Helper.Helper.GetRandomIndex(0, PredefinedNames.Length, true)];
                Age = PredefinedAges[Helper.Helper.GetRandomIndex(0, PredefinedAges.Length, true)];
                OwnedCars = new List<Car>();
                for (int i = 0; i < (hasOneCar? 1:2); i++)
                {
                    OwnedCars.Add(new Car());
                }
            }

            public string Name { get; set; }

            public int Age { get; set; }

            public ICollection<Car> OwnedCars { get; set; }

        }

        public enum EngineType
        {
            Diesel,
            Petrol
        }

        public enum Manufacturer
        {
            Mercedes,
            BMW,
            Audi,
            Subaru,
            Toyota,
            Ford,
            Volkswagen,
            Tesla,
            Jaguar,
            KIA,
            Hyndai,
            Porshe
        }
    }
}
