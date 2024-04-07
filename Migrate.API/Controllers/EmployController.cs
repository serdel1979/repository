using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Migrate.DTO;
using Migrate.Entities;
using Migrate.Repository;
using Migrate.Services.Employee;
using Swashbuckle.AspNetCore.Annotations;

namespace Migrate.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class EmployController : ControllerBase
    {
        private readonly IRepository<Employ> _repository;
        private readonly IMapper _mapper;
        private readonly IEmployeeService _employeeService;

        public EmployController(IRepository<Employ> repository, IMapper mapper, IEmployeeService employeeService)
        {
            this._repository = repository;
            this._mapper = mapper;
            this._employeeService = employeeService;
        }

        [HttpGet("GetAll")]
        public ResponseDTO<IEnumerable<EmployeDTO>> GetAll(int pageNumber = 1, int pageSize = 10)
        {
            var response = new ResponseDTO<IEnumerable<EmployeDTO>>();
            try
            {

                response.Data =  _mapper.Map<IEnumerable<EmployeDTO>>(_repository.GetAll(pageNumber, pageSize));
                response.Success = true;
                response.Message = string.Empty;

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Data = null;
            }
            return response;
        }



        [HttpGet("Find/{filter:alpha?}")]
        public async Task<IActionResult> FindEmployes(string? filter = "all", int pageNumber = 1, int pageSize = 10)
        {
            var response = new ResponseDTO<List<EmployeDTO>>();
            try
            {

                response.Data = await _employeeService.Request(filter, pageNumber, pageSize);
                response.Success = true;
                response.Message = string.Empty;

                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Data = null;
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }


        [HttpGet("{Id:int}")]
        public ResponseDTO<Employ> GetEmploye(int Id)
        {
            var response = new ResponseDTO<Employ>();
            try
            {
                response.Data = _repository.Get(Id);
                response.Success = true;
                response.Message = string.Empty;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Data = null;
            }
            return response;
        }

        [HttpPut("Id:int")]
        public async Task<IActionResult> Update(EmployeDTO data, int Id)
        {
            ResponseDTO<bool> response = new ResponseDTO<bool>();
            try
            {
                await _employeeService.Update(Id,data);
                response.Success = true;
                response.Data = true;
                response.Message = "Updated";

                return Ok(response);

            }catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return StatusCode(500, response);
            }
        }

    }
}
