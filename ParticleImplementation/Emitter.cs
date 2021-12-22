using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ParticleImplementation
{
    public class Emitter
    {
        public List<Particle> particles = new List<Particle>();
        public int MousePositionX; // позиция мыши по Х
        public int MousePositionY; // позиция мыши по У
        public float GravitationX = 0; // сила гравитации по Х
        public float GravitationY = 1; // сила гравитации по У
        public List<IImpactPoint> impactPoints = new List<IImpactPoint>(); // лист точек притяжения
        public int X; // координата X центра эмиттера
        public int Y; // соответствующая координата Y 
        public int Direction = 0; // вектор направления в градусах куда сыпет эмиттер
        public int Spreading = 360; // разброс частиц относительно Direction
        public int SpeedMin = 1; // начальная минимальная скорость движения частицы
        public int SpeedMax = 10; // начальная максимальная скорость движения частицы
        public int RadiusMin = 2; // минимальный радиус частицы
        public int RadiusMax = 10; // максимальный радиус частицы
        public int LifeMin = 20; // минимальное время жизни частицы
        public int LifeMax = 100; // максимальное время жизни частицы
        public int ParticlesPerTick = 1; // создание частиц за тик 
        public int ParticlesCount; // кол-во частиц
        public Color ColorFrom = Color.OrangeRed; // начальный цвет частицы
        public Color ColorTo = Color.FromArgb(0, Color.Yellow); // конечный цвет частиц
        public void UpdateState()
        {
            int particlesToCreate = ParticlesPerTick; // фиксируем счетчик сколько частиц нам создавать за тик
            foreach (var particle in particles)
            {
                if (particle.Life <= 0)
                {
                    if (particlesToCreate > 0)
                    {
                        particlesToCreate -= 1; // у нас как сброс частицы равносилен созданию частицы поэтому уменьшаем счётчик созданных частиц на 1
                        ResetParticle(particle);
                    }
                }
                else
                {                   
                    particle.X += particle.SpeedX;
                    particle.Y += particle.SpeedY;
                    particle.Life -= 1;
                    foreach (var point in impactPoints)
                    {
                        point.ImpactParticle(particle);
                    }
                    particle.SpeedX += GravitationX;
                    particle.SpeedY += GravitationY;
                }
            }
            while (particlesToCreate >= 1)
            {
                particlesToCreate -= 1;
                var particle = CreateParticle();
                ResetParticle(particle);
                particles.Add(particle);
            }
        }
        public void Render(Graphics g)
        {
            foreach (var particle in particles)
            {
                particle.Draw(g);
            }
            foreach (var point in impactPoints)
            {
                point.Render(g);
            }
        }
        public virtual Particle CreateParticle()
        {
            var particle = new ParticleColorful();
            particle.FromColor = ColorFrom;
            particle.ToColor = ColorTo;
            return particle;
        }
        public virtual void ResetParticle(Particle particle)
        {
            particle.Life = 20 + Particle.random.Next(LifeMin, LifeMax);
            particle.X = X;
            particle.Y = Y;
            var direction = Direction + (double)Particle.random.Next(Spreading) - Spreading / 2;
            var speed = SpeedMin + Particle.random.Next(SpeedMin, SpeedMax);
            particle.SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
            particle.SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);
            particle.Radius = Particle.random.Next(RadiusMin, RadiusMax);
        }
    }
}