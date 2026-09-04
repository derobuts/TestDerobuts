namespace DSAandAlgo.Shared;

public class Employee
{
    public int id;
    public int importance;
    public IList<int> subordinates = new List<int>();
}
