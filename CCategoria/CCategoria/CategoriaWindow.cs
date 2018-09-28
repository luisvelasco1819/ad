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

                IDbDataParameter dbDataParameter = dbCommand.CreateParameter();
                dbDataParameter.ParameterName = "nombre";
                dbDataParameter.Value = entryNombre.Text;
                dbCommand.Parameters.Add(dbDataParameter);

                int filas = dbCommand.ExecuteNonQuery();

                Console.WriteLine("Nombre=" + entryNombre.Text);
            };

        }

	}
}
