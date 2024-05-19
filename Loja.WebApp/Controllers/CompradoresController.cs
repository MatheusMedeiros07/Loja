using Loja.Application.Dtos;
using Loja.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class CompradoresController : Controller
{
    private readonly ICompradorService _compradorService;

    public CompradoresController(ICompradorService compradorService)
    {
        _compradorService = compradorService;
    }

    // GET: Compradores
    public async Task<IActionResult> Index(string searchNome, string searchEmail, string bloqueado)
    {
        ViewData["searchNome"] = searchNome;
        ViewData["searchEmail"] = searchEmail;
        ViewData["bloqueado"] = bloqueado;

        var compradores = await _compradorService.GetAllCompradoresAsync();

        if (!string.IsNullOrEmpty(searchNome))
        {
            compradores = compradores.Where(c => c.NomeRazaoSocial.Contains(searchNome, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        if (!string.IsNullOrEmpty(searchEmail))
        {
            compradores = compradores.Where(c => c.Email.Contains(searchEmail, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        if (!string.IsNullOrEmpty(bloqueado))
        {
            bool isBloqueado = bool.Parse(bloqueado);
            compradores = compradores.Where(c => c.Bloqueado == isBloqueado).ToList();
        }

        return View(compradores);
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

    // POST: Compradores/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CompradorDto compradorDto)
    {
        if (ModelState.IsValid)
        {
            await _compradorService.AddCompradorAsync(compradorDto);
            return RedirectToAction(nameof(Index));
        }
        return View(compradorDto);
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
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _compradorService.DeleteCompradorAsync(id);
        return RedirectToAction(nameof(Index));
    }

    // POST: Compradores/DeleteSelected
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteSelected(int[] selectedIds)
    {
        if (selectedIds != null && selectedIds.Length > 0)
        {
            foreach (var id in selectedIds)
            {
                await _compradorService.DeleteCompradorAsync(id);
            }
        }
        return RedirectToAction(nameof(Index));
    }

    private bool CompradorExists(int id)
    {
        return _compradorService.GetCompradorByIdAsync(id) != null;
    }
}