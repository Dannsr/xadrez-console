using System;
using xadrez_console.tabuleiro;
using xadrez_console.tabuleiro.Enums;
using xadrez;
using xadrez_console.tabuleiro.Exceptions;
using xadrez_console.xadrez;

namespace xadrez_console
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				PartidaDeXadrez partidaDeXadrez = new PartidaDeXadrez();
				while (!partidaDeXadrez.Terminada)
				{
					Console.Clear();
					Tela.ImprimirTabuleiro(partidaDeXadrez.Tab);
					Console.Write("Digite a Posição de Origem: ");
					Posicao origem = Tela.LerPosicao().ConvertePosicao();

					Console.Write("Digite a Posição de Destino: ");
					Posicao destino = Tela.LerPosicao().ConvertePosicao();

					partidaDeXadrez.ExecutaMovimento(origem, destino);

				}
            }
			catch (TabuleiroException e)
			{
                Console.WriteLine(e.Message);
            }

		}
	}
}