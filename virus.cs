using System;
using System.Collections.Generic;
using System.Text;

namespace overerving
{
    public class Virus
    {
        public string Naam { get; private set; }// we maken de naam private set omdat we willen dat de naam alleen bij het aanmaken van het virus kan worden ingesteld en niet later kan worden veranderd
        public int DoomCountdown
        {
            get => doomCountdown;// we gebruiken een property zodat we de logica kunnen toevoegen dat wanneer de countdown op 0 komt, er een bericht wordt weergegeven dat het spel voorbij is
            private set
            {
                doomCountdown = value;// we zetten de waarde van de countdown
                if (doomCountdown <= 0)
                    Console.WriteLine($"Game over {Naam}");
            }
        }

        private int doomCountdown;
        private int killcode;// we maken de killcode private omdat we niet willen dat deze van buitenaf kan worden bekeken of veranderd, alleen via de TryVaccin methode kunnen we proberen om de killcode te raden
        private static Random rnd = new Random();// we maken de random generator static omdat we maar één random generator nodig hebben voor alle virussen, als we er meerdere zouden maken, zouden ze allemaal dezelfde seed hebben en dus dezelfde getallen genereren

        public Virus()
        {
            DoomCountdown = rnd.Next(10, 21);
            killcode = rnd.Next(0, 100);
            Naam = $"{(char)rnd.Next('A', 'Z')}" +// we genereren een naam voor het virus door willekeurige letters te combineren met een getal, dit maakt het makkelijker om verschillende virussen te onderscheiden tijdens het spelen
                   $"{(char)rnd.Next('A', 'Z')}" +
                   $"{(char)rnd.Next('A', 'Z')}{rnd.Next(1, 100)}";// we genereren een naam voor het virus door willekeurige letters te combineren met een getal, dit maakt het makkelijker om verschillende virussen te onderscheiden tijdens het spelen
        }

        public bool TryVaccin(Vaccin v)
        {
            int probeer = v.TryKillCode();// we proberen de killcode te raden door de TryKillCode methode van het vaccin aan te roepen, deze methode geeft een getal terug dat we kunnen vergelijken met de killcode van het virus
            if (probeer == killcode)
            {
                v.Oplossing = probeer;// als de poging om de killcode te raden succesvol is, stellen we de oplossing van het vaccin in op de geraden killcode, dit maakt het makkelijker om te zien welke vaccins succesvol zijn geweest tijdens het spelen
                return true;
            }
            DoomCountdown--;// als de poging om de killcode te raden niet succesvol is, verlagen we de countdown van het virus, dit maakt het spannender tijdens het spelen omdat er een limiet is aan het aantal pogingen dat je hebt om het virus te verslaan voordat het spel voorbij is
            return false;
        }
    }

}

