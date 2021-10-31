using System;
using System.Collections.Generic;
using CadastroDeSeries.Interfaces;

namespace CadastroDeSeries
{
   public class SerieRepository : iRepository<Serie>
   {
      private List<Serie> listSeries = new List<Serie>();
      public void Delete(int id)
      {
         listSeries[id].delete();
      }

      public void Insert(Serie obj)
      {
         listSeries.Add(obj);
      }

      public List<Serie> list()
      {
         return listSeries;
      }

      public int NextId()
      {
         return listSeries.Count;
      }

      public Serie ReturnForId(int id)
      {
         return listSeries[id];
      }

      public void Update(int id, Serie obj)
      {
         listSeries[id] = obj;
      }
   }
}