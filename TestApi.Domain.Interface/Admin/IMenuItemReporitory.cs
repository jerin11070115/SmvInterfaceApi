using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApi.Domain.Entities.BodyModel.Admin;
using TestApi.Domain.Entities.DataModel.Admin;
using TestApi.Domain.Entities.DataModel.Admin.TableModel;

namespace TestApi.Domain.Interface.Admin
{
    public interface IMenuItemReporitory
    {
        Task<int> AddCategory(CategoryInsertModel categoryInsertModel);
        
        Task<IEnumerable<CategoryDataModel>> GetCategory();
        Task<int> AddSubSubCategory(SubSubCategoryBodyModel subSubCategoryBodyModel);
        Task<int> AddItem(ItemBodyModel itemBodyModel);
        Task<int> AddSubcategory(SubCategoryBodyModel subCategoryBodyModel);
        Task<IEnumerable<SubCategoryDataModel>> GetSubCategory(int categoryId);
        Task<IEnumerable<SubSubCategoryDataModel>> GetSubSubCategory(int subCategoryId);
        Task<int> AddSubItem(SubItemBodyModel subItemBodyModel);
        Task<IEnumerable<ItemDataModel>> GetItems(int SubSubCategoryId);
        //Task<int> AddSubSubItem(SubSubItemBodyModel subSubItemBodyModel);
        Task<IEnumerable<SubItemDataModel>> GetSubItems(int ItemId);
        Task<IEnumerable<BuyerDataModel>> GetBuyers();
        Task<IEnumerable<CategoryDataModel>> GetAllCategory();
        Task<IEnumerable<SubCategoryTableDataModel>> GetAllSubCategory();
        Task<IEnumerable<SubSubCategoryTableDataModel>> GetAllSubSubCategory();
        Task<IEnumerable<ItemsTableDataModel>> GetAllItems();
        Task<IEnumerable<SubItemTableDataModel>> GetAllSubItems();
    }
}
