using System;
using Gtk;
using Serpis.Ad;
using Serpis.Ad.Ventas;

using CArticulo;

public partial class MainWindow : Gtk.Window
{
    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
		//var list = new[] {
		//new { Id = 1, Nombre = "Artículo 1"},
		//    new { Id = 2, Nombre = "Artículo 2"},
		//    new { Id = 3, Nombre = "Artículo 3"}
		//};
		Title = "Artículo";

		EntityDao<Articulo> articuloDao = new EntityDao<Articulo>();

		TreeViewHelper.Fill(treeView, new string[] { "Id", "Nombre", "Precio", "Categoria"}, articuloDao.Enumerable);

		newAction.Activated += delegate {
            new ArticuloWindow(new Articulo());
        };

		editAction.Activated += delegate {
			object id = TreeViewHelper.GetId(treeView);
			Articulo articulo = articuloDao.Load(id);
			new ArticuloWindow(articulo);
		};

		deleteAction.Activated += delegate {
			if (WindowHelper.Confirm(this, "¿Quieres eliminar el registro?")) {
    			object id = TreeViewHelper.GetId(treeView);
    			articuloDao.Delete(id);
		    }
		};

		refreshAction.Activated += delegate {
			TreeViewHelper.Fill(treeView, new string[] { "Id", "Nombre", "Precio", "Categoria" }, articuloDao.Enumerable);
		};

		treeView.Selection.Changed += delegate {
            refreshUI();
        };

        refreshUI();
    }

    private void refreshUI()
    {
        bool treeViewIsSelected = treeView.Selection.CountSelectedRows() > 0;
        editAction.Sensitive = treeViewIsSelected;
        deleteAction.Sensitive = treeViewIsSelected;
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }
}
