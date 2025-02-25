using OOP_Lab_1.Models.Containers;
using OOP_Lab_1.Models.Enums;
using OOP_Lab_1.Models.ReturnTypes;
using OOP_Lab_2.Views;

namespace OOP_Lab_1.Models;

public class Tester
{
    private int _collectionLength;
    private TesterCollectionType _collectionType;
    private TesterActionType _actionType;

    private delegate void CurrentTest();
    
    private ComputerList _testCompList;// = new ComputerList();
    private Computer[] _testCompArray; // = new Computer[Test.ElementsCount];

    private void FillList()
    {
        for (int i = 0; i < _collectionLength; i++)
        {
            var randomComputer = HardwareGenerator.GenerateRandomComputer();
            _testCompList.Add(randomComputer);
        }
    }
    
    private void FillArray()
    {
        for (int i = 0; i < _collectionLength; i++)
        {
            var randomComputer = HardwareGenerator.GenerateRandomComputer();
            _testCompArray[i] = randomComputer;
        }
    }

    public Tester(int collectionLength, TesterCollectionType testerCollectionType, TesterActionType testerActionType)
    {
        _collectionLength = collectionLength;
        _collectionType = testerCollectionType;
        _actionType = testerActionType;
        
        _testCompList = new ComputerList();
        _testCompArray = new Computer[collectionLength];
    }

    private Test BasicTest(CurrentTest currentTest)
    {
        var test = new Test(_collectionLength, _collectionType, _actionType);
        var startTime = System.Diagnostics.Stopwatch.StartNew();
        
        currentTest();
        
        startTime.Stop();
        var resultTime = startTime.Elapsed;
        test.TestingTime = (int)resultTime.TotalMilliseconds;
        return test;
    }

    public Test ListInsertionTest()
    {
        return BasicTest(() => { FillList(); });
    }

    public Test ArrayInsertionTest()
    {
        return BasicTest(() => { FillArray(); });
    }
    
    public Test ListSelectionTest()
    {
        FillList();
        
        return BasicTest(() =>
        {
            string selectedString = "";

            for (int i = 0; i < _collectionLength; i++)
            {
                selectedString += $"{_testCompList[i]} ";
            }
            Console.WriteLine(selectedString);
        });
    }
    
    public Test ArraySelectionTest()
    {
        FillArray();
        return BasicTest(() =>
        {
            string selectedString = "";

            for (int i = 0; i < _collectionLength; i++)
            {
                selectedString += $"{_testCompArray[i]} ";
            }
            Console.WriteLine(selectedString);
        });
    }
}