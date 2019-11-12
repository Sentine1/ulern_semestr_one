// Вставьте сюда финальное содержимое файла SentencesParserTask.cs
using System;
using System.Collections.Generic;

namespace TextAnalysis
{
    static class SentencesParserTask
    {
        public static List<List<string>> ParseSentences(string text)
        {
            var sentencesList = new List<List<string>>();
            char[] orders = new char[] { '.', ';', '!', '?', ';', ':', '(', ')' };
            var sentences = text.Split(orders, StringSplitOptions.RemoveEmptyEntries);
            foreach (var sentence in sentences)
            {
                var extractedWords = ExtractWords(sentence);
                if (extractedWords.Count != 0)
                    sentencesList.Add(extractedWords);
            }
            return sentencesList;
        }

        static List<string> ExtractWords(string sentence)
        {
            var extractionList = new List<string>();
            for (int charIndex = 0; charIndex < sentence.Length; charIndex++)
            {
                if (!char.IsLetter(sentence[charIndex]) && sentence[charIndex] != '\'')
                {
                    string word = sentence.Substring(0, charIndex).ToLower();
                    if (word != "")
                        extractionList.Add(word.ToLower());
                    sentence = sentence.Remove(0, charIndex + 1);
                    charIndex = -1;
                }
            }
            if (sentence != "")
                extractionList.Add(sentence.ToLower());
            return extractionList;
        }
    }
}