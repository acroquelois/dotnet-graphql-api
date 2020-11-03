using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Skeleton.Domain.Models;
using Skeleton.Domain.Repositories.Abstraction;
using Skeleton.Internal.Repositories.Core;

namespace Skeleton.Api.Controllers
{
    [ApiController, Route("questions")]
    public class QuestionController: ControllerBase
    {
        private readonly ICrudRepository<Question, int> _repository;

        public QuestionController(ICrudRepository<Question, int> repository)
        {
            _repository = repository;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var list = await _repository.ListAsync();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var response = await _repository.GetAsync(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Question question)
        {
            try
            {
                _repository.InsertAsync(question);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}