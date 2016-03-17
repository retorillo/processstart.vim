// ProcessStart.cs / The MIT License / (C) Retorillo
using System.Diagnostics;
static class Program {
   static void Main(string[] args){
      foreach (var a in args)
         Process.Start(a);
   }
}
