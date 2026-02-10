using System;
using System.Collections.Generic;
using System.Text;

namespace overerving
{
    public class Vaccin
    {
            public string Naam { get; private set; }// we maken de naam private set omdat we willen dat de naam alleen bij het aanmaken van het vaccin kan worden ingesteld en niet later kan worden veranderd
        public int Oplossing { get; set; } = -1;// we maken de oplossing public set omdat we deze willen kunnen instellen wanneer een vaccin succesvol is in het raden van de killcode van een virus, dit maakt het makkelijker om te zien welke vaccins succesvol zijn geweest tijdens het spelen
        private static Random rnd = new Random();// we maken de random generator static omdat we maar één random generator nodig hebben voor alle vaccins, als we er meerdere zouden maken, zouden ze allemaal dezelfde seed hebben en dus dezelfde getallen genereren

        public Vaccin(string naam)
            {
                Naam = naam;
        }

            public int TryKillCode()
            {
                if (Oplossing != -1)// als er al een oplossing is ingesteld, geven we die terug, dit maakt het makkelijker om te zien welke vaccins succesvol zijn geweest tijdens het spelen
                return Oplossing;
                return rnd.Next(1, 101);
            }

            public void ToonInfo()
            {
                Console.WriteLine($"{Naam} heeft killcode: {Oplossing}");
            }
    }
}
