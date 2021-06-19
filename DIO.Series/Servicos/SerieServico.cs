using DIO.Series.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIO.Series.Servicos
{
    public class SerieServico
    {
        public static SerieRepositorio repositorio = new SerieRepositorio();

        public static void AtualizarSerie()
        {
            ExibirMensagemAviso("Atualizar série:");
            Console.WriteLine();

            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            Console.WriteLine();

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero), i)}");
            }

            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição de Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Atualiza(indiceSerie, atualizaSerie);

            Console.WriteLine();
            ExibirMensagemAviso("Série atualizada com sucesso.");
            ExibirMensagemEncerramento();
        }
        
        public static void ExcluirSerie()
        {
            ExibirMensagemAviso("Excluir uma série:");
            Console.WriteLine();

            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);

            Console.WriteLine();
            ExibirMensagemAviso("Série excluída com sucesso.");
            ExibirMensagemEncerramento();
        }

        public static void InserirSerie()
        {
            ExibirMensagemAviso("Inserir nova série:");
            Console.WriteLine();

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero), i)}");
            }

            Console.WriteLine();
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição de Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Insere(novaSerie);

            Console.WriteLine();
            ExibirMensagemAviso("Série adicionada com sucesso.");
            ExibirMensagemEncerramento();
        }

        public static void ListarSeries()
        {
            var lista = SerieServico.repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.Clear();
                ExibirMensagemAviso("Nenhuma série cadastrada.");
                return;
            }

            ExibirMensagemAviso("Lista de séries:");
            Console.WriteLine();

            foreach (Serie serie in lista)
            {
                bool excluido = serie.retornaExcluido();
                Console.WriteLine($"#ID {serie.retornaId()}: - {serie.retornaTitulo()} {(excluido ? "*Excluido*" : "")}");
            }

            Console.WriteLine($"{Environment.NewLine}********************************************");
            ExibirMensagemEncerramento();
        }

        public static void VisualizarSerie()
        {
            ExibirMensagemAviso("Visualizar uma série:");

            Console.Write($"{Environment.NewLine}Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Serie serie = repositorio.RetornaPorId(indiceSerie);
            Console.WriteLine(serie);

            ExibirMensagemEncerramento();
        }

        public static void ExibirMensagemAviso(string mensagem)
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine($"\t{mensagem}");
            Console.WriteLine("--------------------------------------------");
        }

        public static void ExibirMensagemEncerramento()
        {
            Console.Write($"{Environment.NewLine}Pressione qualquer tecla para retornar ao menu inicial...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
