
using CodeChallenge.Models;
using CodeChallenge.Repositories;

namespace CodeChallenge.Services
{
    public interface ICompensationService
    {
        Compensation Create(Compensation compensation);
        Compensation GetById(string id);
    }

    public class CompensationService : ICompensationService
    {
        private readonly ICompensationRepository _compensationRepository;

        public CompensationService(ICompensationRepository repo)
        {
            _compensationRepository = repo;
        }

        public Compensation Create(Compensation compensation)
        {
            if (compensation != null)
            {
                _compensationRepository.Add(compensation);
            }

            return compensation;
        }

        public Compensation GetById(string id)
        {
            if (!string.IsNullOrEmpty(id.ToString()))
            {
                return _compensationRepository.GetById(id);
            }

            return null;
        }
    }
}
