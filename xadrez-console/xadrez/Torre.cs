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
		private bool PodeMover(Posicao pos)
		{
			Peca p = Tab.RetornaPeca(pos);
			return p == null || p.Cor != Cor;
		}

		public override bool[,] MovimentosPecas()
		{
			bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

			Posicao pos = new Posicao(0, 0);

			// acima

			pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
			while (Tab.PosicaoValida(pos) && PodeMover(pos))
			{
				mat[pos.Linha, pos.Coluna] = true;
				if (Tab.RetornaPeca(pos) != null && Tab.RetornaPeca(pos).Cor != Cor)
				{
					break;
				}
				pos.Linha--;
			}

			// abaixo

			pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
			while (Tab.PosicaoValida(pos) && PodeMover(pos))
			{
				mat[pos.Linha, pos.Coluna] = true;
				if (Tab.RetornaPeca(pos) != null && Tab.RetornaPeca(pos).Cor != Cor)
				{
					break;
				}
				pos.Linha++;
			}

			// direita

			pos.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
			while (Tab.PosicaoValida(pos) && PodeMover(pos))
			{
				mat[pos.Linha, pos.Coluna] = true;
				if (Tab.RetornaPeca(pos) != null && Tab.RetornaPeca(pos).Cor != Cor)
				{
					break;
				}
				pos.Coluna++;
			}

			// esquerda

			pos.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
			while (Tab.PosicaoValida(pos) && PodeMover(pos))
			{
				mat[pos.Linha, pos.Coluna] = true;
				if (Tab.RetornaPeca(pos) != null && Tab.RetornaPeca(pos).Cor != Cor)
				{
					break;
				}
				pos.Coluna--;
			}
			return mat;
		}
	}
}

