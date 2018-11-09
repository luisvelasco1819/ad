using System;
using Gtk;

public partial class MainWindow : Gtk.Window
{
    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();

		//var cellRendererText = new CellRendererText();
		//comboBox.PackStart(cellRendererText, expand:false);
		//comboBox.AddAttribute(cellRendererText, "text", 0);
		var labelCellRendererText = new CellRendererText();
		comboBox.PackStart(labelCellRendererText, expand: false);
		comboBox.AddAttribute(labelCellRendererText, "text", 1);

		var list = new[] {
			new {Id = 1, Nombre = "cat 1"},
			new {Id = 2, Nombre = "cat 2"},
			new {Id = 3, Nombre = "cat 3"}
		};
		int? initialId = 2;

		var listStore = new ListStore(typeof(object), typeof(string));
		var initialTreeIter = listStore.AppendValues(null, "<sin asignar>");
		foreach (var item in list) {
			var treeIter = listStore.AppendValues(item, item.Nombre);
			if (item.Id == initialId)
				initialTreeIter = treeIter;
		}
		comboBox.Model = listStore;
		comboBox.SetActiveIter(initialTreeIter);

    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }
}
