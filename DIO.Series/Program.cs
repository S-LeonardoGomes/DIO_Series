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
                    #region ListarSeries
                    case "1":
                        SerieServico.ExibirMensagemAviso("Lista de séries:");
                        Console.WriteLine();
                        SerieServico.ListarSeries();
                        SerieServico.ExibirMensagemEncerramento();
                        break;
                    #endregion

                    #region InserirSerie
                    case "2":
                        SerieServico.ExibirMensagemAviso("Inserir nova série:");
                        Console.WriteLine();

                        SerieServico.ExibirGeneros();

                        Console.WriteLine();
                        Console.Write("Digite o gênero entre as opções acima: ");
                        int entradaGenero = int.Parse(Console.ReadLine());

                        Console.Write("Digite o Título da Série: ");
                        string entradaTitulo = Console.ReadLine();

                        Console.Write("Digite o Ano de Início da Série: ");
                        int entradaAno = int.Parse(Console.ReadLine());

                        Console.Write("Digite a Descrição de Série: ");
                        string entradaDescricao = Console.ReadLine();

                        SerieServico.InserirSerie(entradaGenero, entradaTitulo, entradaAno, entradaDescricao);
                        Console.WriteLine();
                        SerieServico.ExibirMensagemAviso("Série adicionada com sucesso.");
                        SerieServico.ExibirMensagemEncerramento();
                        break;
                    #endregion

                    #region AtualizarSerie
                    case "3":
                        SerieServico.ExibirMensagemAviso("Atualizar série:");
                        Console.WriteLine();

                        Console.Write("Digite o id da série: ");
                        int indiceAtualizar = int.Parse(Console.ReadLine());
                        Console.WriteLine();

                        if (!SerieServico.ExisteSerie(indiceAtualizar))
                        {
                            SerieServico.ExibirMensagemAviso("Série não encontrada.");
                            SerieServico.ExibirMensagemEncerramento();
                            break;
                        }

                        SerieServico.VisualizarSerie(indiceAtualizar);
                        Console.WriteLine();

                        SerieServico.ExibirGeneros();

                        Console.Write("Digite o gênero entre as opções acima: ");
                        int genero = int.Parse(Console.ReadLine());

                        Console.Write("Digite o Título da Série: ");
                        string titulo = Console.ReadLine();

                        Console.Write("Digite o Ano de Início da Série: ");
                        int ano = int.Parse(Console.ReadLine());

                        Console.Write("Digite a Descrição de Série: ");
                        string descricao = Console.ReadLine();

                        SerieServico.AtualizarSerie(indiceAtualizar, genero, titulo, descricao, ano);
                        SerieServico.ExibirMensagemEncerramento();
                        break;
                    #endregion

                    #region ExcluirSerie
                    case "4":
                        SerieServico.ExibirMensagemAviso("Excluir uma série:");
                        Console.WriteLine();

                        Console.Write("Digite o id da série: ");
                        int indiceExcluir = int.Parse(Console.ReadLine());

                        SerieServico.ExcluirSerie(indiceExcluir);
                        SerieServico.ExibirMensagemEncerramento();
                        break;
                    #endregion

                    #region VisualizarSerie
                    case "5":
                        SerieServico.ExibirMensagemAviso("Visualizar uma série:");

                        Console.Write($"{Environment.NewLine}Digite o id da série: ");
                        int indiceVisualizar = int.Parse(Console.ReadLine());
                        Console.WriteLine();

                        SerieServico.VisualizarSerie(indiceVisualizar);
                        SerieServico.ExibirMensagemEncerramento();
                        break;
                    #endregion

                    #region Clear
                    case "C":
                        Console.Clear();
                        break;
                    #endregion

                    #region Default
                    default:
                        throw new ArgumentOutOfRangeException();
                    #endregion
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
