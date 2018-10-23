using System;
using System.Data;

using Serpis.Ad.Ventas;

namespace CCategoria
{
    public partial class CategoriaWindow : Gtk.Window
    {
		public CategoriaWindow(Categoria categoria) : base(Gtk.WindowType.Toplevel) {
            this.Build();
			entryNombre.Text = categoria.Nombre;

			buttonSave.Clicked += delegate {
				categoria.Nombre = entryNombre.Text;
				CategoriaDao.Save(categoria);
    //            IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand();
    //            dbCommand.CommandText = "insert into categoria (nombre) values (@nombre)";
				//DbCommandHelper.AddParameter(dbCommand, "nombre", entryNombre.Text);
                //int filas = dbCommand.ExecuteNonQuery();
            };

        }

	}
}
