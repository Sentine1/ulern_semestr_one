using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TextAnalysis
{
    static class TextGeneratorTask
    {
        public static string ContinuePhrase(
            Dictionary<string, string> nextWords,
            string phraseBeginning,
            int wordsCount)
        {
            var words =Regex.Split(phraseBeginning, @"\W+").ToList();
            var keyLastWord = words.Last();
            string keyPreLastWord = null;
            if (words.Count>1)
             keyPreLastWord = words[words.Count-1];
            for (int i = 0; i < wordsCount; i++)
            {
                if (!string.IsNullOrEmpty(keyLastWord)&& !string.IsNullOrEmpty(keyPreLastWord)&&wordsCount>2)
                if (nextWords.ContainsKey(keyLastWord))
                {
                    phraseBeginning += " " + nextWords[keyPreLastWord]+" " + nextWords[keyLastWord];
                }
                else if (nextWords.ContainsKey(keyPreLastWord + " "+phraseBeginning))
                    phraseBeginning += " " + nextWords[keyPreLastWord + " " + phraseBeginning];

            }
            if (!string.IsNullOrEmpty(keyLastWord) && nextWords.ContainsKey(keyLastWord)&& wordsCount>1)
                    phraseBeginning += " " + nextWords[keyLastWord];
            return phraseBeginning;
        }
    }
}