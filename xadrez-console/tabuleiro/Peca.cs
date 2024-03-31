using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xadrez_console.tabuleiro;
using xadrez_console.tabuleiro.Enums;

namespace xadrez_console.tabuleiro
{
	abstract class Peca
	{
		public Posicao Posicao { get; set; }

		public Cor Cor { get; protected set; }

		public int QteMovimentos { get; protected set; }

		public Tabuleiro Tab { get; set; }

		public Peca(Cor cor, Tabuleiro tab)
		{
			Posicao = null;
			Cor = cor;
			Tab = tab;
		}

		public void IncrementarQteMovimentos()
		{
			QteMovimentos++;
		}

		public void DecrementarQteMovimentos()
		{
			QteMovimentos--;
		}

		public bool ExisteMovimentoPossiveis()
		{
			bool[,] mat = MovimentosPecas();
			for (int i = 0; i< Tab.Linhas; i++)
			{
				for (int j = 0; j < Tab.Colunas; j++)
				{
					if (mat[i, j])
					{
						return true;
					}
				}
			}
			return false;
		}

		public bool MovimentoPossivel(Posicao pos)
		{
			return MovimentosPecas()[pos.Linha, pos.Coluna];
		}

		public abstract bool[,] MovimentosPecas();
	}
}
