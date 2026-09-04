namespace DSAandAlgo.Intervals;

public class NumberOfWeeks
{
    public long NumberOfWeeks(int[] milestones)
    {
        var maxMilestones = new PriorityQueue<int, int>();

        for (int i = 0; i < milestones.Length; i++)
            maxMilestones.Enqueue(i, -milestones[i]);

        long weeks = 0;
        int prevProject = -1;

        while (maxMilestones.Count > 0)
        {
            int project = maxMilestones.Dequeue();

            // If it's the same as last week, use the next best project
            if (project == prevProject)
            {
                if (maxMilestones.Count == 0)
                    break;

                int second = maxMilestones.Dequeue();
                maxMilestones.Enqueue(project, -milestones[project]);
                project = second;
            }

            weeks++;
            milestones[project]--;
            prevProject = project;

            if (milestones[project] > 0)
                maxMilestones.Enqueue(project, -milestones[project]);
        }

        return weeks;
    }
}