using NUnit.Framework;
using System.Linq;
using PierreFeuilleCiseaux;
using Assert = NUnit.Framework.Assert;

namespace PierreFeuilleCiseaux
{
    [TestFixture]
    public class TestsPierreFeuilleCiseaux
    {
        [Test]
        public void SimulerChoixAleatoire_DoitRetournerChoixValide()
        {
            Choix choix = PierreFeuilleCiseaux.SimulerChoixAleatoire();
            Assert.That(choix, Is.EqualTo(Choix.Pierre).Or.EqualTo(Choix.Feuille).Or.EqualTo(Choix.Ciseaux));
        }

        [TestCase(Choix.Pierre, Choix.Pierre, Vainqueur.Egalite)]
        [TestCase(Choix.Pierre, Choix.Feuille, Vainqueur.Joueur2)]
        [TestCase(Choix.Pierre, Choix.Ciseaux, Vainqueur.Joueur1)]
        [TestCase(Choix.Feuille, Choix.Feuille, Vainqueur.Egalite)]
        [TestCase(Choix.Feuille, Choix.Ciseaux, Vainqueur.Joueur2)]
        [TestCase(Choix.Feuille, Choix.Pierre, Vainqueur.Joueur1)]
        [TestCase(Choix.Ciseaux, Choix.Ciseaux, Vainqueur.Egalite)]
        [TestCase(Choix.Ciseaux, Choix.Pierre, Vainqueur.Joueur2)]
        [TestCase(Choix.Ciseaux, Choix.Feuille, Vainqueur.Joueur1)]
        public void DeterminerVainqueur_DoitRetournerResultatCorrect(Choix choix1, Choix choix2, Vainqueur vainqueurAttendu)
        {
            Vainqueur vainqueur = PierreFeuilleCiseaux.DeterminerVainqueur(choix1, choix2);
            Assert.That(vainqueur, Is.EqualTo(vainqueurAttendu));
        }

        [Test]
        public void JouerPartie_DoitRetournerHistoriqueEtVainqueurValides()
        {
            List<ResultatManche> historique = PierreFeuilleCiseaux.JouerPartie();
            int victoiresJoueur1 = historique.Count(r => r.Vainqueur == Vainqueur.Joueur1);
            int victoiresJoueur2 = historique.Count(r => r.Vainqueur == Vainqueur.Joueur2);

            Assert.That(historique.Count, Is.GreaterThanOrEqualTo(2));
            Assert.That(victoiresJoueur1, Is.GreaterThanOrEqualTo(2).Or.LessThanOrEqualTo(1));
            Assert.That(victoiresJoueur2, Is.GreaterThanOrEqualTo(2).Or.LessThanOrEqualTo(1));
        }
    }
}