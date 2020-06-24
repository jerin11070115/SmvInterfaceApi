using System.Collections.Generic;
using System.Threading.Tasks;
using TestApi.Domain.Entities.DataModel;

namespace TestApi.Services.Interfaces
{
    public interface ITestService
    {
        Task<IEnumerable<CategoryDataModel>> GetCategoryInfo(string categoryId);
         Task<IEnumerable<CategoryDataModel>> GetAllCategoryInfo();
        Task<IEnumerable<CategoryDataModel>> GetAllCategoryBindInfo();
    }
}
