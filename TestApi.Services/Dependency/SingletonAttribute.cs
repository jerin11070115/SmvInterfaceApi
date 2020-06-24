using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApi.Services.Dependency
{
    [System.AttributeUsage(System.AttributeTargets.Class | System.AttributeTargets.Struct)]
    public class SingletonAttribute : System.Attribute
    {
        public double version;

        public SingletonAttribute()
        {
            version = 1.0;
        }
    }
}
