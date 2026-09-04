namespace DSAandAlgo.LineSweep;

public class VideoStitching
{
    /**
     * You are given a series of video clips from a sporting event that lasted time seconds. These video clips can be overlapping with each other and have varying lengths.

Each video clip is described by an array clips where clips[i] = [starti, endi] indicates that the ith clip started at starti and ended at endi.

We can cut these clips into segments freely.

For example, a clip [0, 7] can be cut into segments [0, 1] + [1, 3] + [3, 7].
Return the minimum number of clips needed so that we can cut the clips into segments that cover the entire sporting event [0, time]. If the task is impossible, return -1.

 

Example 1:

Input: clips = [[0,2],[4,6],[8,10],[1,9],[1,5],[5,9]], time = 10
Output: 3
Explanation: We take the clips [0,2], [8,10], [1,9]; a total of 3 clips.
Then, we can reconstruct the sporting event as follows:
We cut [1,9] into segments [1,2] + [2,8] + [8,9].
Now we have segments [0,2] + [2,8] + [8,10] which cover the sporting event [0, 10].
     */
    public int VideoStitchingF(int[][] clips, int time)
    {
        var maxReach = new int[time];
        foreach (var clip in clips)
        {
            var startIndex = clip[0];
            maxReach[startIndex] =  Math.Max(maxReach[startIndex], clip[1]);
        }

        int currentEnd = 0;
        int furthestEnd = 0;
        int count = 0;
        int i = 0;
        
        for (;i < maxReach.Length; i++)
        {
            furthestEnd = Math.Max(furthestEnd, maxReach[i]);
            if (i == currentEnd)
            {
                count++;
                currentEnd = furthestEnd;
            }
        }
        return i >= time ? count : -1;
    }
}