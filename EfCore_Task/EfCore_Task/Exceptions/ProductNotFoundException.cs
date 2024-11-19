using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore_Task.Exceptions
{
     class ProductNotFoundException : Exception
    {
        public ProductNotFoundException(string message) : base(message) { }

    }
}
