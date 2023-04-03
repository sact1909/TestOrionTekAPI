using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestOrionTekAPI.Data.Entities;
using TestOrionTekAPI.Repo.Core;
using TestOrionTekAPI.Repo.Core.Abstract;

namespace TestOrionTekAPI.Controllers
{
    public class BaseController<TEntity, TEntityDTO> : ControllerBase where TEntity : class
    {
        protected readonly IUnitOfWork _unitofwork;
        protected readonly IRepository<TEntity> _genericRepository;
        protected readonly IMapper _mapper;

        
        public BaseController(IUnitOfWork unitofwork, IRepository<TEntity> genericRepository, IMapper mapper)
        {
            _unitofwork = unitofwork;
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public virtual async Task<IActionResult> Get()
        {

            try
            {
                var model = await _genericRepository.GetAllAsync();
                var modelDTOList = _mapper.Map<List<TEntityDTO>>(model);
                return Ok(modelDTOList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Ha ocurrido un error, Favor intentar nuevamente", ErrorType = ex.Message });
            }

        }




        [HttpDelete]
        [Route("Delete")]
        public virtual async Task<IActionResult> Delete(TEntityDTO dtoValues)
        {

            try
            {
                var model = _mapper.Map<TEntity>(dtoValues);
                await _genericRepository.RemoveAsync(model);
                await _unitofwork.SaveChangesAsync();
                return Ok("Registro Removido de manera Exitosa");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Ha ocurrido un error, Favor intentar nuevamente", ErrorType = ex.Message });
            }

        }

        [HttpPut]
        public virtual async Task<IActionResult> Put(TEntityDTO tEntity)
        {

            try
            {
                var model = _mapper.Map<TEntity>(tEntity);
                await _genericRepository.UpdateAsync(model);
                await _unitofwork.SaveChangesAsync();
                return Ok("Registro actualizado de manera Exitosa");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Ha ocurrido un error, Favor intentar nuevamente", ErrorType = ex.Message });
            }

        }

        [HttpPost]
        public virtual async Task<IActionResult> Post(TEntityDTO tEntity)
        {

            try
            {
                var model = _mapper.Map<TEntity>(tEntity);
                await _genericRepository.AddAsync(model);
                await _unitofwork.SaveChangesAsync();
                return Ok("Registro guardado de manera Exitosa");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Ha ocurrido un error, Favor intentar nuevamente", ErrorType = ex.Message });
            }

        }
    }
}
