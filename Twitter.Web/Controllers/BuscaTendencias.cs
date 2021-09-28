using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Twitter.Web.Funcionalidades;
using Twitter.Web.Interfaces;
using Twitter.Web.Models;
using System;

namespace Twitter.Web.Controllers
{
    public class BuscaTendencias : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly ICosmosDbService _cosmosDbService;

        public IEnumerable<TrendsAvailablesViewModel> ResultadoRequisicao { get; set; }
        public IEnumerable<SelectListItem> Itens { get; set; }
        public static IEnumerable<ListaCidadesPorPaises> Lista { get; set; }
        public static ItemViewModel _item { get; set; }

        public BuscaTendencias(IHttpClientFactory clientFactory, ICosmosDbService cosmosDbService)
        {
            _clientFactory = clientFactory;
            _cosmosDbService = cosmosDbService;
        }

        #region Consumindo

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            CommonViewModel commonViewModel = new()
            {
                ListaCidadesPorPaises = null,
                TrendsViewModel = new List<TrendsViewModel>()
            };

            await RequisicaoTrendsAvailableApi();

            commonViewModel.ListaCidadesPorPaises = Lista.Select(c => new SelectListItem
            {
                Value = c.Pais,
                Text = c.Pais
            });

            return View(commonViewModel);
        }

        [HttpPost]
        public async Task<JsonResult> SetDropDownList(string type, string value)
        {
            await RequisicaoTrendsAvailableApi();

            var listaPaises = Lista.ToList();
            var listaCidades = new List<Cidade>();

            for (int i = 0; i < Lista.Count(); i++)
            {
                if (listaPaises[i].Pais == value)
                {
                    listaCidades = listaPaises[i].Cidades;
                    break;
                }
            }

            var listaCidadesSelectList = listaCidades.Select(c => new SelectListItem
            {
                Value = c.Nome,
                Text = c.Nome
            });

            return Json(listaCidadesSelectList);
        }

        [HttpPost]
        public async Task<IActionResult> Index(CommonViewModel commonViewModel, string pais, string cidades)
        {

            await RequisicaoTrendsAvailableApi();

            IEnumerable<SelectListItem> model = Lista.Select(c => new SelectListItem
            {
                Value = c.Pais,
                Text = c.Pais
            });

            ViewBag.Pais = model;

            string woeid = DefineWoeid(pais, cidades);

            IEnumerable<TrendsPlacesViewModel> Resultado = null;
            var request = new HttpRequestMessage(HttpMethod.Get, $"/1.1/trends/place.json?id={woeid}");
            var client = _clientFactory.CreateClient("twitter");
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                Resultado = JsonSerializer.Deserialize<IEnumerable<TrendsPlacesViewModel>>(responseString);
            }

            var m = new TrendsPlacesViewModel();
            var n = Resultado.ToList();

            m.as_of = n[0].as_of;
            m.created_at = n[0].created_at;
            m.locations = n[0].locations;
            m.trends = n[0].trends;

            ViewBag.Tabela = m.trends;

            commonViewModel.TrendsViewModel = m.trends;

            return View(commonViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Favoritos()
        {
            return View(await _cosmosDbService.GetItemsAsync("SELECT * FROM c")); ;
        }

        [HttpPost]
        public async Task<IActionResult> Salvar(ItemViewModel itemViewModel)
        {
            if (ModelState.IsValid)
            {
                itemViewModel.Id = Guid.NewGuid().ToString();
                await _cosmosDbService.AddItemAsync(itemViewModel);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Editar()
        {

            if(_item == null)
            {
                @ViewBag.Name = "";
                @ViewBag.Url = "";
                ViewBag.Tweets = 0;
            }
            else
            {
                @ViewBag.Name = _item.Name;
                @ViewBag.Url = _item.Url;
                ViewBag.Tweets = _item.Tweets;
            }

            

            return View(_item);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(string id)
        {
            ItemViewModel item = await _cosmosDbService.GetItemAsync(id);

            @ViewBag.Name = item.Name;
            @ViewBag.Url = item.Url;
            ViewBag.Tweets = item.Tweets;

            _item = item;

            return View(_item);
        }

        [HttpPost]
        public async Task<IActionResult> EditarS([Bind("Id,Name,Url,Tweets")] ItemViewModel item)
        {
            if (ModelState.IsValid)
            {
                await _cosmosDbService.UpdateItemAsync(item.Id, item);
            }

            return RedirectToAction("Editar");
        }

        [HttpPost]
        public async Task<ActionResult> Deletar([Bind("id")] string id)
        {
            await _cosmosDbService.DeleteItemAsync(id);
            return RedirectToAction("Favoritos");
        }

        public string DefineWoeid(string pais, string cidades)
        {
            var listaPaises = Lista.ToList();
            var listaCidades = new List<Cidade>();
            string woeid = "";

            if (pais == "Escolha um pais ..." || pais == null)
            {
                ModelState.AddModelError("", "Nenhum campo informado");
                return "1";
            }

            for (int i = 0; i < Lista.Count(); i++)
            {
                if (listaPaises[i].Pais == pais)
                {
                    if (cidades == "Escolha uma cidade ..." || cidades == null)
                    {
                        return listaPaises[i].Woeid.ToString();
                    }
                    listaCidades = listaPaises[i].Cidades;
                }
            }

            for (int i = 0; i < listaCidades.Count; i++)
            {
                if (listaCidades[i].Nome == cidades)
                {
                    woeid = listaCidades[i].Woeid.ToString();
                }
            }

            return woeid;
        }

        public async Task RequisicaoTrendsAvailableApi()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "1.1/trends/available.json");
            var client = _clientFactory.CreateClient("twitter");
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                ResultadoRequisicao = JsonSerializer.Deserialize<IEnumerable<TrendsAvailablesViewModel>>(responseString);
                var listaCidadesPorPaises = new OrganizaCidadesPorPais(ResultadoRequisicao);
                Lista = listaCidadesPorPaises.Organizar();
            }
        }

        #endregion
    }
}
