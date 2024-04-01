using xadrez_console.tabuleiro;
using xadrez_console.tabuleiro.Enums;

namespace xadrez
{
	internal class Cavalo : Peca
	{
		public Cavalo(Tabuleiro tab, Cor cor) : base(cor, tab)
		{
		}

		public override string ToString()
		{
			return "C";
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


			pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 2);
			if (Tab.PosicaoValida(pos) && PodeMover(pos))
			{
				mat[pos.Linha, pos.Coluna] = true;
			}


			pos.DefinirValores(Posicao.Linha - 2, Posicao.Coluna - 1);
			if (Tab.PosicaoValida(pos) && PodeMover(pos))
			{
				mat[pos.Linha, pos.Coluna] = true;
			}


			pos.DefinirValores(Posicao.Linha - 2, Posicao.Coluna + 1);
			if (Tab.PosicaoValida(pos) && PodeMover(pos))
			{
				mat[pos.Linha, pos.Coluna] = true;
			}

			pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 2);
			if (Tab.PosicaoValida(pos) && PodeMover(pos))
			{
				mat[pos.Linha, pos.Coluna] = true;
			}


			pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 2);
			if (Tab.PosicaoValida(pos) && PodeMover(pos))
			{
				mat[pos.Linha, pos.Coluna] = true;
			}


			pos.DefinirValores(Posicao.Linha + 2, Posicao.Coluna + 1);
			if (Tab.PosicaoValida(pos) && PodeMover(pos))
			{
				mat[pos.Linha, pos.Coluna] = true;
			}


			pos.DefinirValores(Posicao.Linha + 2, Posicao.Coluna - 1);
			if (Tab.PosicaoValida(pos) && PodeMover(pos))
			{
				mat[pos.Linha, pos.Coluna] = true;
			}


			pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 2);
			if (Tab.PosicaoValida(pos) && PodeMover(pos))
			{
				mat[pos.Linha, pos.Coluna] = true;
			}
			return mat;

		}
	}
}
