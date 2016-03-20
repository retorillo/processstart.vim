// ProcessStart.cs / The MIT License / (C) Retorillo
using System;
using System.Text;
using System.Diagnostics;
static class Program {
   static string ShellEscape(string str){
      return string.Concat("\"", str.Replace("\"", "\"\""), "\"");
   }
   static void Main(string[] args){
      try {
         var pg = args[0];
         var pg_args = new StringBuilder();
         for (var c = 1; c < args.Length; c++) {
            if (pg_args.Length > 0)
               pg_args.Append(' ');
            pg_args.Append(ShellEscape(args[c]));
         }
         Process.Start(pg, pg_args.ToString());
      }
      catch (Exception e) {
         Console.Error.WriteLine(string.Concat("ERROR: ", e.Message));
      }
   }
}
