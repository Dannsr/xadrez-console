using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xadrez_console.tabuleiro.Exceptions
{
	internal class TabuleiroException : Exception
	{
		public TabuleiroException(string msg) : base(msg)
		{
		}
	}
}
