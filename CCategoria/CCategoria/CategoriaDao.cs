using System;
using System.Collections.Generic;
using System.Data;

using Serpis.Ad;

namespace CCategoria
{
    public class CategoriaDao
    {
		private static string selectAll = "select id, nombre from categoria order by id";
		public static IList<Categoria> Categorias {
			get {
				List<Categoria> categorias = new List<Categoria>();
				IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand();
				dbCommand.CommandText = selectAll;
				IDataReader dataReader = dbCommand.ExecuteReader();
				while (dataReader.Read())
					categorias.Add(new Categoria((ulong)dataReader["id"], (string)dataReader["nombre"]));
				dataReader.Close();
				return categorias;
			}
		}
    }
}
