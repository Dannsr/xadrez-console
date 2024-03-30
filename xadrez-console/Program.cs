using System;
using xadrez_console.tabuleiro;
using xadrez_console.tabuleiro.Enums;
using xadrez;
using xadrez_console.tabuleiro.Exceptions;
using xadrez_console.xadrez;

namespace xadrez_console
{
	class Program
	{
		static void Main(string[] args)
		{
			PosicaoXadrez pos = new PosicaoXadrez('b', 4);

            Console.WriteLine(pos.ConvertePosicao());

            Console.WriteLine(pos);
        }
	}
}