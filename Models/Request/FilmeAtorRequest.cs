using System;
using System.Collections;
using System.Collections.Generic;

namespace ApiParaRoteiro.Models.Request
{
    public class FilmeAtorRequest
    {
        public int IdFilme { get; set; }
        public List<FilmeAtorItemRequest> Atores { get; set; }
    }
}