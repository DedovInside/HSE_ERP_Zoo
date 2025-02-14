namespace FirstMiniHomework.Tests
{
    public class ZooTests
    {
        // Тест на проверку добавления здорового животного в зоопарк
        [Fact]
        public void AddAnimal_ShouldAddHealthyAnimal()
        {
            // Arrange
            VetClinic vetClinic = new ();
            Zoo zoo = new (vetClinic);
            Animal animal = new Tiger(1, "Simba", 20);
            animal.IsHealthy = true;


            // Act
            zoo.AddAnimal(animal);

            // Assert
            Assert.Contains(animal, zoo.Animals);
        }
        
        // Тест на проверку недобавления больного животного в зоопарк
        [Fact]
        public void AddAnimal_ShouldNotAddSickAnimal()
        {
            // Arrange
            VetClinic vetClinic = new ();
            Zoo zoo = new (vetClinic);
            Animal animal = new Tiger(1, "Simba", 20);
            animal.IsHealthy = false;

            // Act
            zoo.AddAnimal(animal);

            // Assert
            Assert.DoesNotContain(animal, zoo.Animals);
        }

        // Тест на проверку добавления стола в зоопарк
        [Fact]
        public void AddThing_ShouldAddTableToInventory()
        {
            // Arrange
            VetClinic vetClinic = new();
            Zoo zoo = new(vetClinic);
            Thing table = new Table(1, "IkeaTable");

            // Act
            zoo.AddThing(table);

            // Assert
            Assert.Contains(table, zoo.Inventory);
        }

        // Тест на проверку добавления компьютера в зоопарк
        [Fact]
        public void AddThing_ShouldAddComputerToInventory()
        {
            // Arrange
            VetClinic vetClinic = new ();
            Zoo zoo = new (vetClinic);
            Thing computer = new Computer(1, "Macbook");

            // Act
            zoo.AddThing(computer);

            // Assert
            Assert.Contains(computer, zoo.Inventory);
        }


        // Тест на проверку подсчета общего количества еды для всех животных в зоопарке
        [Fact]
        public void FoodConsumption_ShouldReturnTotalFood()
        {
            // Arrange
            VetClinic vetClinic = new ();
            Zoo zoo = new (vetClinic);
            Animal tiger = new Tiger(1, "Simba", 20);
            Animal rabbit = new Rabbit(2, "Bumba", 3, 8);
            Animal monkey = new Monkey(3, "Jack", 5, 7);
            Animal wolf = new Wolf(4, "Grey", 9);
            tiger.IsHealthy = true;
            rabbit.IsHealthy = true;
            monkey.IsHealthy = true;
            wolf.IsHealthy = true;
            zoo.AddAnimal(tiger);
            zoo.AddAnimal(rabbit);
            zoo.AddAnimal(monkey);
            zoo.AddAnimal(wolf);

            // Act
            int totalFood = zoo.FoodConsumption();

            // Assert
            Assert.Equal(37, totalFood);
        }
        
        // Тест на вывод животных, которые могут взаимодействовать с посетителями
        [Fact]
        public void PrintInteractiveAnimals_ShouldPrintInteractiveAnimals()
        {
            // Arrange
            VetClinic vetClinic = new ();
            Zoo zoo = new (vetClinic);
            Animal tiger = new Tiger(1, "Simba", 20);
            Animal rabbit = new Rabbit(2, "Bumba", 3, 8);
            Animal monkey = new Monkey(3, "Jack", 5, 7);
            Animal wolf = new Wolf(4, "Grey", 9);
            
            Animal unKindMonkey = new Monkey(5, "John", 5, 3);
            Animal unKindRabbit = new Rabbit(6, "Bimba", 3, 3);
            
            tiger.IsHealthy = true;
            rabbit.IsHealthy = true;
            monkey.IsHealthy = true;
            wolf.IsHealthy = true;
            unKindMonkey.IsHealthy = true;
            unKindRabbit.IsHealthy = true;
            zoo.AddAnimal(tiger);
            zoo.AddAnimal(rabbit);
            zoo.AddAnimal(monkey);
            zoo.AddAnimal(wolf);
            zoo.AddAnimal(unKindMonkey);
            zoo.AddAnimal(unKindRabbit);

            // Act
            List<Herbo> interactiveAnimals = zoo.PrintInteractiveAnimals();

            // Assert
            Assert.Contains(monkey, interactiveAnimals);
            Assert.Contains(rabbit, interactiveAnimals);
            Assert.DoesNotContain(unKindMonkey, interactiveAnimals);
            Assert.DoesNotContain(unKindRabbit, interactiveAnimals);
        }
        
        // Тест на вывод всего, что стоит на балансе зоопарка (животные и предметы)
        [Fact]
        public void PrintInventory_ShouldPrintCorrectInventory()
        {
            // Arrange
            VetClinic vetClinic = new();
            Zoo zoo = new(vetClinic);
            Animal tiger = new Tiger(1, "Виталий", 20);
            Animal rabbit = new Rabbit(2, "Степан", 3, 8);
            Thing computer = new Computer(1, "Macbook");
            Thing table = new Table(2, "IkeaTable");

            tiger.IsHealthy = true;
            rabbit.IsHealthy = true;
            zoo.AddAnimal(tiger);
            zoo.AddAnimal(rabbit);
            zoo.AddThing(computer);
            zoo.AddThing(table);

            using StringWriter sw = new();
            TextWriter originalOut = Console.Out;
            Console.SetOut(sw);

            try
            {
                // Act
                zoo.PrintInventory();

                // Assert
                string expectedOutput = "Инвентарь зоопарка:\n\r\n" +
                                        "Предметы:\n\r\n" +
                                        "Тип: Computer || Название: Macbook || Номер: 1\r\n" +
                                        "Тип: Table || Название: IkeaTable || Номер: 2\r\n\n\r\n" +
                                        "Животные:\n\r\n" +
                                        "Тип: Tiger || Имя: Виталий || Номер: 1\r\n" +
                                        "Тип: Rabbit || Имя: Степан || Номер: 2\r\n";
                string actualOutput = sw.ToString();
                Assert.Equal(expectedOutput, actualOutput);
            }
            finally
            {
                Console.SetOut(originalOut);
            }
        }
        
    }
}