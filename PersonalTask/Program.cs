namespace Lab5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Bike Factory!");
            Console.WriteLine("Choose your bike manufacturer:");
            Console.WriteLine("1. Trek");
            Console.WriteLine("2. Giant");

            IBikeFactory factory = null;
            string manufacturerChoice = Console.ReadLine();

            switch (manufacturerChoice)
            {
                case "1":
                    factory = new TrekFactory();
                    break;
                case "2":
                    factory = new GiantFactory();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Exiting program.");
                    return;
            }

            while (true)
            {
                Console.WriteLine("Choose your bike type:");
                Console.WriteLine("1. Sport Bike");
                Console.WriteLine("2. Casual Bike");
                Console.WriteLine("Type 'exit' to quit.");

                string bikeTypeChoice = Console.ReadLine();

                if (bikeTypeChoice.ToLower() == "exit")
                    break;

                switch (bikeTypeChoice)
                {
                    case "1":
                        ISportBike sportBike = factory.CreateSportBike();
                        sportBike.RideFast();
                        break;
                    case "2":
                        ICasualBike casualBike = factory.CreateCasualBike();
                        casualBike.Ride();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }

            Console.WriteLine("Thank you for visiting the Bike Factory!");
        }
    }
    public interface IBikeFactory
    {
        ISportBike CreateSportBike();
        ICasualBike CreateCasualBike();
    }
    public interface ISportBike
    {
        void RideFast();
    }
    public class FXSport : ISportBike
    {
        public void RideFast()
        {
            Console.WriteLine("You ride fast Trek FX Sport");
        }
    }
    public class FastRoad : ISportBike
    {
        public void RideFast()
        {
            Console.WriteLine("You ride fast Giant FastRoad");
        }
    }

    public interface ICasualBike
    {
        void Ride();
    }
    public class Verse : ICasualBike
    {
        public void Ride()
        {
            Console.WriteLine("You ride casually Trek Verse");
        }
    }
    public class Escape : ICasualBike
    {
        public void Ride()
        {
            Console.WriteLine("You ride casually Giant Escape");
        }
    }

    public class TrekFactory : IBikeFactory
    {
        public ICasualBike CreateCasualBike() => new Verse();

        public ISportBike CreateSportBike() => new FXSport();
    }
    public class GiantFactory : IBikeFactory
    {
        public ICasualBike CreateCasualBike() => new Escape();

        public ISportBike CreateSportBike() => new FastRoad();
    }
}
