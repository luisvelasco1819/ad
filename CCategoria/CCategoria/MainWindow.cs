using Gtk;
using System;

using CCategoria;
using Serpis.Ad;
using Serpis.Ad.Ventas;

public class EntityDaoCategoria : EntityDao<Categoria> { }

public partial class MainWindow : Gtk.Window
{
	public MainWindow() : base(Gtk.WindowType.Toplevel) {
		Build();

		Title = "Categoría";

		EntityDaoCategoria entityDaoCategoria = new EntityDaoCategoria();

		//object defaultUlong = Activator.CreateInstance(typeof(ulong));
		object defaultUlong = Activator.CreateInstance<ulong>();

		Console.WriteLine("defaultUlong=" + defaultUlong);
        //TreeViewHelper.Fill(treeView, new string[] {"Id", "Nombre"}, CategoriaDao.Categorias);
		TreeViewHelper.Fill(treeView, new string[] { "Id", "Nombre" }, entityDaoCategoria.Enumerable);

		newAction.Activated += delegate {
			new CategoriaWindow(new Categoria());		
		};

		editAction.Activated += delegate {
			object id = TreeViewHelper.GetId(treeView);
			Categoria categoria = CategoriaDao.Load(id);
			new CategoriaWindow(categoria);
		};

		deleteAction.Activated += delegate {
			if (WindowHelper.Confirm(this, "¿Quieres eliminar el registro?")) {
				object id = TreeViewHelper.GetId(treeView);
				CategoriaDao.Delete(id);
			}
		};

		refreshAction.Activated += delegate {
			TreeViewHelper.Fill(treeView, new string[] { "Id", "Nombre" }, CategoriaDao.Categorias);
		};

		treeView.Selection.Changed += delegate {
			refreshUI();
		};

		refreshUI();
    }

	private void refreshUI() {
		bool treeViewIsSelected = treeView.Selection.CountSelectedRows() > 0;
		editAction.Sensitive = treeViewIsSelected;
		deleteAction.Sensitive = treeViewIsSelected;
	}

	protected void OnDeleteEvent(object sender, DeleteEventArgs a) {
        Application.Quit();
        a.RetVal = true;
    }
}
