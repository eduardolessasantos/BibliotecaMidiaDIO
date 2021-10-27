using System;

namespace DIO.Series
{
    public class MusicaControle
    {
        static MusicaRepositorio repositorio = new MusicaRepositorio();

        public MusicaControle()
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarMusicas();
						break;
					case "2":
						InserirMusica();
						break;
					case "3":
						AtualizarMusica();
						break;
					case "4":
						ExcluirMusica();
						break;
					case "5":
						VisualizarMusica();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Músicas a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar músicas");
			Console.WriteLine("2- Inserir nova música");
			Console.WriteLine("3- Atualizar música");
			Console.WriteLine("4- Excluir música");
			Console.WriteLine("5- Visualizar música");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}

        private static void ListarMusicas()
		{
			Console.WriteLine("Listar músicas");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma música cadastrada.");
				return;
			}

			foreach (var musica in lista)
			{
                var excluido = musica.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", musica.retornaId(), musica.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirMusica()
		{
			Console.WriteLine("Inserir nova música");

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(GeneroMusica)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(GeneroMusica), i));
			}
			Console.Write("Digite o gênero musical entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Música: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Música: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Música: ");
			string entradaDescricao = Console.ReadLine();

			Musica novoMusica = new Musica(id: repositorio.ProximoId(),
										genero: (GeneroMusica)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Insere(novoMusica);
		}

        private static void AtualizarMusica()
		{
			Console.Write("Digite o id da música: ");
			int indiceMusica = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(GeneroMusica)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(GeneroMusica), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Música: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Música: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Música: ");
			string entradaDescricao = Console.ReadLine();

			Musica atualizaMusica = new Musica(id: indiceMusica,
										genero: (GeneroMusica)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceMusica, atualizaMusica);
		}

        private static void ExcluirMusica()
		{
			Console.Write("Digite o id da música: ");
			int indiceFilme = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceFilme);
		}

        private static void VisualizarMusica()
		{
			Console.Write("Digite o id da música: ");
			int indiceFilme = int.Parse(Console.ReadLine());

			var filme = repositorio.RetornaPorId(indiceFilme);

			Console.WriteLine(filme);
		}
    }
}