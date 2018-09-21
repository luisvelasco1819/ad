using Gtk;
using MySql.Data.MySqlClient;
using System;
using System.Data;


public partial class MainWindow : Gtk.Window
{
	
    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();

		IDbConnection dbConnection = new MySqlConnection(
                "server=localhost;database=dbprueba;user=root;password=sistemas;ssl-mode=none"
        );
        dbConnection.Open();
            

		treeView.AppendColumn("ID", new CellRendererText(), "text", 0);
		treeView.AppendColumn("Nombre", new CellRendererText(), "text", 1);

		//ListStore listStore = new ListStore(typeof(ulong), typeof(string));
		ListStore listStore = new ListStore(typeof(string), typeof(string));
		treeView.Model = listStore;

		//listStore.AppendValues("1", "cat 1");
		//listStore.AppendValues("2", "cat 2");

		IDbCommand dbCommand = dbConnection.CreateCommand();
		dbCommand.CommandText = "select id, nombre from categoria order by id";
		IDataReader dataReader = dbCommand.ExecuteReader();
		while (dataReader.Read())
			listStore.AppendValues(dataReader["id"] + "", dataReader["nombre"] + "");
		dataReader.Close();


		dbConnection.Close();

    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }
}
