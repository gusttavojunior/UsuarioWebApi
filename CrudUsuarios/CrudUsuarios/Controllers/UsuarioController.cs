﻿using System.Collections.Generic;
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


        [HttpGet("obter")]
        public Usuario Obter(int Id)
        {
            var usuario = _context.Usuarios.Find(Id);
            return usuario;
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


        [HttpPost("atualizar")]
        public string Atualizar(Usuario usuario)
        {
            //var usuario = _context.Usuarios.Find(_usuario.Id);
            if(usuario != null)
            {
                _context.Usuarios.Update(usuario);
                _context.SaveChanges();

                return "Usuário: " + usuario.Nome + " foi atualizado com sucesso!" ;
            }
            return "Usuário não encontrado";
        }


        [HttpDelete("deletar")]
        public string Deletar(Usuario _usuario)
        {

            var usuario = _context.Usuarios.Find(_usuario.Id);
            if(usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                _context.SaveChanges();

                return "Usuário removido com sucesso!";
            }

            return "Usuário não encontrado";
        }



    }
}