using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParticleImplementation
{
    public partial class Form1 : Form
    {
        public static Random random = new Random();
        List<Emitter> emitters = new List<Emitter>();
        Emitter emitter1;
        CountPoint point1; // добавил поле под первую точку
        RadarPoint point2;
        public Form1()
        {
            InitializeComponent();
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);
            this.emitter1 = new Emitter // создаю эмиттер и привязываю его к полю emitter
            {
                Direction = 270,
                Spreading = 200,
                SpeedMin = 1,
                SpeedMax = 10,
                ColorFrom = Color.OrangeRed,
                ColorTo = Color.FromArgb(0, Color.Yellow),
                ParticlesPerTick = 150,
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / picDisplay.Height,
            };

            emitters.Add(this.emitter1);

            point1 = new CountPoint
            {
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 2,
            };

            point2 = new RadarPoint
            {
                X = picDisplay.Width / 4 * 3,
                Y = picDisplay.Height / 4 * 3,
            };
            // привязываем поля к эмиттеру

            emitter1.impactPoints.Add(point1);
            emitter1.impactPoints.Add(point2);
        }
        // ну и обработка тика таймера, тут просто декомпозицию выполнили
        private void timer1_Tick(object sender, EventArgs e)
        {
            emitter1.UpdateState();
            using (var g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.Black);
                emitter1.Render(g);
            }
            lb_Count.Text = $"{emitter1.particles.Where(particle => particle.Life > 0).Count()}";
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
        private void b_NewCount_Click(object sender, EventArgs e)
        {
            emitter1.impactPoints.Add(new CountPoint { X = picDisplay.Width / 2 + random.Next(-250, 250), Y = picDisplay.Height / 2 + random.Next(-250, 250) });
        }
        private void tb_Spread_Scroll(object sender, EventArgs e)
        {
            emitter1.SpeedMax = tb_Spread.Value;
        }
        private void tb_ParticlesPerTick_Scroll(object sender, EventArgs e)
        {
            emitter1.ParticlesPerTick = tb_ParticlesPerTick.Value;
        }
    }
}
