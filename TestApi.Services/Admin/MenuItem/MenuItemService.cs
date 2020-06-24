using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApi.Domain.Entities.BodyModel.Admin;
using TestApi.Domain.Entities.DataModel.Admin;
using TestApi.Domain.Entities.DataModel.Admin.TableModel;
using TestApi.Domain.Interface.Admin;
using TestApi.Services.Dependency;
using TestApi.Services.Interfaces.Admin.MenuItem;

namespace TestApi.Services.Admin.MenuItem
{
    [TransientLifetime]
    public class MenuItemService: IMenuItemService
    {

        private readonly IMenuItemReporitory _menuItemReporitory;
        public MenuItemService(IMenuItemReporitory menuItemReporitory)
        {
            _menuItemReporitory = menuItemReporitory;
        }

        public async Task<int> AddCategory(CategoryInsertModel categoryInsertModel)
        {
            return await _menuItemReporitory.AddCategory(categoryInsertModel);
        }

        public async Task<IEnumerable<CategoryDataModel>> GetCategory()
        {
            return await _menuItemReporitory.GetCategory();
        }

        public async Task<int> AddSubSubCategory(SubSubCategoryBodyModel subSubCategoryBodyModel)
        {
            return await _menuItemReporitory.AddSubSubCategory(subSubCategoryBodyModel);
        }

        public async Task<int> AddItem(ItemBodyModel itemBodyModel)
        {
            return await _menuItemReporitory.AddItem(itemBodyModel);
        }
        public async Task<int> AddSubcategory(SubCategoryBodyModel subCategoryBodyModel)
        {
            return await _menuItemReporitory.AddSubcategory(subCategoryBodyModel);
        }
        public async Task<IEnumerable<SubCategoryDataModel>> GetSubCategory(int categoryId)
        {
            return await _menuItemReporitory.GetSubCategory(categoryId);
        }

        public async Task<IEnumerable<SubSubCategoryDataModel>> GetSubSubCategory(int subCategoryId)
        {
            return await _menuItemReporitory.GetSubSubCategory(subCategoryId);
        }

        public async Task<int> AddSubItem(SubItemBodyModel subItemBodyModel)
        {
            return await _menuItemReporitory.AddSubItem(subItemBodyModel);
        }

        public async Task<IEnumerable<ItemDataModel>> GetItems(int SubSubCategoryId)
        {
            return await _menuItemReporitory.GetItems(SubSubCategoryId);
        }

        //public async Task<int> AddSubSubItem(SubSubItemBodyModel subSubItemBodyModel)
        //{
        //   return await _menuItemReporitory.AddSubSubItem(subSubItemBodyModel);
        //}
        public async Task<IEnumerable<SubItemDataModel>> GetSubItems(int ItemId)
        {
            return await _menuItemReporitory.GetSubItems(ItemId);
        }
        public async Task<IEnumerable<BuyerDataModel>> GetBuyers()
        {
            return await _menuItemReporitory.GetBuyers();
        }

        public async Task<IEnumerable<CategoryDataModel>> GetAllCategory()
        {
            return await _menuItemReporitory.GetAllCategory();

        }

        public async Task<IEnumerable<SubCategoryTableDataModel>> GetAllSubCategory()
        {
            return await _menuItemReporitory.GetAllSubCategory();
        }
        public async Task<IEnumerable<SubSubCategoryTableDataModel>> GetAllSubSubCategory()
        {
            return await _menuItemReporitory.GetAllSubSubCategory();
        }
        public async Task<IEnumerable<ItemsTableDataModel>> GetAllItems()
        {
            return await _menuItemReporitory.GetAllItems();
        }
        public async Task<IEnumerable<SubItemTableDataModel>> GetAllSubItems()
        {
            return await _menuItemReporitory.GetAllSubItems();
        }

    }
}
