using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace NoteTimer
{
    class Program
    {

        static void Main(string[] args)
        {
            string[] options = {"Technologie wsp.wytw.oprogr.",
            "Inżynieria pozyskiwania i ochr",
            "Bezpieczeństwo sys.web.i mob.",
            "Projektowanie sys. informat.",
            "Podstawy biz. i ochr.wł.intel.",
            "Zast.rozw.chmur.aplik.webowych",
            "Zaawansowane sys. baz danych"};

            Menu menu = new Menu();
            int selectedSubject = menu.MultipleChoice(true, options);
            Console.WriteLine();
            string formatted = "";
            Stopwatch stopwatch = new Stopwatch();
            while (true)
            {
                stopwatch.Start();

                var color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                string note = Console.ReadLine();
                Console.ForegroundColor = color;
                if (note == "0")
                    break;

                // format and display the timespan value.
                formatted += FormatNote(stopwatch.Elapsed, note);
                Console.WriteLine(formatted);

            }
            SaveFile(options[selectedSubject], formatted);

        }


        static string FormatNote(TimeSpan elapsed, string note)
        {
            return String.Format("{0:00}:{1:00}.{2:00} - {3}\n", elapsed.Minutes, elapsed.Seconds, elapsed.Milliseconds / 10, note);
        }

        static void SaveFile(string title, string toSave)
        {
            string path = Path.Combine("..\\", title + " " + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".txt").ToString();
            File.WriteAllText(path, toSave);
        }
    }
}
