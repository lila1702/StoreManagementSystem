using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_StoreManagement.Models;
using WebAPI_StoreManagement.Service.StaffService;

namespace WebAPI_StoreManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffInterface _staffInterface;

        public StaffController(IStaffInterface staffInterface)
        {
            _staffInterface = staffInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<StaffModel>>>> GetStaffAsync()
        {
            return Ok(await _staffInterface.GetStaffAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<StaffModel>>> GetStaffWorkerByIdAsync(int id)
        {
            ServiceResponse<StaffModel> serviceResponse = await _staffInterface.GetStaffWorkerByIdAsync(id);
            return Ok(serviceResponse);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<StaffModel>>>> CreateStaffWorkerAsync(StaffModel newStaffWorker)
        {
            return Ok(await _staffInterface.CreateStaffWorkerAsync(newStaffWorker));
        }

        [HttpPut("inactivateStaffWorker/{id}")]
        public async Task<ActionResult<ServiceResponse<List<StaffModel>>>> InactivateStaffWorkerByIdAsync(int id)
        {
            ServiceResponse<List<StaffModel>> serviceResponse = await _staffInterface.InactivateStaffWorkerByIdAsync(id);
            return Ok(serviceResponse);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<StaffModel>>>> UpdateStaffWorkerByIdAsync(StaffModel editedStaffWorker)
        {
            ServiceResponse<List<StaffModel>> serviceResponse = await _staffInterface.UpdateStaffWorkerByIdAsync(editedStaffWorker);
            return Ok(serviceResponse);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<StaffModel>>>> DeleteStaffWorkerByIdAsync(int id)
        {
            ServiceResponse<List<StaffModel>> serviceResponse = await _staffInterface.DeleteStaffWorkerByIdAsync(id);
            return Ok(serviceResponse);
        }
    }
}
