using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApi.Connection;
using TestApi.Domain.Entities.BodyModel.Admin;
using TestApi.Domain.Entities.DataModel.Admin;
using TestApi.Domain.Interface.Admin;
using TestApi.Services.Dependency;

namespace TestApi.Infrastructure.Data.Admin
{
    [TransientLifetime]
    public class BuyerRepository: IBuyerRepository
    {
         IConnection _connection;

        public BuyerRepository(IConnection connection)
        {
            _connection = connection;
        }

        public async Task<int>InsertBuyerInfo(string buyerName,int isActive)
        {
            try
            {
                var parameter = new DynamicParameters();

                parameter.Add(name: "@BuyerName", value: buyerName, dbType: DbType.String);
                parameter.Add(name: "@IsActive", value: isActive, dbType: DbType.Int32);


                return await _connection.GetConnection.ExecuteAsync(
                            sql: @"[buyer].[USP_InsertBuyerInfo]",
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
        public async Task<int> AddBuyerCategory(BuyerCategoryBodyModel buyerCategoryBodyModel)
        {
            try
            {
                return await _connection.GetConnection.ExecuteAsync(
                    sql: @"[Buyer].[USP_InsertBuyerCategory]",
                    commandType: CommandType.StoredProcedure,
                    param: buyerCategoryBodyModel
                    );
            }
            catch(Exception exception)
            {
                throw exception;
            }
            finally
            {
                _connection.Dispose();
            }

        }

        public async Task<IEnumerable<BuyerCategoryDataModel>> GetBuyerCategory(int buyerId)
        {
            try
            {
                var parameter = new DynamicParameters();

                parameter.Add(name: "@BuyerId", value: buyerId, dbType: DbType.Int32);



                return await _connection.GetConnection.QueryAsync<BuyerCategoryDataModel>(
                            sql: @"[Buyer].[Usp_GetBuyerCategoryForDD]",
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

        public async Task<int> AddComponent(BuyerComponentBodyModel buyerComponentBodyModel)
        {
            try
            {
                return await _connection.GetConnection.ExecuteAsync(
                    sql: @"[Buyer].[USP_AddBuyerComponent]",
                    commandType: CommandType.StoredProcedure,
                    param: buyerComponentBodyModel
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
        public async Task<int> AddComponentStage(ComponentStageBodyModel componentStageBodyModel)
        {
            try
            {
                return await _connection.GetConnection.ExecuteAsync(
                    sql: @"[Buyer].[Usp_AddComponentStage]",
                    commandType: CommandType.StoredProcedure,
                    param: componentStageBodyModel
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

        public async Task<IEnumerable<BuyerComponentDataModel>> GetBuyerComponent()
        {
            try
            {
                //var parameter = new DynamicParameters();
                //parameter.Add(name: "@BuyerId", value: buyerId, dbType: DbType.Int32);

                return await _connection.GetConnection.QueryAsync<BuyerComponentDataModel>(
                            sql: @"[Buyer].[USP_GetBuyerComponentDd]",
                            commandType: CommandType.StoredProcedure
                            //param: parameter
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
        public async Task<IEnumerable<ComponentStageDataModel>> GetBuyerComponentStages(int componentId)
        {
            try
            {
                var parameter = new DynamicParameters();

                parameter.Add(name: "@ComponentId", value: componentId, dbType: DbType.Int32);



                return await _connection.GetConnection.QueryAsync<ComponentStageDataModel>(
                            sql: @"[Buyer].[USP_LoadComponentStagedd]",
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



        public async Task<IEnumerable<ComponentStageDataModel>> GetBuyerComponentSubStages(int componentStageId)
        {
            try
            {
                var parameter = new DynamicParameters();

                parameter.Add(name: "@ComponentStageId", value: componentStageId, dbType: DbType.Int32);



                return await _connection.GetConnection.QueryAsync<ComponentStageDataModel>(
                            sql: @"[Buyer].[USP_LoadSubComponentStagedd]",
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



        public async Task<int> AddSampleStage(SampleStageBodyModel sampleStageBodyModel)
        {
            try
            {
                return await _connection.GetConnection.ExecuteAsync(
                    sql: @"[Buyer].[USP_InsertSampleStage]",
                    commandType: CommandType.StoredProcedure,
                    param: sampleStageBodyModel
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

        public async Task<IEnumerable<SampleStageDataModel>> GetBuyerSampleStages(int buyerId)
        {
            try
            {
                var parameter = new DynamicParameters();

                parameter.Add(name: "@BuyerId", value: buyerId, dbType: DbType.Int32);



                return await _connection.GetConnection.QueryAsync<SampleStageDataModel>(
                            sql: @"[Buyer].[USP_LoadBuyerWiseSampleStage]",
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

        public async Task<int> AddBuyerMapping(BuyerMappingBodyModel buyerMappingBodyModel)
        {
            try
            {
                return await _connection.GetConnection.ExecuteAsync(
                    sql: @"[Buyer].[USP_InsertBuyerMapping]",
                    commandType: CommandType.StoredProcedure,
                    param: buyerMappingBodyModel
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

        public async Task<int> AddUserAccount(UserInsertBodyModel  userInsertBodyModel)
        {
            try
            {
                return await _connection.GetConnection.ExecuteAsync(
                    sql: @"[dbo].[USP_InsertUser]",
                    commandType: CommandType.StoredProcedure,
                    param: userInsertBodyModel
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
