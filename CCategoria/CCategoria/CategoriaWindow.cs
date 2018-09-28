using System;
using System.Data;

namespace CCategoria
{
    public partial class CategoriaWindow : Gtk.Window
    {
        public CategoriaWindow() : base(Gtk.WindowType.Toplevel) {
            this.Build();

			buttonSave.Clicked += delegate {
                IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand();
                dbCommand.CommandText = "insert into categoria (nombre) values (@nombre)";
				DbCommandHelper.AddParameter(dbCommand, "nombre", entryNombre.Text);
                int filas = dbCommand.ExecuteNonQuery();
            };

        }

	}
}
