using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class WarehouseItem
{
    public int ID { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }
    public double Depth { get; set; }
    public double Weight { get; set; }
}

// Класс, описывающий коробку
public class Box : WarehouseItem
{
    public DateTime ProductionDate { get; set; }
    public DateTime ExpiryDate { get; set; }

    public Box(double width, double height, double depth, double weight, DateTime productionDate)
    {
        Width = width;
        Height = height;
        Depth = depth;
        Weight = weight;
        ProductionDate = productionDate;
        ExpiryDate = productionDate.AddDays(100); // По умолчанию срок годности 100 дней
    }

    public Box(double width, double height, double depth, double weight, DateTime productionDate, DateTime expiryDate)
    {
        Width = width;
        Height = height;
        Depth = depth;
        Weight = weight;
        ProductionDate = productionDate;
        ExpiryDate = expiryDate;
    }
}

// Класс, описывающий паллету
public class Pallet : WarehouseItem
{
    private List<Box> boxes = new List<Box>();

    public IEnumerable<Box> Boxes => boxes;

    public void AddBox(Box box)
    {
        if (box.Width > Width || box.Depth > Depth)
        {
            throw new Exception("Box dimensions exceed pallet dimensions.");
        }
        boxes.Add(box);
    }

    public DateTime GetExpiryDate()
    {
        if (boxes.Count == 0)
            return DateTime.MinValue;

        return boxes.Min(box => box.ExpiryDate);
    }

    public double GetWeight()
    {
        return boxes.Sum(box => box.Weight) + 30; // Вес паллеты = сумма весов коробок + 30кг
    }

    public double GetVolume()
    {
        return boxes.Sum(box => box.Width * box.Height * box.Depth) + Width * Height * Depth;
    }
}
