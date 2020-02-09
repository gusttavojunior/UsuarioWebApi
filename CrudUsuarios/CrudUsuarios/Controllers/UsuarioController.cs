using System.Collections.Generic;
using System.Linq;
using CrudUsuarios.Models.Context;
using CrudUsuarios.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace CrudUsuarios.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly Context _context;
        public UsuarioController(Context context)
        {
            _context = context;
        }

        [HttpGet("listar")]
        public List<Usuario> Listar()
        {
            var lista = _context.Usuarios.ToList();
            return lista;
        }


        [HttpPost("inserir")]
        public string Inserir(Usuario usuario)
        {
            if(usuario != null)
            {
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();

                return "Usuário Cadastrado";
            }

            return "Usuário não cadastrado";
        }



    }
}