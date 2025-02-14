using Microsoft.Extensions.DependencyInjection;

namespace FirstMiniHomework
{
    internal static class Program
    {
        private static void Main()
        {
            IServiceCollection services = new ServiceCollection()
                .AddSingleton<VetClinic>()
                .AddSingleton<Zoo>();
            
            ServiceProvider serviceProvider = services.BuildServiceProvider();
            
            Zoo zoo = serviceProvider.GetRequiredService<Zoo>();
            
            List<string> existingTypesOfAnimals = new List<string> { "Predator", "Herbo" };
            List<string> existingPredatorSpecies = new List<string> {"Tiger", "Wolf"};
            List<string> existingHerboSpecies = new List<string> {"Rabbit", "Monkey"};
            List<string> existingTypesOfThings = new List<string> { "Computer", "Table" };
            
            
            Console.WriteLine("Здравствуйте. Добро пожаловать в сервис управления зоопарком.");
            Console.WriteLine("Нажмите любую клавишу, чтобы продолжить:");
            Console.ReadKey();
            
            Console.WriteLine("Выберите действие:");
            while (true)
            {
                Console.WriteLine("\u001b[36mУкажите номер пункта меню для запуска действия:\u001b[0m ");
                
                ConsoleKeyInfo key;
                int option = 1; // Начальный параметр для выделения первого действия.
                bool isSelected = false;
                string color = "\u001b[36m";

                Console.CursorVisible = false;
                // Создаём интерактивное меню.

                while (!isSelected)
                {
                    Console.Clear();
                    Console.WriteLine("\nИспользуйте клавиши \u001b[36mU\u001b[0m и \u001b[36mD\u001b[0m для навигации по меню и нажмите \u001b[36mEnter\u001b[0m, чтобы подтвердить выбор\n");
                    Console.WriteLine($"{(option == 1 ? color : "")}1. Добавить животное в зоопарк\u001b[0m");
                    Console.WriteLine($"{(option == 2 ? color : "")}2. Добавить вещь в зоопарк\u001b[0m");
                    Console.WriteLine($"{(option == 3 ? color : "")}3. Вывести необходимое количество еды животным в зоопарке\u001b[0m");
                    Console.WriteLine($"{(option == 4 ? color : "")}4. Вывести список животных, с которыми можно взаимодействовать в контактном зоопарке\u001b[0m");
                    Console.WriteLine($"{(option == 5 ? color : "")}5. Вывести информацию о всём, что стоит на балансе зоопарка\u001b[0m");
                    Console.WriteLine($"{(option == 6 ? color : "")}6. Выйти из программы\u001b[0m");
                    key = Console.ReadKey(true);

                    switch (key.Key)
                    {
                        case ConsoleKey.D:
                            option = option == 6 ? 1 : option + 1;
                            break;
                        case ConsoleKey.U:
                            option = option == 1 ? 6 : option - 1;
                            break;
                        case ConsoleKey.Enter:
                            isSelected = true;
                            break;
                    }
                    
                }
                
                Console.WriteLine($"\n{color}Вы выбрали действие {option}\u001b[0m");
                Console.CursorVisible = true;
                
                if (option == 1)
                {
                    ProcessesAddingAnimal.AddAnimal(zoo, existingTypesOfAnimals, existingPredatorSpecies, existingHerboSpecies );
                    Console.WriteLine("Нажмите любую клавишу, чтобы продолжить:");
                    Console.ReadKey();
                }

                if (option == 2)
                {
                    ProcessesAddingThing.AddThingToZoo(zoo, existingTypesOfThings);
                    Console.WriteLine("Нажмите любую клавишу, чтобы продолжить:");
                    Console.ReadKey();
                }
                
                if (option == 3)
                {
                    zoo.FoodConsumption();
                    Console.WriteLine("Нажмите любую клавишу, чтобы продолжить:");
                    Console.ReadKey();
                }
                
                if (option == 4)
                {
                    zoo.PrintInteractiveAnimals();
                    Console.WriteLine("Нажмите любую клавишу, чтобы продолжить:");
                    Console.ReadKey();
                }
                
                if (option == 5)
                {
                    zoo.PrintInventory();
                    Console.WriteLine("Нажмите любую клавишу, чтобы продолжить:");
                    Console.ReadKey();
                }
                
                if (option == 6)
                {
                    return;
                }
            }
        }
    }
}




