namespace FirstMiniHomework
{

    public abstract class Animal : IAlive, IInventory
    {
        public int Food { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public bool IsHealthy { get; set; }

        protected Animal(int number, string name, int food)
        {
            Number = number;
            Name = name;
            Food = food;
            IsHealthy = new Random().Next(2) == 0;
        }
    }
}