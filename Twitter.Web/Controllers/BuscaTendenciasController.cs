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
    public class BuscaTendenciasController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly ICosmosDbService _cosmosDbService;

        public static ItemViewModel _item { get; set; }
        public static CidadesPorPais listaCidadesPorPaises { get; set; }
        public CommonViewModel commonViewModel = new()
        {
            ListaCidadesPorPaises = new List<SelectListItem>(),
            TrendsViewModel = new List<TrendsViewModel>(),
            ItemViewModel = new ItemViewModel()
        };

        public BuscaTendenciasController(IHttpClientFactory clientFactory, ICosmosDbService cosmosDbService)
        {
            _clientFactory = clientFactory;
            _cosmosDbService = cosmosDbService;
        }

        #region Consumindo

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string responseString = await RequisicaoApi("1.1/trends/available.json");
            IEnumerable<TrendsAvailablesViewModel> ResultadoRequisicao = JsonSerializer.Deserialize<IEnumerable<TrendsAvailablesViewModel>>(responseString);
            listaCidadesPorPaises = new CidadesPorPais(ResultadoRequisicao);
            listaCidadesPorPaises.ListarPaises();

            commonViewModel.ListaCidadesPorPaises = listaCidadesPorPaises.ObterPaisesPorCidades.Select(c => new SelectListItem
            {
                Value = c.Pais,
                Text = c.Pais
            });

            return View(commonViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(string pais, string cidades)
        {
            commonViewModel.ListaCidadesPorPaises = listaCidadesPorPaises.ObterPaisesPorCidades.Select(c => new SelectListItem
            {
                Value = c.Pais,
                Text = c.Pais
            });

            string woeid = listaCidadesPorPaises.ObterWoeid(pais, cidades);

            IEnumerable<TrendsPlacesViewModel> Resultado = JsonSerializer.Deserialize<IEnumerable<TrendsPlacesViewModel>>(await RequisicaoApi($"/1.1/trends/place.json?id={woeid}")); ;

            var _trends = new TrendsPlacesViewModel();
            var trendsPlacesViewModel = Resultado.ToList();

            _trends.trends = trendsPlacesViewModel[0].trends;
            ViewBag.Tabela = _trends.trends;
            commonViewModel.TrendsViewModel = _trends.trends;

            return View(commonViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> ObterFavoritos()
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

            return Redirect("/Index");
        }

        [HttpGet]
        public async Task<IActionResult> Editar()
        {
            return View(_item);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(ItemViewModel item)
        {
            _item = item;

            return View(_item);
        }

        [HttpPost]
        public async Task<IActionResult> Atualizar([Bind("Id,Name,Url,Tweets")] ItemViewModel item)
        {
            if (ModelState.IsValid)
            {
                await _cosmosDbService.UpdateItemAsync(item.Id, item);
            }

            return Redirect("/BuscaTendencias/ObterFavoritos");
        }

        [HttpPost]
        public async Task<ActionResult> Deletar([Bind("id")] string id)
        {
            await _cosmosDbService.DeleteItemAsync(id);
            return RedirectToAction("Favoritos");
        }

        [HttpPost]
        public async Task<JsonResult> SetDropDownList(string value)
        {
            var listaPaises = listaCidadesPorPaises.ObterPaisesPorCidades.ToList();
            var listaCidades = new List<Cidade>();

            foreach (var i in listaCidadesPorPaises.ObterPaisesPorCidades.ToList())
            {
                if (i.Pais == value)
                {
                    listaCidades = i.Cidades;
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

        public async Task<string> RequisicaoApi(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var client = _clientFactory.CreateClient("twitter");
            var response = await client.SendAsync(request);
            string responseString = null;

            if (response.IsSuccessStatusCode)
            {
                responseString = await response.Content.ReadAsStringAsync();
            }

            return responseString;
        }

        #endregion
    }
}
