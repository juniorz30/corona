using System;
using System.Collections.Generic;
using System.Text;

namespace overerving
{// we gebruiken static onmdat we het rechtstreeks via klassenaam gebruiken dus we maken geen object
    public static class VaccinatieCentrum// public static class omdat we geen instantie van deze klasse nodig hebben, we willen gewoon een centrale plek om de oplossing op te slaan
    {
        // Hier bewaren we de juiste oplossing
        public static int BewaardeOplossing { get; private set; } = -1;// -1 betekent dat er nog geen oplossing is opgeslagen

        // Methode om de juiste killcode op te slaan
        public static void BewaarVaccin(int oplossing)
        {
            BewaardeOplossing = oplossing;
        }

        // Methode die een nieuw vaccin teruggeeft met de juiste oplossing
        public static Vaccin GeefVaccin()
        {
            if (BewaardeOplossing == -1)// Als er nog geen oplossing is opgeslagen, kunnen we geen vaccin teruggeven
                return null;

            Vaccin v = new Vaccin("CentrumVaccin");// We geven het vaccin een naam, maar de naam is niet belangrijk voor de oplossing
            v.Oplossing = BewaardeOplossing;
            return v;
        }
    }
}
