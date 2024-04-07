using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Migrate.DTO;
using Migrate.Entities;
using Migrate.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Migrate.Services.Employee
{
    public class EmplyeService : IEmployeeService
    {
        private readonly IRepository<Employ> _repository;
        private readonly IMapper _mapper;

        public EmplyeService(IRepository<Employ> repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }


        public Task<EmployeDTO> Add(EmployeDTO data)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<EmployeDTO> Get(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<EmployeDTO>> GetAll(int page, int size)
        {
            throw new NotImplementedException();
        }

        public async Task<List<EmployeDTO>> Request(string filter, int page, int size)
        {

            var req = _repository.Request(p =>
                           p.Name!.ToLower().Contains(filter.ToLower()));

            List<EmployeDTO> list = _mapper.Map<List<EmployeDTO>>(await req.ToListAsync());
            return list;
        }

        public Task Update(int Id, EmployeDTO data)
        {

            var entity = _repository.Get(Id);
            if(entity != null)
            {
                _repository.Update(entity);
            }
            else
            {
                throw new NotFoundException($"No se encontró ninguna entidad con el ID {Id}");
            }
            return Task.CompletedTask;
        }
    }
}
