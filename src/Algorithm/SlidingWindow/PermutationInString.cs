namespace DSAandAlgo.SlidingWindow;

public class PermutationInString
{
    public bool CheckInclusion(string s1, string s2) {
        if (string.IsNullOrEmpty(s1) || string.IsNullOrEmpty(s2)) return false;
        if (s1.Length > s2.Length) return false;

        var charcounts = new int[26];
        var currentwindow = new int[26];

        int required_characters = 0;

        for (int i = 0; i < s1.Length; i++) {
            if (charcounts[s1[i] - 'a'] == 0) required_characters++;   // FIX: - 'a'
            charcounts[s1[i] - 'a']++;                                  // FIX: - 'a'
        }

        int formed = 0;
        int left = 0;

        for (int right = 0; right < s2.Length; right++) {
            // expand
            int c = s2[right] - 'a';                                    // FIX: - 'a'
            currentwindow[c]++;

            if (currentwindow[c] == charcounts[c]) {
                formed++;                                                // FIX: formed, not required_characters
            }

            // shrink: keep window at most s1.Length wide
            while ((right - left + 1) > s1.Length) {                    // FIX: s1.Length, no right--
                int lc = s2[left] - 'a';
                if (currentwindow[lc] == charcounts[lc]) formed--;      // breaking satisfaction
                currentwindow[lc]--;
                left++;
            }

            // check: correct size AND all counts matched
            if (right - left + 1 == s1.Length && formed == required_characters) {
                return true;                                             // FIX: check formed too
            }
        }
        return false;
    }
}