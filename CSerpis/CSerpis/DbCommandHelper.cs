using System;
using System.Data;
namespace Serpis.Ad
{
    public class DbCommandHelper
    {
		public static void AddParameter(IDbCommand dbCommand, string parameterName, object value) {
			IDbDataParameter dbDataParameter = dbCommand.CreateParameter();
			dbDataParameter.ParameterName = parameterName;
			dbDataParameter.Value = value;
			dbCommand.Parameters.Add(dbDataParameter);
		}
    }
}
