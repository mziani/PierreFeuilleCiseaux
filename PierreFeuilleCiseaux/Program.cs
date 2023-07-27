using System;

namespace PierreFeuilleCiseaux;

class Program
{
    static void Main(string[] args)
    {
        PierreFeuilleCiseaux jeu = new PierreFeuilleCiseaux();
        var historique = jeu.JouerPartie();

        int victoiresJoueur1 = historique.FindAll(r => r.Vainqueur == Vainqueur.Joueur1).Count;
        int victoiresJoueur2 = historique.FindAll(r => r.Vainqueur == Vainqueur.Joueur2).Count;

        Console.WriteLine("Historique des manches :");
        foreach (var manche in historique)
        {
            Console.WriteLine($"Joueur 1 : {manche.ChoixJoueur1}, Joueur 2 : {manche.ChoixJoueur2}, Vainqueur : {manche.Vainqueur}");
        }

        if (victoiresJoueur1 > victoiresJoueur2)
        {
            Console.WriteLine("Le joueur 1 remporte la partie !");
        }
        else
        {
            Console.WriteLine("Le joueur 2 remporte la partie !");
        }
    }
}