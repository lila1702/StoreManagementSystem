using Microsoft.EntityFrameworkCore;
using WebAPI_StoreManagement.DataContext;
using WebAPI_StoreManagement.Models;

namespace WebAPI_StoreManagement.Service.StaffService
{
    public class StaffService : IStaffInterface
    {
        private readonly ApplicationDbContext _context;

        public StaffService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<StaffModel>>> CreateStaffWorkerAsync(StaffModel newStaffWorker)
        {
            ServiceResponse<List<StaffModel>> serviceResponse = new ServiceResponse<List<StaffModel>>();

            try
            {
                if (newStaffWorker == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Type Data";
                    serviceResponse.Success = false;
                    return serviceResponse;
                }

                _context.Staff.Add(newStaffWorker);
                await _context.SaveChangesAsync();
                serviceResponse.Data = _context.Staff.ToList();
            }
            catch(Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<StaffModel>>> DeleteStaffWorkerByIdAsync(int id)
        {
            ServiceResponse<List<StaffModel>> serviceResponse = new ServiceResponse<List<StaffModel>>();

            try
            {
                StaffModel staffWorker = _context.Staff.FirstOrDefault(s => s.Id == id);
                
                if (staffWorker == null) {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Staff worker not found";
                    serviceResponse.Success = false;
                }

                _context.Staff.Remove(staffWorker);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _context.Staff.ToList();
            }
            catch(Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<StaffModel>>> GetStaffAsync()
        {
            ServiceResponse<List<StaffModel>> serviceResponse = new ServiceResponse<List<StaffModel>>();
            try
            {
                serviceResponse.Data = _context.Staff.ToList();

                if (serviceResponse.Data.Count() == 0)
                {
                    serviceResponse.Message = "No staff workers found";
                }
            }
            catch(Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }
            
            return serviceResponse;
        }

        public async Task<ServiceResponse<StaffModel>> GetStaffWorkerByIdAsync(int id)
        {
            ServiceResponse<StaffModel> serviceResponse = new ServiceResponse<StaffModel>();

            try
            {
                StaffModel staffWorker = _context.Staff.FirstOrDefault(s => s.Id == id);
                if (staffWorker == null) {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Staff worker not found";
                    serviceResponse.Success = false;
                    return serviceResponse;
                }
                serviceResponse.Data = staffWorker;
            }
            catch(Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<StaffModel>>> InactivateStaffWorkerByIdAsync(int id)
        {
            ServiceResponse<List<StaffModel>> serviceResponse = new ServiceResponse<List<StaffModel>>();

            try
            {
                StaffModel staffWorker = _context.Staff.FirstOrDefault(s => s.Id == id);
                if (staffWorker == null) {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Staff worker not found";
                    serviceResponse.Success = false;
                    return serviceResponse;
                }

                staffWorker.Active = false;
                staffWorker.ModificationDate = DateTime.UtcNow;
                
                _context.Staff.Update(staffWorker);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _context.Staff.ToList();
            }
            catch(Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<StaffModel>>> UpdateStaffWorkerByIdAsync(StaffModel editedStaffWorker)
        {
            ServiceResponse<List<StaffModel>> serviceResponse = new ServiceResponse<List<StaffModel>>();

            try
            {
                StaffModel staffWorker = _context.Staff.AsNoTracking().FirstOrDefault(s => s.Id == editedStaffWorker.Id);
                if (staffWorker == null) {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Staff worker not found";
                    serviceResponse.Success = false;
                    return serviceResponse;
                }

                staffWorker.ModificationDate = DateTime.UtcNow;

                _context.Staff.Update(editedStaffWorker);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _context.Staff.ToList();
            }
            catch(Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }
    }
}
