using GoVisit_Project.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoVisit_Project.BusinessLogic.Interfaces
{
    public interface IAppointmentService
    {
        Task<List<AppointmentModel>> GetAllAsync();
        Task<AppointmentModel?> GetByIdAsync(long id);
        Task AddAsync(AppointmentModel appointment);
        Task UpdateAsync(long id, AppointmentModel appointment);
        Task DeleteAsync(long id);
    }
}
