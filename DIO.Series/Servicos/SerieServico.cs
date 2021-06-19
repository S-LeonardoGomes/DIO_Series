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
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("\tAtualizar série.");
            Console.WriteLine($"--------------------------------------------{Environment.NewLine}");

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

            Console.WriteLine($"{Environment.NewLine}--------------------------------------------");
            Console.WriteLine("\tSérie atualizada com sucesso");
            Console.WriteLine($"--------------------------------------------{Environment.NewLine}");
            Console.Write("Pressione qualquer tecla para retornar ao menu inicial...");
            Console.ReadKey();
            Console.Clear();
        }

        public static void ExcluirSerie()
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("\tExcluir uma série:");
            Console.WriteLine($"--------------------------------------------{Environment.NewLine}");

            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);

            Console.WriteLine($"{Environment.NewLine}--------------------------------------------");
            Console.WriteLine("\tSérie excluída com sucesso");
            Console.WriteLine($"--------------------------------------------{Environment.NewLine}");
            Console.Write("Pressione qualquer tecla para retornar ao menu inicial...");
            Console.ReadKey();
            Console.Clear();
        }

        public static void InserirSerie()
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("\tInserir nova série:");
            Console.WriteLine($"--------------------------------------------{Environment.NewLine}");

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

            Console.WriteLine($"{Environment.NewLine}--------------------------------------------");
            Console.WriteLine("\tSérie adicionada com sucesso");
            Console.WriteLine($"--------------------------------------------{Environment.NewLine}");
            Console.Write("Pressione qualquer tecla para retornar ao menu inicial...");
            Console.ReadKey();
            Console.Clear();
        }

        public static void ListarSeries()
        {
            var lista = SerieServico.repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("\tNenhuma série cadastrada.");
                Console.WriteLine("--------------------------------------------");
                return;
            }

            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("\tLista de séries.");
            Console.WriteLine($"--------------------------------------------{Environment.NewLine}");

            foreach (Serie serie in lista)
            {
                bool excluido = serie.retornaExcluido();
                Console.WriteLine($"#ID {serie.retornaId()}: - {serie.retornaTitulo()} {(excluido ? "*Excluido*" : "")}");
            }

            Console.WriteLine($"{Environment.NewLine}********************************************{Environment.NewLine}");
            Console.Write("Pressione qualquer tecla para retornar ao menu inicial...");
            Console.ReadKey();
            Console.Clear();
        }

        public static void VisualizarSerie()
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("\tVisualizar uma série.");
            Console.WriteLine($"--------------------------------------------{Environment.NewLine}");

            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Serie serie = repositorio.RetornaPorId(indiceSerie);
            Console.WriteLine(serie);
            Console.Write($"{Environment.NewLine}Pressione qualquer tecla para retornar ao menu inicial...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
