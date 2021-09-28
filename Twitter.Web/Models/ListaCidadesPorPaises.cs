using System;
using System.Collections.Generic;

namespace Twitter.Web.Models
{
    public class ListaCidadesPorPaises
    {
        public string Pais { get; set; }
        public string CodigoPais { get; set; }
        public int Woeid { get; set; }
        public List<Cidade> Cidades { get; set; }

    }
}
