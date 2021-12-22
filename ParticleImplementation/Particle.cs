using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ParticleImplementation
{
    public class Particle
    {
        public int Radius; // радуис частицы
        public float X; // X координата положения частицы в пространстве
        public float Y; // Y координата положения частицы в пространстве
        public float SpeedX; // направление движения
        public float SpeedY; // скорость перемещения
        public float Life; // запас здоровья частицы
        public static Random random = new Random();
        public virtual void Draw(Graphics g)
        {
            var color = Color.FromArgb(random.Next(255), random.Next(255), random.Next(255));
            var b = new SolidBrush(color); // кисть для рисования 
            g.FillEllipse(b, X - Radius, Y - Radius, Radius * 2, Radius * 2); // нарисовали залитый кружок радиусом Radius с центром в X, Y
            b.Dispose();
        }
    }
    public class ParticleColorful : Particle // класс для цветных частиц
    {
        public Color FromColor; // нач цвет
        public Color ToColor; // конечный цвет
        public static Color MixColor(Color color1, Color color2, float k)
        {
            return Color.FromArgb(
                (int)(color2.A * k + color1.A * (1 - k)),
                (int)(color2.R * k + color1.R * (1 - k)),
                (int)(color2.G * k + color1.G * (1 - k)),
                (int)(color2.B * k + color1.B * (1 - k)));
        }
        public override void Draw(Graphics g)
        {
            float k = Math.Min(1f, Life / 100);            
            var color = MixColor(ToColor, FromColor, k);
            var b = new SolidBrush(color);
            g.FillEllipse(b, X - Radius, Y - Radius, Radius * 2, Radius * 2);
            b.Dispose();
        }
    }
}
