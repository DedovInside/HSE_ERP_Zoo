﻿namespace FirstMiniHomework
{
    /// <summary>
    /// Класс, содержащий процессы добавления вещей в зоопарк
    /// </summary>
    public static class ProcessesAddingThing
    {
        /// <summary>
        /// Основной метод по добавлению вещи в зоопарк
        /// </summary>
        /// <param name="zoo">Зоопарк, куда добавляем</param>
        /// <param name="existingTypesOfThings">Существующий список типов вещей</param>
        public static void AddThingToZoo(Zoo zoo, List<string> existingTypesOfThings)
        {
            Console.WriteLine("Введите тип вещи из текущих: ");
            Console.WriteLine(string.Join(", ", existingTypesOfThings));
            string? thingType = Console.ReadLine();
            if (thingType != null && existingTypesOfThings.Contains(thingType))
            {
                string? name = GetThingName();
                if (name != null)
                {
                    if (TryGetThingNumber(out int number))
                    {
                        AddThingByType(zoo, thingType, number, name);
                    }
                }
            }
            else
            {
                Console.WriteLine("Такого типа вещи нет в списке доступных типов. Повторите попытку.");
            }
        }

        /// <summary>
        /// Метод по получению наименования вещи
        /// </summary>
        /// <returns></returns>
        private static string? GetThingName()
        {
            Console.WriteLine("Введите наименование вещи:");
            string? name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Наименование вещи введено некорректно. Повторите попытку.");
                return null;
            }
            return name;
        }
        
        /// <summary>
        /// Метод по получению номера вещи и проверке его корректности
        /// </summary>
        /// <param name="number">Номер вещи</param>
        /// <returns>Корректность ввода</returns>
        private static bool TryGetThingNumber(out int number)
        {
            Console.WriteLine("Введите номер вещи:");
            if (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Номер введен некорректно. Повторите попытку.");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Метод по добавлению вещи в зоопарк по типу.
        /// </summary>
        /// <param name="zoo">Зоопарк</param>
        /// <param name="thingType">Тип вещи, введённый пользователем</param>
        /// <param name="number">Номер вещи</param>
        /// <param name="name">Наименование вещи</param>
        private static void AddThingByType(Zoo zoo, string thingType, int number, string name)
        {
            if (zoo.Inventory.Any(t => t.GetType().Name == thingType && t.Name == name && t.Number == number))
            {
                Console.WriteLine("Такая вещь уже есть в зоопарке.");
                return;
            }
            
            switch (thingType)
            {
                case "Computer":
                    zoo.AddThing(new Computer(number, name));
                    break;
                case "Table":
                    zoo.AddThing(new Table(number, name));
                    break;
            }
        }
    }
}