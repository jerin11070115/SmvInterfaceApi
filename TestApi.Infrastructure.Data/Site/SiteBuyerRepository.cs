using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApi.Connection;
using TestApi.Domain.Entities.DataModel.Site.Buyer;
using TestApi.Domain.Interface.Site;
using TestApi.Services.Dependency;

namespace TestApi.Infrastructure.Data.Site
{
    [TransientLifetime]
    public class SiteBuyerRepository: ISiteBuyerRepository
    {
        IConnection _connection;
        public SiteBuyerRepository(IConnection connection)
        {
            _connection = connection;
        }

        //public async Task<IEnumerable<SiteBuyerComponentDataModel>> GetComponentData(int buyerCategoryId)
        //{
        //    try
        //    {
        //        var parameter = new DynamicParameters();

        //        parameter.Add(name: "@BuyerCategoryId", value: buyerCategoryId, dbType: DbType.Int32);

        //        return await _connection.GetConnection.QueryAsync<SiteBuyerComponentDataModel>(
        //            sql: @"[Buyer].[USP_GetBuyerComponentForSite]",
        //            param: parameter,
        //            commandType: CommandType.StoredProcedure
        //            );
        //    }
        //    catch (Exception exception)
        //    {
        //        throw exception;
        //    }
        //    finally
        //    {
        //        _connection.Dispose();
        //    }
        //}
        public async Task<IEnumerable<SiteBuyerComponentDataModel>> GetComponentDataNew()
        {
            try
            {
                var parameter = new DynamicParameters();

                //parameter.Add(name: "@BuyerCategoryId", value: buyerCategoryId, dbType: DbType.Int32);
                //parameter.Add(name: "@BuyerId", value: buyerId, dbType: DbType.Int32);

                return await _connection.GetConnection.QueryAsync<SiteBuyerComponentDataModel>(
                    sql: @"[Buyer].[USP_GetBuyerComponentForSite_New]",
                    //param: parameter,
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
