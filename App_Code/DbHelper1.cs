using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.Odbc;
using System.IO;

//using iAnywhere.Data.AsaClient;
//using System.Data.SQLite;

using StaticFunction;
using Log;

namespace DatabaseHelper1
{
    public enum Providers
    {
        SqlServer, OleDb, FireBird, SQLAnywhere, SQLAnywhereAsaClient_V9,SQLite, ODBC, ConfigDefined
    }

    public enum DbConnectionState
    {
        KeepOpen, CloseOnExit
    }

    public class DbHelper1:IDisposable
    {
        private const string key = "intersoft_fox_white";
        private string strConnectionString;
        private DbConnection objConnection;
        private DbCommand objCommand;
        private DbProviderFactory objFactory = null;
        private bool boolHandleErrors;
        private string strLastError;
        private bool boolLogError;
        private string strLogFile;
        private Providers m_provider;

        internal string replace_query(string query)
        {
            string result = query;
            switch (m_provider)
            {
                case Providers.SQLAnywhereAsaClient_V9:
                    break;
                case Providers.SQLAnywhere:
                    break;
                case Providers.SQLite:
                    result = result.Replace("isnull", "ifnull");
                    result = result.Replace("getdate()", "datetime('now','localtime')");
                    break;

            }
            return result;
        }

        public DbHelper1(string connectionstring,Providers provider)
        {
            if (connectionstring.Substring(0, 9) == "N_ENCRYPT")
            {
                strConnectionString = connectionstring.Replace("N_ENCRYPT", "");
            }
            else
            {
                strConnectionString = connectionstring;// Crypto.DecryptMessage(key, connectionstring);
            }

            switch (provider)
            {
                case Providers.SqlServer:
                    objFactory = SqlClientFactory.Instance;
                    m_provider = provider;
                    break;
                case Providers.OleDb:
                    objFactory = OleDbFactory.Instance;
                    m_provider = provider;
                    break;
                //case Providers.FireBird:
                //    objFactory = FirebirdClientFactory.Instance;
                //    break;
                //case Providers.SQLAnywhere:
                //    objFactory=SAFactory.Instance;
                //    break;
                //case Providers.SQLAnywhereAsaClient_V9:
                //    objFactory = AsaFactory.Instance;
                //    break;
                //case Providers.SQLite:
                //    objFactory = SQLiteFactory.Instance;
                //    break;
                case Providers.ODBC:
                    objFactory = OdbcFactory.Instance;
                    m_provider = provider;
                    break;
                case Providers.ConfigDefined:
                    string providername = ConfigurationManager.ConnectionStrings["DBLeanBarcode"].ProviderName;
                    switch (providername)
                    {
                        case "System.Data.SqlClient":
                            objFactory = SqlClientFactory.Instance;
                            m_provider = Providers.SqlServer;
                            break;
                        case "System.Data.OleDb":
                            objFactory = OleDbFactory.Instance;
                            m_provider = Providers.OleDb;
                            break;
                        //case "FirebirdSql.Data.FirebirdClient":
                        //    objFactory = FirebirdClientFactory.Instance;
                        //    break;
                       
                        //case "iAnywhere.Data.SQLAnywhere.v4.0":
                        //    objFactory=SAFactory.Instance;
                        //    break;
                        //case "iAnywhere.Data.AsaClient":
                        //    objFactory = AsaFactory.Instance;
                        //    break;
                        //case "System.Data.SQLite":
                        //    objFactory = SQLiteFactory.Instance;
                        //    m_provider = Providers.SQLite;
                        //    break;
                        case "System.Data.Odbc":
                            objFactory = OdbcFactory.Instance;
                            m_provider = Providers.ODBC;
                            break;
                    }
                    break;

            }
            objConnection = objFactory.CreateConnection();
            objCommand = objFactory.CreateCommand();

            objConnection.ConnectionString = strConnectionString;
            objCommand.Connection = objConnection;
        }

        public DbHelper1(Providers provider)
            : this(ConfigurationManager.ConnectionStrings["DBLeanBarcode"].ConnectionString, provider)
        {
        }

        public DbHelper1()
            : this(ConfigurationManager.ConnectionStrings["DBLeanBarcode"].ConnectionString, Providers.ConfigDefined)
        {
        }

        public bool HandleErrors
        {
            get
            {
                return boolHandleErrors;
            }
            set
            {
                boolHandleErrors = value;
            }
        }

        public string LastError
        {
            get
            {
                return strLastError;
            }
        }

        public bool LogErrors
        {
            get
            {
                return boolLogError;
            }
            set
            {
                boolLogError=value;
            }
        }

        public string LogFile
        {
            get
            {
                return strLogFile;
            }
            set
            {
                strLogFile = value;
            }
        }

        public Providers Provider
        {
            get { return m_provider; }
        }

        public int AddParameter(string name,object value)
        {
            DbParameter p = objFactory.CreateParameter();
            p.ParameterName = name;
            p.Value = value;
            return objCommand.Parameters.Add(p);
        }

        public int AddParameterIsNull(string name, object value)
        {
            DbParameter p = objFactory.CreateParameter();
           p.ParameterName = name;
           if (!string.IsNullOrEmpty(value.ToString ()))
               p.Value = value;
           else
               p.Value = DBNull.Value;
           return objCommand.Parameters.Add(p);
        }
        public int AddParameterOut(string name, int size, DbType dbType,ParameterDirection direction)
        {
            DbParameter p = objFactory.CreateParameter();
            p.ParameterName = name;
            p.Size = size;
            p.DbType = dbType;
            p.Direction = direction;

            return objCommand.Parameters.Add(p);
        }

        public int AddParameter(DbParameter parameter)
        {
            return objCommand.Parameters.Add(parameter);
        }

        public DbCommand Command
        {
            get
            {
                return objCommand;
            }
        }

        public void BeginTransaction()
        {
            if (objConnection.State == System.Data.ConnectionState.Closed)
            {
                objConnection.Open();
            }
            objCommand.Transaction = objConnection.BeginTransaction();
        }

        public void CommitTransaction()
        {
            objCommand.Transaction.Commit();
            objConnection.Close();
        }

        public void RollbackTransaction()
        {
            objCommand.Transaction.Rollback();
            objConnection.Close();
        }

        public int ExecuteNonQuery(string query)
        {
            return ExecuteNonQuery(query, CommandType.Text, DbConnectionState.CloseOnExit);
        }

        public int ExecuteNonQuery(string query,CommandType commandtype)
        {
            return ExecuteNonQuery(query, commandtype, DbConnectionState.CloseOnExit);
        }

        public int ExecuteNonQuery(string query,DbConnectionState connectionstate)
        {
            return ExecuteNonQuery(query,CommandType.Text,connectionstate);
        }

        public int ExecuteNonQuery(string query,CommandType commandtype, DbConnectionState connectionstate)
        {
            objCommand.CommandText = this.replace_query(query);
            objCommand.CommandType = commandtype;
            int i = -1;
            try
            {
                if (objConnection.State == System.Data.ConnectionState.Closed)
                {
                    objConnection.Open();
                }
                i = objCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                HandleExceptions(ex);
            }
            finally
            {
                //objCommand.Parameters.Clear();
                if (connectionstate == DbConnectionState.CloseOnExit)
                {
                    objConnection.Close();
                }
            }

            return i;
        }

        public object ExecuteScalar(string query)
        {
            return ExecuteScalar(query, CommandType.Text, DbConnectionState.CloseOnExit);
        }

        public object ExecuteScalar(string query,CommandType commandtype)
        {
            return ExecuteScalar(query, commandtype, DbConnectionState.CloseOnExit);
        }

        public object ExecuteScalar(string query, DbConnectionState connectionstate)
        {
            return ExecuteScalar(query, CommandType.Text, connectionstate);
        }

        public object ExecuteScalar(string query,CommandType commandtype, DbConnectionState connectionstate)
        {
            objCommand.CommandText = this.replace_query(query);
            objCommand.CommandType = commandtype;
            object o = null;
            try
            {
                if (objConnection.State == System.Data.ConnectionState.Closed)
                {
                    objConnection.Open();
                }
                o = objCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                HandleExceptions(ex);
            }
            finally
            {
                //objCommand.Parameters.Clear();
                if (connectionstate == DbConnectionState.CloseOnExit)
                {
                    objConnection.Close();
                }
            }

            return o;
        }

        public DbDataReader ExecuteReader(string query)
        {
            return ExecuteReader(query, CommandType.Text, DbConnectionState.CloseOnExit);
        }

        public DbDataReader ExecuteReader(string query,CommandType commandtype)
        {
            return ExecuteReader(query, commandtype, DbConnectionState.CloseOnExit);
        }

        public DbDataReader ExecuteReader(string query, DbConnectionState connectionstate)
        {
            return ExecuteReader(query, CommandType.Text, connectionstate);
        }

        public DbDataReader ExecuteReader(string query,CommandType commandtype, DbConnectionState connectionstate)
        {
            objCommand.CommandText = this.replace_query(query);
            objCommand.CommandType = commandtype;
            DbDataReader reader=null;
            try
            {
                if (objConnection.State == System.Data.ConnectionState.Closed)
                {
                    objConnection.Open();
                }
                if (connectionstate == DbConnectionState.CloseOnExit)
                {
                    reader = objCommand.ExecuteReader(CommandBehavior.CloseConnection);
                }
                else
                {
                    reader = objCommand.ExecuteReader();
                }

            }
            catch (Exception ex)
            {
                HandleExceptions(ex);
            }
            finally
            {
                objCommand.Parameters.Clear();
            }

            return reader;
        }

        public DataSet ExecuteDataSet(string query)
        {
            return ExecuteDataSet(query, CommandType.Text, DbConnectionState.CloseOnExit);
        }

        public DataSet ExecuteDataSet(string query,CommandType commandtype)
        {
            return ExecuteDataSet(query, commandtype, DbConnectionState.CloseOnExit);
        }

        public DataSet ExecuteDataSet(string query,DbConnectionState connectionstate)
        {
            return ExecuteDataSet(query, CommandType.Text, connectionstate);
        }

        public DataSet ExecuteDataSet(string query,CommandType commandtype, DbConnectionState connectionstate)
        {
            DbDataAdapter adapter = objFactory.CreateDataAdapter();
            objCommand.CommandText = this.replace_query(query);
            objCommand.CommandType = commandtype;
            adapter.SelectCommand = objCommand;
            DataSet ds = new DataSet();
            try
            {
                adapter.Fill(ds);
            }
            catch (Exception ex)
            {
                HandleExceptions(ex);
            }
            finally
            {
                //objCommand.Parameters.Clear();
                if (connectionstate == DbConnectionState.CloseOnExit)
                {
                    if (objConnection.State == System.Data.ConnectionState.Open)
                    {
                        objConnection.Close();
                    }
                }
            }
            return ds;
        }

        private void HandleExceptions(Exception ex)
        {
            if (LogErrors)
            {
                WriteToLog(ex.Message);
            }
            if (HandleErrors)
            {
                strLastError = ex.Message;
            }
            else
            {
                throw ex;
            }
        }

        private void WriteToLog(string msg)
        {
            TraceLog.WriteError(msg);
        }
        
        public void Dispose()
        {
            objConnection.Close();
            objConnection.Dispose();
            objCommand.Dispose();
        }

        public string CipherMessage(string msg)
        {
            return Crypto.DecryptMessage(key, msg);
        }
    }

}
