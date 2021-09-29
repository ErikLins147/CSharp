using System;
using System.Collections.Generic;
using System.Linq;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/cliente")]
    public class ClienteController : ControllerBase
    {
        private readonly DataContext _context;
        public ClienteController(DataContext context)
        {
            _context = context;
        }

        //POST: /api/cliente/create
        [Route("create")]
        [HttpPost]
        public IActionResult Create([FromBody] Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
            return Created("", cliente);
        }

        //GET: /api/cliente/list
        [Route("list")]
        [HttpGet]
        public IActionResult List() => Ok(_context.Clientes.ToList());

        //GET: api/cliente/getbyid/1
        [HttpGet]
        [Route("getbyid/{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            //Buscar um objeto pela chave primária
            Cliente cliente = _context.Clientes.Find(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        //GET: api/cliente/delete/Bolacha
        [HttpDelete]
        [Route("delete/{name}")]
        public IActionResult Delete(string name)
        {
            //Where -> Expressão lambda
            //Buscar um objeto pelo nome
            Cliente cliente = _context.Clientes.FirstOrDefault(cliente => cliente.Nome == name);
            if (cliente == null)
            {
                return NotFound();
            }
            _context.Clientes.Remove(cliente);
            _context.SaveChanges();
            return Ok(_context.Clientes.ToList());
        }

        //PUT: /api/cliente/create
        [Route("update")]
        [HttpPut]
        public IActionResult Update([FromBody] Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            _context.SaveChanges();
            return Ok(cliente);
        }
    }
}