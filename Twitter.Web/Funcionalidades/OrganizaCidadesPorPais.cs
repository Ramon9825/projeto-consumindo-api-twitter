using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twitter.Web.Models;

namespace Twitter.Web.Funcionalidades
{
    public class OrganizaCidadesPorPais
    {
        private IEnumerable<TrendsAvailablesViewModel> _enumerable { get; set; }
        public OrganizaCidadesPorPais(IEnumerable<TrendsAvailablesViewModel> enumerable)
        {
            _enumerable = enumerable;
        }

        public IEnumerable<ListaCidadesPorPaises> Organizar()
        {
            var lista = _enumerable.ToList();
            var listaPaises = new List<ListaCidadesPorPaises>();

            for (int i = 0; i < lista.Count(); i++)
            {
                if (lista[i].name == lista[i].country || lista[i].countryCode == null)
                {
                    var listaCidadesPorPaises = new ListaCidadesPorPaises();
                    listaCidadesPorPaises.Pais = lista[i].country;
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
                    if (lista[i].name == lista[i].country)
                    {
                        break;
                    }

                    if (listaPaises[j].Pais == lista[i].country)
                    {
                        var cidade = new Cidade();
                        cidade.Nome = lista[i].name;
                        cidade.Woeid = lista[i].woeid;

                        listaPaises[j].Cidades.Add(cidade);
                    }
                }
            }

            return listaPaises;
        }
    }
}
