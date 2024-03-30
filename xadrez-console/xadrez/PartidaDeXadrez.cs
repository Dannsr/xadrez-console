using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xadrez;
using xadrez_console.tabuleiro;
using xadrez_console.tabuleiro.Enums;

namespace xadrez_console.xadrez
{
	internal class PartidaDeXadrez
	{

		public Tabuleiro Tab { get; private set; }
		private int turno;
		private Cor jogadorAtual;
        public bool Terminada { get; private set; }

        public PartidaDeXadrez()
		{
			Tab = new Tabuleiro(8, 8);
			turno = 1;
			jogadorAtual = Cor.Branco;
			ColocarPecas();
		}

		public void ExecutaMovimento(Posicao origem, Posicao destino)
		{
			Peca p = Tab.RetirarPeca(origem);
			p.IncrementarQteMovimentos();
			Peca capturada = Tab.RetirarPeca(destino);
			Tab.ColocarPeca(p, destino);
		}

		private void ColocarPecas()
		{
			Tab.ColocarPeca(new Torre(Tab, Cor.Preto), new PosicaoXadrez('c', 1).ConvertePosicao());
			Tab.ColocarPeca(new Torre(Tab, Cor.Preto), new PosicaoXadrez('c', 2).ConvertePosicao());
			Tab.ColocarPeca(new Rei(Tab, Cor.Preto), new PosicaoXadrez('d', 1).ConvertePosicao());
			Tab.ColocarPeca(new Torre(Tab, Cor.Preto), new PosicaoXadrez('d', 2).ConvertePosicao());
			Tab.ColocarPeca(new Torre(Tab, Cor.Preto), new PosicaoXadrez('e', 1).ConvertePosicao());
			Tab.ColocarPeca(new Torre(Tab, Cor.Preto), new PosicaoXadrez('e', 2).ConvertePosicao());

			Tab.ColocarPeca(new Torre(Tab, Cor.Branco), new PosicaoXadrez('c', 7).ConvertePosicao());
			Tab.ColocarPeca(new Torre(Tab, Cor.Branco), new PosicaoXadrez('c', 8).ConvertePosicao());
			Tab.ColocarPeca(new Rei(Tab, Cor.Branco), new PosicaoXadrez('d', 7).ConvertePosicao());
			Tab.ColocarPeca(new Torre(Tab, Cor.Branco), new PosicaoXadrez('d', 8).ConvertePosicao());
			Tab.ColocarPeca(new Torre(Tab, Cor.Branco), new PosicaoXadrez('e', 7).ConvertePosicao());
			Tab.ColocarPeca(new Torre(Tab, Cor.Branco), new PosicaoXadrez('e', 8).ConvertePosicao());
		}

	}
}
