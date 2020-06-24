using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using TestApi.Connection;
using TestApi.Domain.Entities.DataModel;
using TestApi.Domain.Interface;
using TestApi.Services.Dependency;

namespace TestApi.Infrastructure.Data
{
    [TransientLifetime]
    public class TestRepository: ITestRepository
    {
        IConnection _connection;
        public TestRepository(IConnection connection)
        {
            _connection = connection;
        }    

        public async Task<IEnumerable<CategoryDataModel>> GetCategoryInfo(string categoryId)
        {

            try
            {
                var parameter = new DynamicParameters();
                parameter.Add(name: "@CategoryId", value: categoryId, dbType: DbType.String);

                return await _connection.GetConnection.QueryAsync<CategoryDataModel>(
                            sql: @"[Menu].[USP_GetCategoryInfo]",
                            commandType: CommandType.StoredProcedure,
                            param: parameter);
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

        public async Task<IEnumerable<CategoryDataModel>> GetAllCategoryInfo()
        {

            try
            {
                

                return await _connection.GetConnection.QueryAsync<CategoryDataModel>(
                            sql: @"[Menu].[USP_GetAllCategoryInfo]",
                            commandType: CommandType.StoredProcedure
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

        public async Task<IEnumerable<CategoryBindDataModel>> GetAllCategoryBindInfo()
        {
            try
            {


                return await _connection.GetConnection.QueryAsync<CategoryBindDataModel>(
                            sql: @"[Menu].[USP_GetAllCategorySubSubCategory]",
                            commandType: CommandType.StoredProcedure
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
