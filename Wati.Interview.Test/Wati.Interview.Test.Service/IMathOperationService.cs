using Wati.Interview.Test.Model;

namespace Wati.Interview.Test.Service
{
    public interface IMathOperationService
    {
        Task<int> AddAsync(Sum sum);
    }
}