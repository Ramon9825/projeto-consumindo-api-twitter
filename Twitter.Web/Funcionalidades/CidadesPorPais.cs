using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twitter.Web.Models;

namespace Twitter.Web.Funcionalidades
{
    public class CidadesPorPais
    {
        private IEnumerable<TrendsAvailablesViewModel> _enumerable { get; set; }
        public IEnumerable<ListaCidadesPorPaises> ObterPaisesPorCidades { get; set; }
        public CidadesPorPais(IEnumerable<TrendsAvailablesViewModel> enumerable)
        {
            _enumerable = enumerable;
        }

        public void ListarPaises()
        {
            var lista = _enumerable.ToList();
            var listaPaises = new List<ListaCidadesPorPaises>();

            for (int i = 0; i < lista.Count(); i++)
            {
                if (lista[i].name == lista[i].country)
                {
                    var listaCidadesPorPaises = new ListaCidadesPorPaises();
                    listaCidadesPorPaises.Pais = lista[i].country;
                    listaCidadesPorPaises.CodigoPais = lista[i].countryCode;
                    listaCidadesPorPaises.Woeid = lista[i].woeid;
                    listaCidadesPorPaises.Cidades = new List<Cidade>();
                    listaPaises.Add(listaCidadesPorPaises);
                }

                if (lista[i].countryCode == null)
                {
                    var listaCidadesPorPaises = new ListaCidadesPorPaises();
                    listaCidadesPorPaises.Pais = "World";
                    listaCidadesPorPaises.CodigoPais = lista[i].countryCode;
                    listaCidadesPorPaises.Woeid = lista[i].woeid;
                    listaCidadesPorPaises.Cidades = new List<Cidade>();
                    listaPaises.Add(listaCidadesPorPaises);
                }
            }

            for (int i = 0; i < lista.Count(); i++)
            {
                for (int j = 0; j < listaPaises.Count(); j++)
                {
                    if (listaPaises[j].Pais == lista[i].country && lista[i].name != lista[i].country)
                    {
                        var cidade = new Cidade();
                        cidade.Nome = lista[i].name;
                        cidade.Woeid = lista[i].woeid;
                        listaPaises[j].Cidades.Add(cidade);
                    }
                }
            }

            ObterPaisesPorCidades = listaPaises;

        }

        public string ObterWoeid(string pais, string cidades)
        {
            if (cidades == "Escolha uma cidade ...")
            {
                return ObterWoeidPais(pais);
            }

            return ObterWoeidCidades(cidades);
        }

        private string ObterWoeidPais(string pais)
        {
            foreach(var i in ObterPaisesPorCidades.ToList())
            {
                if (i.Pais == pais)
                {
                    return i.Woeid.ToString();
                }
            }

            return "1";
        }

        private string ObterWoeidCidades(string cidades)
        {
            foreach (var i in ObterPaisesPorCidades.ToList())
            {
                foreach (var j in i.Cidades)
                {
                    if (j.Nome == cidades)
                    {
                        return j.Woeid.ToString();
                    }
                }
            }

            return "1";
        }
    }
}
