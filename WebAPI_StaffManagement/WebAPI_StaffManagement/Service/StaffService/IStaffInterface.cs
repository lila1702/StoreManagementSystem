using WebAPI_StoreManagement.Models;

namespace WebAPI_StoreManagement.Service.StaffService
{
    public interface IStaffInterface
    {
        Task<ServiceResponse<List<StaffModel>>> GetStaffAsync();
        Task<ServiceResponse<List<StaffModel>>> CreateStaffWorkerAsync(StaffModel newStaffWorker);
        Task<ServiceResponse<StaffModel>> GetStaffWorkerByIdAsync(int id);
        Task<ServiceResponse<List<StaffModel>>> UpdateStaffWorkerByIdAsync(StaffModel editedStaffWorker);
        Task<ServiceResponse<List<StaffModel>>> DeleteStaffWorkerByIdAsync(int id);
        Task<ServiceResponse<List<StaffModel>>> InactivateStaffWorkerByIdAsync(int id);
    }
}
