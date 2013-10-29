using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrosswordGen.Model
{
    public interface ICanvasWriter
    {
        string write(Canvas canvas);
    }
}
