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

        TreeViewHelper.Fill(treeView, new string[] {"Id", "Nombre"}, CategoriaDao.Categorias);

		newAction.Activated += delegate {
			new CategoriaWindow(new Categoria());		
		};

		editAction.Activated += delegate {
			object id = GetId(treeView);
			Console.WriteLine("Id=" +  id);
			Categoria categoria = CategoriaDao.Load(id);
			new CategoriaWindow(categoria);
		};

		refreshAction.Activated += delegate {
			TreeViewHelper.Fill(treeView, new string[] { "Id", "Nombre" }, CategoriaDao.Categorias);
		};

		treeView.Selection.Changed += delegate {
			refreshUI();
		};

		refreshUI();
    }

	public static object GetId(TreeView treeView) {
		return Get(treeView, "Id");
	}

	public static object Get(TreeView treeView, string propertyName) {
		if (!treeView.Selection.GetSelected(out TreeIter treeIter))
			return null;
        object model = treeView.Model.GetValue(treeIter, 0);
		return model.GetType().GetProperty(propertyName).GetValue(model);
	}

	private void refreshUI() {
		bool treeViewIsSelected = treeView.Selection.CountSelectedRows() > 0;
		editAction.Sensitive = treeViewIsSelected;
		deleteAction.Sensitive = treeViewIsSelected;
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
