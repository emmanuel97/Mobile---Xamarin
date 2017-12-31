using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using SQLite;
using System;
using System.IO;

namespace AndroidXamarin
{
    [Activity(Label = "AndroidXamarin", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private ListView listaDeCursos;
        private List<CursoDB> cursos;
        private Button button;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource __ cursos.Add(new Curso("TADS", "Informatica", "4000")
            SetContentView(Resource.Layout.Main);
            button = (Button)FindViewById(Resource.Id.button);
            
            button.Click += (sender, e) => {
                Viajar();
            };
            cursos = new List<CursoDB>();
            Banco.CreateDatabase();
            cursos=Banco.SelectData();
            listaDeCursos = (ListView)FindViewById(Resource.Id.meusCursos);
            ArrayAdapter<CursoDB> ListAdapter = new ArrayAdapter<CursoDB>(this, Android.Resource.Layout.SimpleListItem1, cursos);
            listaDeCursos.Adapter = ListAdapter;
            listaDeCursos.ItemClick += ListaDeCursos_ItemClick;
            
        }

        private void ListaDeCursos_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            CursoDB c = cursos[e.Position];
            Banco.DeleteData(c);
            Volta();
        }

        public void Viajar()
        {
            var intent = new Intent(this, typeof(Activity2));
            StartActivity(intent);
        }

        public void Volta()
        {
            var intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }





    }
}

