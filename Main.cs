using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MainProgram
{
    static void Program()
    {
        // Создаем несколько коробок
        var box1 = new Box(1, 1, 1, 1, new DateTime(2024, 4, 15));
        var box2 = new Box(2, 2, 2, 2, new DateTime(2024, 4, 15));
        var box3 = new Box(3, 3, 3, 3, new DateTime(2024, 4, 15));

        // Создаем паллеты и добавляем в них коробки
        var pallet1 = new Pallet { ID = 1, Width = 10, Height = 10, Depth = 10 };
        var pallet2 = new Pallet { ID = 2, Width = 20, Height = 20, Depth = 20 };
        pallet1.AddBox(box1);
        pallet2.AddBox(box2);
        pallet2.AddBox(box3);

        // Создаем список паллет
        var pallets = new List<Pallet> { pallet1, pallet2 };

        // Группируем паллеты по сроку годности и сортируем в каждой группе по весу
        var groupedPallets = pallets.GroupBy(p => p.GetExpiryDate())
                                     .OrderBy(g => g.Key)
                                     .SelectMany(g => g.OrderBy(p => p.GetWeight()));

        // Выводим на экран результат
        Console.WriteLine("Паллеты сгруппированные по сроку годности и отсортированные по весу:");
        foreach (var pallet in groupedPallets)
        {
            Console.WriteLine($"ID: {pallet.ID}, Expiry Date: {pallet.GetExpiryDate()}, Weight: {pallet.GetWeight()}");
        }

        // Находим три паллеты с наибольшим сроком годности и сортируем их по объему
        var top3Pallets = pallets.OrderByDescending(p => p.GetExpiryDate())
                                  .Take(3)
                                  .OrderBy(p => p.GetVolume());

        // Выводим на экран результат
        Console.WriteLine("\nТоп 3 паллеты с наибольшим сроком годности, отсортированные по объему:");
        foreach (var pallet in top3Pallets)
        {
            Console.WriteLine($"ID: {pallet.ID}, Expiry Date: {pallet.GetExpiryDate()}, Volume: {pallet.GetVolume()}");
        }
    }
}
