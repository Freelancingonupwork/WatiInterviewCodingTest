using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wati.Interview.Test.Context;
using Wati.Interview.Test.Model;

namespace Wati.Interview.Test.Service.Impl
{
    public class MathOperationService : IMathOperationService
    {
		private readonly MathOperationDb mathOperationDb;

		public MathOperationService(MathOperationDb _mathOperationDb)
        {
            mathOperationDb = _mathOperationDb;
        }

        public async Task<int> AddAsync(Sum sum)
        {
			try
			{
				sum.Total = sum.Num1 + sum.Num2;
				mathOperationDb.Add(sum);
				await mathOperationDb.SaveChangesAsync();

				return sum.Total;
			}
			catch (Exception)
			{
				throw;
			}
        }
    }
}
