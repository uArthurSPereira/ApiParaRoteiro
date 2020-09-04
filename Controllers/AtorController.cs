using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Mvc;

namespace ApiParaRoteiro.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AtorController
    {
        
        [HttpPost]
        public Models.TbAtor Salvar(Models.TbAtor ator)
        {
            Models.apidbContext ctx =new Models.apidbContext();
            ctx.TbAtor.Add(ator);

            ctx.SaveChanges();

            return ator;
        }

    }
}