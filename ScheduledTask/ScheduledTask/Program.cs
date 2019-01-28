using ScheduledTask.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace ScheduledTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.GetEncoding(1251);
            Console.WriteLine(GetKey("Як скласти ЗНО? Як піготуватися до ЗНО? Лооол Як вивчити метаматику? Що мені завтра вдягнути? Скільки мені років? а що ти вже вмієш? Хто тебе написав? Пісюн Хай <ss type='laugh'>:D</ss> ти тут? Гоу поваляємся? ждту Скільки зірок на небі? Кто дал тебе такое имя? ти працюєш? Чим займається? ти Біл Гецтс Де ти живеш? Пошлікаться Скажи їм що вони підари"));

            Console.ReadKey();
        }

        public static string GetKey(string inputAnswer)
        {
            var rgx = new Regex("(([А-Яа-яіІїЇєЄ]){3,})");
            var allMatches = rgx.Matches(inputAnswer);

            var words = new StringBuilder(allMatches.Count);
            for (int i = 0; i < allMatches.Count; i++)
            {
                string prefix = i == 0 ? "{0}" : "+{0}";
                words.AppendFormat(prefix, allMatches[i]);
            }

            return words.ToString();
        }
    }
}
