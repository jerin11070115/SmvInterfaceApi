using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApi.Domain.Entities.DataModel.Site.Buyer;

namespace TestApi.Domain.Interface.Site
{
    public interface ISiteBuyerRepository
    {
        //Task<IEnumerable<SiteBuyerComponentDataModel>> GetComponentData(int buyerCategoryId);
        Task<IEnumerable<SiteBuyerComponentDataModel>> GetComponentDataNew();
    }
}
