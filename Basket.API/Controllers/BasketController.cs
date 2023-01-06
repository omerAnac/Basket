using Basket.Redis.Entities;
using Basket.Redis;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Basket.Redis.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Basket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {

        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public BasketController(IBasketRepository basketRepository, IMapper mapper)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }


        // GET api/<BasketController>/5
        [HttpGet("{userName}")]
        public async Task<TblBasket> Get(string userName)
        {
            return await _basketRepository.Get(userName);
        }

        // POST api/<BasketController>
        [HttpPost("{userName}")]
        public async Task Post(string userName)
        {
            await _basketRepository.Create(_mapper.Map<TblBasket>(new BasketDTO { UserName = userName }));
        }

        // POST api/<BasketController>
        [HttpPost]
        public async Task<TblBasket> Post([FromBody] string itemId, string userName)
        {
            return await _basketRepository.AddToBasket(userName, itemId);
        }

        // PUT api/<BasketController>/5
        [HttpPut("{userName}")]
        public async Task Put(string userName, [FromBody] TblBasket basket)
        {
            await _basketRepository.Update(userName, basket);
        }

        // DELETE api/<BasketController>/5
        [HttpDelete("{userName}")]
        public async Task Delete(string userName)
        {
            await _basketRepository.Delete(userName);
        }


    }
}
