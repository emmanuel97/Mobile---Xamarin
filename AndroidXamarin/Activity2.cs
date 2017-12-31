using System;
using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Widget;
using System.Json;
using System.Net;
using System.IO;
using Android.Content;

namespace AndroidXamarin
{
    [Activity(Label = "Activity2")]
    public class Activity2 : Activity
    {
        private Button button;  
        private ListView listaDeCursos;
        private List<Curso> cursos;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.cursos);
            button = (Button)FindViewById(Resource.Id.voltaBtn);

            button.Click += (sender, e) => {
                Volta();
            };
            ListarCursos();
            listaDeCursos = (ListView)FindViewById(Resource.Id.cursos);
            ArrayAdapter<Curso> ListAdapter = new ArrayAdapter<Curso>(this, Android.Resource.Layout.SimpleListItem1, cursos);
            listaDeCursos.Adapter = ListAdapter;
            listaDeCursos.ItemClick += ListaDeCursos_ItemClick;

        }

        private void ListaDeCursos_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Curso c = cursos[e.Position];
            Banco.InsertData(c.Nome,c.Area,c.Tempo);
        }

        public void Volta()
        {
            var intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }

        public void ListarCursos()
        {
            cursos = new List<Curso>();
            JsonArray jsonArray = RestCall("https://suap.ifrn.edu.br/api/v2/edu/cursos/");

            foreach (JsonObject obj in jsonArray)
            {
                Console.Out.WriteLine("Response: {0}", obj["descricao"]);
                Console.Out.WriteLine("Response: {0}", obj["modalidade"]);
                Console.Out.WriteLine("Response: {0}", obj["carga_horaria"]);
                string a = "" + obj["descricao"], b = "" + obj["modalidade"];
                int c = obj["carga_horaria"];
                Curso cur = new Curso(a, b, c.ToString());
                cursos.Add(cur);
            }

        }

        public JsonArray RestCall(string url)
        {
            HttpWebRequest request = HttpWebRequest.CreateHttp(new Uri(url));
            request.ContentType = "application/json";
            // request.Headers.Add("Accept", "application/json");
            request.Headers.Add("X-CSRFToken", "XYnw1wQNt7Ibj1D5fsZvHYoaL0baGFQsUb5nn3xeUGJE0nlHJLsjxDRfp9KXOthn");
            //
            request.Headers.Add("Authorization", "Basic MjAxNTIwMTQwNDAwMTM6TWF2ZXJpY2s3MDM=");
            request.Method = "GET";


            // Send the request to the server and wait for the response:
            using (WebResponse response = request.GetResponse())
            {
                // Get a stream representation of the HTTP web response:
                using (Stream stream = response.GetResponseStream())
                {
                    // Use this stream to build a JSON document object:
                    JsonValue jsonDoc = JsonObject.Load(stream);

                    //JsonObject respostaJson = new JsonObject{{ "consulta", jsonDoc } };
                    JsonArray jsonArray = (JsonArray)jsonDoc["results"];
                    return jsonArray;
                }
            }
        }


    }

}

