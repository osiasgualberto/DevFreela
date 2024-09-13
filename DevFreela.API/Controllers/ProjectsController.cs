﻿using DevFreela.Application.Models;
using DevFreela.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using DevFreela.Application.Services;

namespace DevFreela.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly DevFreelaDbContext _context;
        private readonly IProjectService _service;

        public ProjectsController(DevFreelaDbContext context, IProjectService service)
        {
            _context = context;
            _service = service;
        }


        //GEt api/projects?search=crm
        [HttpGet]
        public IActionResult Get(string search = "")
        {
            var result = _service.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _service.GetById(id);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post(CreateProjectInputModel model)
        {
            var result = _service.Insert(model);
            return CreatedAtAction(nameof(GetById), new { id = result.Data }, model);

        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateProjectInputModel model)
        {
            var result = _service.Update(model);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _service.Delete(id);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }
        //PUT api/projects/1234/start
        [HttpPut("{id}/start")]
        public IActionResult Start(int id)
        {
            var result = _service.Start(id);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }
        //PUT api/projects/1234/complete
        [HttpPut("{id}/complete")]
        public IActionResult Complete(int id)
        {
            var result = _service.Complete(id);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }
        //POST api/projects/1234/comments
        [HttpPost("{id}/comments")]
        public IActionResult PostComment(int id, CreateProjectCommentInputModel model)
        {
            var result = _service.InsertComment(id, model);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return NoContent();
        }
    }
}
