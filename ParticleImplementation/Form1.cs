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
        // собственно список, пока пустой
        List<Particle> particles = new List<Particle>();
        // добавляем переменные для хранения положения мыши
        private int MousePositionX = 0;
        private int MousePositionY = 0;
        public Form1()
        {
            InitializeComponent();
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);
        }
        // добавил функцию обновления состояния системы
        private void UpdateState()
        {
            foreach (var particle in particles)
            {
                particle.Life -= 1; // уменьшаю здоровье
                                    // если здоровье кончилось
                if (particle.Life < 0)
                {                   
                    // восстанавливаю здоровье
                    particle.Life = 20 + Particle.random.Next(100);
                    // новое начальное расположение частицы — это то, куда указывает курсор
                    particle.X = MousePositionX;
                    particle.Y = MousePositionY;
                    particle.Direction = Particle.random.Next(360);
                    particle.Speed = 1 + Particle.random.Next(20);
                    particle.Radius = 2 + Particle.random.Next(10);
                }
                else
                {
                    var directionInRadians = particle.Direction / 180 * Math.PI;
                    particle.X += (float)(particle.Speed * Math.Cos(directionInRadians));
                    particle.Y -= (float)(particle.Speed * Math.Sin(directionInRadians));
                }
            }

            // генерирую 500 частиц
            for (var i = 0; i < 10; ++i)
            {
                if (particles.Count < 500) // пока частиц меньше 500 генерируем новые
                {
                    var particle = new Particle();
                    // новое начальное расположение частицы — это то, куда указывает курсор
                    particle.X = MousePositionX;
                    particle.Y = MousePositionY;
                    // добавляю список
                    particles.Add(particle);
                    // а у тут уже наш новый класс используем
                    /*var particle = new ParticleColorful();
                    // ну и цвета меняем
                    particle.FromColor = Color.Yellow;
                    particle.ToColor = Color.FromArgb(0, Color.Magenta);
                    particle.X = MousePositionX;
                    particle.Y = MousePositionY;
                    particles.Add(particle);*/
                }
                else
                {
                    break; // а если частиц уже 500 штук, то ничего не генерирую
                }
            }
        }

        // функция рендеринга
        private void Render(Graphics g)
        {
            // утащили сюда отрисовку частиц
            foreach (var particle in particles)
            {
                particle.Draw(g);
            }
        }

        // ну и обработка тика таймера, тут просто декомпозицию выполнили
        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateState(); // каждый тик обновляем систему
            using (var g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.Black); // добавил очистку
                Render(g); // рендерим систему
            }
            picDisplay.Invalidate();
        }

        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            // в обработчике заносим положение мыши в переменные для хранения положения мыши
            MousePositionX = e.X;
            MousePositionY = e.Y;
        }
    }
}
