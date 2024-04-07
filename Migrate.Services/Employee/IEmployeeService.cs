using Migrate.DTO;
using Migrate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Migrate.Services.Employee
{
    public interface IEmployeeService
    {
        //IQueryable<TEntity> Request(Expression<Func<TEntity, bool>>? filter = null, int pageNumber = 1, int pageSize = 10);
        //IEnumerable<TEntity> GetAll(int pageNumber = 1, int pageSize = 10);
        //TEntity Get(int id);
        //void Add(TEntity data);
        //void Delete(int Id);
        //void Update(TEntity data);
        //void Save();
        //Task<List<CategoriaDTO>> Lista(string buscar);

        //Task<CategoriaDTO> Obtener(int id);

        //Task<CategoriaDTO> Crear(CategoriaDTO modelo);

        //Task<bool> Editar(CategoriaDTO modelo);
        //Task<bool> Eliminar(int Id);
        Task<List<EmployeDTO>> Request(string filter, int page, int size);
        Task<IQueryable<EmployeDTO>> GetAll(int page, int size);
        Task<EmployeDTO> Get(int Id);
        Task Update(int Id,EmployeDTO data);
        Task Delete(int Id);
        Task<EmployeDTO> Add(EmployeDTO data);

    }
}
