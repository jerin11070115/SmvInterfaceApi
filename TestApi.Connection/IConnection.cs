using System;
using System.Data;

namespace TestApi.Connection
{
    public interface IConnection: IDisposable
    {
        IDbConnection GetConnection { get; }
    }
}
