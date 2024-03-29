using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xadrez_console.tabuleiro;
using xadrez_console.tabuleiro.Enums;

namespace xadrez_console.tabuleiro
{
	internal class Peca
	{
		public Posicao Posicao { get; set; }

		public Cor Cor { get; protected set; }

		public int QteMovimentos { get; protected set; }

		public Tabuleiro Tab { get; set; }

		public Peca(Cor cor, Tabuleiro tab)
		{
			Posicao = null;
			Cor = cor;
			Tab = Tab;
		}


	}
}
