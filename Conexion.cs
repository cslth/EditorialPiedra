using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace AppProyectoBD
{
    class Conexion
    {
        private MySqlConnection conect;
        private MySqlCommand codigo;
        private MySqlDataReader leer;

        /*public Conexion()
        {
            conect = new MySqlConnection("server=localhost;database=EditorialPiedra;Uid=root;pwd=1016;");
            conect.Open();
            codigo = new MySqlCommand
            {
                Connection = conect
            };
        }*///}

        public MySqlConnection Conect
        {
            get {
                conect = new MySqlConnection("server=localhost;database=EditorialPiedra;Uid=root;pwd=334920179;");
                conect.Open();
                return conect; }
        }
        //}
        /*
         * ----------------Este funciona-------------------------
        public MySqlConnection Conect()
        {
            MySqlConnection conec = new MySqlConnection("server=localhost;database=EditorialPiedra;Uid=root;pwd=1016;");
            conec.Open();
            return conec;
        }

        public MySqlDataReader Comando(String com)
        {
            MySqlCommand codigo = new MySqlCommand(String.Format(com), Conect());
            leer = codigo.ExecuteReader();
            return leer;
        }* //-----------------------------------------------------
    
     */
        public bool LeerRead
        {
            get { return leer.Read(); }
        }
        public MySqlDataReader Leer
        {
            get { return leer; }
        }
        public void Cerrar()
        {
            conect.Close();
        }
        public void Comando(String com)
        {
            codigo =  new MySqlCommand((com),Conect);
            leer = codigo.ExecuteReader();
        }
       

    }
}
