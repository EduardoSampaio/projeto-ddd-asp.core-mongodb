using Controle.Imobilizado.Application.Interfaces;
using Controle.Imobilizado.Application.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace Controle.Imobilizado.Service.Controllers
{
    [Route("api/[controller]")]
    public class ImmobilizedController : Controller
    {
        private readonly IImmobilizedAppService _appService;

        public ImmobilizedController(IImmobilizedAppService appService)
        {
            _appService = appService;
        }

        [HttpGet("version")]
        public string Version()
        {
            return "Api Running V1";
        }

        // GET: api/Immobilized
        [HttpGet]
        public IEnumerable<ImmobilizedViewModel> Get(int? skip = 0, int? limit = 50)
        {
            return _appService.GetAll(skip, limit);
        }

        // GET api/Immobilized/5
        [HttpGet("{id}")]
        public ImmobilizedViewModel Get(string id)
        {
            return _appService.GetById(ObjectId.Parse(id));
        }

        // POST api/Immobilized
        [HttpPost]
        public IActionResult Post(ImmobilizedCreateCommand model)
        {
            try
            {
                _appService.Create(model);
                return Ok("Cadastrado com sucesso!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/Immobilized
        [HttpPut]
        public IActionResult Put(ImmobilizedUpdateCommand model)
        {
            try
            {
                _appService.Update(model);
                return Ok("Atualizado com sucesso");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/Immobilized/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                _appService.Delete(ObjectId.Parse(id));
                return Ok("Deletado com sucesso");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}