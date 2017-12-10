using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;

namespace LeetCodeTests
{
	public abstract class Problem_0049
	{
		/*
Given an array of strings, group anagrams together.

For example, given: ["eat", "tea", "tan", "ate", "nat", "bat"], 
Return:
[
  ["ate", "eat","tea"],
  ["nat","tan"],
  ["bat"]
]
Note: All inputs will be in lower-case.
		*/
		public static void Test()
		{
			Solution sol = new Solution();

			/*
			var input = new int[] { 2, 7, 11, 15 };
			Console.WriteLine($"Input array: {string.Join(", ", input)}");
			*/

			var input = new string[] { "eat", "tea", "tan", "ate", "nat", "bat"};
			Console.WriteLine($"For input '{Utils.PrintArray(input)}' \n -> \n'{Utils.PrintArray(sol.GroupAnagrams(input))}'");

			/*
Submission Result: Time Limit Exceeded More Details

Last executed input:
["nozzle","punjabi","waterlogged","imprison","crux","numismatists","sultans","rambles","deprecating","aware","outfield","marlborough","guardrooms",
"roast","wattage","shortcuts","confidential","reprint","foxtrot","dispossession","floodgate","unfriendliest","semimonthlies","dwellers","walkways",
"wastrels","dippers","engrossing","undertakings","unforeseen","oscilloscopes","pioneers","geller","neglects","cultivates","mantegna","elicit","couriered",
"shielded","shrew","heartening","lucks","teammates","jewishness","documentaries","subliming","sultan","redo","recopy","flippancy","rothko","conductor",
"e","carolingian","outmanoeuvres","gewgaw","saki","sarah","snooping","hakka","highness","mewling","spender","blockhead","detonated","cognac","congaing",
"prissy","loathes","bluebell","involuntary","aping","sadly","jiving","buffalo","chided","instalment","boon","ashikaga","enigmas","recommenced","snell",
"parsley","buns","abracadabra","forewomen","persecuted","carsick","janitorial","neonate","expeditiously","porterhouse","bussed","charm","tinseled",
"pencils","inherits","crew","estimate","blacktop","mythologists","essequibo","dusky","fends","pithily","positively","participants","brew","tows",...
			*/
		}

		public class Solution
		{
			public IList<IList<string>> GroupAnagrams(string[] strs)
			{
				List<IList<string>> resList = new List<IList<string>>();
				Dictionary<int, List<IList<string>>> lenStrs = new Dictionary<int, List<IList<string>>>();
				Dictionary<int, List<char[]>> lenAnags = new Dictionary<int, List<char[]>>();

				foreach (string str in strs)
				{
					char[] chs = str.ToCharArray();
					Array.Sort(chs);
					if (lenAnags.ContainsKey(str.Length))
					{
						List<char[]> anags = lenAnags[str.Length];
						bool found = false;
						for (int ind = 0; ind < anags.Count; ind++)
						{
							if (CmpCharArrays(anags[ind], chs))
							{
								lenStrs[str.Length][ind].Add(str);
								found = true;
								break;
							}
						}
						if (!found)
						{
							var tmpList = new List<string> { str };
							lenStrs[str.Length].Add(tmpList);
							resList.Add(tmpList);
							lenAnags[str.Length].Add(chs);
						}
					}
					else
					{
						lenAnags.Add(str.Length, new List<char[]>() { chs });
						var tmplist = new List<string>() { str };
						lenStrs.Add(str.Length, new List<IList<string>>() { tmplist });
						resList.Add(tmplist);
					}


				}
				return resList;
			}
			private bool CmpCharArrays(char[] arr1, char[] arr2)
			{
				if ((arr1 == null) && (arr2 == null))
					return true;
				if ((arr1 == null) || (arr2 == null))
					return false;
				if (arr1.Length != arr2.Length)
					return false;
				for (int ind = 0; ind < arr1.Length; ind++)
					if (arr1[ind] != arr2[ind])
						return false;
				return true;
			}
		}
	}//public abstract class Problem_
}