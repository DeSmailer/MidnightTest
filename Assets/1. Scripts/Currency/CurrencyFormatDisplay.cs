public static class CurrencyFormatDisplay
{
    public static string Display(double gold)
    {
        string result;
        string[] goldNames = new string[] { "", "k", "M", "B", "T", "aa", "ab",
            "ac", "ad", "ae", "af", "ag", "ah", "ai", "aj", "ak", "al", "am", "an",
            "ao", "ap", "aq", "ar", "as", "at", "au", "av", "aw", "ax", "ay", "az",
            "ba", "bb", "bc", "bd", "be", "bf", "bg", "bh", "bi", "bj", "bk", "bl",
            "bm", "bn", "bo", "bp", "bq", "br", "bs", "bt", "bu", "bv", "bw", "bx",
            "by", "bz", };
        int i;

        for (i = 0; i < goldNames.Length; i++)
            if (gold < 900)
                break;
            else gold = System.Math.Floor(gold / 100f) / 10f;

        if (gold == System.Math.Floor(gold))
            result = gold.ToString() + goldNames[i];
        else result = gold.ToString("F1") + goldNames[i];
        return result;
    }
}
