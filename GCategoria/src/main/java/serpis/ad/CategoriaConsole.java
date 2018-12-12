package serpis.ad;

import java.util.List;

public class CategoriaConsole {
	
	public static long getId() {
		return -1;
	}
	
	public static void newCategoria(Categoria categoria) {
		
		
	}
	
	
	public static void editCategoria(Categoria categoria) {
		
	}

	public static void idNotExists() {
		
	}
	
	public static boolean deleteConfirm() {
		return false; 
	}
	
	public static void show(Categoria categoria) {
		
	}
	
	public static void showList(List<Categoria> categorias) {
		for (Categoria categoria : categorias) {
			System.out.printf("%4s %-20s %n", categoria.getId(), categoria.getNombre());
		}
		
	}
	
}

