using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xadrez;
using xadrez_console.tabuleiro;
using xadrez_console.tabuleiro.Enums;
using xadrez_console.tabuleiro.Exceptions;

namespace xadrez_console.xadrez
{
	internal class PartidaDeXadrez
	{

		public Tabuleiro Tab { get; private set; }
		public int Turno { get; private set; }
		public Cor JogadorAtual { get; private set; }
		public bool Terminada { get; private set; }

        public PartidaDeXadrez()
		{
			Tab = new Tabuleiro(8, 8);
			Turno = 1;
			JogadorAtual = Cor.Branco;
			ColocarPecas();
		}

		public void ValidarPosicaoDeOrigem(Posicao pos)
		{
			if (Tab.RetornaPeca(pos) == null)
			{
				throw new TabuleiroException("Não há peça nessa posição de origem escolhida!");
			}
			if (JogadorAtual != Tab.RetornaPeca(pos).Cor)
			{
				throw new TabuleiroException("A peça de origem escolhida não é sua!");
			}
			if (Tab.RetornaPeca(pos).ExisteMovimentoPossiveis() == false)
			{
				throw new TabuleiroException("Não há movimentos possíveis!");
			}
		}

		public void ValidarPosicaoDeDestino(Posicao origem, Posicao destino)
		{
			if (!Tab.RetornaPeca(origem).PodeMoverPara(destino))
			{
				throw new TabuleiroException("Posição de destino inválida!");
			}
		}

		public void ExecutaMovimento(Posicao origem, Posicao destino)
		{
			Peca p = Tab.RetirarPeca(origem);
			p.IncrementarQteMovimentos();
			Peca capturada = Tab.RetirarPeca(destino);
			Tab.ColocarPeca(p, destino);
		}

		public void RealizaJogada(Posicao origem, Posicao destino)
		{
			ExecutaMovimento(origem, destino);
			Turno++;
			MudaJogador();

		}
		private void MudaJogador()
		{
			if (JogadorAtual == Cor.Branco)
			{
				JogadorAtual = Cor.Preto;
			}
			else
			{
				JogadorAtual = Cor.Branco;
			}
		}

		private void ColocarPecas()
		{
			Tab.ColocarPeca(new Torre(Tab, Cor.Branco), new PosicaoXadrez('c', 1).ConvertePosicao());
			Tab.ColocarPeca(new Torre(Tab, Cor.Branco), new PosicaoXadrez('c', 2).ConvertePosicao());
			Tab.ColocarPeca(new Rei(Tab, Cor.Branco), new PosicaoXadrez('d', 1).ConvertePosicao());
			Tab.ColocarPeca(new Torre(Tab, Cor.Branco), new PosicaoXadrez('d', 2).ConvertePosicao());
			Tab.ColocarPeca(new Torre(Tab, Cor.Branco), new PosicaoXadrez('e', 1).ConvertePosicao());
			Tab.ColocarPeca(new Torre(Tab, Cor.Branco), new PosicaoXadrez('e', 2).ConvertePosicao());

			Tab.ColocarPeca(new Torre(Tab, Cor.Preto), new PosicaoXadrez('c', 7).ConvertePosicao());
			Tab.ColocarPeca(new Torre(Tab, Cor.Preto), new PosicaoXadrez('c', 8).ConvertePosicao());
			Tab.ColocarPeca(new Rei(Tab, Cor.Preto), new PosicaoXadrez('d', 7).ConvertePosicao());
			Tab.ColocarPeca(new Torre(Tab, Cor.Preto), new PosicaoXadrez('d', 8).ConvertePosicao());
			Tab.ColocarPeca(new Torre(Tab, Cor.Preto), new PosicaoXadrez('e', 7).ConvertePosicao());
			Tab.ColocarPeca(new Torre(Tab, Cor.Preto), new PosicaoXadrez('e', 8).ConvertePosicao());
		}

	}
}
