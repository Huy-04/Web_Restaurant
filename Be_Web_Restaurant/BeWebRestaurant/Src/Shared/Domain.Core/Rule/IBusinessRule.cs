using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.Rule
{
    public interface IBusinessRule
    {
        bool IsSatisfied();
        string Message { get; }
        string Field { get; }
    }
}
