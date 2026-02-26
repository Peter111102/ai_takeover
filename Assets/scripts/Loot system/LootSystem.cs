using UnityEngine;
using System.Collections.Generic;

public class LootSystem : MonoBehaviour
{
    public Database database; // Database di tutti i moduli
    public RaritaModulo raritaMassima = RaritaModulo.Leggendario;

    // Mappa dei pesi per ogni rarità
    private Dictionary<RaritaModulo, int> pesiRarita = new Dictionary<RaritaModulo, int>()
    {
        { RaritaModulo.Comune, 60 },
        { RaritaModulo.NonComune, 25 },
        { RaritaModulo.Raro, 10 },
        { RaritaModulo.Epico, 4 },
        { RaritaModulo.Leggendario, 1 }
    };

    public ModuleSO GeneraDrop()
    {
        // 1 Raggruppa moduli per rarità
        Dictionary<RaritaModulo, List<ModuleSO>> gruppi = new Dictionary<RaritaModulo, List<ModuleSO>>();
        foreach (var obj in database.oggetti)
        {
            if (obj is ModuleSO modulo)
            {
                if (modulo.rarita <= raritaMassima)
                {
                    if (!gruppi.ContainsKey(modulo.rarita))
                        gruppi[modulo.rarita] = new List<ModuleSO>();
                    gruppi[modulo.rarita].Add(modulo);
                }
            }
        }

        if (gruppi.Count == 0) return null; // Nessun modulo disponibile

        // 2️ Somma pesi
        int pesoTotale = 0;
        foreach (var r in gruppi.Keys)
            pesoTotale += pesiRarita[r];

        // 3️ Roll random
        int roll = Random.Range(0, pesoTotale);
        int somma = 0;

        foreach (var r in gruppi.Keys)
        {
            somma += pesiRarita[r];
            if (roll < somma)
            {
                // 4️ Pick casuale tra gli oggetti della rarità scelta
                var lista = gruppi[r];
                return lista[Random.Range(0, lista.Count)];
            }
        }

        return null; // fallback
    }
}