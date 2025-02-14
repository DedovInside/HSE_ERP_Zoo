namespace FirstMiniHomework
{
    /// <summary>
    /// Класс, содержащий процессы добавления животных в зоопарк
    /// </summary>
    public static class ProcessesAddingAnimal
    {
        /// <summary>
        /// Основной метод по добавлению животного в зоопарк
        /// </summary>
        /// <param name="zoo"></param>
        /// <param name="existingTypesOfAnimals">Существующие на данный момент типы животных</param>
        /// <param name="existingPredatorSpecies">Существующие на данный момент виды хищников</param>
        /// <param name="existingHerboSpecies">Существующие на данный момент виды травоядных</param>
        public static void AddAnimal(Zoo zoo, List<string> existingTypesOfAnimals, List<string> existingPredatorSpecies, List<string> existingHerboSpecies)
        {
            Console.Write("Введите тип животного из текущих: ");
            Console.WriteLine(string.Join(", ", existingTypesOfAnimals));
            string? animalType = Console.ReadLine();
            if (animalType != null && existingTypesOfAnimals.Contains(animalType))
            {
                switch (animalType)
                {
                    case "Predator":
                        AddPredator(zoo, existingPredatorSpecies);
                        break;
                    case "Herbo":
                        AddHerbo(zoo, existingHerboSpecies);
                        break;
                }
            }
            else
            {
                Console.WriteLine("Такого типа животного нет в списке доступных типов. Повторите попытку.");
            }
        }
        
        
        /// <summary>
        /// Метод по добавлению хищника в зоопарк
        /// </summary>
        /// <param name="zoo">Зоопарк</param>
        /// <param name="existingPredatorSpecies">Существующие на данный момент виды хищников</param>
        private static void AddPredator(Zoo zoo, List<string> existingPredatorSpecies)
        {
            Console.WriteLine("Введите вид животного из текущих для типа Predator:");
            Console.WriteLine(string.Join(", ", existingPredatorSpecies));
            string? predatorSpecies = Console.ReadLine();
            if (predatorSpecies != null && existingPredatorSpecies.Contains(predatorSpecies))
            {
                string? name = GetAnimalName();
                if (name != null)
                {
                    if (TryGetAnimalNumber(out int number) && TryGetAnimalFood(out int food))
                    {
                        if (zoo.Animals.Any(a =>
                                a.GetType().Name == predatorSpecies && a.Name == name && a.Number == number))
                        {
                            Console.WriteLine("Животное с таким именем и номером уже есть в зоопарке.");
                        }
                        else
                        {
                            switch (predatorSpecies)
                            {
                                case "Tiger":
                                    zoo.AddAnimal(new Tiger(number, name, food));
                                    break;
                                case "Wolf":
                                    zoo.AddAnimal(new Wolf(number, name, food));
                                    break;
                            }
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Такого вида животного нет в списке доступных видов для типа Predator. Повторите попытку.");
            }
        }

        /// <summary>
        /// Метод по добавлению травоядного в зоопарк
        /// </summary>
        /// <param name="zoo">Зоопарк</param>
        /// <param name="existingHerboSpecies">Существующие на данный момент виды травоядных</param>
        private static void AddHerbo(Zoo zoo, List<string> existingHerboSpecies)
        {
            Console.WriteLine("Введите вид животного из текущих для типа Herbo:");
            Console.WriteLine(string.Join(", ", existingHerboSpecies));
            string? herboSpecies = Console.ReadLine();
            if (herboSpecies != null && existingHerboSpecies.Contains(herboSpecies))
            {
                string? name = GetAnimalName();
                if (name != null)
                {
                    if (TryGetAnimalNumber(out int number) && TryGetAnimalFood(out int food) && TryGetKindnessLevel(out int kindnessLevel))
                    {
                        if (zoo.Animals.Any(a => a.GetType().Name == herboSpecies && a.Name == name && a.Number == number))
                        {
                            Console.WriteLine("Животное с таким именем и номером уже есть в зоопарке.");
                        }
                        else
                        {
                            switch (herboSpecies)
                            {
                                case "Rabbit":
                                    zoo.AddAnimal(new Rabbit(number, name, food, kindnessLevel));
                                    break;
                                case "Monkey":
                                    zoo.AddAnimal(new Monkey(number, name, food, kindnessLevel));
                                    break;
                            }
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Такого вида животного нет в списке доступных видов для типа Herbo. Повторите попытку.");
            }
        }

        /// <summary>
        /// Получение имени животного
        /// </summary>
        /// <returns>Имя животного</returns>
        private static string? GetAnimalName()
        {
            Console.WriteLine("Введите имя животного:");
            string? name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Имя введено некорректно. Повторите попытку.");
                return null;
            }
            return name;
        }

        /// <summary>
        /// Получение номера животного (инвентарный номер)
        /// </summary>
        /// <param name="number"></param>
        /// <returns>Корректность ввода</returns>
        private static bool TryGetAnimalNumber(out int number)
        {
            Console.WriteLine("Введите номер животного:");
            if (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Номер введен некорректно. Повторите попытку.");
                return false;
            }
            return true;
        }
        
        /// <summary>
        /// Получение количества еды, которое потребляет животное
        /// </summary>
        /// <param name="food">Значение еды</param>
        /// <returns>Корректность ввода</returns>
        private static bool TryGetAnimalFood(out int food)
        {
            Console.WriteLine("Введите количество еды, которое потребляет животное:");
            if (!int.TryParse(Console.ReadLine(), out food))
            {
                Console.WriteLine("Количество еды введено некорректно. Повторите попытку.");
                return false;
            }
            return true;
        }

        private static bool TryGetKindnessLevel(out int kindnessLevel)
        {
            Console.WriteLine("Введите уровень доброты животного (от 1 до 10):");
            if (!int.TryParse(Console.ReadLine(), out kindnessLevel) || kindnessLevel < 1 || kindnessLevel > 10)
            {
                Console.WriteLine("Уровень доброты введен некорректно. Повторите попытку.");
                return false;
            }
            return true;
        }
    }
}