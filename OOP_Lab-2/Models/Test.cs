using OOP_Lab_1.Models.Enums;

namespace OOP_Lab_1.Models;

public class Test
{
    public static int InstanceCount { get; private set; }

    private int _id;
    private int _elementsCount;
    private TesterCollectionType _collectionType;
    private TesterActionType _actionType;
    private int _testingTime;
    private DateTime _testDate;

    public Test()
    {
        InstanceCount++;
        TestDate = DateTime.Now;
        Id = InstanceCount;
    }
    public Test(int elementsCount, TesterCollectionType collectionType, 
        TesterActionType actionType)
    {
        InstanceCount++;
        TestDate = DateTime.Now;
        Id = InstanceCount;
        ElementsCount = elementsCount;
        CollectionType = collectionType;
        ActionType = actionType;
    }
    public Test(int elementsCount, TesterCollectionType collectionType, 
        TesterActionType actionType, int testingTime = 0)
    {
        InstanceCount++;
        TestDate = DateTime.Now;
        Id = InstanceCount;
        ElementsCount = elementsCount;
        CollectionType = collectionType;
        ActionType = actionType;
        TestingTime = testingTime;
    }

    public int Id
    {
        get => _id; 
        set => _id = value;
    }
    
    public int ElementsCount
    {
        get => _elementsCount; 
        set => _elementsCount = value;
    }

    public TesterCollectionType CollectionType
    {
        get => _collectionType; 
        set => _collectionType = value;
    }

    public TesterActionType ActionType
    {
        get => _actionType; 
        set => _actionType = value;
    }

    public int TestingTime
    {
        get => _testingTime; 
        set => _testingTime = value;
    }

    public DateTime TestDate
    {
        get => _testDate; 
        set => _testDate = value;
    }
}