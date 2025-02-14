namespace FirstMiniHomework
{
    /// <summary>
    /// Класс хищника, наследуется от класса Animal
    /// </summary>
    public class Predator : Animal
    {
        protected Predator(int number, string name, int food) : base(number, name, food) { }
    }
}