using System.Windows;
using OOP_Lab_1.Models;
using OOP_Lab_1.Models.Components;
using OOP_Lab_1.Models.Containers;
using OOP_Lab_1.Models.Enums;

namespace OOP_Lab_2.Views;

public partial class TesterWindow : Window
{
    public static List<Test> TestList = new List<Test>();
    public MainWindow OwnerWindow;

    public TesterWindow()
    {
        InitializeComponent();
        TesterList.ItemsSource = TestList;
    }

    private void StartTestButton_OnClick(object sender, RoutedEventArgs e)
    {
        if (!Enum.TryParse<TesterCollectionType>(CollectionTypeCombobox.Text, out TesterCollectionType collectionType))
            throw new Exception("Неверный тип коллекции");

        if (!Enum.TryParse<TesterActionType>(ActionTypeCombobox.Text, out TesterActionType actionType))
            throw new Exception("Неверное действие");

        var Test = new Test(int.Parse(ElsCountTextBox.Text), collectionType, actionType);

        var TestCompList = new ComputerList();
        var TestCompArray = new Computer[Test.ElementsCount];
        var startTime = System.Diagnostics.Stopwatch.StartNew();

        for (int i = 0; i < Test.ElementsCount; i++)
        {
            Random rnd = new Random();

            int processorFrequency = rnd.Next(1, 6);
            var processorManufacturer = (Manufacturer)rnd.Next(0, 3);
            var processorModel =
                $"Core i{rnd.Next(1, 10)} Ryzen {rnd.Next(1, 10)} {rnd.Next(1, 10)}{rnd.Next(1, 10)}00";
            var p1 = new Processor(processorManufacturer, processorModel, processorFrequency);

            int ramSize = rnd.Next(1, 256);
            var memoryType = (MemoryType)rnd.Next(0, 3);
            var r1 = new Ram(ramSize, memoryType);

            decimal price = rnd.Next(1, 100000);
            int storageSize = rnd.Next(128, 4096);
            var storageType = (StorageType)rnd.Next(0, 3);
            var compManufacturer = (Manufacturer)rnd.Next(0, 4);

            var c1 = new Computer(p1, r1, storageSize, storageType, compManufacturer, price);

            if (collectionType == TesterCollectionType.List)
            {
                TestCompList.Add(c1);
            }
            else if (collectionType == TesterCollectionType.Array)
            {
                TestCompArray[i] = c1;
            }
        }


        startTime.Stop();
        var resultTime = startTime.Elapsed;
        Test.TestingTime = (int)resultTime.TotalMilliseconds;

        TestList.Add(Test);
        TesterList.Items.Refresh();
    }
}