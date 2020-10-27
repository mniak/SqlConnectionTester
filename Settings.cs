using System;

namespace SqlConnectionTester
{
    public class Settings
    {
        public string ConnectionString { get; set; }
        public string TableName { get; set; }

        private string query = "Person.Person";
        public string Query
        {
            get => query ?? $"SELECT TOP(1) 1 FROM {TableName}";
            set => query = value;
        }

        public int Delay { get; set; } = 2000;

        public void ThrowExceptionIfInvalid()
        {
            if (ConnectionString == null)
                throw new ArgumentNullException("Invalid connection string", nameof(ConnectionString));

            if (Delay < 0)
                throw new ArgumentOutOfRangeException("The delay must be positive", nameof(Delay));

            if (Query == null)
                throw new ArgumentNullException("Invalid query/table name", nameof(Query));
        }
    }
}
