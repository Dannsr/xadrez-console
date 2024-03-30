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
				Tabuleiro tab = new Tabuleiro(8, 8);

				tab.ColocarPeca(new Torre(tab, Cor.Preto), new Posicao(0, 0));
				tab.ColocarPeca(new Torre(tab, Cor.Branco), new Posicao(2, 7));
				tab.ColocarPeca(new Torre(tab, Cor.Preto), new Posicao(5, 0));

				Tela.ImprimirTabuleiro(tab);
            }
			catch (TabuleiroException e)
			{
                Console.WriteLine(e.Message);
            }

		}
	}
}