using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xadrez_console.tabuleiro.Exceptions;
namespace xadrez_console.tabuleiro
{
	internal class Tabuleiro
	{
        public int Linhas { get; set; }

        public int Colunas { get; set; }

        private Peca[,] pecas;

        public Tabuleiro(int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
            pecas = new Peca[linhas, colunas];
        }
        public Peca RetornaPeca(int linha, int coluna)
        {
            return pecas[linha, coluna]; 
        }
		public Peca RetornaPeca(Posicao pos)
		{
			return pecas[pos.Linha, pos.Coluna];
		}
		public void ColocarPeca(Peca p, Posicao pos)
        {
            if (ExistePeca(pos)){
                throw new TabuleiroException("Já existe outra peça nessa posição! ");
            }
            pecas[pos.Linha, pos.Coluna] = p;
            p.Posicao = pos;
        }

        public Peca RetirarPeca(Posicao pos)
        {
            if (RetornaPeca(pos) == null)
            {
                return null;
            }
            Peca aux = RetornaPeca(pos);
            aux.Posicao = null;
            pecas[pos.Linha, pos.Coluna] = null;
            return aux;
        }

        public bool PosicaoValida(Posicao pos)
        {
            if (pos.Linha < 0 || pos.Linha >= Linhas || pos.Coluna < 0 || pos.Coluna >= Colunas)
            {
                return false;
            }
            return true;
        }

        public void ValidarPosicao(Posicao pos)
        {
            if (!PosicaoValida(pos))
            {
                throw new TabuleiroException("Posição Inválida! ");
            }
        }

        public bool ExistePeca(Posicao pos)
        {
            ValidarPosicao(pos);
            return RetornaPeca(pos) != null;
        }
    }
}
