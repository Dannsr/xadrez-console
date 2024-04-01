using xadrez_console.tabuleiro;
using xadrez_console.tabuleiro.Enums;
using xadrez_console.xadrez;

namespace xadrez
{
	internal class Rei : Peca
	{
		private PartidaDeXadrez partida;
		public Rei(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(cor, tab)
		{
			this.partida = partida;
		}

		public override string ToString()
		{
			return "R";
		}

		private bool PodeMover(Posicao pos)
		{
			Peca p = Tab.RetornaPeca(pos);
			return p == null || p.Cor != Cor;
		}

		private bool TesteTorreParaRoque(Posicao pos)
		{
			Peca p = Tab.RetornaPeca(pos);
			return p != null && p is Torre && p.Cor == Cor && p.QteMovimentos == 0;
		}


		public override bool[,] MovimentosPecas()
		{
			bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

			Posicao pos = new Posicao(0, 0);

			// acima

			pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
			if (Tab.PosicaoValida(pos) && PodeMover(pos))
			{
				mat[pos.Linha, pos.Coluna] = true;
			}

			// ne

			pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
			if (Tab.PosicaoValida(pos) && PodeMover(pos))
			{
				mat[pos.Linha, pos.Coluna] = true;
			}

			// direita

			pos.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
			if (Tab.PosicaoValida(pos) && PodeMover(pos))
			{
				mat[pos.Linha, pos.Coluna] = true;
			}

			// se

			pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
			if (Tab.PosicaoValida(pos) && PodeMover(pos))
			{
				mat[pos.Linha, pos.Coluna] = true;
			}

			// abaixo

			pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
			if (Tab.PosicaoValida(pos) && PodeMover(pos))
			{
				mat[pos.Linha, pos.Coluna] = true;
			}

			// so

			pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
			if (Tab.PosicaoValida(pos) && PodeMover(pos))
			{
				mat[pos.Linha, pos.Coluna] = true;
			}

			// esquerda

			pos.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
			if (Tab.PosicaoValida(pos) && PodeMover(pos))
			{
				mat[pos.Linha, pos.Coluna] = true;
			}

			// no

			pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
			if (Tab.PosicaoValida(pos) && PodeMover(pos))
			{
				mat[pos.Linha, pos.Coluna] = true;
			}

			// #jogadaespecial roque pequeno

			if (QteMovimentos == 0 && !partida.Xeque)
			{
				Posicao posT1 = new Posicao(Posicao.Linha, Posicao.Coluna + 3);
				if (TesteTorreParaRoque(posT1))
				{
					Posicao p1 = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
					Posicao p2 = new Posicao(Posicao.Linha, Posicao.Coluna + 2);
					if (Tab.RetornaPeca(p1) == null && Tab.RetornaPeca(p2) == null)
					{
						mat[Posicao.Linha, Posicao.Coluna + 2] = true;
					}
				}
			}

			// #jogadaespecial roque grande

			if (QteMovimentos == 0 && !partida.Xeque)
			{
				Posicao posT2 = new Posicao(Posicao.Linha, Posicao.Coluna - 4);
				if (TesteTorreParaRoque(posT2))
				{
					Posicao p1 = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
					Posicao p2 = new Posicao(Posicao.Linha, Posicao.Coluna - 2);
					Posicao p3 = new Posicao(Posicao.Linha, Posicao.Coluna - 3);
					if (Tab.RetornaPeca(p1) == null && Tab.RetornaPeca(p2) == null && Tab.RetornaPeca(p3) == null)
					{
						mat[Posicao.Linha, Posicao.Coluna - 2] = true;
					}
				}
			}
			return mat;

		}
	}
}
