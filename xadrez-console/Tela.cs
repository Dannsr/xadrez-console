using xadrez_console.tabuleiro;
using System;
using xadrez;
using xadrez_console.xadrez;


namespace xadrez_console
{
	internal class Tela
	{
		public static void ImprimirTabuleiro(Tabuleiro tab)
		{
			for (int i = 0; i < tab.Linhas; i++)
			{
				Console.Write(8 - i + " ");
				for (int j = 0; j < tab.Colunas; j++)
				{
					Tela.ImprimirTela(tab.RetornaPeca(i, j));
				}
				Console.WriteLine();
			}
			Console.WriteLine("  a b c d e f g h");
		}
		public static void ImprimirTela(Peca peca)
		{
			if (peca == null)
			{
				Console.Write("- ");
			}
			else
			{
				if (peca.Cor == tabuleiro.Enums.Cor.Branco)
				{
					Console.Write(peca);
				}
				else
				{
					ConsoleColor aux = Console.ForegroundColor;
					Console.ForegroundColor = ConsoleColor.Magenta;
					Console.Write(peca);
					Console.ForegroundColor = aux;
				}
				Console.Write(" ");
			}
		}
		public static void ImprimirTabuleiro(Tabuleiro tab, bool[,] movimentos)
		{
			ConsoleColor fundoOriginal = Console.BackgroundColor;
			ConsoleColor fundoAlterado = ConsoleColor.DarkBlue;

			for (int i = 0; i < tab.Linhas; i++)
			{
				Console.Write(8 - i + " ");
				for (int j = 0; j < tab.Colunas; j++)
				{
					if (movimentos[i, j] == true)
					{
						Console.BackgroundColor = fundoAlterado;
					}
					else
					{
						Console.BackgroundColor = fundoOriginal;
					}
					Tela.ImprimirTela(tab.RetornaPeca(i, j));
					Console.BackgroundColor = fundoOriginal;
				}
				Console.WriteLine();
			}
			Console.WriteLine("  a b c d e f g h");
			Console.BackgroundColor = fundoOriginal;
		}
		public static PosicaoXadrez LerPosicao()
		{
			string s = Console.ReadLine();
			char coluna = s[0];
			int linha = int.Parse(s[1] + "");
			return new PosicaoXadrez(coluna, linha);
		}
	}
}

