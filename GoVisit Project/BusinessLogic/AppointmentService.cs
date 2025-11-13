using GoVisit_Project.DAL.Interfaces;
using GoVisit_Project.BusinessLogic.Interfaces;
using GoVisit_Project.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace GoVisit_Project.BusinessLogic
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _repository;

        public AppointmentService(IAppointmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<AppointmentModel>> GetAllAsync() =>
            await _repository.GetAllAsync();

        public async Task<AppointmentModel?> GetByIdAsync(long id) =>
            await _repository.GetByIdAsync(id);

        public async Task AddAsync(AppointmentModel appointment)
        {
            if (appointment.AppointmentDate < DateTime.UtcNow)
                throw new InvalidOperationException("Appointment date cannot be in the past.");

            await _repository.AddAsync(appointment);
        }

        public async Task UpdateAsync(long id, AppointmentModel appointment)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
                throw new KeyNotFoundException($"Appointment with Id {id} not found.");

            appointment.Id = id;
            await _repository.UpdateAsync(id, appointment);
        }

        public async Task DeleteAsync(long id)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
                throw new KeyNotFoundException($"Appointment with Id {id} not found.");

            await _repository.DeleteAsync(id);
        }
    }
}
