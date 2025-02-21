using System.Windows;

namespace OOP_Lab_1.Models.Containers;

public class ComputerList : List<Computer>
{
    public delegate void ComputerEventHandler(string message);
    public event ComputerEventHandler? ComputerEvent;
    
    private void DisplayMessage(string message) => MessageBox.Show(message);

    public ComputerList()
    {
        ComputerEvent += DisplayMessage;
    }
    public new void Add(Computer computer)
    {
        base.Add(computer);
        ComputerEvent?.Invoke("Computer added");
    }

    public new void Remove(Computer computer)
    {
        base.Remove(computer);
        ComputerEvent?.Invoke("Computer removed");
    }
}