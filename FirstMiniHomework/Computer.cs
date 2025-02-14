namespace FirstMiniHomework 
{
    /// <summary>
    /// Класс компьютера
    /// </summary>
    public class Computer : Thing
    {
        /// <summary>
        /// Конструктор компьютера
        /// </summary>
        /// <param name="number">Инвентаризационный номер</param>
        /// <param name="name">Название компьютера</param>
        public Computer(int number, string name) : base(number, name) { }
    }
}