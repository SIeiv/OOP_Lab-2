using System.Windows;

namespace OOP_Lab_1.Models.Containers;

public class ComputerList : List<Computer>
{
    public delegate void AddMethodContainer(string message);

    public event AddMethodContainer? OnAdd;
    public delegate void DeleteMethodContainer(string message);

    public event DeleteMethodContainer? OnDelete;
    
    public new void Add(Computer computer)
    {
        base.Add(computer);
        OnAdd?.Invoke("Компьютер добавлен.");
    }

    public new void Remove(Computer computer)
    {
        base.Remove(computer);
        OnDelete?.Invoke("Компьютер удален.");
    }
}