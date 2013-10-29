﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CrosswordGen.Model;

namespace CrosswordGen.Models
{
    class HtmlCanvasWriter : ICanvasWriter
    {
        private byte TamanhoLacuna = 26;
        private byte BordaLacuna = 2;

        public string write(Canvas canvas)
        {
            StringBuilder Builder = new StringBuilder();

            int cWidth = 0, cHeight = 0;
            cWidth = (this.TamanhoLacuna + this.BordaLacuna + this.BordaLacuna) * canvas.Width;
            cHeight = (this.TamanhoLacuna + this.BordaLacuna + this.BordaLacuna) * canvas.Height;

            // div para deixar a altura minima do body
            string div = String.Format("<div class='heightPlaceholder' style='width:{0}px;height:{1}px; padding-bottom:50px;'></div>\n", cWidth, cHeight);

            Builder.Append(div).Append(String.Format("<div style='width:{0}px;height:{1}px;position:absolute;left:0;top:0; border:5px solid #000; background: #333;'>", cWidth, cHeight));

            for (short i = 0; i < canvas.WordsAtCanvas.Count; i++)
            {
                Word w = canvas.WordsAtCanvas[i];

                char[] wChars = w.ToString().ToCharArray();

                for (short n = 0; n < wChars.Count(); n++)
                {
                    Builder
                        .Append("<div style='")
                        .Append("width:").Append(this.TamanhoLacuna).Append("px;")
                        .Append("height:").Append(this.TamanhoLacuna).Append("px;")
                        .Append("border:").Append(this.BordaLacuna).Append("px solid #000;")
                        .Append("position:absolute;")
                        .Append("background:rgba(120,120,120,0.4);")
                        .Append("color:#fff;")
                        .Append("font-weight:bold;")
                        .Append("text-align:center;")
                    ;

                    if (w.Orientation == Orientation.Vertical)
                    {
                        Builder
                            .Append("left:").Append(w.X * (this.TamanhoLacuna + this.BordaLacuna * 2)).Append("px;")
                            .Append("top:").Append((w.Y + n) * (this.TamanhoLacuna + this.BordaLacuna * 2)).Append("px;")
                        ;
                    }
                    else if (w.Orientation == Orientation.Horizontal)
                    {
                        Builder
                            .Append("left:").Append((w.X + n) * (this.TamanhoLacuna + this.BordaLacuna * 2)).Append("px;")
                            .Append("top:").Append(w.Y * (this.TamanhoLacuna + this.BordaLacuna * 2)).Append("px;")
                        ;
                    }

                    Builder
                        .Append("'>")
                        .Append(wChars[n])
                        .Append("</div>")
                    ;
                }
            }

            Builder.Append("</div>");
            Builder.Append(String.Format("<input type='hidden' name='words' id='words' value='{0}' />", canvas.WordsAtCanvas.Count));

            return Builder.ToString();
        }
    }
}
