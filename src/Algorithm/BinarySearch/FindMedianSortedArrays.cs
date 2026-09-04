namespace DSAandAlgo.BinarySearch;

/// <summary>
/// LeetCode 4 - Median of Two Sorted Arrays.
/// Given two sorted arrays <c>nums1</c> and <c>nums2</c>, return the median
/// of the merged sorted array in O(log (min(m, n))) time.
/// </summary>
/// <example>
/// Input:  nums1=[1,3], nums2=[2]       Output: 2.0
/// Input:  nums1=[1,2], nums2=[3,4]     Output: 2.5
/// Input:  nums1=[], nums2=[1]          Output: 1.0
/// </example>
/// <remarks>
/// Approach: partition the two arrays so that the left half contains exactly
/// (m + n + 1) / 2 elements and every element on the left is &lt;= every
/// element on the right. Binary-search the partition position in the
/// shorter array. The median is then derived from the four boundary
/// elements (max-left, min-right on either side).
/// </remarks>
public class FindMedianSortedArrays
{
    public double Solve(int[] nums1, int[] nums2)
    {
        if (nums1.Length > nums2.Length) (nums1, nums2) = (nums2, nums1);

        int m = nums1.Length, n = nums2.Length;
        int half = (m + n + 1) / 2;

        int lo = 0, hi = m;
        while (lo <= hi)
        {
            int i = (lo + hi) / 2;
            int j = half - i;

            int left1 = i == 0 ? int.MinValue : nums1[i - 1];
            int right1 = i == m ? int.MaxValue : nums1[i];
            int left2 = j == 0 ? int.MinValue : nums2[j - 1];
            int right2 = j == n ? int.MaxValue : nums2[j];

            if (left1 <= right2 && left2 <= right1)
            {
                if (((m + n) & 1) == 1)
                {
                    return Math.Max(left1, left2);
                }
                return (Math.Max(left1, left2) + Math.Min(right1, right2)) / 2.0;
            }

            if (left1 > right2) hi = i - 1;
            else lo = i + 1;
        }

        throw new InvalidOperationException("Inputs are not sorted.");
    }
}
