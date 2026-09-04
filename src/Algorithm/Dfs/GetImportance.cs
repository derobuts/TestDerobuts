using DSAandAlgo.Shared;

namespace DSAandAlgo.Dfs;

/// <summary>
/// LeetCode 690 - Employee Importance.
/// Each employee has an id, an importance value, and a list of direct-report
/// ids. Return the sum of importance for the employee with the given id
/// plus all of their (transitive) subordinates.
/// </summary>
/// <example>
/// Input:  employees=[[1,5,[2,3]],[2,3,[]],[3,3,[]]], id=1
/// Output: 11   (5 + 3 + 3)
/// </example>
/// <remarks>
/// Approach: build an id -> Employee map for O(1) lookup, then DFS from the
/// target id accumulating importance. O(n) where n is total employees.
/// </remarks>
public class GetImportance
{
    public int Solve(IList<Employee> employees, int id)
    {
        var byId = employees.ToDictionary(e => e.id);
        return Dfs(byId, id);
    }

    private int Dfs(Dictionary<int, Employee> byId, int id)
    {
        if (!byId.TryGetValue(id, out var employee))
        {
            return 0;
        }

        int total = employee.importance;
        foreach (int sub in employee.subordinates)
        {
            total += Dfs(byId, sub);
        }
        return total;
    }
}
