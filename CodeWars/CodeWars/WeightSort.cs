using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars
{
    public class WeightSort
    {
        public static string orderWeight(string strng)
        {
            var digitArr = strng.Split(' ');
            var sortedValues = new SortedList<int, List<string>>(digitArr.Length);
            var rand = new Random();

            foreach (var item in digitArr) 
            { 
                int key = item.Sum(part => Int32.Parse(part.ToString()));
                if (sortedValues.ContainsKey(key))
                {
                    sortedValues[key].Add(item);
                    sortedValues[key].Sort();
                }
                else
                    sortedValues.Add(
                        key, 
                        new List<string>(){
                            item
                        });
            }

            return JoinValue(sortedValues);
        }

        public static string JoinValue(SortedList<int, List<string>> sortedValues)
        {
            var tempString = new List<string>();
            foreach (var item in sortedValues)
            {
                tempString.Add(string.Join(" ", item.Value));
            }

            return String.Join(" ", tempString);
        }
    }

}
