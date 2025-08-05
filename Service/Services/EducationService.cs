using Repository.Repositories;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class EducationService:IEducationService
    {
        private readonly EducationRepository _educationRepo;
        public EducationService()
        {
            _educationRepo = new EducationRepository();
        }
    }
}
