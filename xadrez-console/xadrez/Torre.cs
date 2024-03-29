using xadrez_console.tabuleiro;
using xadrez_console.tabuleiro.Enums;

namespace xadrez
{
	internal class Torre : Peca
	{
		public Torre(Tabuleiro tab, Cor cor) : base(cor, tab)
		{
		}

		public override string ToString()
		{
			return "T";
		}
	}
}

