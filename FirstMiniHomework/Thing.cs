namespace FirstMiniHomework
{
    public abstract class Thing : IInventory
    {
        public int Number { get; set; }
        public string Name { get; set; }

        protected Thing(int number, string name)
        {
            Number = number;
            Name = name;
        }
    }
}