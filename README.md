# ProximitySearch
Algorithm

1. Traverse input text of the file as we find the word match for key1 or key2 add the position of occurence to respective list. Store the position as key and the occurence for key1 or key2 at that position as value in a dictionary.
2.  Since we know that until a given position how many times the word has occured,
we just need to calculate how many times the second word has occured in range.
3. We do that by traversing through the matches of key1 and finding how many times key2 occured in the range which we have in the map. Subtract the occurances of key2 at end of range to the starting of it.
4. Add it to the total occurences. Repeat the same process for key2 and get its count and it the toal occurences.

Eg: Lets say string is "hello world hello world", keys are "hello", "world", range:6
key1 list has its position occurences 0,2
key2 list has its position occurences 1,3
key1map has positionToOccurenceMapOfKey1 which looks like 
key -1 value 0 key 0 value 1 key 1 value 1 key 2 value 2 key 3 value 2
key2map has positionToOccurenceMapOfKey2 which looks like
key -1 value 0 key 0 value 0 key 1 value 1 key 2 value 1 key 3 value 2
Now, the first hello is at index 0 .Now, we need to know how many times world comes b/w,
position 0, 0+6 (or 3, since 6 exceeds word array length). By using the map we constructed, we get that very easily, World has occured 2 times in the range for the first hello.Doing this for all positions of key1, and also for cases where key2 comes before key1, we get the total occurances.
      
      Time complexity calculation:
      Traversing Entire Input Text Once O(n), where n = word count
      Traversing for key1Matches O(key1Count), where key1Count < n
      Traversing for key2Matches O(key2Count), where key2Count < n
      Total = O(n + key1Count + key2Count) = O(n)
      
      Space complexity calculation:
      key1PositionsList + key2PositionsList: max values = n, ie, O(n)
      key1PositionToOccurancesMap + key2PositionToOccurancesMap: max values = n, ie, O(n)
      Total = O(n + n) = O(2n) = O(n)
