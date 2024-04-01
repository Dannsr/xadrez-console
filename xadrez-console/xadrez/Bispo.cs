using xadrez_console.tabuleiro;
using xadrez_console.tabuleiro.Enums;

namespace xadrez
{
	internal class Bispo : Peca
	{
		public Bispo(Tabuleiro tab, Cor cor) : base(cor, tab)
		{
		}

		public override string ToString()
		{
			return "B";
		}
		private bool PodeMover(Posicao pos)
		{
			Peca p = Tab.RetornaPeca(pos);
			return p == null || p.Cor != Cor;
		}

		public override bool[,] MovimentosPecas()
		{
			bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

			Posicao pos = new Posicao(0, 0);

			// NO

			pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna -1);
			while (Tab.PosicaoValida(pos) && PodeMover(pos))
			{
				mat[pos.Linha, pos.Coluna] = true;
				if (Tab.RetornaPeca(pos) != null && Tab.RetornaPeca(pos).Cor != Cor)
				{
					break;
				}
				pos.DefinirValores(pos.Linha - 1, pos.Coluna - 1);
			}

			// NE

			pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
			while (Tab.PosicaoValida(pos) && PodeMover(pos))
			{
				mat[pos.Linha, pos.Coluna] = true;
				if (Tab.RetornaPeca(pos) != null && Tab.RetornaPeca(pos).Cor != Cor)
				{
					break;
				}
				pos.DefinirValores(pos.Linha - 1, pos.Coluna + 1);
			}

			// SE

			pos.DefinirValores(Posicao.Linha + 1 , Posicao.Coluna + 1);
			while (Tab.PosicaoValida(pos) && PodeMover(pos))
			{
				mat[pos.Linha, pos.Coluna] = true;
				if (Tab.RetornaPeca(pos) != null && Tab.RetornaPeca(pos).Cor != Cor)
				{
					break;
				}
				pos.DefinirValores(pos.Linha + 1, pos.Coluna + 1);
			}

			// SO

			pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
			while (Tab.PosicaoValida(pos) && PodeMover(pos))
			{
				mat[pos.Linha, pos.Coluna] = true;
				if (Tab.RetornaPeca(pos) != null && Tab.RetornaPeca(pos).Cor != Cor)
				{
					break;
				}
				pos.DefinirValores(pos.Linha + 1, pos.Coluna - 1);
			}
			return mat;
		}
	}
}

