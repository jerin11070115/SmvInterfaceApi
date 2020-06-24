using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApi.Connection;
using TestApi.Domain.Entities.BodyModel.Site;
using TestApi.Domain.Entities.DataModel.Site.Buyer;
using TestApi.Domain.Entities.DataModel.Site.Operation;
using TestApi.Domain.Interface.Site;
using TestApi.Services.Dependency;

namespace TestApi.Infrastructure.Data.Site
{
    [TransientLifetime]
    public class SiteOperationRepository: ISiteOperationRepository
    {
        IConnection _connection;
        public SiteOperationRepository(IConnection connection)
        {
            _connection = connection;
        }
        
        public async Task<IEnumerable<OperationDataModel>>GetOperationData(OperationRequestBodyModel operationRequestBodyModel)
        {
            try
            {
                return await _connection.GetConnection.QueryAsync<OperationDataModel>(
                            sql: @"[SMV].[USP_GetOperationDataForView]",
                            commandType: CommandType.StoredProcedure,
                            param: operationRequestBodyModel);
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


        public async Task<IEnumerable<OperationDataModel>> GetBasicOperationDataForView(int buyerId)
        {
            try
            {
                var parameter = new DynamicParameters();

                //parameter.Add(name: "@BuyerCategoryId", value: buyerCategoryId, dbType: DbType.Int32);
                parameter.Add(name: "@BuyerId", value: buyerId, dbType: DbType.Int32);

                return await _connection.GetConnection.QueryAsync<OperationDataModel>(
                    sql: @"[SMV].[USP_GetBasicOperationDataForView]",
                    param: parameter,
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



        public async Task<IEnumerable<OperationDataModel>> GetOperationSearchData(OperationSearchBodyModel operationSearchBodyModel)
        {
            try
            {
                return await _connection.GetConnection.QueryAsync<OperationDataModel>(
                            sql: @"[Smv].[USP_GetOperationSearchData]",
                            commandType: CommandType.StoredProcedure,
                            param: operationSearchBodyModel);
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


        public async Task<IEnumerable<OperationBuyerInfoDataModel>> GetOperationBuyerInfo(OperationBuyerInfoBodyModel operationBuyerInfoBodyModel)
        {
            try
            {
                return await _connection.GetConnection.QueryAsync<OperationBuyerInfoDataModel>(
                            sql: @"[Buyer].[USP_LoadOperationBulletinBuyerInfo]",
                            commandType: CommandType.StoredProcedure,
                            param: operationBuyerInfoBodyModel);
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

        public async Task<int> AddOperationBulletin(DataTable data)
        {
            try
            {
                return await _connection.GetConnection.ExecuteAsync(
                    sql: @"[SMV].[USP_AddOperationBulletin]",
                    commandType: CommandType.StoredProcedure,
                    param: new
                    {
                        operationTvp = data
                    }
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


        public async Task<IEnumerable<BuyerStyleNumberBodyModel>> GetBuyerStyleNumber(StyleSearchBodyModel styleSearchBodyModel)
        {
            try
            {
                return await _connection.GetConnection.QueryAsync<BuyerStyleNumberBodyModel>(
                            sql: @"[Buyer].[Usp_GetBuyerWiseStyleNumber]",
                            commandType: CommandType.StoredProcedure,
                            param: styleSearchBodyModel);
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

        public async Task<IEnumerable<OperationBulletinSummaryDataModel>> GetOperationBulletinSummary(StyleSearchBodyModel styleSearchBodyModel)
        {
            try
            {
                return await _connection.GetConnection.QueryAsync<OperationBulletinSummaryDataModel>(
                            sql: @"[Buyer].[Usp_GetBuyerAndStyleNumberWiseObData]",
                            commandType: CommandType.StoredProcedure,
                            param: styleSearchBodyModel);
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
        public async Task<IEnumerable<OperationBulletinSummaryDataModel>> GetOperationbBulletinDetails(OperationDetailsSearchBodyModel operationDetailsSearchBodyModel)
        {
            try
            {
                var result= await _connection.GetConnection.QueryAsync<OperationBulletinSummaryDataModel>(
                            sql: @"[Buyer].[Usp_GetBuyerAndStyleNumberWiseObDetailsData]",
                            commandType: CommandType.StoredProcedure,
                            param: operationDetailsSearchBodyModel);
                return result;
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
