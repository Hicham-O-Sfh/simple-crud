using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using simple_crud.Models;

namespace simple_crud.Controllers;

public class EtudiantController : Controller
{
    List<Etudiant> _listEtudiant;
    private readonly ILogger<EtudiantController> _logger;

    public EtudiantController(ILogger<EtudiantController> logger)
    {
        _logger = logger;
        this._listEtudiant = new List<Etudiant>()
        {
            new Etudiant(){Id = 1,DateNaissance = DateTime.Now,MoyenneGenerale = 17.5f,Nom = "nom_1",Prenom = "prenom_1"},
            new Etudiant(){Id = 2,DateNaissance = DateTime.Now,MoyenneGenerale = 16.5f,Nom = "nom_2",Prenom = "prenom_2"},
            new Etudiant(){Id = 3,DateNaissance = DateTime.Now,MoyenneGenerale = 15.5f,Nom = "nom_3",Prenom = "prenom_3"},
            new Etudiant(){Id = 4,DateNaissance = DateTime.Now,MoyenneGenerale = 14.5f,Nom = "nom_4",Prenom = "prenom_4"}
        };
    }

    [HttpGet]
    public IActionResult Index()
    {
        List<Etudiant> list = this._listEtudiant;
        return View(list);
    }

    [HttpPost]
    public IActionResult Add(Etudiant etudiant)
    {
        this._listEtudiant.Add(etudiant);
        ModelState.Clear();
        return RedirectToAction("Index");
    }

    [HttpPut("{id}")]
    public IActionResult Edit(int id, Etudiant etudiant)
    {
       
        return RedirectToAction("Index");
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
       
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
