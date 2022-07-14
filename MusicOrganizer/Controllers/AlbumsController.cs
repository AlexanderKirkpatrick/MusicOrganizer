using Microsoft.AspNetCore.Mvc;
using MusicOrganizer.Models;
using System.Collections.Generic;

namespace MusicOrganizer.Controllers
{
  public class AlbumsController : Controller
  {
    [HttpGet("/mediums/{mediumId}/albums/new")]
    public ActionResult New(int mediumId)
    {
       Medium medium = Medium.Find(mediumId);
       return View(medium);
    }

    [HttpGet("/mediums/{mediumId}/albums/{albumId}")]
    public ActionResult Show(int mediumId, int albumId)
    {
      Album album = Album.Find(albumId);
      Medium medium = Medium.Find(mediumId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("album", album);
      model.Add("medium", medium);
      return View(model);
    }

    [HttpPost("/albums/delete")]
    public ActionResult DeleteAll()
    {
      Album.ClearAll();
      return View();
    }
  }
}