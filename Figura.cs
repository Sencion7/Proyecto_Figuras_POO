using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ReDraw
{
    abstract class Figura : IComparable
    {
        public Punto punto1 { get; set; }
        public Punto punto2 { get; set; }

        protected SolidBrush brocha { get; set; }
        protected Pen pluma { get; set; }
        protected int anchoPluma { get; set; }
        public Color colorRelleno { get; set; }
        public Color colorContorno { get; set; }

        protected int Ancho
        {
            get
            {
                return punto2.X - punto1.X;
            }

        }

        protected int Alto
        {
            get
            {
                return punto2.Y - punto1.Y;
            }
        }

        public int Area
        {
            get
            {
                return Ancho * Alto;
            }
        }

        public Figura(Punto punto1, Punto punto2)
        {
            this.punto1 = punto1;
            this.punto2 = punto2;
            colorRelleno = Color.White;
            new SolidBrush(colorRelleno);
            colorContorno = Color.Black;
            anchoPluma = 1;
            new Pen(colorContorno, anchoPluma);
        }

        public abstract void Dibuja(Form forma);

        public bool EstaDentro(int x, int y)
        {
            return (x >= punto1.X && x <= punto2.X && y >= punto1.Y && y <= punto2.Y);
        }

        public int CompareTo(object obj)
        {
            return this.Area.CompareTo((obj as Figura).Area);
        }
    }

    class Rectangulo : Figura
    {
        public Punto Punto1 { get; set; }
        public Punto Punto2 { get; set; }

        public Rectangulo(Punto punto1, Punto punto2) : base(punto1, punto2)
        {

        }
        public override void Dibuja(Form forma)
        {
            Graphics graphics = forma.CreateGraphics();
            graphics.FillRectangle(new SolidBrush(colorRelleno), punto1.X, punto1.Y, punto2.X - punto1.X, punto2.Y - punto1.Y);
            graphics.DrawRectangle(new Pen(colorContorno, anchoPluma), punto1.X, punto1.Y, punto2.X - punto1.X, punto2.Y - punto1.Y);

        }
    }

    class Elipse : Figura
    {
        public Punto Punto1 { get; set; }
        public Punto Punto2 { get; set; }

        public Elipse(Punto punto1, Punto punto2) : base(punto1, punto2)
        {

        }
        public override void Dibuja(Form forma)
        {
            Graphics graphics = forma.CreateGraphics();
            graphics.FillEllipse(new SolidBrush(colorRelleno), punto1.X, punto1.Y, punto2.X - punto1.X, punto2.Y - punto1.Y);
            graphics.DrawEllipse(new Pen(colorContorno, anchoPluma), punto1.X, punto1.Y, punto2.X - punto1.X, punto2.Y - punto1.Y);
        }
    }

    class Linea : Figura
    {
        public Punto Punto1 { get; set; }
        public Punto Punto2 { get; set; }

        public Linea(Punto punto1, Punto punto2) : base(punto1, punto2)
        {

        }
        public override void Dibuja(Form forma)
        {
            Graphics graphics = forma.CreateGraphics();
            graphics.DrawLine(new Pen(colorContorno), punto1.X, punto1.Y, punto2.X, punto2.Y);
        }
    }

    class Triangulo : Figura
    {
        public Punto Punto1 { get; set; }
        public Punto Punto2 { get; set; }

        public Triangulo(Punto punto1, Punto punto2) : base(punto1, punto2)
        {

        }
        public override void Dibuja(Form forma)
        {

            Graphics graphics = forma.CreateGraphics();
            Point[] puntos = { new Point(punto1.X, punto1.Y), new Point(punto2.X, punto2.Y),new Point((punto1.X + punto2.X)/2 , (punto1.Y + punto2.Y) ) };
            graphics.FillPolygon(new SolidBrush(colorRelleno), puntos);
            graphics.DrawPolygon(new Pen(colorContorno, anchoPluma), puntos);
            
        }
    }

}
