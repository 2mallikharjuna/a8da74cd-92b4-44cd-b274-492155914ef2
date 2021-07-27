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
        /// Find the first Longest Increasing Subsequence
        /// </summary>
        /// <param name="elements">Input elements list</param>
        /// <returns>return Earliest and Longest Increasing Subsequence</returns>
        private IEnumerable<int> FindLongestIncreasingSubsequence(IList<int> elements)
        {
            List<int> longestSeq = new List<int>();
            List<int> firstLongestSubSeq = new List<int>();           
            
            for (var i = 0; i < elements.Count; i++)
            {
                //traverse the sequence until last element to find the longest sub-sequence
                if (i != elements.Count - 1 && elements[i + 1] > elements[i])
                {
                    //Prepare sub sequence list
                    if(longestSeq.Count == 0)
                        longestSeq.Add(elements[i]);
                    longestSeq.Add(elements[i+1]);   
                }
                else 
                {
                    //New prepared sequence is having greater count than existing count
                    if (firstLongestSubSeq.Count() < longestSeq.Count())
                    {
                        firstLongestSubSeq.Clear();
                        firstLongestSubSeq.AddRange(longestSeq);
                    }
                    longestSeq.Clear();
                }              
                
            }
            return firstLongestSubSeq;    //return the highest sub sequence list
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
