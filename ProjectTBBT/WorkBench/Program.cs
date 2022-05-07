using System;
using System.Text.RegularExpressions;

namespace WorkBench
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var act = new ActionBattle();
                Console.WriteLine("Digite um limite de rodadas: ");
                var roundLimit = int.Parse(Console.ReadLine());
                Console.Clear();

                Score score = new Score();

                do
                {
                    act.Jogar(score);
                    if ((score.Round +1) == roundLimit)
                    {
                        Console.WriteLine("Última rodada!");
                    }

                } while ((score.Round) < roundLimit);

                act.DeclararResultado(score);

            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Insira um número válido.");
            }
            catch (Exception)
            {

                throw;
            }
        }      
    }
}