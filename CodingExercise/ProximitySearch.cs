using System;
using System.Collections.Generic;

namespace CodingExercise
{
    public class ProximitySearch:IProximitySearch
    {
        public int CalculateOccurences(string input, string key1, string key2, int range)
        {
            int totalOccurences = 0;
            List<int> key1PositionsList = new List<int>();
            List<int> key2PositionsList = new List<int>();
            Dictionary<int, int> key1PositionToOccurencesMap = new Dictionary<int, int>();
            Dictionary<int, int> key2PositionToOccurencesMap = new Dictionary<int, int>();
            //Since at -1'th index, the occurance is 0
            key1PositionToOccurencesMap.Add(-1, 0);
            key2PositionToOccurencesMap.Add(-1, 0);
            string[] words = input.Split(' ');

            for(int i=0; i<words.Length;i++)
            {
                int position = i;
                string word = words[i];
                int OccurencesForKey1 = key1PositionToOccurencesMap[position - 1];
                int OccurencesForKey2 = key2PositionToOccurencesMap[position - 1];
                if(word.Equals(key1,StringComparison.InvariantCultureIgnoreCase))
                {
                    //Key1's count increases
                    key1PositionsList.Add(position);
                    OccurencesForKey1++;
                }
                else if(word.Equals(key2,StringComparison.InvariantCultureIgnoreCase))
                {
                    //Key2's count increases
                    key2PositionsList.Add(position);
                    OccurencesForKey2++;
                }
                key1PositionToOccurencesMap.Add(position, OccurencesForKey1);
                key2PositionToOccurencesMap.Add(position, OccurencesForKey2);
            }
            // Calculate Occurences where key1 comes before key2
            int key1Occurences = CalculateOccurencesInRange(key1PositionsList, key2PositionToOccurencesMap, range, words.Length);
            // Calculate Occurences where key2 comes before key1
            int key2Occurences = CalculateOccurencesInRange(key2PositionsList, key1PositionToOccurencesMap, range, words.Length);
            return totalOccurences = key1Occurences + key2Occurences;
        }

        private int CalculateOccurencesInRange(List<int> keyPositionsList, Dictionary<int, int> otherKeyPositionToOccurencesMap, 
                                                int range, int length)
        {
            int OccurencesOfOtherKeyInRange = 0;
            foreach (int keyPosition in keyPositionsList)
            {
                int rangeStart = keyPosition;
                if (rangeStart == length - 1)
                {
                    break;
                }
                int rangeEnd = keyPosition + range - 1;//since key is part of range
                rangeEnd = Math.Min(rangeEnd, length- 1); // for cases where range exceeds length of array
                int otherKeyOccurencesAtRangeStart = otherKeyPositionToOccurencesMap[rangeStart];
                int otherKeyOccurencesAtRangeEnd = otherKeyPositionToOccurencesMap[rangeEnd];
                OccurencesOfOtherKeyInRange += otherKeyOccurencesAtRangeEnd - otherKeyOccurencesAtRangeStart;
            }
            return OccurencesOfOtherKeyInRange;
        }
    }
}
