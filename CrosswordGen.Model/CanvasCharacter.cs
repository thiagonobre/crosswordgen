using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrosswordGen.Model
{
    public class CanvasCharacter
    {
        public readonly char CanvasChar;
        public readonly ushort Index;
        public readonly Word Word;
        public readonly int X;
        public readonly int Y;

        public CanvasCharacter(char canvasChar, ushort index, Word word, int x, int y)
        {
            CanvasChar = canvasChar;
            Index = index;
            this.Word = word;
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return CanvasChar.ToString();
        }
    }
}
