using System;

namespace DIO.Series
{
  class Program
  {
    static SerieRepositorio repositorio = new SerieRepositorio();
    
    static void Main(string[] args)
    {
      string opcaoUsuario = ObterOpcaoUsuario();

      while(opcaoUsuario != "X")
      {
        switch(opcaoUsuario)
        {
          case "1":
            ListarSeries();
            break;

          case "2":
            InserirSerie();
            break;

          case "3":
            AtualizarSerie();
            break;
          
          case "4":
            ExcluirSerie();
            break;
          
          case "5":
            VisualizarSerie();
            break;
          
          case "C":
            Console.Clear();
            break;
          
          default:
            throw new ArgumentOutOfRangeException();
        }

        opcaoUsuario = ObterOpcaoUsuario();
      }

      Console.WriteLine("Obrigado por utilizar nossos serviços.");
      Console.ReadLine();
    }

    private static void ListarSeries()
    {
      var lista = repositorio.Lista();

      if(lista.Count == 0)
      {
        Console.WriteLine("Nenhuma série cadastrada.");
        return;
      }

      foreach(var serie in lista)
      {
        Console.WriteLine($"#ID {serie.retornaId()}: - {serie.retornaTitulo()}");
      }
    }

    private static string ObterOpcaoUsuario()
    {
      Console.WriteLine();
      Console.WriteLine("DIO Séries a seu dispor!!");
      Console.WriteLine("Informe a opção desejada:");

      Console.WriteLine("1 - Listar séries");
      Console.WriteLine("2 - Inserir nova série");
      Console.WriteLine("3 - Atualizar série");
      Console.WriteLine("4 - Excluir série");
      Console.WriteLine("5 - Visualizar série");
      Console.WriteLine("C - Limpar tela");
      Console.WriteLine("X - Sair");
      Console.WriteLine();

      string opcaoUsuario = Console.ReadLine().ToUpper();
      Console.WriteLine();
      return opcaoUsuario;
    }
  }
}
