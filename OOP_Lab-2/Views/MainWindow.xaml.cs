using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OOP_Lab_1.Models;
using OOP_Lab_1.Models.Containers;
using OOP_Lab_1.Models.Enums;
using OOP_Lab_2.Views;

namespace OOP_Lab_2;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public ComputerList CompList = new ComputerList();
    public MainWindow()
    {
        InitializeComponent();
        CompList.OnAdd += ComputerListHandler.InfoMessage;
        CompList.OnDelete += (message) => MessageBox.Show(message, "Warning", 
            MessageBoxButton.OK, MessageBoxImage.Warning);
        MainList.ItemsSource = CompList;
    }

    private void AddButton_OnClick(object sender, RoutedEventArgs e)
    {
        var addWindow = new AddWindow();
        addWindow.OwnerWindow = this;
        addWindow.Show();
    }

    private void DeleteButton_OnClick(object sender, RoutedEventArgs e)
    {
        if (MainList.SelectedItem != null)
        {
            CompList.Remove(MainList.SelectedItem as Computer);
            MainList.Items.Refresh();
        }
    }

    private void TesterButton_OnClick(object sender, RoutedEventArgs e)
    {
        var testerWindow = new TesterWindow();
        testerWindow.OwnerWindow = this;
        testerWindow.Show();
    }
}