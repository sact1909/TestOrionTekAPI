using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestOrionTekAPI.Data.Entities;
using TestOrionTekAPI.Repo.Core.Abstract;
using TestOrionTekAPI.Repo.DTOs;

namespace TestOrionTekAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : BaseController<Employees, EmployeesDTO>
    {
        public IRepository<Address> _addressRepository;
        public EmployeesController(IUnitOfWork unitofwork, IRepository<Employees> genericRepository, IMapper mapper, IRepository<Address> addressRepository)
            : base(unitofwork, genericRepository, mapper)
        {

            _addressRepository = addressRepository;

        }

        [HttpGet]
        [Route("GetWithAddress")]
        public async Task<IEnumerable<EmployeesDTO>> GetWithAddress() 
        {
            var resultData = await _genericRepository.GetAllAsync(a=>a.Include(a=>a.Address));
            var mapperResult = _mapper.Map<IEnumerable<EmployeesDTO>>(resultData);

            return mapperResult;
        }

        [HttpGet]
        [Route("GetWithAddressById/{Id}")]
        public async Task<EmployeesDTO> GetWithAddressById(string Id)
        {
            var newId = Guid.Parse(Id);
            var resultData = await _genericRepository.GetSingleAsync(a => a.Include(a => a.Address), w=> w.Id == newId);
            var mapperResult = _mapper.Map<EmployeesDTO>(resultData);

            return mapperResult;
        }

        [HttpDelete]
        [Route("DeleteWithAddressById/{Id}")]
        public async Task<IActionResult> DeleteWithAddressById(string Id)
        {
            try
            {
                var newId = Guid.Parse(Id);
                var resultData = await _genericRepository.GetSingleAsync(a => a.Include(a => a.Address), w => w.Id == newId);
                await _genericRepository.RemoveAsync(resultData);
                await _unitofwork.SaveChangesAsync();
                return Ok("Registro Removido de manera Exitosa");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Ha ocurrido un error, Favor intentar nuevamente", ErrorType = ex.Message });
            }

        }

        public override async Task<IActionResult> Put(EmployeesDTO tEntity)
        {
            try
            {
                var model = _mapper.Map<Employees>(tEntity);
                var resultData = await _genericRepository.GetSingleAsync(a => a.Include(a => a.Address), w => w.Id == model.Id);

                await _addressRepository.RemoveAllAsync(resultData.Address);

                await _genericRepository.UpdateAsync(model);
                await _unitofwork.SaveChangesAsync();
                return Ok("Registro actualizado de manera Exitosa");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Ha ocurrido un error, Favor intentar nuevamente", ErrorType = ex.Message });
            }
        }


    }
}
