package serpis.ad;

import java.sql.DriverManager;
import java.sql.SQLException;
import java.time.LocalDateTime;
import java.util.List;

public class CategoriaMain {

	@FunctionalInterface
	interface DaoAction {
		void execute() throws SQLException;
	}
	
	public static void main(String[] args) throws SQLException {
		App.getInstance().setConnection(
			DriverManager.getConnection("jdbc:mysql://localhost/dbprueba", "root", "sistemas")
		);
		Menu.create("Menú Categoría")
		.add("\t1 - Nuevo", () -> tryAction(CategoriaMain::nuevo, "No se ha podido insertar."))
		.add("\t2 - Editar", () -> tryAction(CategoriaMain::editar, "No se ha podido modificar"))
		.add("\t3 - Eliminar", () -> tryAction(CategoriaMain::eliminar, "No se ha podido eliminar"))
		.add("\t4 - Consultar", () -> tryAction(CategoriaMain::consultar, "No se ha podido realizar la consulta"))
		.add("\t5 - Listar", () -> tryAction(CategoriaMain::listar, "No se ha podido realizar la consulta"))
		.exitWhen("\t0 - Salir")
		.loop();		
		App.getInstance().getConnection().close();
	}
	
	public static void tryAction(DaoAction daoAction, String errorMessage) {
		try {
			daoAction.execute();
		} catch (SQLException ex) {
			System.out.println(errorMessage);
			System.out.println(ex);
		}
	}
	
	public static void nuevo() throws SQLException {
		Categoria categoria = new Categoria();
		//CategoriaConsole.newCategoria(categoria);
		categoria.setNombre("nuevo " + LocalDateTime.now());
		CategoriaDao.save(categoria);
	}

	public static void editar() throws SQLException {
		long id = CategoriaConsole.getId();
		Categoria categoria = CategoriaDao.load(id);
		if (categoria == null) {
			CategoriaConsole.idNotExists();
			return;
		}
		CategoriaConsole.editCategoria(categoria);
		CategoriaDao.save(categoria);
	}
	
	public static void eliminar() throws SQLException {
		long id = CategoriaConsole.getId();
		if (CategoriaConsole.deleteConfirm())
			CategoriaDao.delete(id);
	}
	
	public static void consultar() throws SQLException {
		long id = CategoriaConsole.getId(); 
		Categoria categoria = CategoriaDao.load(id);
		if (categoria == null) {
			CategoriaConsole.idNotExists();
			return;
		}
		CategoriaConsole.show(categoria);
	}
	
	public static void listar() throws SQLException {
		List<Categoria> categorias = CategoriaDao.getAll();
		CategoriaConsole.showList(categorias);
	}
	
	
}
