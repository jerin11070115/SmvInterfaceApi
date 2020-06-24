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
using TestApi.Domain.Entities.DataModel.Admin.TableModel;
using TestApi.Domain.Interface.Admin;
using TestApi.Services.Dependency;

namespace TestApi.Infrastructure.Data.Admin
{
    [TransientLifetime]
    public class MenuItemReporitory: IMenuItemReporitory
    {
        IConnection _connection;
        public MenuItemReporitory(IConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> AddCategory(CategoryInsertModel categoryInsertModel)
        {
            try
            {
                return await _connection.GetConnection.ExecuteAsync(
                          sql: @"[Menu].[USP_InsertCategory]",
                           param: categoryInsertModel,
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

        public async Task<IEnumerable<CategoryDataModel>> GetCategory()
        {
            try
            {
                var data = await _connection.GetConnection.QueryAsync<CategoryDataModel>(
                    sql: @"[Menu].[USP_GetAllActiveCategory]",
                    commandType:CommandType.StoredProcedure
                    );
                return data;
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

        public async Task<int> AddSubSubCategory(SubSubCategoryBodyModel subSubCategoryBodyModel)
        {
            try
            {
                return await _connection.GetConnection.ExecuteAsync(
                    sql: @"[Menu].[Usp_InsertSubSubCategory]",
                    param:subSubCategoryBodyModel,
                    commandType:CommandType.StoredProcedure
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
        public async Task<int>AddItem(ItemBodyModel itemBodyModel)
        {
            try
            {
                return await _connection.GetConnection.ExecuteAsync(
                    sql: @"[Menu].[Usp_InsertItems]",
                    param: itemBodyModel,
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


        public async Task<int> AddSubcategory(SubCategoryBodyModel subCategoryBodyModel)
        {
            try
            {
                return await _connection.GetConnection.ExecuteAsync(
                          sql: @"[Menu].[Usp_InsertSucategory]",
                           param: subCategoryBodyModel,
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

        public async Task<IEnumerable<SubCategoryDataModel>>GetSubCategory(int categoryId)
        {
            try
            {
                var parameter = new DynamicParameters();

                parameter.Add(name: "@CategoryId", value: categoryId, dbType: DbType.Int32);

                return await _connection.GetConnection.QueryAsync<SubCategoryDataModel>(
                            sql: @"[Menu].[USP_LoadSubCategory]",
                            commandType: CommandType.StoredProcedure,
                            param: parameter);
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

        public async Task<IEnumerable<SubSubCategoryDataModel>> GetSubSubCategory(int subCategoryId)
        {
            try
            {
                var parameter = new DynamicParameters();

                parameter.Add(name: "@SubCategoryId", value: subCategoryId, dbType: DbType.Int32);

                return await _connection.GetConnection.QueryAsync<SubSubCategoryDataModel>(
                            sql: @"[Menu].[USP_LoadSubSubCategory]",
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

        public async Task<int>AddSubItem(SubItemBodyModel subItemBodyModel)
        {
            try
            {
                return await _connection.GetConnection.ExecuteAsync(
                          sql: @"[Menu].[USP_InsertSubMenu]",
                           param: subItemBodyModel,
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
        public async Task<IEnumerable<ItemDataModel>> GetItems(int SubSubCategoryId)
        {
            try
            {
                var parameter = new DynamicParameters();

                parameter.Add(name: "@SubSubCategoryId", value: SubSubCategoryId, dbType: DbType.Int32);

                return await _connection.GetConnection.QueryAsync<ItemDataModel>(
                    sql: @"[Menu].[Usp_LoadItems]",
                    param: parameter,
                    commandType: CommandType.StoredProcedure
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

        //public async Task<int> AddSubSubItem(SubSubItemBodyModel subSubItemBodyModel)
        //{
        //    try
        //    {
        //        return await _connection.GetConnection.ExecuteAsync(
        //                  sql: @"[Menu].[Usp_InsertSubSubItem]",
        //                   param: subSubItemBodyModel,
        //                  commandType: CommandType.StoredProcedure
        //                  );
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

        public async Task<IEnumerable<SubItemDataModel>>GetSubItems(int ItemId)
        {
            try
            {
                var parameter = new DynamicParameters();

                parameter.Add(name: "@ItemId", value: ItemId, dbType: DbType.Int32);

                return await _connection.GetConnection.QueryAsync<SubItemDataModel>(
                    sql: @"[Menu].[USP_GetSubItem]",
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

        public async Task<IEnumerable<BuyerDataModel>> GetBuyers()
        {
            try
            {
                var data = await _connection.GetConnection.QueryAsync<BuyerDataModel>(
                    sql: @"[menu].[USP_LoadBuyers]",
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

        public async Task<IEnumerable<CategoryDataModel>> GetAllCategory()
        {
            try
            {
                return await _connection.GetConnection.QueryAsync<CategoryDataModel>(
                    sql: @"[Buyer].[USP_LoadAllNavCategory]",
                    commandType: CommandType.StoredProcedure
                    );
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally {
                _connection.Dispose();
            }

        }

        public async Task<IEnumerable<SubCategoryTableDataModel>> GetAllSubCategory()
        {
            try
            {
                var result = await _connection.GetConnection.QueryAsync<SubCategoryTableDataModel>(
                    sql: @"[Menu].[USP_LoadSubCategoryData]",
                    commandType:CommandType.StoredProcedure
                    );
                return result;
            }
            catch (Exception exception) {
                throw exception;
            }
            finally
            {
                _connection.Dispose();
            }
        }


        public async Task<IEnumerable<SubSubCategoryTableDataModel>> GetAllSubSubCategory()
        {
            try
            {
                var result = await _connection.GetConnection.QueryAsync<SubSubCategoryTableDataModel>(
                    sql: @"[Menu].[USP_GetAllSubSubCategoryData]",
                    commandType: CommandType.StoredProcedure
                    );
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
        public async Task<IEnumerable<ItemsTableDataModel>> GetAllItems()
        {
            try
            {
                var result = await _connection.GetConnection.QueryAsync<ItemsTableDataModel>(
                    sql: @"[Menu].[USP_GetAllItemsData]",
                    commandType: CommandType.StoredProcedure
                    );
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

        public async Task<IEnumerable<SubItemTableDataModel>> GetAllSubItems()
        {
            try
            {
                var result = await _connection.GetConnection.QueryAsync<SubItemTableDataModel>(
                    sql: @"[Menu].[USP_GetAllSubItemsData]",
                    commandType: CommandType.StoredProcedure
                    );
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
