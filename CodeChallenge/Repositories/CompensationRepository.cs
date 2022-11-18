using System.Linq;
using System.Threading.Tasks;
using CodeChallenge.Models;
using CodeChallenge.Data;
using Microsoft.EntityFrameworkCore;

namespace CodeChallenge.Repositories
{
    public interface ICompensationRepository
    {
        Task<Compensation> Add(Compensation compensation);
        Compensation GetById(string id);
    }

    public class CompensationRepository : ICompensationRepository
    {
        private readonly CompensationContext _compensationContext;

        public CompensationRepository(CompensationContext ctx)
        {
            _compensationContext = ctx;
        }

        public async Task<Compensation> Add(Compensation compensation)
        {
            _compensationContext.Compensation.Add(compensation);
            await SaveAsync();
            return compensation;
        }

        public Compensation GetById(string id)
        {
            return _compensationContext.Compensation
                .Include(c => c.Employee)
                .SingleOrDefault(c => c.Id == id);
        }

        public Task SaveAsync()
        {
            return _compensationContext.SaveChangesAsync();
        }
    }
}

