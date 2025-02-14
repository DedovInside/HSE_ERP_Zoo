namespace FirstMiniHomework
{
    public abstract class Herbo : Animal
    {
        public int KindnessLevel { get; private set; }

        protected Herbo(int number, string name, int food, int kindnessLevel) : base(number, name, food)
        {
            KindnessLevel = kindnessLevel;
        }
    }
}