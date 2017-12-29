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
        private String nome, area, tempo;

        public Curso(String nome, String area, String tempo)
        {
            this.nome = nome;
            this.tempo = tempo;
            this.area = area;
        }


        public String GetTempo()
        {
            return tempo;
        }

        public String GetNome()
        {
            return nome;
        }

        public String GetArea()
        {
            return area;
        }


        public override String ToString() { return nome + " - " + area + " - " + tempo + "hs\n"; }
    }
}