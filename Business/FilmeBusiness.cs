using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ApiParaRoteiro.Business
{
    public class FilmeBusiness
    {
        DataBase.FilmeDatabase filmeDB = new DataBase.FilmeDatabase();

        public Models.TbFilme Salvar(Models.TbFilme filme)
        {
            if  (string.IsNullOrEmpty(filme.NmFilme))
                throw new ArgumentException("Nome é obrigatório.");

            if  (string.IsNullOrEmpty(filme.DsGenero))
                throw new ArgumentException("Genero é obrigatório.");

            if  (filme.VlAvaliacao < 0)
                throw new ArgumentException("Avaliação inválida.");

            if  (filme.NrDuracao < 0)
                throw new ArgumentException("Duração inválida."); 

            if (filmeDB.FilmeExistente(filme.NmFilme))
                throw new ArgumentException("Filme já cadastrado.");        


            Models.TbFilme f = filmeDB.Salvar(filme);
            return f;            
        }
    }
}