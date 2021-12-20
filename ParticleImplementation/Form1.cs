using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ParticleImplementation.Emitter;

namespace ParticleImplementation
{
    public partial class Form1 : Form
    {
        List<Emitter> emitters = new List<Emitter>();
        List<IImpactPoint> points = new List<IImpactPoint>();
        Emitter emitter;
        GravityPoint point1; // добавил поле под первую точку
        RadarPoint point2;
        public Form1()
        {
            InitializeComponent();
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);
            picDisplay.MouseWheel += picDisplay_MouseWheel;
            this.emitter = new Emitter // создаю эмиттер и привязываю его к полю emitter
            {
                Direction = 0,
                Spreading = 150,
                SpeedMin = 10,
                SpeedMax = 10,
                ColorFrom = Color.Red,
                ColorTo = Color.FromArgb(0, Color.Black),
                ParticlesPerTick = 5,
                X = picDisplay.Width / picDisplay.Width,
                Y = picDisplay.Height / picDisplay.Height,
            };

            emitters.Add(this.emitter); // все равно добавляю в список emitters, чтобы он рендерился и обновлялся 

            point1 = new GravityPoint
            {
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 2,
            };

            point2 = new RadarPoint
            {
                X = picDisplay.Width / 3,
                Y = picDisplay.Height / 3,
            };
            // привязываем поля к эмиттеру

            emitter.impactPoints.Add(point1);
            emitter.impactPoints.Add(point2);
            /*emitter = new TopEmitter
            {
                Width = picDisplay.Width,
                GravitationY = 0.25f
            };*/
        }

        // ну и обработка тика таймера, тут просто декомпозицию выполнили
        private void timer1_Tick(object sender, EventArgs e)
        {
            emitter.UpdateState();
            using (var g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.Black);
                emitter.Render(g);
            }
            /*foreach (var point in emitter.impactPoints)
            {
                if (point.count > 249)
                {
                    emitter.impactPoints.Remove(point);
                }
            }*/


            picDisplay.Invalidate();
        }

        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            // это не трогаем
            foreach (var emitter in emitters)
            {
                emitter.MousePositionX = e.X;
                emitter.MousePositionY = e.Y;
            }

            // а тут передаем положение мыши, в положение гравитона
            point2.X = e.X;
            point2.Y = e.Y;
        }

        private void picDisplay_MouseClick(object sender, MouseEventArgs e)
        {
            emitter.impactPoints.Add(new GravityPoint { 
            X = e.X,
            Y = e.Y,
            });
        }
        private void picDisplay_MouseWheel(object sender, MouseEventArgs e)
        {
            // сюда реакцию на колесико мышки пихать
        }
    }
}
