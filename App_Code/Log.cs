using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Globalization;

namespace Log
{
    public enum TraceStatus
    { 
        Error,
        Warning,
        Information
    }

    public class TraceLog
    {
        public static void WriteError(string msg)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "log";
            WriteError(msg, path);  
        }

        public static void WriteError(string msg,string path)
        {
            Trace.Indent();
            TextWriterTraceListener tr = null;
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            string date = DateTime.Now.ToString("ddMMyyyy", new CultureInfo("en-US"));

            path += "\\" + date + ".txt";
            if (System.IO.File.Exists(path))
            {
                tr = new TextWriterTraceListener(System.IO.File.Open(path, System.IO.FileMode.Append));
            }
            else
            {
                tr = new TextWriterTraceListener(System.IO.File.Create(path));
            }

            date = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss", new CultureInfo("en-US"));
            Trace.Listeners.Add(tr);
            Trace.TraceError(string.Format("{0} --> {1}", date, msg));
            Trace.Unindent();
            Trace.Flush();
            tr.Close();
        }

        public static void WriteWarning(string msg)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "log";
            WriteWarning(msg, path);
        }

        public static void WriteWarning(string msg,string path)
        {
            Trace.Indent();
            TextWriterTraceListener tr = null;
           
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            string date = DateTime.Now.ToString("ddMMyyyy", new CultureInfo("en-US"));

            path += "\\" + date + ".txt";
            if (System.IO.File.Exists(path))
            {
                tr = new TextWriterTraceListener(System.IO.File.Open(path, System.IO.FileMode.Append));
            }
            else
            {
                tr = new TextWriterTraceListener(System.IO.File.Create(path));
            }

            date = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss", new CultureInfo("en-US"));
            Trace.Listeners.Add(tr);
            Trace.TraceWarning(string.Format("{0} --> {1}", date, msg));
            Trace.Unindent();
            Trace.Flush();
            tr.Close();
        }

        public static void WriteInformation(string msg)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "log";
            WriteInformation(msg, path);
        }

        public static void WriteInformation(string msg,string path)
        {
            Trace.Indent();
            TextWriterTraceListener tr = null;
           
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            string date = DateTime.Now.ToString("ddMMyyyy", new CultureInfo("en-US"));

            path += "\\" + date + ".txt";
            if (System.IO.File.Exists(path))
            {
                tr = new TextWriterTraceListener(System.IO.File.Open(path, System.IO.FileMode.Append));
            }
            else
            {
                tr = new TextWriterTraceListener(System.IO.File.Create(path));
            }

            date = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss", new CultureInfo("en-US"));
            Trace.Listeners.Add(tr);
            Trace.TraceInformation(string.Format("{0} --> {1}", date, msg));
            Trace.Unindent();
            Trace.Flush();
            tr.Close();
        }
    }
}
