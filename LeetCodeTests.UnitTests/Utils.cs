using System.Collections.Generic;

namespace LeetCodeTests
{
    public static class Utils
    {
        /// <summary>
        /// Convert to the same format
        /// </summary>
        /// <param name="inList"></param>
        /// <returns></returns>
        public static IList<IList<int>> GetInvariantListOfList(IList<IList<int>> inList)
        {
            var result = new List<IList<int>>();
            foreach (var list in inList)
            {
                result.Add(new List<int>(list));
            }
            return result;
        }
    }
}
