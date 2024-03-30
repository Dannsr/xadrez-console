using xadrez_console.tabuleiro;

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
					if (tab.RetornaPeca(i, j)==null)
					{
                        Console.Write("- ");
                    }
					else
					{
						Tela.ImprimirTela(tab.RetornaPeca(i, j));
						Console.Write(" ");
					}
                }
				Console.WriteLine();
			}
            Console.WriteLine("  a b c d e f g h");
        }
		public static void ImprimirTela(Peca peca)
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
		}
	}
}
