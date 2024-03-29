using System;
using xadrez_console.tabuleiro;
using xadrez_console.tabuleiro.Enums;
using xadrez;

namespace xadrez_console
{
	class Program
	{
		static void Main(string[] args)
		{
			Tabuleiro tab = new Tabuleiro(8, 8);

			tab.ColocarPeca(new Torre(tab, Cor.Preto), new Posicao(0, 0));
			tab.ColocarPeca(new Rei(tab, Cor.Branco), new Posicao(1, 3));

			Tela.ImprimirTabuleiro(tab);
        }
	}
}