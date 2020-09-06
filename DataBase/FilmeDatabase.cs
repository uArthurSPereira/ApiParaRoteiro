using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ApiParaRoteiro.DataBase
{
    public class FilmeDatabase
    {
        public Models.TbFilme Salvar(Models.TbFilme filme)
        {
            Models.apidbContext ctx =new Models.apidbContext();
            ctx.TbFilme.Add(filme);
            ctx.SaveChanges();

            return filme;
        }

        
        public bool FilmeExistente(string nome)
        {
            Models.apidbContext ctx = new Models.apidbContext();

            bool exixtente = ctx.TbFilme.Any(x => x.NmFilme == nome);
            return exixtente;
        }
    }
}