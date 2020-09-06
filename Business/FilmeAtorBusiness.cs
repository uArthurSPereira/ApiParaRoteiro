using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ApiParaRoteiro.Business
{
    public class FilmeAtorBusiness
    {
        DataBase.FilmeAtorDatabase filmeAtorDb = new DataBase.FilmeAtorDatabase();

        public List<Models.Response.FilmeAtorResponse> Consultar(string genero, string personagem, string ator)
        {
            List<Models.TbFilme> filmes = filmeAtorDb.Consultar(genero,personagem, ator);
            Utils.FilmeAtorResponseConverter faConverter = new Utils.FilmeAtorResponseConverter();
            List<Models.Response.FilmeAtorResponse> response = faConverter.Converter(filmes);
            return response;
        }

    }
}