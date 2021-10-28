﻿using GenericApi.Api.Filters;
using GenericApi.Core.BaseModel;
using GenericApi.Services.Services;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace GenericApi.Controllers
{
    [ApiController]
    //[Authorize]
    [Route("api/[controller]")]
    public class BaseController<TEntity, TDto> : ControllerBase
        where TEntity : IBase
        where TDto : IBaseDto
    {
        protected readonly IBaseService<TEntity, TDto> _service;
        public BaseController(IBaseService<TEntity, TDto> service)
        {
            _service = service;
        }
        //TODO: refactor this method to return dto
        [HttpGet]
        [EnableQuery]
        public virtual IActionResult Get()
        {
            var query = _service.AsQuery();
            return Ok(query);
        }

        [HttpGet("Query")]
        [ODataFeature]
        public virtual async Task<IActionResult> Query(ODataQueryOptions<TEntity> queryOptions)
        {
            var query = _service.AsQuery();

            var odataQuery = queryOptions.ApplyTo(query).Cast<TEntity>();

            var result = await _service.ProjectToDto(odataQuery);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> GetById([FromRoute] int id)
        {
            var result = await _service.GetByIdAsync(id);

            if (result is null)
                return NotFound($"The record with id {id} was not found");

            return Ok(result);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Post([FromBody] TDto dto)
        {
            var result = await _service.AddAsync(dto);

            if (result.IsSuccess is false)
                return UnprocessableEntity(result);

            return CreatedAtAction(WebRequestMethods.Http.Get, new { id = result.Entity.Id }, result.Entity);
        }

        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Put([FromRoute] int id, [FromBody] TDto dto)
        {
            var result = await _service.UpdateAsync(id, dto);

            if (result is null)
                return NotFound($"The record with id {id} was not found");

            if (result.IsSuccess is false)
                return UnprocessableEntity(result);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _service.DeleteByIdAsync(id);

            if (result is null)
                return NotFound($"The record with id {id} was not found");

            return Ok(result);
        }
    }
}
