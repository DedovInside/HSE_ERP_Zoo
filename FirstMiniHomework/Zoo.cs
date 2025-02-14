namespace FirstMiniHomework
{

    public class Zoo
    {
        private List<Animal> _animals = new();
        private List<Thing> _inventory = new();
        private readonly VetClinic _vetClinic;

        public Zoo(VetClinic vetClinic)
        {
            _vetClinic = vetClinic;
        }

        public IReadOnlyList<Animal> Animals => _animals;
        public IReadOnlyList<Thing> Inventory => _inventory;

        public void AddAnimal(Animal animal)
        {
            if (_vetClinic.CheckAnimalHealth(animal))
            {
                _animals.Add(animal);
                Console.WriteLine(new string('-', 25));
                Console.WriteLine($"Животное {animal.Name} добавлено в зоопарк");
                Console.WriteLine(new string('-', 25));
            }
            else
            {
                Console.WriteLine(new string('-', 25));
                Console.WriteLine($"Животное {animal.Name} не добавлено в зоопарк по причине болезни");
                Console.WriteLine(new string('-', 25));
            }
        }

        public void AddThing(Thing thing)
        {
            _inventory.Add(thing);
            Console.WriteLine($"Предмет {thing.Name} добавлен в инвентарь зоопарка");
        }

        public int FoodConsumption()
        {
            if (_animals.Count == 0)
            {
                Console.WriteLine("В зоопарке нет животных, поэтому еды не требуется");
                return 0;
            }
            int totalFood = _animals.Sum(animal => animal.Food);
            Console.WriteLine($"Общее количество потребляемой животными из зоопарка еды: {totalFood}");
            return totalFood;
        }

        public List<Herbo> PrintInteractiveAnimals()
        {
            List<Herbo> interactiveAnimals = _animals.OfType<Herbo>().Where(animal => animal.KindnessLevel > 5).ToList();
            if (interactiveAnimals.Count == 0)
            {
                Console.WriteLine("В зоопарке нет животных, которых можно поместить в контактный зоопарк");
                return interactiveAnimals;
            }

            Console.WriteLine("Животные, которых можно поместить в контактный зоопарк:");
            foreach (Herbo animal in interactiveAnimals)
            {
                Console.WriteLine(
                    $"Номер: {animal.Number} || Имя: {animal.Name} || Уровень доброты: {animal.KindnessLevel}");
            }

            return interactiveAnimals;
        }

        public void PrintInventory()
        {
            Console.WriteLine("Инвентарь зоопарка:\n");
            if (_inventory.Count == 0)
            {
                Console.WriteLine("В распоряжении зоопарка нет никаких предметов");
            }
            else
            {
                Console.WriteLine("Предметы:\n");
                foreach (Thing thing in _inventory)
                {
                    Console.WriteLine($"Тип: {thing.GetType().Name} || Название: {thing.Name} || Номер: {thing.Number}");
                }
            }
            
            if (_animals.Count == 0)
            {
                Console.WriteLine("В зоопарке нет животных");
            }

            else
            {
                Console.WriteLine("\n");
                Console.WriteLine("Животные:\n");
                foreach (Animal animal in _animals)
                {
                    Console.WriteLine($"Тип: {animal.GetType().Name} || Имя: {animal.Name} || Номер: {animal.Number}");
                }
            }
        }

    }
}