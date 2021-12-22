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
        CountPoint countPoint; // добавил поле под точку счетчик
        RadarPoint radarPoint; // добавил поле под точку радар
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
            countPoint = new CountPoint {X = picDisplay.Width / 2, Y = picDisplay.Height / 2,};
            radarPoint = new RadarPoint {X = picDisplay.Width, Y = picDisplay.Height,};
            emitter1.impactPoints.Add(countPoint);
            emitter1.impactPoints.Add(radarPoint);
        }
        private void timer1_Tick(object sender, EventArgs e) // ну и обработка тика таймера, тут просто декомпозицию выполнили
        {
            emitter1.UpdateState();
            using (var g = Graphics.FromImage(picDisplay.Image)){
                g.Clear(Color.Black);
                emitter1.Render(g);}
            lb_Count.Text = $"{emitter1.particles.Where(particle => particle.Life > 0).Count()}"; // счётчик кол-ва частиц на форме в данный момент
            picDisplay.Invalidate();}
        private void picDisplay_MouseMove(object sender, MouseEventArgs e){
            foreach (var emitter in emitters){
                emitter.MousePositionX = e.X;
                emitter.MousePositionY = e.Y;}
            radarPoint.X = e.X; // передаем положение мыши, в положение радара
            radarPoint.Y = e.Y;
        }
        private void b_NewCount_Click(object sender, EventArgs e) // добавление точки счетчика с помощью кнопки в рандомное место на форме
        {emitter1.impactPoints.Add(new CountPoint { X = picDisplay.Width / 2 + random.Next(-250, 250), Y = picDisplay.Height / 2 + random.Next(-250, 250) });}
        private void tb_Spread_Scroll(object sender, EventArgs e) // трекбар для разброса от скорости
        {emitter1.SpeedMax = tb_Spread.Value;}
        private void tb_ParticlesPerTick_Scroll(object sender, EventArgs e) // трекбар для кол-ва частиц за тик
        {emitter1.ParticlesPerTick = tb_ParticlesPerTick.Value;}
    }
}