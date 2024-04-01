using System.Security.AccessControl;
using xadrez_console.tabuleiro;
using xadrez_console.tabuleiro.Enums;
using xadrez_console.xadrez;

namespace xadrez
{
	internal class Peao : Peca
	{
		public Peao(Tabuleiro tab, Cor cor) : base(cor, tab)
		{
		}

		public override string ToString()
		{
			return "P";
		}

		private bool ExisteInimigo(Posicao pos)
		{
			Peca p = Tab.RetornaPeca(pos);
			return p != null && p.Cor != Cor;
		}

		private bool Livre(Posicao pos)
		{
			return Tab.RetornaPeca(pos) == null;
		}

		public override bool[,] MovimentosPecas()
		{
			bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

			Posicao pos = new Posicao(0, 0);

			PartidaDeXadrez partida = new PartidaDeXadrez();

			if (Cor == Cor.Branco)
			{
				// acima 

				pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
				if (Tab.PosicaoValida(pos) && Livre(pos))
				{
					mat[pos.Linha, pos.Coluna] = true;
				}
				// acima + 2

				pos.DefinirValores(Posicao.Linha - 2, Posicao.Coluna);
				Posicao p2 = new Posicao(Posicao.Linha - 1, Posicao.Coluna);
				if (Tab.PosicaoValida(p2) && Livre(p2) && Tab.PosicaoValida(pos) && Livre(pos) && QteMovimentos == 0)
				{
					mat[pos.Linha, pos.Coluna] = true;
				}

				// diagonal esquerda

				pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
				if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
				{
					mat[pos.Linha, pos.Coluna] = true;
				}

				// diagonal direita

				pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
				if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
				{
					mat[pos.Linha, pos.Coluna] = true;
				}
			}
			else
			{
				// acima 
				pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
				if (Tab.PosicaoValida(pos) && Livre(pos))
				{
					mat[pos.Linha, pos.Coluna] = true;
				}

				// acima + 2

				pos.DefinirValores(Posicao.Linha + 2, Posicao.Coluna);
				Posicao p2 = new Posicao(Posicao.Linha + 1, Posicao.Coluna);
				if (Tab.PosicaoValida(p2) && Livre(p2) && Tab.PosicaoValida(pos) && Livre(pos) && QteMovimentos == 0)
				{
					mat[pos.Linha, pos.Coluna] = true;
				}

				// diagonal direita

				pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
				if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
				{
					mat[pos.Linha, pos.Coluna] = true;
				}

				// diagonal esquerda

				pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
				if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
				{
					mat[pos.Linha, pos.Coluna] = true;
				}
			}
			return mat;
		}
	}
}