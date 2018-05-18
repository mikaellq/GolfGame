using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string angletxt, velocitytxt;
            double angle, velocity;

            do
            {
                int test = 0;
                GolfRound round = new GolfRound();

                do
                {
                    do
                    {
                        Console.Write("Angle: ");
                        angletxt = Console.ReadLine();
                    } while (!Double.TryParse(angletxt, out angle));

                    do
                    {
                        Console.Write("Velocity: ");
                        velocitytxt = Console.ReadLine();
                    } while (!Double.TryParse(velocitytxt, out velocity));

                    test = round.Shoot(angle, velocity);
                    if (test == Const.FAIL)
                    {
                        try
                        {
                            throw new System.InvalidOperationException("You got too far away from the hole!");
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine("Ending the game!");
                            //                        System.Console.WriteLine(ex);
                        }
                    }
                } while (test == Const.INGAME);
                Console.WriteLine("Press Enter to continue, any other key to exit:");
            } while (Console.ReadKey().KeyChar == '\r');
        }
    }
}
