using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Collections.Generic;

namespace CMySql
{
    class MainClass
    {
		private static string[] getFieldNames(IDataReader dataReader) {
			//int fieldCount = dataReader.FieldCount;
			//string[] fieldNames = new string[fieldCount];
			//for (int index = 0; index < fieldCount; index++)
			//	fieldNames[index] = dataReader.GetName(index);
			//return fieldNames;
			int fieldCount = dataReader.FieldCount;
			List<string> fieldNameList = new List<string>();
			for (int index = 0; index < fieldCount; index++)
				fieldNameList.Add(dataReader.GetName(index));
			return fieldNameList.ToArray();
   		}

        public static void Main(string[] args)
        {
			IDbConnection dbConnection = new MySqlConnection(
				"server=localhost;database=dbprueba;user=root;password=sistemas;ssl-mode=none"
			);
			dbConnection.Open();
            
            IDbCommand dbCommand = dbConnection.CreateCommand();
			dbCommand.CommandText = "select id, nombre from categoria order by id";
			IDataReader dataReader = dbCommand.ExecuteReader();
			string[] fieldNames = getFieldNames(dataReader);
			foreach (string fieldName in fieldNames)
				Console.WriteLine("columna=" + fieldName);

			//while (dataReader.Read()) 
				//Console.WriteLine("id='{0}' nombre='{1}'", dataReader["id"], dataReader["nombre"]);
    			////Console.WriteLine("id={0} nombre={1}", dataReader[0], dataReader[1]);
            dataReader.Close();

			dbConnection.Close();
        }
    }
}
