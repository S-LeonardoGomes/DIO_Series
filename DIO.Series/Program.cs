using System;
using DIO.Series.Repositorios;
using DIO.Series.Servicos;

namespace DIO.Series
{
    class Program
    {
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        SerieServico.ListarSeries();
                        break;

                    case "2":
                        SerieServico.InserirSerie();
                        break;

                    case "3":
                        SerieServico.AtualizarSerie();
                        break;

                    case "4":
                        SerieServico.ExcluirSerie();
                        break;

                    case "5":
                        SerieServico.ExibirMensagemAviso("Visualizar uma série:");

                        Console.Write($"{Environment.NewLine}Digite o id da série: ");
                        int indiceSerie = int.Parse(Console.ReadLine());
                        Console.WriteLine();

                        SerieServico.VisualizarSerie(indiceSerie);
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
            Console.ReadKey();
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
