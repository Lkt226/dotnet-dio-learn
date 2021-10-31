using System;
namespace CadastroDeSeries
{
   public class Serie : EntidadeBase
   {
      // Atributos
      private Gender Gender { get; set; }
      private string Title { get; set; }
      private string Description { get; set; }
      private int Age { get; set; }

      private bool isDelete { get; set; }

      // Metodos
      public Serie(int id, Gender gender, string title, string description, int age)
      {
         this.Id = id;
         this.Gender = gender;
         this.Title = title;
         this.Description = description;
         this.Age = age;
         this.isDelete = false;
      }

      public override string ToString()
      {
         string response = "";
         response += "Gênero: " + this.Gender + Environment.NewLine;
         response += "Titulo: " + this.Title + Environment.NewLine;
         response += "Descrição: " + this.Description + Environment.NewLine;
         response += "Ano de Inicio: " + this.Age + Environment.NewLine;
         response += "Excluido: " + this.isDelete + Environment.NewLine;

         return response;
      }

      public string returnTitle()
      {
         return this.Title;
      }
      public int returnId()
      {
         return this.Id;
      }
      public bool returnDeleted()
      {
         return this.isDelete;
      }

      public void delete()
      {
         this.isDelete = true;
      }
   }
}