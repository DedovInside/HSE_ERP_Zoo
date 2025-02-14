namespace FirstMiniHomework
{
    /// <summary>
    /// Класс кролика - наследник класса травоядных
    /// </summary>
    public class Rabbit : Herbo
    {
        public Rabbit(int number, string name, int food, int kindnessLevel) : base(number, name, food, kindnessLevel) { }
    }
}