package serpis.ad;

import java.sql.PreparedStatement;
import java.sql.SQLException;

public class CategoriaDao {
	
	private static String insertSql = "insert into categoria (nombre) values (?)";
	public static void insert(Categoria categoria) throws SQLException {
		PreparedStatement preparedStatement = App.getInstance().getConnection().prepareStatement(insertSql);
		preparedStatement.setObject(1, categoria.getNombre());
		preparedStatement.executeUpdate();
	}

}
