using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextAnalysis
{
    static class FrequencyAnalysisTask
    {
        public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> text)
        {
            var result = new Dictionary<string, string>();
            var list = new Dictionary<string, Dictionary<string, int>>();//Буду сюда собирать частотность по ключам
            for (var i = 0; i < text.Count; i++) //Иду по вложенным Lista`ам
            {
                if (text[i].Count > 1) // Захожу если в листе больше 2 слов
                {
                    for (var k = 0; k + 1 < text[i].Count; k++) // Иду по словам листа
                    {
                        if (!list.ContainsKey(text[i][k]))  // Если текущего слова нет как ключа, добавляю его в Dictionary и
                            list[text[i][k]] = new Dictionary<string, int> { { text[i][k + 1], 1 } }; // добавляю value к ключу в виде следующего слова и завожу счетчик 1;
                        else if (!list[text[i][k]].ContainsKey(text[i][k + 1])) // Если такой ключ есть, проверяю есть ли подключ и если нет,
                            list[text[i][k]][text[i][k + 1]] = 1; //то завожу и ставлю счетчик 
                        else
                            list[text[i][k]][text[i][k + 1]]++;        // Если оба ключа на месте, +1 к счетчику               
                    }
                }
                if (text[i].Count > 2) // Этот цикл необходим для сбора ключей вида Key(слово1 + слово2) = Value(слово3)
                {
                    for (var k = 0; k + 2 < text[i].Count; k++) // Опять иду по этим же словам 2-ой раз и дальше принцип тот же
                    {
                        if (!list.ContainsKey(text[i][k] + " " + text[i][k + 1]))
                            list[text[i][k] + " " + text[i][k + 1]] = new Dictionary<string, int> { { text[i][k + 2], 1 } };
                        else if (!list[text[i][k] + " " + text[i][k + 1]].ContainsKey(text[i][k + 2]))
                            list[text[i][k] + " " + text[i][k + 1]][text[i][k + 2]] = 1;
                        else
                            list[text[i][k] + " " + text[i][k + 1]][text[i][k + 2]]++;
                    }
                }
            }
            foreach (var item in list)
            {
                result.Add(item.Key, item.Value.OrderByDescending(x => x.Value).ThenBy(s => s.Key, StringComparer.Ordinal).First().Key); //Забираю либо самый частотный ключ к ключу либо с меньшим StringComparer.Ordinal
            }
            return result;
        }
    }
}
