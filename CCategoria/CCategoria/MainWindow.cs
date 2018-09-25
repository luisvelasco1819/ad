﻿using Gtk;
using MySql.Data.MySqlClient;
using System;
using System.Data;

using CCategoria;

using System.Reflection;

public partial class MainWindow : Gtk.Window
{
	private IDbConnection dbConnection;
	public MainWindow() : base(Gtk.WindowType.Toplevel) {
		Build();

		dbConnection = new MySqlConnection(
				"server=localhost;database=dbprueba;user=root;password=sistemas;ssl-mode=none"
		);
		dbConnection.Open();

		//insert();
		//update();
		update(new Categoria(3, "categoría 3 " + DateTime.Now));
		//delete();

		CellRendererText cellRendererText = new CellRendererText();

		string[] properties = new string[] { "Id", "Nombre" };

		foreach (string property in properties){
			treeView.AppendColumn(
				property,
				cellRendererText,
				delegate (TreeViewColumn tree_column, CellRenderer cell, TreeModel tree_model, TreeIter iter) {
					object model = tree_model.GetValue(iter, 0);
				    object value = model.GetType().GetProperty(property).GetValue(model);
					cellRendererText.Text = value + "";
				}
			);
	    }

		ListStore listStore = new ListStore(typeof(object));
		treeView.Model = listStore;

		IDbCommand dbCommand = dbConnection.CreateCommand();
		dbCommand.CommandText = "select id, nombre from categoria order by id";
		IDataReader dataReader = dbCommand.ExecuteReader();
		while (dataReader.Read())
			listStore.AppendValues(new Categoria((ulong)dataReader["id"], (string)dataReader["nombre"]));
		dataReader.Close();

		dbConnection.Close();
    }

	private void insert() {
		IDbCommand dbCommand = dbConnection.CreateCommand();
		dbCommand.CommandText = "insert into categoria (nombre) values ('categoría 4')";
		int filas = dbCommand.ExecuteNonQuery();
	}

	private void update() {
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "update categoria set nombre='categoría 4 modificada' where id=4";
        dbCommand.ExecuteNonQuery();
    }

    
	private void update(Categoria categoria) {
        IDbCommand dbCommand = dbConnection.CreateCommand();
		dbCommand.CommandText = "update categoria set nombre=@nombre where id=@id";

		IDbDataParameter dbDataParameterNombre = dbCommand.CreateParameter();
		dbDataParameterNombre.ParameterName = "nombre";
		dbDataParameterNombre.Value = categoria.Nombre;
		dbCommand.Parameters.Add(dbDataParameterNombre);

		IDbDataParameter dbDataParameterId = dbCommand.CreateParameter();
        dbDataParameterId.ParameterName = "id";
		dbDataParameterId.Value = categoria.Id;
        dbCommand.Parameters.Add(dbDataParameterId);

		dbCommand.ExecuteNonQuery();
    }
    
	private void delete() {
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "delete from categoria where id=4";
        dbCommand.ExecuteNonQuery();
    }

	protected void OnDeleteEvent(object sender, DeleteEventArgs a) {
        Application.Quit();
        a.RetVal = true;
    }
}
