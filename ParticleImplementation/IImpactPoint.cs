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
        public Color Color;
        //public Color Color = Color.OrangeRed; // начальный цвет частицы
        public abstract void ImpactParticle(Particle particle); // абстрактный метод с помощью которого будем изменять состояние частиц
        public virtual void Render(Graphics g) // базовый класс для отрисовки точечки
        {
            g.FillEllipse(
                    new SolidBrush(Color.OrangeRed),
                    X - 5,
                    Y - 5,
                    10,
                    10
                );
        }
    }
    public class CountPoint : IImpactPoint
    {
        public int Radius = 100; // радиус
        public int Count = 0; // сам счётчик
        public override void ImpactParticle(Particle particle)
        {
            float gX = X - particle.X;
            float gY = Y - particle.Y;
            double r = Math.Sqrt(gX * gX + gY * gY); // считаем расстояние от центра точки до центра частицы
            var p = (particle as ParticleColorful);
            if (r + particle.Radius < Radius / 2) // если частица оказалось внутри окружности
            {
                p.Life = 0; // а частица умерла туть(
                Count++; // счётчик прибавился туть)
            }
        }
        public override void Render(Graphics g)
        {           
            /*g.FillEllipse( // окружность с диаметром равным Radius
                 new SolidBrush(Color.Black),
                 X - Radius / 2,
                 Y - Radius / 2,
                 Radius,
                 Radius);*/
            g.DrawEllipse( // окружность с диаметром равным Radius
                 new Pen(Color.OrangeRed, 2),
                 X - Radius / 2,
                 Y - Radius / 2,
                 Radius,
                 Radius);
            var stringFormat = new StringFormat(); // создаем экземпляр класса
            stringFormat.Alignment = StringAlignment.Center; // выравнивание по горизонтали
            stringFormat.LineAlignment = StringAlignment.Center; // выравнивание по вертикали
            g.DrawString(
                 $"{Count}", // надпись, можно перенос строки вставлять (если вы Катя, то может не работать и надо использовать \r\n)
                 new Font("Verdana", 14), // шрифт и его размер
                 new SolidBrush(Color.OrangeRed), // цвет шрифта
                 X, // расположение в пространстве
                 Y,
                 stringFormat);
        }
    }
    public class RadarPoint : IImpactPoint
    {
        public int Radius = 100; // радиус
        List<Particle> radarParticles = new List<Particle>(); // место хранения частиц, которые попали во внутрь
        public override void ImpactParticle(Particle particle)
        {
            float gX = X - particle.X;
            float gY = Y - particle.Y;
            double r = Math.Sqrt(gX * gX + gY * gY); // считаем расстояние от центра точки до центра частицы
            var p = (particle as ParticleColorful);
            if (r + particle.Radius < Radius / 2) // если частица оказалось внутри окружности
            {
                radarParticles.Add(p);
                if (Color == Color.OrangeRed)
                {
                    p.FromColor = Color.MediumSpringGreen;
                    p.ToColor = Color.MediumSpringGreen;
                }
                //radarParticles.Add(p);
            }
            if (r + particle.Radius > Radius / 2) // если частица оказалось вне окружности
            {
                radarParticles.Remove(p);
                if (Color == Color.OrangeRed)
                {
                    p.FromColor = Color.OrangeRed;
                    p.ToColor = Color.Yellow; 
                }
                //radarParticles.Remove(p);
            }
        }
        public override void Render(Graphics g)
        {
            g.DrawEllipse( // окружность с диаметром равным Radius
                 new Pen(Color.MediumSpringGreen, 2),
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
                 new SolidBrush(Color.MediumSpringGreen),
                 X,
                 Y,
                 stringFormat);
        }
    }
}
