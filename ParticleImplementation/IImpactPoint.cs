using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleImplementation
{
    public abstract class IImpactPoint
    {
        public float X; // ну точка же, вот и две координаты
        public float Y;
        public Color Color = Color.Red; // начальный цвет частицы

        // абстрактный метод с помощью которого будем изменять состояние частиц
        // например притягивать
        public abstract void ImpactParticle(Particle particle);

        // базовый класс для отрисовки точечки
        public virtual void Render(Graphics g)
        {
            g.FillEllipse(
                    new SolidBrush(Color.Red),
                    X - 5,
                    Y - 5,
                    10,
                    10
                );
        }
    }
    public class CountPoint : IImpactPoint
    {
        public int Radius = 100; // сила притяжения
        public int count = 0;
        // а сюда по сути скопировали с минимальными правками то что было в UpdateState
        public override void ImpactParticle(Particle particle)
        {
            float gX = X - particle.X;
            float gY = Y - particle.Y;

            double r = Math.Sqrt(gX * gX + gY * gY); // считаем расстояние от центра точки до центра частицы

            if (r + particle.Radius < Radius / 2) // если частица оказалось внутри окружности
            {
                var p = (particle as ParticleColorful);
                count++;                
                p.Life = 0;
            }
        }
        public override void Render(Graphics g)
        {
            // буду рисовать окружность с диаметром равным Power
            g.DrawEllipse(
                 new Pen(Color.Red),
                 X - Radius / 2,
                 Y - Radius / 2,
                 Radius,
                 Radius);

            var stringFormat = new StringFormat(); // создаем экземпляр класса
            stringFormat.Alignment = StringAlignment.Center; // выравнивание по горизонтали
            stringFormat.LineAlignment = StringAlignment.Center; // выравнивание по вертикали

            g.DrawString(
                 $"{count}", // надпись, можно перенос строки вставлять (если вы Катя, то может не работать и надо использовать \r\n)
                 new Font("Verdana", 10), // шрифт и его размер
                 new SolidBrush(Color.White), // цвет шрифта
                 X, // расположение в пространстве
                 Y,
                 stringFormat);
        }
    }

    public class RadarPoint : IImpactPoint
    {
        public int Radius = 100; // сила отторжения
        List<Particle> radarParticles = new List<Particle>(); // место хранения частиц, которые попали во внутрь
        // а сюда по сути скопировали с минимальными правками то что было в UpdateState
        public override void ImpactParticle(Particle particle)
        {
            float gX = X - particle.X;
            float gY = Y - particle.Y;

            double r = Math.Sqrt(gX * gX + gY * gY); // считаем расстояние от центра точки до центра частицы
            var p = (particle as ParticleColorful);
            if (r + particle.Radius < Radius / 2) // если частица оказалось внутри окружности
            {
                if(Color == Color.Red)
                {
                    p.FromColor = Color.Green;
                    p.ToColor = Color.Green;
                }
                radarParticles.Add(p);
            }
            if (r + particle.Radius > Radius / 2) // если частица оказалось вне окружности
            {
                if (Color == Color.Red)
                {
                    p.FromColor = Color.Red;
                    p.ToColor = Color.Black;
                }
                radarParticles.Remove(p);
            }
        }
        public override void Render(Graphics g)
        {
            // окружность с диаметром равным Radius
            g.DrawEllipse(
                 new Pen(Color.Green),
                 X - Radius / 2,
                 Y - Radius / 2,
                 Radius,
                 Radius);

            var stringFormat = new StringFormat(); // экземпляр класса
            stringFormat.Alignment = StringAlignment.Center; // выравнивание по горизонтали
            stringFormat.LineAlignment = StringAlignment.Center; // выравнивание по вертикали

            g.DrawString(
                 $"{radarParticles.Count}",
                 new Font("Verdana", 14),
                 new SolidBrush(Color.Green),
                 X,
                 Y,
                 stringFormat);
        }
    }
}
