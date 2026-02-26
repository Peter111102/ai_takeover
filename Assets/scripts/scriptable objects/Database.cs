using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Database", menuName = "RPG/Database")]
public class Database : ScriptableObject {
    // La lista ora contiene ElementiGDR (che hanno l'ID)
    public List<ElementoGDR> oggetti = new List<ElementoGDR>();

    private Dictionary<string, ElementoGDR> mappaOggetti;

    private void OnEnable()
    {
        mappaOggetti = new Dictionary<string, ElementoGDR>();

        foreach (var oggetto in oggetti)
        {
            if (oggetto == null)
                continue;

            if (string.IsNullOrEmpty(oggetto.id))
            {
                Debug.LogError($"Database: Oggetto {oggetto.name} ha ID nullo o vuoto.");
                continue;
            }

            if (!mappaOggetti.ContainsKey(oggetto.id))
            {
                mappaOggetti.Add(oggetto.id, oggetto);
            }
            else
            {
                Debug.LogWarning($"Database: ID duplicato trovato - {oggetto.id}. Ignorato.");
            }
        }
    }
    
    // Versione avanzata per ottenere il tipo corretto (es. PartyMember)
    public T GetOggetto<T>(string idCercato) where T : ElementoGDR
    {
        if (!mappaOggetti.TryGetValue(idCercato, out ElementoGDR trovato))
        {
            Debug.LogWarning($"Database: Oggetto con ID {idCercato} non trovato.");
            return null;
        }

        if (trovato is T typed)
            return typed;

        Debug.LogWarning($"Database: Oggetto {idCercato} non è di tipo {typeof(T)}.");
        return null;
    }
}

