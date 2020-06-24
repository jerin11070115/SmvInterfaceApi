using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using TestApi.Connection;
using TestApi.Domain.Entities.BodyModel.Site;
using TestApi.Domain.Entities.DataModel.Site.Buyer;
using TestApi.Domain.Entities.DataModel.Site.Navbar;
using TestApi.Domain.Interface.Site;
using TestApi.Services.Dependency;

namespace TestApi.Infrastructure.Data.Site
{
    [TransientLifetime]
    public class NavbarRepository: INavbarRepository
    {
        IConnection _connection;
        public NavbarRepository(IConnection connection)
        {
            _connection = connection;
        }


        public async Task<IEnumerable<CategoryDataModel>>GetCategoryForNavbar()
        {
            try
            {
                var data = await _connection.GetConnection.QueryAsync<CategoryDataModel>(
                    sql: @"[Menu].[USP_GetAllActiveCategory]",
                    commandType: CommandType.StoredProcedure
                    );
                return data;
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


        public async Task<IEnumerable<MenubarDataModel>> GetAllMenubarData()
        {
            try
            {


                return await _connection.GetConnection.QueryAsync<MenubarDataModel>(
                            sql: @"[Menu].[USP_GetAllMenubarList]",
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

        public async Task<IEnumerable<BuyerMenuListDataModel>> GetBuyerMenuList(int SubItemId)
        {
            try
            {
                var parameter = new DynamicParameters();

                parameter.Add(name: "@SubItemId", value: SubItemId, dbType: DbType.Int32);
                return await _connection.GetConnection.QueryAsync<BuyerMenuListDataModel>(
                            sql: @"[Buyer].[BuyerMenuList]",
                            commandType: CommandType.StoredProcedure,
                            param:parameter
                            
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

        public async Task<IEnumerable<UserDataModel>> CheckUserForLogin(UserBodyModel userBodyModel)
        {
            try
            {
              
                return await _connection.GetConnection.QueryAsync<UserDataModel>(
                            sql: @"[dbo].[Usp_CheckUlerLogingInfo]",
                            commandType: CommandType.StoredProcedure,
                            param: userBodyModel

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

        public async Task<IEnumerable<BuyerWiseSampleStageDataModel>>LoadBuyerWiseSampleStage(int buyerId)
        {
            try
            {
                var parameter = new DynamicParameters();

                parameter.Add(name: "@BuyerId", value: buyerId, dbType: DbType.Int32);
                return await _connection.GetConnection.QueryAsync<BuyerWiseSampleStageDataModel>(
                            sql: @"[KP].[USP_LoadSamplestageById]",
                            commandType: CommandType.StoredProcedure,
                            param: parameter

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

        public async Task<IEnumerable<BuyerWiseSampleStageDataModel>> LoadSamplestageBySampleStageId(int SampleStageId)
        {
            try
            {
                var parameter = new DynamicParameters();

                parameter.Add(name: "@SampleStageId", value: SampleStageId, dbType: DbType.Int32);
                return await _connection.GetConnection.QueryAsync<BuyerWiseSampleStageDataModel>(
                            sql: @"[KP].[USP_LoadSamplestageBySampleStageId]",
                            commandType: CommandType.StoredProcedure,
                            param: parameter

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
