using System;

namespace CadastroDeSeries
{
   class Program
   {
      static SerieRepository repository = new SerieRepository();
      static void Main(string[] args)
      {
         string userOption = getUserOption();
         while (userOption != "X")
         {
            switch (userOption)
            {
               case "1":
                  listSeries();
                  break;
               case "2":
                  insertSeries();
                  break;
               case "3":
                  updateSeries();
                  break;
               case "4":
                  deleteSeries();
                  break;
               case "5":
                  viewSeries();
                  break;
               case "C":
                  Console.WriteLine("Limpando Tela");
                  Console.Clear();
                  break;
               default:
                  throw new ArgumentOutOfRangeException("Opção inválida");
            }
            userOption = getUserOption();
         }
      }

      private static void viewSeries()
      {
         Console.WriteLine("Visualizar Série");
         Console.WriteLine();
         listSeries();

         Console.Write("Digite o ID da série que gostaria de ver: ");
         int id = int.Parse(Console.ReadLine());
         var getSerie = repository.ReturnForId(id);

         Console.WriteLine();
         Console.WriteLine(getSerie);
         Console.WriteLine();
      }

      private static void deleteSeries()
      {
         Console.WriteLine("Deletar Série");
         Console.WriteLine();
         listSeries();
         Console.Write("Digite o ID da Série a ser deletada: ");
         int id = int.Parse(Console.ReadLine());

         Console.Write("Tem certeza que deseja deletar a Série com ID: " + id + "? (S/N): ");
         string confirm = Console.ReadLine().ToUpper();
         if (confirm == "S")
         {
            repository.Delete(id);
            Console.WriteLine("Série deletada com sucesso!");
         }
         else
         {
            Console.WriteLine($"Cancelado! A série de id: {id} não foi deletado.");
         }
      }

      private static void updateSeries()
      {
         Console.WriteLine("Atualizar Série");
         Console.WriteLine();

         listSeries();

         Console.Write("Digite o id da série que você quer atualizar: ");
         int id = int.Parse(Console.ReadLine());

         var serie = createOBJ();

         Serie updatedSerie = new Serie(
            id: id,
            gender: serie.gender,
            title: serie.title,
            description: serie.description,
            age: serie.age
         );
         repository.Update(id, updatedSerie);
      }

      private static void insertSeries()
      {
         Console.WriteLine("Cadastrando sua Série");

         var serie = createOBJ();

         Serie newSerie = new Serie(
            id: repository.NextId(),
            gender: serie.gender,
            title: serie.title,
            description: serie.description,
            age: serie.age
         );

         repository.Insert(newSerie);
      }

      private static void listSeries()
      {
         Console.WriteLine("Listando Séries");
         var series = repository.list();
         if (series.Count == 0)
         {
            Console.WriteLine("Nenhuma série encontrada");
            return;
         }
         foreach (var serie in series)
         {
            if (serie.returnDeleted())
            {
               Console.WriteLine($"ID: {serie.returnId()} - {serie.returnTitle()}  - deletada");
               continue;
            }

            Console.WriteLine($"ID: {serie.returnId()} - {serie.returnTitle()}");
         }
         Console.WriteLine();
      }

      private static string getUserOption()
      {
         try
         {
            Console.WriteLine();
            Console.WriteLine("DIO series a seu dispor!");
            Console.WriteLine("Informe a opção desejada");
            Console.WriteLine();

            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Cadastrar nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Deletar série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine();
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string option = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return option;
         }
         catch (System.Exception)
         {
            Console.WriteLine();
            Console.WriteLine("Ocorreu um erro, tente novemente.");
            Console.WriteLine();
            return getUserOption();
         }
      }
      private static (Gender gender, string title, string description, int age) createOBJ()
      {
         try
         {
            foreach (int i in Enum.GetValues(typeof(Gender)))
            {
               Console.WriteLine($"{i} - {Enum.GetName(typeof(Gender), i)}");
            }

            Console.Write("Digite o genero entre as opções acima: ");
            int inputGender = int.Parse(Console.ReadLine());

            Console.Write("Digite o titulo da sua série: ");
            string inputTitle = Console.ReadLine();

            Console.Write("Digite o ano da sua série: ");
            int inputAge = int.Parse(Console.ReadLine());

            Console.Write("Digite uma descrição da sua série: ");
            string inputDescription = Console.ReadLine();

            return (
               gender: (Gender)inputGender,
               title: inputTitle,
               description: inputDescription,
               age: inputAge
               );
         }
         catch (System.Exception)
         {
            Console.WriteLine();
            Console.WriteLine("Ocorreu um erro, tente novemente.");
            Console.WriteLine();
            return createOBJ();
         }
      }
   }
}
