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
					try
					{
						Console.Clear();
						Tela.ImprimirPartida(partidaDeXadrez);
                        Console.Write("Digite a Posição de Origem: ");
                        Posicao origem = Tela.LerPosicao().ConvertePosicao();
						partidaDeXadrez.ValidarPosicaoDeOrigem(origem);

						bool[,] posicoesPossiveis = partidaDeXadrez.Tab.RetornaPeca(origem).MovimentosPecas();


						Console.Clear();

						Tela.ImprimirTabuleiro(partidaDeXadrez.Tab, posicoesPossiveis);
						Console.WriteLine();

						Console.Write("Digite a Posição de Destino: ");
						Posicao destino = Tela.LerPosicao().ConvertePosicao();
						partidaDeXadrez.ValidarPosicaoDeDestino(origem, destino);
						partidaDeXadrez.RealizaJogada(origem, destino);


					}
					catch (TabuleiroException e)
					{
						Console.WriteLine(e.Message);
						Console.ReadLine();
					}
					catch (System.IndexOutOfRangeException e)
					{
						Console.WriteLine("Movimento Inválido!");
						Console.ReadLine();
					}
					catch (System.FormatException e)
					{
						Console.WriteLine("Movimento Inválido!");
						Console.ReadLine();
					}
				}
				Console.Clear();
				Tela.ImprimirPartida(partidaDeXadrez);
            }
			catch (TabuleiroException e)
			{
                Console.WriteLine(e.Message);
            }

		}
	}
}