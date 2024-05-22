using Loja.Application.Dtos;
using Loja.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using X.PagedList;

namespace Loja.WebApp.Controllers
{
    public class CompradoresController(ICompradorService compradorService) : Controller
    {
        private readonly ICompradorService _compradorService = compradorService;

        public async Task<IActionResult> Index(string nomeRazaoSocial, string email, string telefone, DateTime? dataCadastro, string bloqueado, int? page)
        {
            var compradores = await _compradorService.GetAllCompradoresAsync() ?? [];

            if (!string.IsNullOrEmpty(nomeRazaoSocial))
            {
                compradores = compradores.Where(c => c.NomeRazaoSocial.Contains(nomeRazaoSocial)).ToList();
                ViewData["NomeRazaoSocial"] = nomeRazaoSocial;
            }

            if (!string.IsNullOrEmpty(email))
            {
                compradores = compradores.Where(c => c.Email.Contains(email)).ToList();
                ViewData["Email"] = email;
            }

            if (!string.IsNullOrEmpty(telefone))
            {
                compradores = compradores.Where(c => c.Telefone.Contains(telefone)).ToList();
                ViewData["Telefone"] = telefone;
            }

            if (dataCadastro.HasValue)
            {
                compradores = compradores.Where(c => c.DataCadastro.Date == dataCadastro.Value.Date).ToList();
                ViewData["DataCadastro"] = dataCadastro.Value.ToString("yyyy-MM-dd");
            }

            if (!string.IsNullOrEmpty(bloqueado))
            {
                bool isBloqueado = string.Equals(bloqueado, "sim", StringComparison.OrdinalIgnoreCase);
                compradores = compradores.Where(c => c.Bloqueado == isBloqueado).ToList();
                ViewData["Bloqueado"] = bloqueado;
            }

            int pageSize = 20;
            int pageNumber = (page ?? 1);
            var pagedCompradores = compradores.ToPagedList(pageNumber, pageSize);

            return View(pagedCompradores);
        }
        // GET: Compradores/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var comprador = await _compradorService.GetCompradorByIdAsync(id);
            if (comprador == null)
            {
                return NotFound();
            }

            return View(comprador);
        }

        // GET: Compradores/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CompradorDto compradorDto)
        {
            try
            {
                var errors = await _compradorService.AddCompradorAsync(compradorDto);

                if (errors.Count != 0)
                {

                    TempData["Errors"] = errors;
                    return View(compradorDto);
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["Errors"] = new List<string> { ex.Message };
                return View(compradorDto);
            }
        }


        // GET: Compradores/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var comprador = await _compradorService.GetCompradorByIdAsync(id);
            if (comprador == null)
            {
                return NotFound();
            }
            return View(comprador);
        }

        // POST: Compradores/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CompradorDto compradorDto)
        {
            if (id != compradorDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _compradorService.UpdateCompradorAsync(compradorDto);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompradorExists(compradorDto.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(compradorDto);
        }

        // GET: Compradores/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var comprador = await _compradorService.GetCompradorByIdAsync(id);
            if (comprador == null)
            {
                return NotFound();
            }

            return View(comprador);
        }

        // POST: Compradores/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _compradorService.DeleteCompradorAsync(id);
            return RedirectToAction(nameof(Index));
        }

        // POST: Compradores/DeleteSelected
        [HttpPost]
        public async Task<IActionResult> DeleteSelected([FromBody] int[] selectedIds)
        {
            if (selectedIds == null || selectedIds.Length == 0)
            {
                return BadRequest("Nenhum cliente selecionado para exclusão.");
            }

            Console.WriteLine("IDs recebidos: " + string.Join(", ", selectedIds));

            foreach (var id in selectedIds)
            {
                var comprador = await _compradorService.GetCompradorByIdAsync(id);
                if (comprador != null)
                {
                    await _compradorService.DeleteCompradorAsync(comprador.Id);
                }
            }

            return Ok();
        }

        private bool CompradorExists(int id)
        {
            return _compradorService.GetCompradorByIdAsync(id) != null;
        }
    }
}