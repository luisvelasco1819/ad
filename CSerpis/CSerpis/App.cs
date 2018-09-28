using System;
using System.Data;

namespace Serpis.Ad
{
    public class App
    {
		private App() {
        }

		private static App instance = new App();

		public static App Instance { 
			get { return instance; }
		}


		private IDbConnection dbConnection;

		public IDbConnection DbConnection {
			get { return dbConnection; }
			set { dbConnection = value; }
		}
    }
}
