using System;
namespace CArticulo
{
    public partial class ArticuloWindow : Gtk.Window
    {
        public ArticuloWindow() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
        }
    }
}
