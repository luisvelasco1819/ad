package serpis.ad;

import java.sql.PreparedStatement;
import java.sql.SQLException;
import java.util.List;

public class CategoriaDao {
	
	private static String insertSql = "insert into categoria (nombre) values (?)";
	private static int insert(Categoria categoria) throws SQLException {
		PreparedStatement preparedStatement = App.getInstance().getConnection().prepareStatement(insertSql);
		preparedStatement.setObject(1, categoria.getNombre());
		return preparedStatement.executeUpdate();
	}

	private static int update(Categoria categoria) throws SQLException {
		return -1; //TODO implementar
	}

	public static int save(Categoria categoria) throws SQLException {
		if (categoria.getId() == 0)
			return insert(categoria);
		else
			return update(categoria);
	}
	
	public static Categoria load(long id) throws SQLException {
		return null;
	}
	
	public static int delete(long id) throws SQLException {
		return -1;
	}

	public static List<Categoria> getAll() throws SQLException {
		return null;
	}
}
