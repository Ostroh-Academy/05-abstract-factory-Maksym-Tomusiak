namespace AbstractFactoryExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Run africa factory:");
            var africa = new AnimalWorld<Africa>();
            africa.RunFoodChain();

            Console.WriteLine("\nRun america factory");
            var america = new AnimalWorld<America>();
            america.RunFoodChain();

            Console.ReadLine();
        }
    }
    public interface IContinentFactory
    {
        IHerbivore CreateHerbivore();
        ICarnivore CreateCarnivore();
    }
    public interface IHerbivore
    {
    }
    public class Wildebeest : IHerbivore
    {
    }
    public class Bison: IHerbivore
    {
    }

    public interface ICarnivore
    {
        void Eat(IHerbivore h);
    }
    public class Lion : ICarnivore
    {
        public void Eat(IHerbivore h)
        {
            Console.WriteLine($"{GetType().Name} eats {h.GetType().Name}");
        }
    }
    public class Wolf : ICarnivore
    {
        public void Eat(IHerbivore h)
        {
            Console.WriteLine($"{GetType().Name} eats {h.GetType().Name}");
        }
    }

    public class Africa : IContinentFactory
    {
        public IHerbivore CreateHerbivore() => new Wildebeest();

        public ICarnivore CreateCarnivore() => new Lion();
    }
    public class America : IContinentFactory
    {
        public IHerbivore CreateHerbivore() => new Bison();

        public ICarnivore CreateCarnivore() => new Wolf();
    }
    public interface IAnimalWorld
    {
        void RunFoodChain();
    }
    public class AnimalWorld<T> : IAnimalWorld where T : IContinentFactory, new()
    {
        private readonly IHerbivore _herbivore;
        private readonly ICarnivore _carnivore;
        public AnimalWorld()
        {
            var factory = new T();

            _carnivore = factory.CreateCarnivore();
            _herbivore = factory.CreateHerbivore();
        }
        public void RunFoodChain()
        {
            _carnivore.Eat(_herbivore);
        }
    }
}
