using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReDraw
{
    public partial class Form1 : Form
    {
        List<Figura> figuras = new List<Figura>();

        private string estado = "dibujando";
        private Punto p1_actual;
        private Color color_actual;
        private Figura figuraSeleccionada;

        private Figura Selecciona(int x, int y)
        {
            for (int i = figuras.Count - 1; i >= 0; i--)
            {
                if (figuras[i].EstaDentro(x, y))
                    return figuras[i];
            }
            return null;
        }

        private void DibujaFiguras()
        {
            foreach (var figura in figuras)
                figura.Dibuja(this);
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            this.DibujaFiguras();


        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (estado == "Linea")
            {
                estado = "moviendoL";
                label1.Text = String.Format($"x: {e.X}, y: {e.Y}");
                p1_actual = new Punto(e.X, e.Y);
            }
            else if(estado == "Rectángulo")
            {
                estado = "moviendoR";
                label1.Text = String.Format($"x: {e.X}, y: {e.Y}");
                p1_actual = new Punto(e.X, e.Y);
            }
            else if (estado == "Elipse")
            {
                estado = "moviendoE";
                label1.Text = String.Format($"x: {e.X}, y: {e.Y}");
                p1_actual = new Punto(e.X, e.Y);
            }
            else if (estado == "Triángulo")
            {
                estado = "moviendoT";
                label1.Text = String.Format($"x: {e.X}, y: {e.Y}");
                p1_actual = new Punto(e.X, e.Y);
            }
            else if (estado == "dibujando")
            {
                estado = "moviendo";
                label1.Text = String.Format($"x: {e.X}, y: {e.Y}");
                p1_actual = new Punto(e.X, e.Y);
            }
            else if (estado == "seleccionando")
            {
                figuraSeleccionada = Selecciona(e.X, e.Y);
                if (figuraSeleccionada != null)
                {
                    label2.Text = String.Format($"Se ha seleccionado : x: {figuraSeleccionada.punto1.X}, y:{figuraSeleccionada.punto1.Y}");
                }

            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (estado == "moviendoL")
            {
                estado = "dibujando";

                label1.Text = String.Format($"x: {e.X}, y: {e.Y}");

                Linea l = new Linea(p1_actual, new Punto(e.X, e.Y));

                l.Dibuja(this);
                figuras.Add(l);
            }
            else if (estado == "moviendoR")
            {
                estado = "dibujando";

                label1.Text = String.Format($"x: {e.X}, y: {e.Y}");

                Rectangulo r = new Rectangulo(p1_actual, new Punto(e.X, e.Y));

                r.Dibuja(this);
                figuras.Add(r);

            }
            else if (estado == "moviendoE")
            {
                estado = "dibujando";

                label1.Text = String.Format($"x: {e.X}, y: {e.Y}");

                Elipse elipse = new Elipse(p1_actual, new Punto(e.X, e.Y));

                elipse.Dibuja(this);
                figuras.Add(elipse);

            }
            else if (estado == "moviendoT")
            {
                estado = "dibujando";

                label1.Text = String.Format($"x: {e.X}, y: {e.Y}");

                Triangulo t = new Triangulo(p1_actual, new Punto(e.X, e.Y));

                t.Dibuja(this);
                figuras.Add(t);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            estado = "seleccionando";
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            estado = "Pluma"; 
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            
                label1.Text = String.Format($"x: {e.X}, y: {e.Y}");
        }

      
        private void pieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            estado = "Linea";
        }

        private void rectánguloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            estado = "Rectángulo";
        }

        private void cpirculoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            estado = "Elipse";
        }

        private void triánguloToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            estado = "Triángulo";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            figuras.Sort();
            figuras.Reverse();
            DibujaFiguras();
        }

        private void rojoToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }
    }
}
