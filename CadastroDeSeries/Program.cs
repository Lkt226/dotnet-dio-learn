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
                  //updateSeries();
                  Console.WriteLine("Atualizando sua Série");
                  break;
               case "4":
                  Console.WriteLine("Deletar Série");
                  //deleteSeries();
                  break;
               case "5":
                  Console.WriteLine("Visualizar Série");
                  //viewSeries();
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

      private static void insertSeries()
      {
         Console.WriteLine("Cadastrando sua Série");
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

         Serie newSerie = new Serie(
            id: repository.NextId(),
            gender: (Gender)inputGender,
            title: inputTitle,
            description: inputDescription,
            age: inputAge
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
            Console.WriteLine($"ID: {serie.returnId()}, {serie.returnTitle()}");
         }
      }

      private static string getUserOption()
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
   }
}
