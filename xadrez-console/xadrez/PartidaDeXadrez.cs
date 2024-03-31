using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xadrez;
using xadrez_console.tabuleiro;
using xadrez_console.tabuleiro.Enums;
using xadrez_console.tabuleiro.Exceptions;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace xadrez_console.xadrez
{
	internal class PartidaDeXadrez
	{
		public Tabuleiro Tab { get; private set; }
		public int Turno { get; private set; }
		public Cor JogadorAtual { get; private set; }
		public bool Terminada { get; private set; }

		private HashSet<Peca> pecas;
		private HashSet<Peca> capturadas;

        public PartidaDeXadrez()
		{
			Tab = new Tabuleiro(8, 8);
			Turno = 1;
			JogadorAtual = Cor.Branco;
			Terminada = false;
			pecas = new HashSet<Peca>();
			capturadas = new HashSet<Peca>();
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
			if(capturada != null)
			{
				capturadas.Add(capturada);
			}
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

		public void ColocarNovaPeca(char coluna, int linha, Peca peca)
		{
			Tab.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ConvertePosicao());
			pecas.Add(peca);
		}

		private void ColocarPecas()
		{
			ColocarNovaPeca('c', 1, new Torre(Tab, Cor.Branco));
			ColocarNovaPeca('c', 2, new Torre(Tab, Cor.Branco));
			ColocarNovaPeca('d', 1, new Rei(Tab, Cor.Branco));
			ColocarNovaPeca('d', 2, new Torre(Tab, Cor.Branco));
			ColocarNovaPeca('e', 1, new Torre(Tab, Cor.Branco));
			ColocarNovaPeca('e', 2, new Torre(Tab, Cor.Branco));

			ColocarNovaPeca('c', 7, new Torre(Tab, Cor.Preto));
			ColocarNovaPeca('c', 8, new Torre(Tab, Cor.Preto));
			ColocarNovaPeca('d', 8, new Rei(Tab, Cor.Preto));
			ColocarNovaPeca('d', 7, new Torre(Tab, Cor.Preto));
			ColocarNovaPeca('e', 7, new Torre(Tab, Cor.Preto));
			ColocarNovaPeca('e', 8, new Torre(Tab, Cor.Preto));
		}

		public HashSet<Peca> PecasCapturadas(Cor cor)
		{
			HashSet<Peca> aux = new HashSet<Peca>();
			foreach (Peca x in capturadas)
			{
				if (x.Cor == cor)
				{
					aux.Add(x);
				}
			}
			return aux;
		}

		public HashSet<Peca> PecasEmjogo(Cor cor)
		{
			HashSet<Peca> aux = new HashSet<Peca>();
			foreach (Peca x in pecas)
			{
				if (x.Cor == cor)
				{
					aux.Add(x);
				}
			}
			aux.ExceptWith(PecasCapturadas(cor));
			return aux;
		}
		

	}
}
