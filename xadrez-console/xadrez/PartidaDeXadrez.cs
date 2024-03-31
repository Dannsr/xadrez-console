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

        public bool Xeque { get; private set; }

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
			if (!Tab.RetornaPeca(origem).MovimentoPossivel(destino))
			{
				throw new TabuleiroException("Posição de destino inválida!");
			}
		}

		public Peca ExecutaMovimento(Posicao origem, Posicao destino)
		{
			Peca p = Tab.RetirarPeca(origem);
			p.IncrementarQteMovimentos();
			Peca capturada = Tab.RetirarPeca(destino);
			Tab.ColocarPeca(p, destino);
			if(capturada != null)
			{
				capturadas.Add(capturada);
			}
			return capturada;
		}

		public void RealizaJogada(Posicao origem, Posicao destino)
		{
			Peca pecaCapturada = ExecutaMovimento(origem, destino);

			if (EstaEmCheque(JogadorAtual))
			{
				DesfazMovimento(origem, destino, pecaCapturada);
				throw new TabuleiroException("Você não pode se colocar em xeque!");
			}
			if (EstaEmCheque(Adversaria(JogadorAtual)))
			{
				Xeque = true;
			}
			else
			{
				Xeque = false;
			}
			if (TesteXequeMate(Adversaria(JogadorAtual)))
			{
				Terminada = true;
			}
			else
			{
                Turno++;
				MudaJogador();
			}

		}

		public void DesfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
		{
			Peca p = Tab.RetirarPeca(destino);
			p.DecrementarQteMovimentos();
			if (pecaCapturada != null)
			{
				Tab.ColocarPeca(pecaCapturada, destino);
				capturadas.Remove(pecaCapturada);
			}
			Tab.ColocarPeca(p, origem);
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

		private Peca Rei(Cor cor)
		{
			foreach (Peca x in PecasEmjogo(cor))
			{
				if (x is Rei)
				{
					return x;
				}
			}
			return null;
		}

		private Cor Adversaria(Cor cor)
		{
			if (cor == Cor.Branco)
			{
				cor = Cor.Preto;
				return cor;
			}
			else
			{
				cor = Cor.Branco;
				return cor;
			}


		}

		public bool EstaEmCheque(Cor cor)
		{
			Peca R = Rei(cor);
			foreach(Peca x in PecasEmjogo(Adversaria(cor)))
			{
				bool[,] mat = x.MovimentosPecas();
				if (mat[R.Posicao.Linha, R.Posicao.Coluna])
				{
					return true;
				}
			}
			return false;
		}

		public bool TesteXequeMate(Cor cor)
		{
			if (!EstaEmCheque(cor))
			{
				return false;
			}
			foreach (Peca x in PecasEmjogo(cor))
			{
				bool[,] mat = x.MovimentosPecas();
				for (int i = 0; i < Tab.Linhas; i++)
				{
					for (int j = 0; j < Tab.Colunas; j++)
					{
						if (mat[i, j])
						{
							Posicao origem = x.Posicao;
							Posicao destino = new Posicao(i, j);
							Peca pecaCapturada = ExecutaMovimento(origem, destino);
							bool testeXeque = EstaEmCheque(cor);
							DesfazMovimento(origem, destino, pecaCapturada);
							if (!testeXeque)
							{
								return false;
							}
						}
					}
				}
			}
			return true;
		}

		private void ColocarPecas()
		{
			ColocarNovaPeca('c', 2, new Torre(Tab, Cor.Branco));
			ColocarNovaPeca('d', 1, new Rei(Tab, Cor.Branco));
			ColocarNovaPeca('h', 7, new Torre(Tab, Cor.Branco));

			ColocarNovaPeca('b', 8, new Torre(Tab, Cor.Preto));
			ColocarNovaPeca('a', 8, new Rei(Tab, Cor.Preto));

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
