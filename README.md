# HSE_ERP_Zoo
Конструирование Программного Обеспечения. Домашнее задание №1. Закрепление принципов SOLID, внедрения  зависимостей средствами DI-контейнера. 

Решение разделено на два проекта:  

1. `FirstMiniHomework` – основной проект, содержащий классы и интерфейсы для работы с животными и инвентарем.
2. `FirstMiniHomework.Tests` – проект с Unit тестами.


## Объяснение с идеями моего решения

- Интерфейсы `IAlive` и `IInventory` задают базовые свойства для живых объектов (потребление еды) и для инвентарных предметов (инвентарный номер).  

- Абстрактный класс `Animal` - базовый для всех животных. В нём я решил реализовать свойство `IsHealthy` , с которой взаимодействует класс `VetClinic`. Генерируется при создании объекта животного рандомным образом, будет ли оно здоровым, или же больным. Этот класс реализует и интерфейс `IALive` (по понятным причинам), и интерфейс `IInventory`, так как считаем, что животные - это тоже инвентарь.
- Его наследниками являются классы `Predator` и `Herbo` - хищники и травоядные соответственно. В классе `Herbo`, исходя из условия, необходимо было также добавить параметр, отвечающий за безопасность животного: уровень доброты (`kindnessLevel`). Это позволит животным интерактивно взаимодействовать с посетителями
- Наследники `Predator` - `Tiger` и `Wolf`. Наследники `Herbo` - `Monkey` и `Rabbit`. Соответственно в будущем можно будет легко добавить новых животных, создав новые классы.

- Абстрактный класс `Thing` - базовый для всех вещей. Реализует интерфейс `IInventory`. Таким образом есть инвентаризационный номер.
- Его наследниками являются классы `Computer` и `Table` - реализация может быть расширена.

- Класс `Zoo` ассоциирует клинику `VetClinic` (передаем ее в конструкторе). В нём содержатся следующие методы:
1. `AddAnimal` - метод, добавляющий животное в список животных после проверки поликлинники (метод `CheckAnimalHealth` из класса `VetClinic`);
2. `AddThing` - метод, добавляющий предмет инвентаря в список предметов инвентаря (оба списка как private поля);
3. `FoodConsumption` - метод, выводящий на экран общее количество потребляемой животными, находящимися в зоопарке, еды;
4. `PrintInteractiveAnimals` - метод, выводящий на экран информацию о том, какие животных можно поместить в контактный зоопарк;
5. `PrintInventory` - метод, выводящий на экран информацию о всём, что стоит на балансе зоопарка: животные и предметы.

Таким образом, когда в будущем потребуется производить учёт ещё и людей, то можно будет легко создать класс, отвечающий за людей, чтобы он реализовывал интерфейс IAlive.

В файлах `Program.cs`, `ProcessesAddingAnimal.cs` и `ProcesseAddingThing.cs` у меня содержатся классы, по управлению взаимодействию с пользователем. Я написал довольно интересное интерактивное меню, управляемое клавишами U и D (для навигации) и Enter для выбора действий. Всего пока что было представлено 6 действий на выбор:
1. Добавить животное в зоопарк
2. Добавить вещь в зоопарк
3. Вывести необходимое количество еды животным в зоопарке
4. Вывести список животных, с которыми можно взаимодействовать в контактном зоопарке
5. Вывести информацию об инвентаре в зоопарке
6. Выйти из программы

При нажатии пользователем различных действий, ему помогают соориентироваться текстовые подсказки.

- Класс `UnitTests.cs` в проекте `FirstMiniHomework.Tests` с поддержкой. Я написал несколько Unit тестов, покрыв основные классы из условия на 80-100% (Я делал в IDE Rider, проблем с показом процентов не было). Я не считал классы `ProcessesAddingAnimal` и `ProcesseAddingThing`, поскольку там идёт многоразовое считывание с клавиатуры, а также случайное назначение параметра здоровья животного в самом конце, когда все данные считаны, поэтому я ограничился сущностями из условия. 

Использование DI-контейнера видно в файле `Program.cs`. Я использую `IServiceCollection services = new ServiceCollection()` для регистрации сервисов, а затем ServiceProvider для разрешения зависимостей.

Таким образом, в моём проекте было продемонстрировано исользование принципов ООП и SOLID (при соблюдении условия), а также использование DI-контейнера и Unit тестирования.

Подключение: `dotnet add package Microsoft.Extensions.DependencyInjection`

