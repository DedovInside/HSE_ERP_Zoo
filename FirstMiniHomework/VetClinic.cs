namespace FirstMiniHomework
{
    /// <summary>
    /// Класс ветеринарной клиники
    /// </summary>
    public class VetClinic
    {
        /// <summary>
        /// Метод проверки здоровья животного
        /// </summary>
        /// <param name="animal">Животное, проходящее проверку</param>
        /// <returns>Возвращает статус животного: здоровое или больное</returns>
        public bool CheckAnimalHealth(Animal animal)
        {
            return animal.IsHealthy;
        }
    }
}