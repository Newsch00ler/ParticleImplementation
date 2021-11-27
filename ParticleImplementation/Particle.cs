using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleImplementation
{
    class Particle
    {
        public int Radius; // радуис частицы
        public float X; // X координата положения частицы в пространстве
        public float Y; // Y координата положения частицы в пространстве

        public float Direction; // направление движения
        public float Speed; // скорость перемещения
        public float Life; // запас здоровья частицы

        // добавили генератор случайных чисел
        public static Random random = new Random();

        // конструктор по умолчанию будет создавать кастомную частицу
        public Particle()
        {
            // я не трогаю координаты X, Y потому что хочу, чтобы все частицы возникали из одного места
            Direction = random.Next(360);
            Speed = 1 + random.Next(10);
            Radius = 2 + random.Next(10);
            Life = 20 + random.Next(100); // Добавили исходный запас здоровья от 20 до 120
        }
        public void Draw(Graphics g)
        {
            // создали кисть для рисования
            var b = new SolidBrush(Color.Black);

            // нарисовали залитый кружок радиусом Radius с центром в X, Y
            g.FillEllipse(b, X - Radius, Y - Radius, Radius * 2, Radius * 2);

            // удалили кисть из памяти, вообще сборщик мусора рано или поздно это сам сделает
            // но документация рекомендует делать это самому
            b.Dispose();
        }
    }
}
