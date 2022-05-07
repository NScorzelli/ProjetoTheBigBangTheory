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
                Console.WriteLine("Digite um limite de rodadas: ");
                var roundLimit = int.Parse(Console.ReadLine());
                Console.Clear();

                Score score = new Score();

                do
                {
                    Jogar(score);
                    if ((score.Round +1) == roundLimit)
                    {
                        Console.WriteLine("Última rodada!");
                    }

                } while ((score.Round) < roundLimit);

                DeclararResultado(score);

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
        public static Score Jogar(Score score)
        {
            Console.WriteLine("Vamos jogar!\nDigite sua escolha: ");
            var playerPicked = Console.ReadLine();
            Console.Clear();

            Regex[] options = new Regex[5];
            {
                options[0] = new Regex("[Pp]ed((r)?a)?", RegexOptions.IgnoreCase);
                options[1] = new Regex("[Pp]ap(e[ul])?", RegexOptions.IgnoreCase);
                options[2] = new Regex("[Tt][ei]so((u)?ra)?", RegexOptions.IgnoreCase);
                options[3] = new Regex("([Ee])?[Ss]p[ou]((qu)?([ck])?([ck])?(e)?)?", RegexOptions.IgnoreCase);
                options[4] = new Regex("[Ll]a(r)?g(r)?a((r)?t[ou])?", RegexOptions.IgnoreCase);
            }

            int playerChoose = GetOpcoes(options, playerPicked);

            SheldonCorrection(playerPicked, playerChoose);

            var sheldonPick = new Random();
            var sheldonChoose = sheldonPick.Next(0, 4);

            if (sheldonChoose == 0)
            {
                Console.WriteLine($"Sheldon escolheu Pedra");
            }
            if (sheldonChoose == 1)
            {
                Console.WriteLine($"Sheldon escolheu Papel");
            }
            if (sheldonChoose == 2)
            {
                Console.WriteLine($"Sheldon escolheu Tesoura");
            }
            if (sheldonChoose == 3)
            {
                Console.WriteLine($"Sheldon escolheu Spock");
            }
            if (sheldonChoose == 4)
            {
                Console.WriteLine($"Sheldon escolheu Lagarto");
            }

            return Lutar(sheldonChoose, playerChoose, score);
        }
        public static void SheldonCorrection(string playerPicked, int playerChoose)
        {
            string playerPickLower = playerPicked.ToLower();

            if (playerPickLower != "spock" && playerChoose == 3)
            {
                Console.WriteLine($"- Sheldon te corrige: O que a falta de um doutorado não faz? É Spock, não {playerPicked}");
            }

            if (playerPickLower != "lagarto" && playerChoose == 4)
            {
                Console.WriteLine($"- Sheldon te corrige: Quase não consegui entender o que você falou... É Lagarto, não {playerPicked}");
            }
            if (playerPickLower != "pedra" && playerChoose == 0)
            {
                Console.WriteLine($"- Sheldon te corrige: Que? É Pedra, não {playerPicked}");
            }
            if (playerPickLower != "tesoura" && playerChoose == 2)
            {
                Console.WriteLine($"- Sheldon te corrige: Faça um favor, escreva direito! É Tesoura, não {playerPicked}");
            }
            if (playerPickLower != "papel" && playerChoose == 1)
            {
                Console.WriteLine($"- Sheldon te corrige: Você deve estar aprendendo Português agora né? É Papel, não {playerPicked}");
            }
        }
        public static Score ReturnLuta(Score score)
        {
            if (score.MatchPoint == "Sheldon")
            {
                score.SheldonScore++;
                Console.WriteLine($"{score.SheldonWins}\nSheldon: {score.SheldonScore} x {score.PlayerScore} Você");
                score.Round++;
                return score;
            }
            else if (score.MatchPoint == "Empate")
            {
                Console.WriteLine(score.Draw);
                Console.WriteLine($"Sheldon: {score.SheldonScore} x {score.PlayerScore} Você");
                score.Round++;
                return score;
            }
            else
            {
                score.PlayerScore++;
                Console.WriteLine($"{score.PlayerWins}\nSheldon: {score.SheldonScore} x { score.PlayerScore} Você");
                score.Round++;
                return score;
            }
        }
        public static int GetOpcoes(Regex[] options, string playerPicked)
        {
            for (int i = 0; i < options.Length; i++)
            {
                if (CompararSelecoes(options, playerPicked) >= 0 && CompararSelecoes(options, playerPicked) < 5)
                {
                    return CompararSelecoes(options, playerPicked);
                }
            }
            throw new ArgumentException("Você é estúpido ou se faz? Selecione uma opção válida.");
        }
        public static int CompararSelecoes(Regex[] opcoes, string playerPicked)
        {
            for (int i = 0; i < opcoes.Length; i++)
            {
                if (opcoes[i].IsMatch(playerPicked))
                {
                    return i;
                }
            }

            return -1;
        }
        public static Score Lutar(int sheldonChoose, int playerChoose, Score item)
        {
            var score = item;

            // Opção 0 = Pedra
            // Opção 1 = Papel
            // Opção 2 = Tesoura
            // Opção 3 = Spock
            // Opção 4 = Lagarto

            if (sheldonChoose == 2 && playerChoose == 1)
            {
                score.MatchPoint = "Sheldon";
                Console.WriteLine("A tesoura corta o papel.");
                return ReturnLuta(score);
            }
            if (sheldonChoose == 1 && playerChoose == 0)
            {
                score.MatchPoint = "Sheldon";
                Console.WriteLine("O papel embrulha a pedra.");
                return ReturnLuta(score);
            }
            if (sheldonChoose == 0 && playerChoose == 4)
            {
                score.MatchPoint = "Sheldon";
                Console.WriteLine("A pedra esmaga o lagarto.");
                return ReturnLuta(score);
            }
            if (sheldonChoose == 4 && playerChoose == 3)
            {
                score.MatchPoint = "Sheldon";
                Console.WriteLine("O lagarto envenena Spock.");
                return ReturnLuta(score);
            }
            if (sheldonChoose == 3 && playerChoose == 2)
            {
                score.MatchPoint = "Sheldon";
                Console.WriteLine("Spock destrói a tesoura.");
                return ReturnLuta(score);
            }
            if (sheldonChoose == 2 && playerChoose == 4)
            {
                score.MatchPoint = "Sheldon";
                Console.WriteLine("A tesoura decapita o lagarto.");
                return ReturnLuta(score);
            }
            if (sheldonChoose == 4 && playerChoose == 1)
            {
                score.MatchPoint = "Sheldon";
                Console.WriteLine("O lagarto come o papel.");
                return ReturnLuta(score);
            }
            if (sheldonChoose == 1 && playerChoose == 3)
            {
                score.MatchPoint = "Sheldon";
                Console.WriteLine("O papel contesta Spock.");
                return ReturnLuta(score);
            }
            if (sheldonChoose == 3 && playerChoose == 0)
            {
                score.MatchPoint = "Sheldon";
                Console.WriteLine("Spock vaporiza a pedra.");
                return ReturnLuta(score);
            }
            if (sheldonChoose == 0 && playerChoose == 2)
            {
                score.MatchPoint = "Sheldon";
                Console.WriteLine("A pedra quebra a tesoura.");
                return ReturnLuta(score);
            }
            if (sheldonChoose == playerChoose && playerChoose == sheldonChoose)
            {
                score.MatchPoint = "Empate";
                return ReturnLuta(score);
            }
            if (playerChoose == 2 && sheldonChoose == 1)
            {
                score.MatchPoint = "Player";
                Console.WriteLine("A tesoura corta o papel.");
                return ReturnLuta(score);
            }
            if (playerChoose == 1 && sheldonChoose == 0)
            {
                score.MatchPoint = "Player";
                Console.WriteLine("O papel embrulha a pedra.");
                return ReturnLuta(score);
            }
            if (playerChoose == 0 && sheldonChoose == 4)
            {
                score.MatchPoint = "Player";
                Console.WriteLine("A pedra esmaga o lagarto.");
                return ReturnLuta(score);
            }
            if (playerChoose == 4 && sheldonChoose == 3)
            {
                score.MatchPoint = "Player";
                Console.WriteLine("O lagarto envenena Spock.");
                return ReturnLuta(score);

            }
            if (playerChoose == 3 && sheldonChoose == 2)
            {
                score.MatchPoint = "Player";
                Console.WriteLine("Spock destrói a tesoura.");
                return ReturnLuta(score);
            }
            if (playerChoose == 2 && sheldonChoose == 4)
            {
                score.MatchPoint = "Player";
                Console.WriteLine("A tesoura decapita o lagarto.");
                return ReturnLuta(score);
            }
            if (playerChoose == 4 && sheldonChoose == 1)
            {
                score.MatchPoint = "Player";
                Console.WriteLine("O lagarto come o papel.");
                return ReturnLuta(score);
            }
            if (playerChoose == 1 && sheldonChoose == 3)
            {
                score.MatchPoint = "Player";
                Console.WriteLine("O papel contesta Spock.");
                return ReturnLuta(score);
            }
            if (playerChoose == 3 && sheldonChoose == 0)
            {
                score.MatchPoint = "Player";
                Console.WriteLine("Spock vaporiza a pedra.");
                return ReturnLuta(score);
            }
            else
            {
                score.MatchPoint = "Player";
                Console.WriteLine("A pedra quebra a tesoura.");
                return ReturnLuta(score);
            }
        }
        public static void DeclararResultado(Score score)
        {
            if (score.SheldonScore > score.PlayerScore)
            {
                Console.WriteLine("Humpf... Deu a lógica, não é mesmo?");
            }
            else if (score.SheldonScore == score.PlayerScore)
            {
                Console.WriteLine("Melhor empatarmos, do que você se frustrar com a derrota.");
            }
            else
            {
                Console.WriteLine("Que jogo ruim! Você não cansa de trapacear? Quero revanche!");
            }
        }
    }
}