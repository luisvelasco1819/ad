package serpis.ad;

import java.util.List;
import java.util.Scanner;

public class CategoriaConsole {
	private static Scanner scanner = new Scanner(System.in);
	
	public static long getId() {
		return ScannerHelper.getInt("Id: ");
	}
	
	public static void newCategoria(Categoria categoria) {
		System.out.print("Nombre: ");
		String nombre = scanner.nextLine();
		categoria.setNombre(nombre);
	}
	
	
	public static void editCategoria(Categoria categoria) {
		show(categoria);
		System.out.print("Nombre: ");
		String nombre = scanner.nextLine();
		categoria.setNombre(nombre);
	}

	public static void showIdNotExists() {
		System.out.println("Ese id no existe.");
	}
	
	public static boolean deleteConfirm() {
		System.out.print("Quieres eliminar el registro [S/N] ? ");
		String response = scanner.nextLine();
		return response.equalsIgnoreCase("S");
	}
	
	public static void show(Categoria categoria) {
		System.out.println("    Id: " + categoria.getId());
		System.out.println("Nombre: " + categoria.getNombre());
	}
	
	public static void showList(List<Categoria> categorias) {
		for (Categoria categoria : categorias) 
			System.out.printf("%4s %-20s %n", categoria.getId(), categoria.getNombre());
	}
	
}

