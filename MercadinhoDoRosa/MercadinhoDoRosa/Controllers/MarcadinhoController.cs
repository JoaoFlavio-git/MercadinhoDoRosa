using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MercadoriaReges.Service;
using ApiDoMercadinho.Models;

namespace MercadoriaReges.Controllers
{
    public class MercadinhoController : Controller
    {
        private readonly apiService _apiContext;


        public MercadinhoController(apiService apiContext)
        {
            this._apiContext = apiContext;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _apiContext.GetMercadinhoAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Mercado Mercadinho)
        {
            _apiContext.PostMercadoAsync(Mercadinho);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Mercado = await _apiContext.GetMercadoAsync(id);

            if (Mercado == null)
            {
                return NotFound();
            }

            return View(Mercado);
        }

        public bool MercadoExists(int id)
        {
            var Mercado = _apiContext.GetMercadoAsync(id);

            if(Mercado.Id == id)
            {
                return true;
            } else
            {
                return false;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Mercado Mercado)
        {
            _apiContext.PutMercadoAsync(id, Mercado);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Mercado = await _apiContext.GetMercadoAsync(id);

            if (Mercado == null)
            {
                return NotFound();
            }

            return View(Mercado);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Mercado = await _apiContext.GetMercadoAsync(id);

            if (Mercado == null)
            {
                return NotFound();
            }

            return View(Mercado);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Mercado = await _apiContext.GetMercadoAsync(id);
            _apiContext.DeleteMercadoAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
