using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeu_Alumettes
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            Console.WriteLine("=============Welcome at the matches game=============\n\nIf you want to learn how to play the game, it's all written in the README file.\n\n");

            ///Initialisation du nombre d'alumettes.
            Console.Write("Player, please choose the start number of matches : ");
            int nbAlumettes;
            string input = Console.ReadLine();
            while(!int.TryParse(input, out nbAlumettes) || nbAlumettes <= 0)
            {
                Console.WriteLine("Wrong choice please choose a whole number above 0\n");
                Console.Write("Player, please choose the start number of matches : ");
                input = Console.ReadLine();
            }
            int nbAlumettesRestantes = nbAlumettes;

            AffichageAlumettes(nbAlumettes, nbAlumettesRestantes);

            ///Boucle de jeu principale
            while (nbAlumettesRestantes > 0)
            {
                ///Tour du joueur------------------------------------------------------------
                Console.Write("\nPlayer, choose the number of matches to withdraw : ");
                int choixJoueur;
                input = Console.ReadLine();
                while (!int.TryParse(input, out choixJoueur) || !(choixJoueur > 0 && choixJoueur < 4 && choixJoueur <= nbAlumettesRestantes))
                {
                    Console.WriteLine("Wrong choice please choose a whole number between 1 and max between 3 and the number of matches left.\n");
                    Console.Write("Player, please choose the number of matches to withdraw : ");
                    input = Console.ReadLine();
                }
                ///AffichageAlumettes choix Joueur
                nbAlumettesRestantes -= choixJoueur;
                Console.WriteLine($"\nYou withdrew {choixJoueur} match(es).");
                
                ///Test de fin de partie (perdante)
                if (nbAlumettesRestantes == 0)
                {
                    Console.WriteLine("\n\nYou lost.");
                    break;
                }

                AffichageAlumettes(nbAlumettes, nbAlumettesRestantes);

                ///Tour de l'ordinateur---------------------------------------------------
                int choixOrdinateur;

                ///Choix de l'ordinateur en fonction du nombre d'allumettes restantes
                if (nbAlumettesRestantes <= 4 && nbAlumettesRestantes > 1)
                {
                    choixOrdinateur = nbAlumettesRestantes - 1;
                }
                else if (nbAlumettesRestantes == 1)
                {
                    choixOrdinateur = 1;
                }
                else
                {
                    choixOrdinateur = random.Next(1, 3);
                }

                ///AffichageAlumettes choix ordinateur
                Console.WriteLine($"The AI withdrew {choixOrdinateur} match(es).");
                nbAlumettesRestantes -= choixOrdinateur;

                ///Test fin de partie (gagnante)
                if (nbAlumettesRestantes == 0)
                {
                    Console.WriteLine("\n\nYou won ! The IA withdrew the last match.");
                    break;
                }
                AffichageAlumettes(nbAlumettes, nbAlumettesRestantes);
            }

            Console.Read();
        }

        static void AffichageAlumettes(int nbAlumettes, int nbAlumettesRestantes)
        {
            ///AffichageAlumettes du nombre d'alumettes restantes avec des espaces pour les alumettes retirées.
            string alumettes = string.Concat(Enumerable.Repeat("|", nbAlumettesRestantes));
            string vide = string.Concat(Enumerable.Repeat(" ", nbAlumettes - nbAlumettesRestantes));
            Console.WriteLine(vide + alumettes);
        }

        
    }
}
