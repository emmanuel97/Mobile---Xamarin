using SQLite;
using System;
using System.IO;
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
    class Banco
    {
        public static void CreateDatabase()
        {
            try
            {
                var db = Conectar();
                db.CreateTable<CursoDB>();
                db.Close();
                Console.Out.WriteLine("_______________________________________Database created_____________________________________________________");
            }
            catch (SQLiteException ex)
            {
                Console.Out.WriteLine(ex.Message);
            }
        }

        public static void InsertData(string nome, string area, string tempo)
        {
            try
            {
                var db = Conectar();
                db.Insert(new CursoDB() { Nome = nome, Area = area, Tempo = tempo });
                db.Close();
            }
            catch (SQLiteException ex)
            {
                Console.Out.WriteLine(ex.Message);
            }
        }
        public static void UpdateData(string nome, string area, string tempo)
        {
            try
            {
                var db = Conectar();
                db.Update(new CursoDB() { Nome = nome, Area = area, Tempo = tempo });
                db.Close();
            }
            catch (SQLiteException ex)
            {
                Console.Out.WriteLine(ex.Message);
            }
        }

        public static void DeleteData(CursoDB c)
        {
            try
            {
                var db = Conectar();
                db.Delete(c);
                db.Close();
            }
            catch (SQLiteException ex)
            {
                Console.Out.WriteLine(ex.Message);
            }
        }

        public static List<CursoDB> SelectData()
        {
            List<CursoDB> cursos = null;
            try
            {
                var db = Conectar();
                cursos = db.Query<CursoDB>("Select * From CursoDB");
                db.Close();
            }
            catch (SQLiteException ex)
            {
                Console.Out.WriteLine(ex.Message);
            }
            return cursos;
        }

        public static SQLiteConnection Conectar()
        {
            SQLiteConnection conn = null;
            try
            {
                return new SQLiteConnection(Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "cursos.db3")) { Trace = true };
            }
            catch (SQLiteException ex)
            {
                Console.Out.WriteLine(ex.Message);
            }
            return conn;
        }
    }
}