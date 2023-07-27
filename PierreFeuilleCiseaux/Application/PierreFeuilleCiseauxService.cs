using System.Collections.Generic;

namespace PierreFeuilleCiseaux.Application
{
    public class PierreFeuilleCiseauxService : IPierreFeuilleCiseauxService
    {
        public List<ResultatManche> JouerPartie()
        {
            return PierreFeuilleCiseaux.JouerPartie();
        }
    }
}