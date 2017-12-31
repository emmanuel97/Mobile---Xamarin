using System;
using SQLite;

namespace AndroidXamarin
{
    class CursoDB
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Nome { get; set; }

        public string Area { get; set; }

        public string Tempo { get; set; }

        public override string ToString()
        {
            return string.Format("[Curso: ID={0}, Nome={1}, Area={2},Tempo={3}]", ID, Nome, Area,Tempo);
        }
    }
}