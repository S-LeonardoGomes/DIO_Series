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

        public static void AtualizarSerie(int indiceSerie, int genero, string titulo, string descricao, int ano)
        {
            Serie atualizaSerie = new Serie(indiceSerie, (Genero) genero, titulo, descricao, ano);

            repositorio.Atualiza(indiceSerie, atualizaSerie);
            Console.WriteLine();
            ExibirMensagemAviso("Série atualizada com sucesso.");
        }
        
        public static void ExcluirSerie(int indiceSerie)
        {
            if(repositorio.RetornaPorId(indiceSerie) == null)
            {
                Console.WriteLine();
                ExibirMensagemAviso("Série não encontrada.");
                return;
            }
            Console.Write("Deseja realmente excluir este registro(S/N)? ");
            char resposta = Convert.ToChar(Console.ReadLine().ToUpper());

            if (resposta == 'N')
            {
                Console.WriteLine();
                ExibirMensagemAviso("Operação abortada.");
                return;
            }
            else if (resposta == 'S')
            {
                if (SerieExcluida(indiceSerie))
                {
                    Console.WriteLine();
                    ExibirMensagemAviso("Esta série já havia sido removida.");
                    return;
                }

                repositorio.Exclui(indiceSerie);
                Console.WriteLine();
                ExibirMensagemAviso("Série excluída com sucesso.");
            }
            else
            {
                Console.WriteLine();
                ExibirMensagemAviso("Opção inválida.");
                return;
            }
        }

        public static void InserirSerie(int genero, string titulo, int ano, string descricao)
        {
            Serie novaSerie = new Serie(repositorio.ProximoId(), (Genero)genero, titulo, descricao, ano);
            
            repositorio.Insere(novaSerie);
        }

        public static void ListarSeries()
        {
            List<Serie> lista = SerieServico.repositorio.Lista();

            if (lista.Count == 0)
            {
                ExibirMensagemAviso("Nenhuma série cadastrada.");
                return;
            }

            foreach (Serie serie in lista)
            {
                bool excluido = serie.retornaExcluido();
                Console.WriteLine($"#ID {serie.retornaId()}: - {serie.retornaTitulo()} {(excluido ? "*Excluido*" : "")}");
            }

            Console.WriteLine($"{Environment.NewLine}********************************************");
        }

        public static void VisualizarSerie(int indiceSerie)
        {
            Serie serie = repositorio.RetornaPorId(indiceSerie);

            if(serie == null)
            {
                ExibirMensagemAviso("Série não encontrada.");
                return;
            }

            Console.WriteLine(serie);
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

        public static void ExibirGeneros()
        {
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero), i)}");
            }
        }

        public static bool ExisteSerie(int indiceBusca)
        {
            return repositorio.RetornaPorId(indiceBusca) != null ? true : false;
        }

        public static bool SerieExcluida(int indiceSerie)
        {
            Serie serie = repositorio.RetornaPorId(indiceSerie);
            if (serie.retornaExcluido())
            {
                return true;
            }
                return false;
        }
    }
}
