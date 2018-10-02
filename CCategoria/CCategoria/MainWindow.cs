using Gtk;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Reflection;

using CCategoria;
using Serpis.Ad;

public partial class MainWindow : Gtk.Window
{
	public MainWindow() : base(Gtk.WindowType.Toplevel) {
		Build();

		App.Instance.DbConnection = new MySqlConnection(
                "server=localhost;database=dbprueba;user=root;password=sistemas;ssl-mode=none"
        );

		App.Instance.DbConnection.Open();

		//new CategoriaWindow();

        TreeViewHelper.Fill(treeView, new string[] {"Id", "Nombre"}, CategoriaDao.Categorias);

		//CellRendererText cellRendererText = new CellRendererText();

		//string[] properties = new string[] { "Id", "Nombre" };

		//foreach (string property in properties){
		//	treeView.AppendColumn(
		//		property,
		//		cellRendererText,
		//		delegate (TreeViewColumn tree_column, CellRenderer cell, TreeModel tree_model, TreeIter iter) {
		//			object model = tree_model.GetValue(iter, 0);
		//		    object value = model.GetType().GetProperty(property).GetValue(model);
		//			cellRendererText.Text = value + "";
		//		}
		//	);
	 //   }

		//ListStore listStore = new ListStore(typeof(object));
		//treeView.Model = listStore;

		////IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand();
		////dbCommand.CommandText = "select id, nombre from categoria order by id";
		////IDataReader dataReader = dbCommand.ExecuteReader();
		////while (dataReader.Read())
		////	listStore.AppendValues(new Categoria((ulong)dataReader["id"], (string)dataReader["nombre"]));
		////dataReader.Close();

		//foreach (Categoria categoria in CategoriaDao.Categorias)
			//listStore.AppendValues(categoria);

    }

	private void insert() {
		IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand();
		dbCommand.CommandText = "insert into categoria (nombre) values ('categoría 4')";
		int filas = dbCommand.ExecuteNonQuery();
	}

	private void update() {
		IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand();
        dbCommand.CommandText = "update categoria set nombre='categoría 4 modificada' where id=4";
        dbCommand.ExecuteNonQuery();
    }

    
	private void update(Categoria categoria) {
		IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand();
		dbCommand.CommandText = "update categoria set nombre=@nombre where id=@id";
        DbCommandHelper.AddParameter(dbCommand, "nombre", categoria.Nombre);
		DbCommandHelper.AddParameter(dbCommand, "id", categoria.Id);
		dbCommand.ExecuteNonQuery();
    }
    
	private void delete() {
		IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand();
        dbCommand.CommandText = "delete from categoria where id=4";
        dbCommand.ExecuteNonQuery();
    }

	protected void OnDeleteEvent(object sender, DeleteEventArgs a) {
		App.Instance.DbConnection.Close();
        Application.Quit();
        a.RetVal = true;
    }
}
