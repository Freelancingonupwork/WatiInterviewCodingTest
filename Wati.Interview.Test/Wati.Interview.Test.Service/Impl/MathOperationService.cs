using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wati.Interview.Test.Model;

namespace Wati.Interview.Test.Service.Impl
{
    public class MathOperationService : IMathOperationService
    {
        public async Task<int> AddAsync(Sum sum)
        {
			try
			{
				return sum.Num1 + sum.Num2;
			}
			catch (Exception)
			{
				throw;
			}
        }
    }
}
