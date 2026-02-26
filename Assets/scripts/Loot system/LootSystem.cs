using UnityEngine;
using System.Collections.Generic;

public class LootSystem : MonoBehaviour
{
    public Database database; // Database di tutti i moduli

    [Header("Filtri Drop")]
    public bool filtraPerRarita = false;
    public RaritaModulo raritaMassima = RaritaModulo.Leggendario;

    /// <summary>
    /// Genera un singolo drop casuale basato sul dropChance di ogni modulo
    /// </summary>
    public ModuleSO GeneraDrop()
    {
        List<ModuleSO> moduliDisponibili = new List<ModuleSO>();

        // Filtra i moduli dal Database
        foreach (var obj in database.oggetti)
        {
            if (obj is ModuleSO modulo)
            {
                if (!filtraPerRarita || modulo.rarita <= raritaMassima)
                    moduliDisponibili.Add(modulo);
            }
        }

        if (moduliDisponibili.Count == 0)
            return null; // Nessun modulo disponibile

        // Prova ogni modulo una sola volta in ordine casuale
        moduliDisponibili.Shuffle(); // funzione di estensione per mescolare la lista
        foreach (var modulo in moduliDisponibili)
        {
            int roll = Random.Range(0, 100);
            if (roll < modulo.dropChance)
            {
                Debug.Log($"Modulo droppato: {modulo.nome} ({modulo.dropChance}%)");
                return modulo;
            }
        }

        return null; // nessun drop
    }
}

// Estensione semplice per mescolare liste
public static class ListExtensions
{
    public static void Shuffle<T>(this IList<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int rnd = Random.Range(i, list.Count);
            T temp = list[i];
            list[i] = list[rnd];
            list[rnd] = temp;
        }
    }
}




