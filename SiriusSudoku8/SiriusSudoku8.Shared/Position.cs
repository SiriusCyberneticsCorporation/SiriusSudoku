using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiriusSudoku8
{
	public class Position
	{
		public int Row = -1;
		public int Column = -1;

		public Position(int rowNumber, int columnNumber)
		{
			Row = rowNumber;
			Column = columnNumber;
		}
	}
}
