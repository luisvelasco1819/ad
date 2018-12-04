package serpis.ad;

import java.sql.DriverManager;
import java.sql.SQLException;

public class CategoriaMain {

	public static void main(String[] args) throws SQLException {
		App.getInstance().setConnection(
			DriverManager.getConnection("jdbc:mysql://localhost/dbprueba", "root", "sistemas")
		);
		Menu.create("Menú Categoría")
		.add("\t1 - Nuevo", CategoriaMain::nuevo)
		.add("\t2 - Editar", CategoriaMain::editar)
		.exitWhen("\t0 - Salir")
		.loop();		
		App.getInstance().getConnection().close();
}
	
	public static void nuevo() {
		System.out.println("Método nuevo");
	}

	public static void editar() {
		System.out.println("Método editar");
		int id = ScannerHelper.getInt("Id: ");
		
	}
	

}
