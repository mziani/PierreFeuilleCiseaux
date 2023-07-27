using PierreFeuilleCiseaux;
using System;
using System.Collections.Generic;

namespace PierreFeuilleCiseaux
{
    public class PierreFeuilleCiseaux
    {
        private static Random random = new Random();

        public static Choix SimulerChoixAleatoire()
        {
            Array valeurs = Enum.GetValues(typeof(Choix));
            return (Choix)valeurs.GetValue(random.Next(valeurs.Length));
        }

        public static Vainqueur DeterminerVainqueur(Choix choix1, Choix choix2)
        {
            if (choix1 == choix2)
                return Vainqueur.Egalite;

            if ((choix1 == Choix.Pierre && choix2 == Choix.Ciseaux) ||
                (choix1 == Choix.Feuille && choix2 == Choix.Pierre) ||
                (choix1 == Choix.Ciseaux && choix2 == Choix.Feuille))
            {
                return Vainqueur.Joueur1;
            }

            return Vainqueur.Joueur2;
        }

        public static List<ResultatManche> JouerPartie()
        {
            List<ResultatManche> historique = new List<ResultatManche>();
            int victoiresJoueur1 = 0;
            int victoiresJoueur2 = 0;

            while (victoiresJoueur1 < 2 && victoiresJoueur2 < 2)
            {
                Choix choixJoueur1 = SimulerChoixAleatoire();
                Choix choixJoueur2 = SimulerChoixAleatoire();
                Vainqueur vainqueur = DeterminerVainqueur(choixJoueur1, choixJoueur2);

                if (vainqueur == Vainqueur.Joueur1)
                    victoiresJoueur1++;
                else if (vainqueur == Vainqueur.Joueur2)
                    victoiresJoueur2++;

                historique.Add(new ResultatManche
                {
                    ChoixJoueur1 = choixJoueur1,
                    ChoixJoueur2 = choixJoueur2,
                    Vainqueur = vainqueur
                });
            }

            return historique;
        }
    }
}