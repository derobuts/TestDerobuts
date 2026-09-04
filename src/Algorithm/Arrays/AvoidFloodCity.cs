namespace DSAandAlgo.Arrays;

public class AvoidFloodCity
{
    public int[] AvoidFlood(int[] rains) {
        int n = rains.Length;
        int[] ans = new int[n];
        for (int i = 0; i < n; i++) ans[i] = rains[i] > 0 ? -1 : 1;   // init

        var earliestFillDate = new Dictionary<int, int>();
        var dryDays = new List<int>();

        for (int i = 0; i < n; i++) {
            if (rains[i] > 0) {
                int lake = rains[i];
                if (earliestFillDate.ContainsKey(lake)) {
                    int foundPos = -1;
                    for (int c = 0; c < dryDays.Count; c++) {
                        if (dryDays[c] > earliestFillDate[lake]) {   // dry day AFTER fill
                            foundPos = c;
                            break;
                        }
                    }
                    if (foundPos == -1) return new int[0];           // FLOOD
                    ans[dryDays[foundPos]] = lake;
                    dryDays.RemoveAt(foundPos);
                }
                earliestFillDate[lake] = i;
            }
            else {
                dryDays.Add(i);
            }
        }
        return ans;
    }
}