using GoVisit_Project.DAL.Interfaces;
using GoVisit_Project.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoVisit_Project.DAL
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly MongoContext _context;

        public AppointmentRepository(MongoContext context)
        {
            _context = context;
        }

        public async Task<List<AppointmentModel>> GetAllAsync() =>
            await _context.Appointments.Find(_ => true).ToListAsync();

        public async Task<AppointmentModel?> GetByIdAsync(long id) =>
            await _context.Appointments.Find(a => a.Id == id).FirstOrDefaultAsync();

        public async Task AddAsync(AppointmentModel appointment) =>
            await _context.Appointments.InsertOneAsync(appointment);

        public async Task UpdateAsync(long id, AppointmentModel appointment) =>
            await _context.Appointments.ReplaceOneAsync(a => a.Id == id, appointment);

        public async Task DeleteAsync(long id) =>
            await _context.Appointments.DeleteOneAsync(a => a.Id == id);
    }
}
