using System.Windows;

namespace OOP_Lab_1.Models.Containers;

public class ComputerListHandler
{
    public static void InfoMessage(string message)
    {
        MessageBox.Show(message, "Info", MessageBoxButton.OK, MessageBoxImage.Information);
    } 
    public void WarningMessage(string message)
    {
        MessageBox.Show(message, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
    } 
}