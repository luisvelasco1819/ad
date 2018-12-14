package serpis.ad;

import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.List;

/**
 * @author luimen
 *
 */
public class CategoriaDao {
	
	private static String insertSql = "insert into categoria (nombre) values (?)";
	private static int insert(Categoria categoria) throws SQLException {
		try (PreparedStatement preparedStatement = App.getInstance().getConnection().prepareStatement(insertSql)) {
			preparedStatement.setObject(1, categoria.getNombre());
			return preparedStatement.executeUpdate();
		}
	}
//	private static int insert(Categoria categoria) throws SQLException {
//		PreparedStatement preparedStatement = App.getInstance().getConnection().prepareStatement(insertSql);
//		preparedStatement.setObject(1, categoria.getNombre());
//		int rowCount = preparedStatement.executeUpdate();
//		preparedStatement.close();
//		return rowCount;
//	}

	private static String updateSql = "update categoria set nombre=? where id=?";
	private static int update(Categoria categoria) throws SQLException {
		try (PreparedStatement preparedStatement = App.getInstance().getConnection().prepareStatement(updateSql)) {
			preparedStatement.setObject(1, categoria.getNombre());
			preparedStatement.setObject(2, categoria.getId());
			return preparedStatement.executeUpdate();
		}
	}
	
	/**
	 * Persiste en la base de datos la categoria.
	 * Realiza un insert (si Id=0) o un update (si Id<>0)
	 * @param categoria
	 * @return Número de filas insertadas o modificadas (un 1 si se ha realizado)
	 * @throws SQLException
	 */
	public static int save(Categoria categoria) throws SQLException {
		if (categoria.getId() == 0)
			return insert(categoria);
		else
			return update(categoria);
	}
	
	
	/**
	 * Lee de la base datos la categoria con el id indicado
	 * @param id
	 * @return categoria con ese id o null si no existe
	 * @throws SQLException
	 */
	private static final String selectWhereId = "select id, nombre from categoria where id=?"; 
	public static Categoria load(long id) throws SQLException {
		try (PreparedStatement preparedStatement = App.getInstance().getConnection().prepareStatement(selectWhereId)) {
			preparedStatement.setObject(1, id);
			ResultSet resultSet = preparedStatement.executeQuery();
			if (!resultSet.next())
				return null;
			Categoria categoria = new Categoria();
			categoria.setId(resultSet.getLong("id"));
			categoria.setNombre((String)resultSet.getObject("nombre"));
			return categoria;
		}
	}
	
	
	private static String deleteSql = "delete categoria where id=?";
	public static int delete(long id) throws SQLException {
		try (PreparedStatement preparedStatement = App.getInstance().getConnection().prepareStatement(deleteSql)) {
			preparedStatement.setObject(1, id);
			return preparedStatement.executeUpdate();
		}
	}

	private static final String selectAll = "select id, nombre from categoria"; 
	public static List<Categoria> getAll() throws SQLException {
		List<Categoria> categorias = new ArrayList<>();
		Statement statement = App.getInstance().getConnection().createStatement();
		ResultSet resultSet = statement.executeQuery(selectAll);
		while (resultSet.next()) {
			Categoria categoria = new Categoria();
			//categoria.setId( ((BigInteger)resultSet.getObject("id")).longValue() );
			categoria.setId( resultSet.getLong("id") );
			categoria.setNombre((String)resultSet.getObject("nombre"));
			categorias.add(categoria);
		}
		statement.close();
		return categorias;
	}
}
