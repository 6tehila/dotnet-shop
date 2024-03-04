using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shop.API.Models;
using Shop.Core;
using Shop.Core.DTOs;
using Shop.Core.Entities;
using Shop.Core.Service;
using Shop.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProviderController : ControllerBase
    {
        private readonly IProviderService _providerService;
        private readonly IMapper _mapper;

        
        public ProviderController(IProviderService providerService,IMapper mapper)
        {
            _providerService = providerService;
            _mapper = mapper;   
           
        }

        // GET: api/<ProviderController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var list= _providerService.GetProvidersAsync();
            var listDto = _mapper.Map<IEnumerable<ProviderDTO>>(list);
            return Ok(listDto);
        }

        // GET api/<ProviderController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var provider=_providerService.GetProviderById(id);
            var providerDTO= _mapper.Map<Provider>(provider);            
            return Ok(providerDTO);
        }

        // POST api/<ProviderController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProviderPostModel provider)
        {
            var providerToAdd = new Provider { Id = provider.Id, Name = provider.Name, City = provider.City };
            var newProvider=await _providerService.AddProviderAsync(providerToAdd);
            return Ok(newProvider);
        }

        // PUT api/<ProviderController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Provider provider)
        {
            var providerToAdd = new Provider { Id = provider.Id, Name = provider.Name, City = provider.City };
            var newProvider = _providerService.UpdateProvider(id,providerToAdd);
            return Ok(newProvider);
            
        }

        // DELETE api/<ProviderController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _providerService.DeleteProvider(id);    
            return Ok();    
        }
    }
}
