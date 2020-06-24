using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApi.Domain.Entities.BodyModel.Admin
{
    public class UserInsertBodyModel
    {

          public string UserName {get;set;}
          public string FullName {get;set;}
          public string Password {get;set;}
          public int IsActive { get; set; }
    }
}
