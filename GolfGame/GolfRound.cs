using System;

static class Const
{
    public const double GRAVITY = 9.82432;
    public const int INGAME = 0;
    public const int FAIL = 1;
    public const int HIT = 2;
    public const int TOOMANY = 5;
    public const double MARGIN = 0.5;
}

namespace GolfGame
{
    internal class GolfRound
    {
        int counter;
        double pos = 0, hole = 0;
        public GolfRound()
        {
            pos = 0; counter = 0;
            Random r = new Random(DateTime.Now.Millisecond);
            hole = r.Next(10, 30);
            Console.WriteLine($"Position hole: {hole}, your: {pos}");
        }

        public int Shoot(double angle, double velocity)
        {
            double rangle = (Math.PI / 180) * angle;
            double newputt = Math.Pow(velocity, 2) / Const.GRAVITY * Math.Sin(2 * rangle);
            counter++;
            if (pos > hole)
            {
                pos -= newputt;
            }
            else pos += newputt;

            Console.WriteLine($"{counter}. New position: {pos}");

            if (pos > hole*2 || pos < 0)
            {
                Console.WriteLine("EXCEPTIONALLY BADLY THROWN!");
                return Const.FAIL;
            }
            else if (counter > Const.TOOMANY)
            {
                Console.WriteLine("EXCEPTIONALLY MANY THROWN!");
                return Const.FAIL;
            }
            else if (pos < hole+Const.MARGIN && pos > hole-Const.MARGIN)
            {
                Console.WriteLine($"Congratulations! You hit the hole in {counter} tries!\n");
                return Const.HIT;
            }
            return Const.INGAME;
        }
    }
}