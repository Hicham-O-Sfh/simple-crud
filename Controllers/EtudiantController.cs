using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using simple_crud.Interfaces;
using simple_crud.Models;

namespace simple_crud.Controllers;

public class EtudiantController : Controller
{

    private readonly IEtudiantService _etudiantService;

    public EtudiantController(IEtudiantService etudiantService)
    {
        this._etudiantService = etudiantService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var etudiants = await this._etudiantService.GetAll();
        return View(etudiants);
    }

    [HttpGet]
    public IActionResult Add()
    {
        var etudiant = new Etudiant();
        return PartialView("Etudiant/_ModalAdd", etudiant);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Etudiant etudiant)
    {
        await this._etudiantService.Add(etudiant);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var etudiant = await this._etudiantService.GetById(id);
        return PartialView("Etudiant/_ModalEdit", etudiant as Etudiant);
    }

    [HttpPost]
    public async Task<IActionResult> Update(Etudiant etudiant)
    {
        await this._etudiantService.Update(etudiant);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var etudiant = await this._etudiantService.GetById(id);
        return PartialView("Etudiant/_ModalDelete", etudiant as Etudiant);
    }

    [HttpPost]
    public async Task<IActionResult> Remove(int id)
    {
        if (!await this._etudiantService.Exists(id))
            return NotFound();
        await this._etudiantService.Delete(id);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> ManageExclusionStatus(int id)
    {
        var etudiant = await this._etudiantService.GetById(id);
        if (etudiant!.IsExclut)
            await this._etudiantService.Include(etudiant);
        else
            await this._etudiantService.Exclude(etudiant);
        return Ok(etudiant.IsExclut);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
