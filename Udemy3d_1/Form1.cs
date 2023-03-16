using Graphics3ds;

namespace Udemy3d_1
{
    public partial class Form1 : Form
    {



        public Form1()
        {
            InitializeComponent();
        }

        Graphics g;
        Graficos3d g3;
        int esc = 5;//escala
        int tr = 5;//trasnlacion
        Point3DF[] nodos = new Point3DF[8];


        //rotacion
        double angulox = 0;
        double anguloy = 0;
        Point posm;
        bool mover = false;



        private void Form1_Load(object sender, EventArgs e)
        {
            nodos[0] = new Point3DF(-50, -50, -50);
            nodos[1] = new Point3DF(-50, -50, 50);
            nodos[2] = new Point3DF(-50, 50, 50);
            nodos[3] = new Point3DF(-50, 50, -50);

            nodos[4] = new Point3DF(50, -50, -50);
            nodos[5] = new Point3DF(50, -50, 50);

            nodos[6] = new Point3DF(50, 50, 50);
            nodos[7] = new Point3DF(50, 50, -50);


            posm = new Point(0, 0);

        }

        private void ptbox_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            g3 = new Graficos3d(g);
            e.Graphics.TranslateTransform(ptbox.Width / 2, ptbox.Height / 2);
            Pen pluma = new Pen(Color.FromArgb(1, 94, 230), 2);

            //cara1
            g3.DrawLine3D(pluma, nodos[0], nodos[1]);
            g3.DrawLine3D(pluma, nodos[1], nodos[2]);
            g3.DrawLine3D(pluma, nodos[2], nodos[3]);
            g3.DrawLine3D(pluma, nodos[3], nodos[0]);

            //cara 2
            g3.DrawLine3D(pluma, nodos[4], nodos[5]);
            g3.DrawLine3D(pluma, nodos[5], nodos[6]);
            g3.DrawLine3D(pluma, nodos[6], nodos[7]);
            g3.DrawLine3D(pluma, nodos[7], nodos[4]);

            //lienas que unen las caras

            g3.DrawLine3D(pluma, nodos[0], nodos[4]);
            g3.DrawLine3D(pluma, nodos[1], nodos[5]);
            g3.DrawLine3D(pluma, nodos[2], nodos[6]);
            g3.DrawLine3D(pluma, nodos[3], nodos[7]);

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {

                case Keys.Left:
                    EscalarX(true);
                    break;

                case Keys.Right:
                    EscalarX(false);
                    break;

                case Keys.Up:
                    EscalarY(true);
                    break;

                case Keys.Down:
                    EscalarY(false);
                    break;

                case Keys.Q:
                    EscalarZ(true);
                    break;

                case Keys.Z:
                    EscalarZ(false);
                    break;


                //trasladar
                case Keys.A://izquierda
                    TrasladarX(false);
                    break;

                case Keys.D://derecha
                    TrasladarX(true);
                    break;

                case Keys.W://arriba
                    TrasladarY(true);
                    break;

                case Keys.S://abajo
                    TrasladarY(false);
                    break;


            }

        }

        private void EscalarX(bool aumentar_dismnuir)
        {
            if (aumentar_dismnuir)
            {

                nodos[4].X += esc;
                nodos[5].X += esc;
                nodos[6].X += esc;
                nodos[7].X += esc;
            }
            else
            {
                nodos[4].X -= esc;
                nodos[5].X -= esc;
                nodos[6].X -= esc;
                nodos[7].X -= esc;

            }
            ptbox.Refresh();

        }

        private void EscalarY(bool aumentar_dismnuir)
        {
            if (aumentar_dismnuir)
            {

                nodos[2].Y += esc;
                nodos[3].Y += esc;
                nodos[6].Y += esc;
                nodos[7].Y += esc;
            }
            else
            {
                nodos[2].Y -= esc;
                nodos[3].Y -= esc;
                nodos[6].Y -= esc;
                nodos[7].Y -= esc;
            }
            ptbox.Refresh();
        }
        private void EscalarZ(bool aumentar_dismnuir)
        {
            if (aumentar_dismnuir)
            {

                nodos[1].Z += esc;
                nodos[2].Z += esc;
                nodos[5].Z += esc;
                nodos[6].Z += esc;
            }
            else
            {
                nodos[1].Z -= esc;
                nodos[2].Z -= esc;
                nodos[5].Z -= esc;
                nodos[6].Z -= esc;
            }
            ptbox.Refresh();

        }

        private void TrasladarX(bool der_izq)
        {
            if (der_izq)
            {
                for (int i = 0; i < nodos.Length; i++)
                    nodos[i].X += tr;
            }
            else
            {
                for (int i = 0; i < nodos.Length; i++)
                    nodos[i].X -= tr;
            }
            ptbox.Refresh();

        }

        private void TrasladarY(bool der_izq)
        {
            if (der_izq)
            {
                for (int i = 0; i < nodos.Length; i++)
                    nodos[i].Y -= tr;
            }
            else
            {
                for (int i = 0; i < nodos.Length; i++)
                    nodos[i].Y += tr;
            }
            ptbox.Refresh();

        }

        private void ptbox_MouseDown(object sender, MouseEventArgs e)
        {
            posm = e.Location;
            mover = true;
        }

        private void ptbox_MouseMove(object sender, MouseEventArgs e)
        {
            //Mueve
            if (mover)
            {
                angulox = e.Location.X - posm.X;
                anguloy = e.Location.Y - posm.Y;
                if (angulox > 0)
                {
                    angulox = 1;
                }
                else if (angulox < 0)
                    angulox = -1;
                if (anguloy > 0)
                    anguloy = -1;
                else if (anguloy < 0)
                    anguloy = 1;

                nodos = Rotar(nodos, angulox, anguloy);
                ptbox.Refresh();
            }


        }

        private void ptbox_MouseUp(object sender, MouseEventArgs e)
        {
            mover = false;
        }

        

        private Point3DF[] Rotar(Point3DF[] pointsr,double angilox,double anguliy)
        {
            Point3DF aux =new Point3DF();
            double gradox = (angilox * Math.PI) / 180;
            double gradosy = (anguliy * Math.PI) / 180;

            for (int i = 0; i < nodos.Length; i++)
            {
                //Rotacion y
                aux.X = Convert.ToSingle(pointsr[i].X * Math.Cos(gradox) - pointsr[i].Z * Math.Sin(gradox));
                aux.Y = pointsr[i].Y;
                aux.Z = Convert.ToSingle(pointsr[i].Z * Math.Cos(gradox) + pointsr[i].X * Math.Sin(gradox));

                //Rotación x
                pointsr[i].X = aux.X;
                pointsr[i].Y = Convert.ToSingle(aux.Y * Math.Cos(gradosy) - aux.Z * Math.Sin(gradosy));
                pointsr[i].Z = Convert.ToSingle(aux.Z * Math.Cos(gradosy) + aux.Y * Math.Sin(gradosy));

            }
           return pointsr;


        }


    }
}