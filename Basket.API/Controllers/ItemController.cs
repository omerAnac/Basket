using AutoMapper;
using Basket.BLL.DTOs;
using Basket.BLL.LogicServices;
using Basket.Entities.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Basket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IService<TblItem> _itemService;
        private readonly IMapper _mapper;

        public ItemController(IService<TblItem> itemService, IMapper mapper)
        {
            _itemService = itemService;
            _mapper = mapper;
        }

        // GET: api/<ItemController>
        [HttpGet]
        public async Task<IEnumerable<TblItem>> Get()
        {
            return await _itemService.GetAll();
        }

        // GET api/<ItemController>/5
        [HttpGet("{id}")]
        public async Task<TblItem> Get(string id)
        {
            return await _itemService.GetById(id);
        }

        // POST api/<ItemController>
        [HttpPost]
        public async Task Post([FromBody] ItemDTO item)
        {
            await _itemService.Create(_mapper.Map<TblItem>(item));
        }

        // PUT api/<ItemController>/5
        [HttpPut("{id}")]
        public async Task Put([FromBody] TblItem value)
        {
            await _itemService.Update(value);
        }

        // DELETE api/<ItemController>/5
        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            await _itemService.DeleteById(id);
        }
    }
}
