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
            Console.WriteLine("Welcome at the matches game.\nIf you want to know how to play the game, it's written in the README file.\n");

            ///Initialisation du nombre d'alumettes.
            Console.WriteLine("Player, please choose the start number of matches.");
            int nbAlumettes;
            string input = Console.ReadLine();
            while(!int.TryParse(input, out nbAlumettes) || nbAlumettes <= 0)
            {
                Console.WriteLine("Wrong choice please choose a whole number above 0");
                input = Console.ReadLine();
            }
            int nbAlumettesRestantes = nbAlumettes;

            Affichage(nbAlumettes, nbAlumettesRestantes);

            ///Boucle de jeu principale
            while (nbAlumettesRestantes > 0)
            {
                ///Tour du joueur------------------------------------------------------------
                Console.Write("Player, choose the number of matches to withdraw : ");
                int choixJoueur;
                input = Console.ReadLine();
                while (!int.TryParse(input, out choixJoueur) || !(choixJoueur > 0 && choixJoueur < 4 && choixJoueur <= nbAlumettesRestantes))
                {
                    Console.WriteLine("Wrong choice please choose a whole number between 1 and max between 3 and the number of matches left.\n");
                    Console.Write("Player, choose the number of matches to withdraw : ");
                    input = Console.ReadLine();
                }
                ///Affichage choix Joueur
                nbAlumettesRestantes -= choixJoueur;
                Console.WriteLine($"You withdrew {choixJoueur} match(es).");
                Affichage(nbAlumettes, nbAlumettesRestantes);

                ///Test de fin de partie (perdante)
                if (nbAlumettesRestantes == 0)
                {
                    Console.WriteLine("You lost.");
                    break;
                }

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

                ///Affichage choix ordinateur
                Console.WriteLine($"The AI withdrew {choixOrdinateur} match(es).");
                nbAlumettesRestantes -= choixOrdinateur;
                Affichage(nbAlumettes, nbAlumettesRestantes);

                ///Test fin de partie (gagnante)
                if (nbAlumettesRestantes == 0)
                {
                    Console.WriteLine("You won ! The IA withdrew the last match.");
                    break;
                }
            }

            Console.Read();
        }

        static void Affichage(int nbAlumettes, int nbAlumettesRestantes)
        {
            ///Affichage du nombre d'alumettes restantes avec des espaces pour les alumettes retirées.
            string alumettes = string.Concat(Enumerable.Repeat("|", nbAlumettesRestantes));
            string vide = string.Concat(Enumerable.Repeat(" ", nbAlumettes - nbAlumettesRestantes));
            Console.WriteLine(vide + alumettes);
        }
    }
}
