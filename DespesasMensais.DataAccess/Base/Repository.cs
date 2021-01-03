using System.Data.SqlClient;

namespace DespesasMensais.DataAccess.Base
{
    public abstract class Repository
    {
        protected string CONNECTION = @"Data Source=localhost;Database=DespesasMensais;Integrated Security=sspi;";

        public SqlConnection GetConnection()
        {
            return new SqlConnection(CONNECTION);
        }
    }
}
