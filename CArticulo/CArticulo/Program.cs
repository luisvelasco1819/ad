using Gtk;
using MySql.Data.MySqlClient;
using System;

using Serpis.Ad;

namespace CArticulo
{
    class MainClass
    {
        public static void Main(string[] args)
        {
			App.Instance.DbConnection = new MySqlConnection(
                    "server=localhost;database=dbprueba;user=root;password=sistemas;ssl-mode=none"
            );

            App.Instance.DbConnection.Open();

            Application.Init();
            MainWindow win = new MainWindow();
            win.Show();
            Application.Run();

			App.Instance.DbConnection.Close();
        }
    }
}
