using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;

namespace NoteTimer
{
    class Program
    {

        static void Main(string[] args)
        {
            List<string> options = ReadSubjects("subjects.txt");
            //string[] options = {"Technologie wsp.wytw.oprogr.",
            //"Inżynieria pozyskiwania i ochr",
            //"Bezpieczeństwo sys.web.i mob.",
            //"Projektowanie sys. informat.",
            //"Podstawy biz. i ochr.wł.intel.",
            //"Zast.rozw.chmur.aplik.webowych",
            //"Zaawansowane sys. baz danych"};


            Menu menu = new Menu();
            int selectedSubject = menu.MultipleChoice(true, options.ToArray());
            int currentChapterNumber = 1;

            string formatted = "";
            Console.WriteLine("\n\n");


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
                formatted += FormatNote(stopwatch.Elapsed, note, currentChapterNumber++);
                Console.WriteLine(formatted);

            }

            string chaptersFile = SaveFile(options[selectedSubject], formatted);
            string inputFile = DateTime.Now.ToString("yyyy-MM-dd HH") + ".mkv";
            string outputFile = string.Format("{0}{1}-chapterized.mkv", options[selectedSubject], inputFile.Substring(0, inputFile.Length - 4));

            MkvManager manager = new MkvManager(inputFile, outputFile, chaptersFile);
            int managerExitCode = manager.Run();
            Console.WriteLine("Manager exited with code: ", managerExitCode);

            Console.ReadLine();
        }


        static string FormatNote(TimeSpan elapsed, string note, int chapterNumber)
        {
            return string.Format("CHAPTER{0:00}={1:00}:{2:00}:{3:00}.{4:000}\nCHAPTER{0:00}NAME={5}\n",
                chapterNumber,
                elapsed.Hours,
                elapsed.Minutes,
                elapsed.Seconds,
                elapsed.Milliseconds / 10,
                note);

        }

        static string SaveFile(string title, string toSave)
        {
            string path = string.Format("{0} {1}.txt", title, DateTime.Now.ToString("yyyy-MM-dd HH")).ToString();
            File.WriteAllText(path, toSave);
            return path;
        }

        static List<string> ReadSubjects(string path)
        {
            string line;
            List<string> subjects = new List<string>();

            using (StreamReader file = new StreamReader(path))
            {
                while ((line = file.ReadLine()) != null)
                {
                    subjects.Add(line);
                }
            }
            return subjects;
        }
    }
}
