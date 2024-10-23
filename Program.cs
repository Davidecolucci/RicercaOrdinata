

using System.Diagnostics;

class RicercaRubrica
{

    static void Main()
    {

        const string FilePath = "RubricaOrdinata.csv";
        string[] righe = File.ReadAllLines(FilePath);

        string[] nominativi = new string[righe.Length];


        for (int i = 0; i < righe.Length; i++)
        {
            string[] parti = righe[i].Split(',');
            nominativi[i] = parti[0] + " " + parti[1];
        }


        Console.WriteLine("Inserisci Il nominativo da cercare");
        string? NomeDaCercare = Console.ReadLine();


        Stopwatch Timer = new Stopwatch();
        Timer.Start();
        RicercaLineare(nominativi, NomeDaCercare);
        Timer.Stop();
        TimeSpan TempoLineare = Timer.Elapsed;
        Console.WriteLine($"Tempo impiegato dal benchmark di Ricerca Lineare è: {Timer.Elapsed.ToString()}");


        Timer.Restart();
        RicercaBinaria(nominativi, NomeDaCercare);
        Timer.Stop();
        TimeSpan TempoBinario = Timer.Elapsed;
        Console.WriteLine($"Tempo impiegato dal benchmark di Ricerca Binaria è: {Timer.Elapsed.ToString()}");

    }


    //Algoritmo di Ricerca Lineare
    public static void RicercaLineare(string[] contatti, string utente)
    {
        bool contattoTrovato = false;

        for (int i = 0; i < contatti.Length; i++)
        {
            if (contatti[i].ToLower() == utente.ToLower())
            {
                contattoTrovato = true;
                Console.WriteLine("contatto trovato!");
            }
        }
        if (!contattoTrovato)
        {
            Console.WriteLine("contatto non trovato!");

        }
    }


    //Algoritmo di Ricerca Binaria
    static void RicercaBinaria (string[] contatti, string utente)
    {
        int left = 0;
        int right = contatti.Length - 1;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            int comparison = string.Compare(contatti[mid], utente, StringComparison.Ordinal);
            if
            (comparison == 0)
            {
                Console.WriteLine($"{utente} trovato!");
                return; 
            }
            else if (comparison < 0)
            {
                left = mid + 1; // Cerca nella parte destra
            }
            else
            {
                right = mid - 1; // Cerca nella parte sinistra
            }
        }
        Console.WriteLine($"{utente} non trovato!");
    }

}

