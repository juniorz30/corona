namespace overerving
{
    internal class Program
    {
        static void Main(string[] args)
        {// fase 1: virus maken en testen met vaccins
            Console.WriteLine(" start opdracht");

            Virus virus = new Virus();// virus maken
            List<Vaccin> vaccins = new List<Vaccin>();// lijst maken voor vaccins

            // 5 vaccins maken
            for (int i = 0; i < 5; i++)
            {
                vaccins.Add(new Vaccin("Vaccin" + i));// naam geven aan vaccin
            }

            Vaccin werkendVaccin = null;// variabele om werkend vaccin op te slaan

            foreach (Vaccin v in vaccins)// elk vaccin testen in de lijst
            {
                Console.WriteLine($"Testen van {v.Naam}...");// naam van vaccin tonen

                if (virus.TryVaccin(v))// testen of vaccin werkt
                {
                    werkendVaccin = v;// als het werkt, opslaan in werkendVaccin
                    Console.WriteLine($"Werkend vaccin gevonden: {v.Naam}");
                    break;// stoppen met testen als werkend vaccin is gevonden
                }// en break betekenty dat de hele programma stopt
            }

            if (werkendVaccin == null)
            {
                Console.WriteLine("Geen werkend vaccin gevonden.");
                return;
            }
            Console.WriteLine("\nVaccin wordt opgeslagen in vaccinatiecentrum...");

            VaccinatieCentrum.BewaarVaccin(werkendVaccin.Oplossing);// vaccin opslaan in centrum

            List<Vaccin> verspreideVaccins = new List<Vaccin>();// lijst maken voor verspreide vaccins

            // 5 centra, elk 7 vaccins dus 35 in totaal
            for (int i = 0; i < 5; i++)
            {// ik gebruik hier geneste loops
                for (int j = 0; j < 7; j++)
                {
                    verspreideVaccins.Add(VaccinatieCentrum.GeefVaccin());//
                }
            }

            Console.WriteLine("\nOverzicht verspreide vaccins:");

            foreach (Vaccin v in verspreideVaccins)
            {
                v.ToonInfo();
            }

            Console.WriteLine("\n einde simulatie ");
        }
    }
}
