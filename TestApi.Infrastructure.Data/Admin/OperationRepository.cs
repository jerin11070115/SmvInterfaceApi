using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApi.Connection;
using TestApi.Domain.Entities.BodyModel.Admin.Operation;
using TestApi.Domain.Entities.DataModel.Admin.Operation;
using TestApi.Domain.Interface.Admin;
using TestApi.Services.Dependency;

namespace TestApi.Infrastructure.Data.Admin
{
    [TransientLifetime]
    public class OperationRepository: IOperationRepository
    {
        IConnection _connection;
        public OperationRepository(IConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<OperationReturnDataModel>> AddOperation(OperationBodyModel operationBodyModel)
        {
            try
            {
                return await _connection.GetConnection.QueryAsync<OperationReturnDataModel>(
                    sql: @"[SMV].[USP_AddOperation]",
                    commandType: CommandType.StoredProcedure,
                    param: operationBodyModel
                    );
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _connection.Dispose();
            }
        }
    }
}
