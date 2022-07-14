using System.Collections.Generic;

namespace MusicOrganizer.Models
{
  public class Medium
  {
    private static List<Medium> _instances = new List<Medium> {};
    public string Name { get; set; }
    public int Id { get; }
    public List<Album> Albums { get; set; }

    public Medium(string mediumName)
    {
      Name = mediumName;
      _instances.Add(this);
      Id = _instances.Count;
      Albums = new List<Album>{};
    }

    public static void ClearAll()
    {
      _instances.Clear();
    } 

    public static List<Medium> GetAll()
    {
      return _instances;
    }

    public static Medium Find(int searchId)
    {
      return _instances[searchId-1];
    }

    public void AddAlbum(Album album)
    {
      Albums.Add(album);
    }

  }
}