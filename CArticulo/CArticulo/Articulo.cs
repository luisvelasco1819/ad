using System;

namespace Serpis.Ad.Ventas
{
    public class Articulo
    {
        private ulong id;
        private string nombre = "";
		private decimal precio = 0;
		private ulong? categoria = null;

        public ulong Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

		public decimal Precio {
			get { return precio; }
			set { precio = value; }
		}
        
		public ulong? Categoria {
			get { return categoria; }
			set { categoria = value; }
		}
        
    }
}
