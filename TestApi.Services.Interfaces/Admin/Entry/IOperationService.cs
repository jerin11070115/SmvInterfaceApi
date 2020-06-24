using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApi.Domain.Entities.BodyModel.Admin.Operation;
using TestApi.Domain.Entities.DataModel.Admin.Operation;

namespace TestApi.Services.Interfaces.Admin.Entry
{
    public interface IOperationService
    {
         Task<IEnumerable<OperationReturnDataModel>> AddOperation();
    }
}
