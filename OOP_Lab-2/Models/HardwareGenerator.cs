using OOP_Lab_1.Models.Components;
using OOP_Lab_1.Models.Enums;

namespace OOP_Lab_1.Models;

public class HardwareGenerator
{
    public static Processor GenerateRandomProcessor()
    {
        var rnd = new Random();
        int processorFrequency = rnd.Next(1, 6);
        var processorManufacturer = (Manufacturer)rnd.Next(0, 3);
        var processorModel =
            $"Core i{rnd.Next(1, 10)} Ryzen {rnd.Next(1, 10)} {rnd.Next(1, 10)}{rnd.Next(1, 10)}00";
        return new Processor(processorManufacturer, processorModel, processorFrequency);
    }

    public static Ram GenerateRandomRam()
    {
        var rnd = new Random();
        int ramSize = rnd.Next(1, 256);
        var memoryType = (MemoryType)rnd.Next(0, 3);
        return new Ram(ramSize, memoryType);
    }
    
    public static Computer GenerateRandomComputer()
    {
        var processor = GenerateRandomProcessor();
        var ram = GenerateRandomRam();
        
        var rnd = new Random();
        decimal price = rnd.Next(1, 100000);
        int storageSize = rnd.Next(128, 4096);
        var storageType = (StorageType)rnd.Next(0, 3);
        var compManufacturer = (Manufacturer)rnd.Next(0, 4);
        return new Computer(processor, ram, storageSize, storageType, compManufacturer, price);
    }
}