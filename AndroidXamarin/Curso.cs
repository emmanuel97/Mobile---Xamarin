using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace AndroidXamarin
{
    public class Curso
    {

        public string Nome { get; set; }

        public string Area { get; set; }

        public string Tempo { get; set; }
        

        public Curso(string nome, string area, string tempo)
        {
            this.Nome = nome;
            this.Tempo = tempo;
            this.Area = area;
        }



        public override string ToString() { return string.Format(Nome + " - " + Area + " - " + Tempo + "hs\n"); }
    }
}