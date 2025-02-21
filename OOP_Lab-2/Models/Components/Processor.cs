﻿using OOP_Lab_1.Exceptions;
using OOP_Lab_1.Models.Enums;

namespace OOP_Lab_1.Models.Components;


public record Processor
{
    private Manufacturer _brand;
    private string _model;
    private double _frequency;

    public Processor() { }

    public Processor(Manufacturer manufacturer, string model, double frequency)
    {
        Brand = manufacturer;
        Model = model;
        FrequencyGHz = frequency;
    }

    public Manufacturer Brand
    {
        get => _brand;
        set => _brand = IsValidBrand(value)
            ? value 
            : throw new InvalidProcessorException("Неверный производитель процессора");
    }

    public string Model
    {
        get => _model;
        set => _model = string.IsNullOrWhiteSpace(value)
            ? throw new InvalidProcessorException("Модель не может быть пустой")
            : value;
    }

    public double FrequencyGHz
    {
        get => _frequency;
        set => _frequency = value is > 0 and <= 6 
            ? value 
            : throw new InvalidProcessorException("Частота должна быть > 0 и <= 6GHz");
    }

    private static bool IsValidBrand(Manufacturer brand) =>
        brand is Manufacturer.Intel or Manufacturer.AMD or Manufacturer.Apple;

    public override string ToString() => $"{Brand} {Model} @ {FrequencyGHz}GHz";
}
