package serpis.ad;

import java.math.BigDecimal;
import java.time.LocalDateTime;
import java.util.List;
import java.util.Random;
import java.util.Scanner;
import java.util.function.Consumer;
import java.util.function.Function;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;

public class PedidoMain {

	public static void main(String[] args) {
		//entityManagerFactory = Persistence.createEntityManagerFactory("serpis.ad.hmysql");

		List<Categoria> categorias = JpaHelper.execute(entityManager -> {
			return entityManager.createQuery("select c from Categoria c order by Id", Categoria.class).getResultList();
		});
		
		for (Categoria categoria : categorias)
			System.out.printf("%4s %s %n", categoria.getId(), categoria.getNombre());
		
		JpaHelper.execute(entityManager -> {
			Articulo articulo = new Articulo();
			articulo.setNombre("nuevo " + LocalDateTime.now());
			articulo.setPrecio(new BigDecimal(1.5));
			entityManager.persist(articulo);
		});
		
		Articulo articulo = JpaHelper.execute(entityManager  -> {
			return entityManager.find(Articulo.class, 13L);
		});
		
		show(articulo);
		
		//entityManagerFactory.close();
	}
	
	private static void show(Articulo articulo) {
		System.out.printf("%4s %-30s %-30s %s %n", 
				articulo.getId(), articulo.getNombre(), articulo.getCategoria(), articulo.getPrecio());
	}

}
