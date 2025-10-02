# WarehouseSystem

Консольное приложение для управления складом.

## Архитектура
- **Product**: Модель продукта (Id, Name, Category, Price).
- **ProductRepository**: Работа с базой данных SQLite.
- **WarehouseService**: Логика управления продуктами.
- **Program**: Консольный интерфейс.

## Диаграммы
- [Диаграмма классов](docs/class-diagram.png)
- [Диаграмма последовательности](docs/sequence-diagram.png)

## Установка и запуск
1. Склонировать: `git clone https://gitlab.com/username/WarehouseSystem.git`
2. Установить зависимости: `dotnet add package System.Data.SQLite`
3. Запустить: `dotnet run`
