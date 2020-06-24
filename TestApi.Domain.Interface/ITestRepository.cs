using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApi.Domain.Entities.DataModel;

namespace TestApi.Domain.Interface
{
    public interface ITestRepository
    {
        Task<IEnumerable<CategoryDataModel>> GetCategoryInfo(string categoryId);
        Task<IEnumerable<CategoryDataModel>> GetAllCategoryInfo();
        Task<IEnumerable<CategoryBindDataModel>> GetAllCategoryBindInfo();
    }
}
