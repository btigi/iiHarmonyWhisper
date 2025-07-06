namespace iiHarmonyWhisper.Helpers
{
    public static class StringHelper
    {
        public static string TrimFromNull(string input)
        {
            int index = input.IndexOf('\0');
            return index < 0 ? input : input.Substring(0, index);
        }
    }
}