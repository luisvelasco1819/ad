using Gtk;
using System;
using System.Collections;

namespace Serpis.Ad
{
    public class TreeViewHelper
    {
		public static void Fill(TreeView treeView, string[] propertyNames, IEnumerable enumerable) {
			if (treeView.Model == null)
				init(treeView, propertyNames);
			ListStore listStore = (ListStore)treeView.Model;
			listStore.Clear();
			foreach (object obj in enumerable)
				listStore.AppendValues(obj);
		}

		private static void init(TreeView treeView, string[] propertyNames) {
			CellRendererText cellRendererText = new CellRendererText();
            foreach (string property in propertyNames) {
                treeView.AppendColumn(
                    property,
                    cellRendererText,
                    delegate (TreeViewColumn tree_column, CellRenderer cell, TreeModel tree_model, TreeIter iter) {
                        object model = tree_model.GetValue(iter, 0);
                        object value = model.GetType().GetProperty(property).GetValue(model);
                        cellRendererText.Text = value + "";
                    }
                );
            }
			treeView.Model = new ListStore(typeof(object));
		}

		public static object GetId(TreeView treeView)
        {
            return Get(treeView, "Id");
        }

        public static object Get(TreeView treeView, string propertyName)
        {
            if (!treeView.Selection.GetSelected(out TreeIter treeIter))
                return null;
            object model = treeView.Model.GetValue(treeIter, 0);
            return model.GetType().GetProperty(propertyName).GetValue(model);
        }
    }
}
