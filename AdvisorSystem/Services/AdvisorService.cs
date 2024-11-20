using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AdvisorSystem.Data;
using AdvisorSystem.Models;

namespace AdvisorSystem.Services
{
    public class AdvisorService : IAdvisorService
    {
        private readonly ApplicationDbContext _context;

        public AdvisorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Advisor> CreateAdvisorAsync(Advisor advisor)
        {
            _context.Advisors.Add(advisor);  // Add new advisor to the database
            await _context.SaveChangesAsync();  // Save changes asynchronously
            return advisor;  // Return the created advisor
        }

        public async Task<Advisor> GetAdvisorByIdAsync(int id)
        {
            return await _context.Advisors
                .AsNoTracking()  // No tracking for read-only operations
                .FirstOrDefaultAsync(a => a.Id == id);  // Find the advisor by ID
        }

        public async Task<List<Advisor>> GetAllAdvisorsAsync()
        {
            return await _context.Advisors
                .AsNoTracking()  // No tracking for read-only operations
                .ToListAsync();  // Return all advisors
        }

        public async Task<Advisor> UpdateAdvisorAsync(Advisor advisor)
        {
            var existingAdvisor = await _context.Advisors.FindAsync(advisor.Id);
            if (existingAdvisor == null) return null;

            existingAdvisor.FullName = advisor.FullName;
            existingAdvisor.SIN = advisor.SIN;
            existingAdvisor.Address = advisor.Address;
            existingAdvisor.PhoneNumber = advisor.PhoneNumber;
            existingAdvisor.HealthStatus = advisor.HealthStatus;

            await _context.SaveChangesAsync();  // Save changes asynchronously
            return existingAdvisor;  // Return the updated advisor
        }

        public async Task<bool> DeleteAdvisorAsync(int id)
        {
            var advisor = await _context.Advisors.FindAsync(id);
            if (advisor == null) return false;

            _context.Advisors.Remove(advisor);  // Remove the advisor from the database
            await _context.SaveChangesAsync();  // Save changes asynchronously
            return true;  // Return true if deletion is successful
        }
    }
}
