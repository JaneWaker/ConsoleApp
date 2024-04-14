using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        List<Pallet> pallets = new List<Pallet>();

        while (true)
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Добавить паллету");
            Console.WriteLine("2. Добавить коробку к паллете");
            Console.WriteLine("3. Показать информацию о паллетах");
            Console.WriteLine("4. Выход");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddPallet(pallets);
                    break;
                case "2":
                    AddBoxToPallet(pallets);
                    break;
                case "3":
                    ShowPalletsInfo(pallets);
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Неверный выбор. Пожалуйста, выберите существующее действие.");
                    break;
            }
        }
    }

    static void AddPallet(List<Pallet> pallets)
    {
        Console.WriteLine("Введите данные для новой паллеты:");

        Console.Write("ID: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Ширина: ");
        double width = double.Parse(Console.ReadLine());

        Console.Write("Высота: ");
        double height = double.Parse(Console.ReadLine());

        Console.Write("Глубина: ");
        double depth = double.Parse(Console.ReadLine());

        Pallet pallet = new Pallet { ID = id, Width = width, Height = height, Depth = depth };
        pallets.Add(pallet);
        Console.WriteLine("Паллета успешно добавлена.");
    }

    static void AddBoxToPallet(List<Pallet> pallets)
    {
        if (pallets.Count == 0)
        {
            Console.WriteLine("Сначала добавьте паллету.");
            return;
        }

        Console.WriteLine("Выберите паллету, к которой нужно добавить коробку:");

        for (int i = 0; i < pallets.Count; i++)
        {
            Console.WriteLine($"{i + 1}. Паллета ID: {pallets[i].ID}");
        }

        int palletIndex = int.Parse(Console.ReadLine()) - 1;

        Console.WriteLine("Введите данные для новой коробки:");

        Console.Write("Ширина: ");
        double width = double.Parse(Console.ReadLine());

        Console.Write("Высота: ");
        double height = double.Parse(Console.ReadLine());

        Console.Write("Глубина: ");
        double depth = double.Parse(Console.ReadLine());

        Console.Write("Вес: ");
        double weight = double.Parse(Console.ReadLine());

        Console.Write("Дата производства (в формате dd.MM.yyyy): ");
        DateTime productionDate = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", null);

        Box box = new Box(width, height, depth, weight, productionDate);
        pallets[palletIndex].AddBox(box);
        Console.WriteLine("Коробка успешно добавлена к паллете.");
    }

    static void ShowPalletsInfo(List<Pallet> pallets)
    {
        if (pallets.Count == 0)
        {
            Console.WriteLine("Нет данных о паллетах.");
            return;
        }

        Console.WriteLine("Информация о паллетах:");
        foreach (var pallet in pallets)
        {
            Console.WriteLine($"ID: {pallet.ID}, Expiry Date: {pallet.GetExpiryDate()}, Weight: {pallet.GetWeight()}");
        }
    }
}

