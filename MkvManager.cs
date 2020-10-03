using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace NoteTimer
{
    public class MkvManager
    {
        private readonly string _input;
        private readonly string _output;
        private readonly string _chapters;

        public MkvManager(string input, string output, string chapters)
        {
            _input = input;
            _output = output;
            _chapters = chapters;
        }
        public int Run()
        {
            Process proc = new Process();
            proc.StartInfo.FileName = "C:\\Program Files\\MKVToolNix\\mkvmerge.exe";
            proc.StartInfo.Arguments = string.Format("--chapters \"{0}\" -o \"{1}\" \"{2}\"", _chapters, _output, _input);
            proc.Start();
            proc.WaitForExit();
            int exitCode = proc.ExitCode;
            proc.Close();

            return exitCode;
        }
    }
}
