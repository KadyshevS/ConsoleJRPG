using System;

namespace Game.Util
{
    class Utils
    {
        public static string AppendString(string str1, string str2, int gap)
        {
            string result = string.Empty;
            string[] strLines1 = str1.Split('\n');
            string[] strLines2 = str2.Split('\n');
            int minLines = Math.Min(strLines1.Length, strLines2.Length);

            for (int i = 0; i < minLines; i++)
            {
                result += strLines1[i];
                for (int j = 0; j < gap; j++)
                    result += ' ';
                result += strLines2[i];
                result += '\n';
            }
            for (int i = minLines; i < strLines1.Length; i++)
            {
                result += strLines1[i] + '\n';
            }

            return result;
        }
    }
}