using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using MusicOrganizer.Models;

namespace MusicOrganizer.Controllers
{
  public class MediumsController : Controller
  {

    [HttpGet("/mediums")]
    public ActionResult Index()
    {
      List<Medium> allMediums = Medium.GetAll();
      return View(allMediums);
    }

    [HttpGet("/mediums/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/mediums")]
    public ActionResult Create(string mediumName)
    {
      Medium newMedium = new Medium(mediumName);
      return RedirectToAction("Index");
    }

    [HttpGet("/mediums/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Medium selectedMedium = Medium.Find(id);
      List<Album> mediumAlbums = selectedMedium.Albums;
      model.Add("medium", selectedMedium);
      model.Add("albums", mediumAlbums);
      return View(model);
    }

    [HttpPost("/mediums/{mediumId}/albums")]
    public ActionResult Create(int mediumId, string albumDescription)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Medium foundMedium = Medium.Find(mediumId);
      Album newAlbum = new Album(albumDescription);
      foundMedium.AddAlbum(newAlbum);
      List<Album> mediumAlbums = foundMedium.Albums;
      model.Add("albums", mediumAlbums);
      model.Add("medium", foundMedium);
      return View("Show", model);
    }

  }
}