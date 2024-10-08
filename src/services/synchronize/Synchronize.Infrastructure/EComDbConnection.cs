using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Synchronize.Infrastructure
{
    public class EComDbConnection : IEComDbConnection
    {
        private readonly IDbConnection _connection;

        public EComDbConnection(IDbConnection connection)
        {
            _connection = connection;
        }

        public string ConnectionString { get => _connection.ConnectionString; set => _connection.ConnectionString = value; }

        public int ConnectionTimeout => _connection.ConnectionTimeout;

        public string Database => _connection.Database;

        public ConnectionState State => _connection.State;

        public IDbTransaction BeginTransaction()
        {
            return _connection.BeginTransaction();
        }

        public IDbTransaction BeginTransaction(IsolationLevel il)
        {
            return _connection.BeginTransaction(il);
        }

        public void ChangeDatabase(string databaseName)
        {
            _connection.ChangeDatabase(databaseName);
        }

        public void Close()
        {
            _connection.Close();
        }

        public IDbCommand CreateCommand()
        {
            return _connection.CreateCommand();
        }

        public void Dispose()
        {
            _connection.Dispose();
        }

        public void Open()
        {
            _connection.Open();
        }
    }
}
