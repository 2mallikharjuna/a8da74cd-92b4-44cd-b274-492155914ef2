using System;
using System.Collections.Generic;
using System.Linq;

namespace Longest_Increasing_Subsequence
{
    class Longest_Increasing_Subsequence
    {
        /// <summary>
        /// Convert the space separate string to list of elements
        /// </summary>
        /// <param name="strElements"></param>
        /// <returns></returns>
        private IEnumerable<int> CovertStringToList(string strElements)
        {
            try
            {
                return strElements.Split(" ").Select(int.Parse).ToArray();
            }
            catch (Exception)
            {
                throw new ArgumentException($"Fail to covert the Input string : {strElements}, please check the input once again");
            }
        }
        
        /// <summary>
        /// Finds the first longest increasing subsequence in the input list.
        /// </summary>
        /// <param name="elements">Input list of integers.</param>
        /// <returns>The earliest and longest increasing subsequence.</returns>
        private IEnumerable<int> FindLongestIncreasingSubsequence(IList<int> elements)
        {
            if (elements == null || elements.Count == 0)
                return Enumerable.Empty<int>(); // Return empty if input is null or empty.
        
            List<int> longestSeq = new List<int>();
            List<int> currentSeq = new List<int>();
        
            for (int i = 0; i < elements.Count; i++)
            {
                // Add the current element to the current sequence
                if (currentSeq.Count == 0 || elements[i] > currentSeq.Last())
                {
                    currentSeq.Add(elements[i]);
                }
                else
                {
                    // Check if the current sequence is the longest found so far
                    if (currentSeq.Count > longestSeq.Count)
                    {
                        longestSeq = new List<int>(currentSeq);
                    }
                    currentSeq.Clear();
                    currentSeq.Add(elements[i]); // Start a new sequence with the current element
                }
            }
        
            // Check the last sequence
            if (currentSeq.Count > longestSeq.Count)
            {
                longestSeq = new List<int>(currentSeq);
            }
        
            return longestSeq;
        }


        static void Main(string[] args)
        {
            // Step 1: test for null.
            if (args == null)
            {
                Console.WriteLine("args is null");
            }
            else
            {
                foreach (string argument in args)
                {
                    //creating object of class Longest_Increasing_Subsequence
                    Longest_Increasing_Subsequence lisObj = new Longest_Increasing_Subsequence();
                    //Convert the input into elements and print the longest sub sequence
                    Console.WriteLine(string.Join(" ", lisObj.FindLongestIncreasingSubsequence(lisObj.CovertStringToList(argument).ToList()))); // Calling method
                }
        }
    }
}
