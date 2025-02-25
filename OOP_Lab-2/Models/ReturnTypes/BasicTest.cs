namespace OOP_Lab_1.Models.ReturnTypes;

public struct BasicTest
{
    Test test; 
    int testingTime;

    public BasicTest(Test test, int testingTime)
    {
        this.test = test;
        this.testingTime = testingTime;
    }
}