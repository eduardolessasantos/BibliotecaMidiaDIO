using System;

namespace DIO.Series
{
    class Program
    {
        //static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            Console.WriteLine();
			Console.WriteLine("Bem vindo ao cadastro de mídias da DIO!!!");
			Console.WriteLine("Inclua sua mídia na nossa biblioteca! Selecione uma opção abaixo:");

			Console.WriteLine("1- Cadastro de músicas");
			Console.WriteLine("2- Cadastro de filmes");
			Console.WriteLine("3- Cadastro de séries");
			
			string opcaoCadastro = Console.ReadLine().ToUpper();
			Console.WriteLine();

			switch(opcaoCadastro)
			{
				case "1":
					MusicaControle musica = new MusicaControle();
					break;
				case "2":
					FilmeControle filme = new FilmeControle();
					break;
				case "3":
					SerieControle serie = new SerieControle();
					break;
				default:
						throw new ArgumentOutOfRangeException();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }
        
    }
}
