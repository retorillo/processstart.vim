// ProcessStart 
// Copyright (C) Retorillo (https://github.com/retorillo)
// Distributed under the MIT license 
// Usage: 
// processstart cmd arg1 arg2
// processstart ?path1?path2 cmd arg1 arg2
// processstart ?path1 ?path2 cmd arg1 arg2

using System;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;

static class Program {
   const string pathPrefix = "?";
   const string pathSeparator = "?";
   static readonly string[] pathExtentions = { ".exe", ".bat" };
   static string ShellEscape(string str){
      return string.Concat("\"", str.Replace("\"", "\"\""), "\"");
   }
   static string ResolveExecutable(string name, IEnumerable<string> pathes) {
      if (name.StartsWith(".") || name.Contains("\\") || name.Contains("/")) 
         return name;
      foreach (var path in pathes)
      foreach (var ext in pathExtentions) {
         var exe = Path.Combine(path, Path.ChangeExtension(name, ext));
         if (File.Exists(exe))
            return exe;
      }
      return name;
   }
   static void Main(string[] args){
      try {
         var pathes = new List<string>();
         var pg = string.Empty;
         var pg_args = new StringBuilder();
         for (var c = 0; c < args.Length; c++) {
            if (string.IsNullOrEmpty(pg)) {
               if (args[c].StartsWith(pathPrefix))
                  pathes.AddRange(args[c].Substring(pathPrefix.Length)
                     .Split(new string[] { pathSeparator }, 
                        StringSplitOptions.RemoveEmptyEntries));
               else
                  pg = args[c];
            }
            else {
               if (pg_args.Length > 0)
                  pg_args.Append(' ');
               pg_args.Append(ShellEscape(args[c]));
            }
         }
         pg = ResolveExecutable(pg, pathes);
         Process.Start(pg, pg_args.ToString());
      }
      catch (Exception e) {
         Console.Error.WriteLine(string.Concat("ERROR: ", e.Message));
      }
   }
}
