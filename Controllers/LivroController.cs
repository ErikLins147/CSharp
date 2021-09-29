using System;
using System.Collections.Generic;
using System.Linq;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/livro")]
    public class LivroController : ControllerBase
    {
        private readonly DataContext _context;
        public LivroController(DataContext context)
        {
            _context = context;
        }

        //POST: /api/livro/create
        [Route("create")]
        [HttpPost]
        public IActionResult Create([FromBody] Livro livro)
        {
            _context.Livros.Add(livro);
            _context.SaveChanges();
            return Created("", livro);
        }

        //GET: /api/livro/list
        [Route("list")]
        [HttpGet]
        public IActionResult List() => Ok(_context.Livros.ToList());

        //GET: api/livro/getbyid/1
        [HttpGet]
        [Route("getbyid/{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            //Buscar um objeto pela chave primária
            Livro livro = _context.Livros.Find(id);
            if (livro == null)
            {
                return NotFound();
            }
            return Ok(livro);
        }

        //GET: api/livro/delete/Bolacha
        [HttpDelete]
        [Route("delete/{name}")]
        public IActionResult Delete(string name)
        {
            //Where -> Expressão lambda
            //Buscar um objeto pelo nome
            Livro livro = _context.Livros.FirstOrDefault(livro => livro.Nome == name);
            if (livro == null)
            {
                return NotFound();
            }
            _context.Livros.Remove(livro);
            _context.SaveChanges();
            return Ok(_context.Livros.ToList());
        }

        //PUT: /api/livro/create
        [Route("update")]
        [HttpPut]
        public IActionResult Update([FromBody] Livro livro)
        {
            _context.Livros.Update(livro);
            _context.SaveChanges();
            return Ok(livro);
        }
    }
}