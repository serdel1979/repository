using Microsoft.AspNetCore.Mvc;
using Migrate.DTO;
using Migrate.Entities;
using Migrate.Repository;

namespace Migrate.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class EmployController : ControllerBase
    {
        private readonly IRepository<Employ> _repository;

        public EmployController(IRepository<Employ> repository)
        {
            this._repository = repository;
        }

        [HttpGet(Name = "GetAllEmployes")]
        public ResponseDTO<IEnumerable<Employ>> GetAll(int pageNumber = 1, int pageSize = 10)
        {
            var response = new ResponseDTO<IEnumerable<Employ>>();
            try
            {

                response.Data = _repository.GetAll(pageNumber, pageSize);
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

    }
}
