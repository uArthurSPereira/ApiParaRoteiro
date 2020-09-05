using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiParaRoteiro.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DiretorController : ControllerBase
    {

       [HttpPost]
       public Models.TbDiretor Salvar(Models.TbDiretor diretor)
        {
            Models.apidbContext ctx =new Models.apidbContext();
            
            ctx.TbDiretor.Add(diretor);
            ctx.SaveChanges();

            return diretor;
        }

        [HttpPost("filme")]
       public Models.Response.DiretorPorFilmeNome SalvarPorFilmeNome(Models.Request.DiretorPorFilmeNomeRequest diretorReq)
        {
            Models.apidbContext ctx =new Models.apidbContext();

            Models.TbFilme filme = ctx.TbFilme.First(x => x.NmFilme == diretorReq.NmFilme);
            Models.TbDiretor diretor = new Models.TbDiretor();
            diretor.NmDiretor = diretorReq.NmDiretor;
            diretor.DtNascimento = diretorReq.DtNascimento;
            diretor.IdFilme = filme.IdFilme;

            ctx.TbDiretor.Add(diretor);
            ctx.SaveChanges();

            Models.Response.DiretorPorFilmeNome resp = new Models.Response.DiretorPorFilmeNome();
            resp.IdDiretor = diretor.IdDiretor;
            resp.IdFilme = filme.IdFilme;
            resp.NmDiretor = diretor.NmDiretor;
            resp.NmFilme = filme.NmFilme;
            resp.DtNascimento = diretor.DtNascimento;

            return resp;
        }
       
        [HttpGet]
        public List<Models.Response.DiretorResponse> Listar()
        {
            Models.apidbContext ctx = new Models.apidbContext();

            List<Models.TbDiretor> diretores = 
                    ctx.TbDiretor.Include(x => x.IdFilmeNavigation)
                                 .ToList();

            List<Models.Response.DiretorResponse> response =
                 diretores.Select( x => new Models.Response.DiretorResponse {
                     IdDiretor = x.IdDiretor,
                     IdFilme = x.IdFilme,
                     Diretor = x.NmDiretor,
                     Filme = x.IdFilmeNavigation.NmFilme,
                     Genero = x.IdFilmeNavigation.DsGenero,
                     Disponivel = x.IdFilmeNavigation.BtDisponivel
                 }).ToList();

                 
            return response;
        }

        [HttpPut]
        public void Alterar(Models.TbDiretor diretor)
        {
            Models.apidbContext ctx = new Models.apidbContext();

            Models.TbDiretor atual = ctx.TbDiretor.First(x => x.IdDiretor == diretor.IdDiretor);
            atual.NmDiretor = diretor.NmDiretor;
            atual.DtNascimento = diretor.DtNascimento;
            atual.IdFilme = diretor.IdFilme;

            ctx.SaveChanges();
        }


        [HttpDelete]
        public void Remover(Models.TbDiretor diretor)
        {
            Models.apidbContext ctx = new Models.apidbContext();

            Models.TbDiretor atual = ctx.TbDiretor.First(x => x.IdDiretor == diretor.IdDiretor);

            ctx.Remove(atual);
            ctx.SaveChanges();
        }
    }
}