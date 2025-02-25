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

        var tester = new Tester(Int32.Parse(ElsCountTextBox.Text), collectionType, actionType);

        Test test;

        if (collectionType == TesterCollectionType.List && actionType == TesterActionType.Insertion)
        {
            test = tester.ListInsertionTest();
        }
        else if (collectionType == TesterCollectionType.Array && actionType == TesterActionType.Insertion)
        { 
            test = tester.ArrayInsertionTest();
        }
        else if (collectionType == TesterCollectionType.List && actionType == TesterActionType.Selection)
        { 
            test = tester.ListSelectionTest();
        }
        else if (collectionType == TesterCollectionType.Array && actionType == TesterActionType.Selection)
        { 
            test = tester.ArraySelectionTest();
        }
        else
        {
            test = new Test();
        }

        TestList.Add(test);
        TesterList.Items.Refresh();
    }
}