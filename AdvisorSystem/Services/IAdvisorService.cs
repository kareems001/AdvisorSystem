using System.Collections.Generic;
using System.Threading.Tasks;
using AdvisorSystem.Models;
namespace AdvisorSystem.Services
{
    public interface IAdvisorService
    {
        Task<Advisor> CreateAdvisorAsync(Advisor advisor);  // Create a new Advisor
        Task<Advisor> GetAdvisorByIdAsync(int id);  // Retrieve an Advisor by ID
        Task<List<Advisor>> GetAllAdvisorsAsync();  // Retrieve all Advisors
        Task<Advisor> UpdateAdvisorAsync(Advisor advisor);  // Update an existing Advisor
        Task<bool> DeleteAdvisorAsync(int id);  // Delete an Advisor by ID
    }
}
