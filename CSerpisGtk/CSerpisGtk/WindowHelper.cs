using Gtk;
using System;

namespace Serpis.Ad
{
    public class WindowHelper {

		public static bool Confirm(Window parentWindow, string message) {
			MessageDialog messageDialog = new MessageDialog(
				parentWindow,
				DialogFlags.Modal,
				MessageType.Question,
				ButtonsType.YesNo,
				message
			);
			messageDialog.Title = parentWindow.Title;
			ResponseType response = (ResponseType)messageDialog.Run();
			messageDialog.Destroy();
			return response == ResponseType.Yes;
		}

    }
}
