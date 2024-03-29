using xadrez_console.tabuleiro;
using xadrez_console.tabuleiro.Enums;

namespace xadrez
{
	internal class Rei : Peca
	{
		public Rei(Tabuleiro tab, Cor cor) : base(cor, tab)
		{
		}

		public override string ToString()
		{
			return "R";
		}
	}
}
