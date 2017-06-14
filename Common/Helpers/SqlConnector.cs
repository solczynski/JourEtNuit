using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helpers
{
    public class SqlConnector : IDisposable
    {
        private SqlConnection Connection { get; set; }
        private SqlCommand Command { get; set; }
        public SqlDataReader Reader { get; private set; }


        public SqlConnector()
        {
            Connection = new SqlConnection(@"Server=WINDEV1704EVAL\SQLEXPRESS;Database=RoofTop;Integrated Security=true;");
            Connection.Open();
        }

        public void ExecuteCommand(string CommandName, Dictionary<string, object> Parameters)
        {
            SqlCommand comm = Connection.CreateCommand();
            comm.CommandType = System.Data.CommandType.StoredProcedure;
            comm.CommandText = CommandName;
            if (Parameters != null)
            {
                foreach (KeyValuePair<string, object> kvp in Parameters)
                {
                    comm.Parameters.Add(new SqlParameter(kvp.Key, kvp.Value));
                }
            }

            Reader = comm.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
        }

        void IDisposable.Dispose()
        {
            if (Reader != null)
            {
                Reader.Dispose();
            }

            if (Command != null)
            {
                Command.Dispose();
            }

            if (Connection != null)
            {
                Connection.Dispose();
            }
        }
    }
}
