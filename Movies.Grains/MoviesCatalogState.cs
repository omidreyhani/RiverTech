using Movies.Contracts;
using System;
using System.Collections.Generic;

namespace Movies.Grains
{
  [Serializable]
  public class MoviesCatalogState
  {
    public List<MovieModel> Movies { get; set; } = new List<MovieModel>();
  }
}
