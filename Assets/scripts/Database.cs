using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Database", menuName = "RPG/Database")]
public class Database : ScriptableObject {
    // La lista ora contiene ElementiGDR (che hanno l'ID)
    public List<ElementoGDR> oggetti = new List<ElementoGDR>();
    
    // Versione avanzata per ottenere il tipo corretto (es. PartyMember)
    public T GetOggetto<T>(string idCercato) where T : ElementoGDR {
    ElementoGDR trovato = oggetti.Find(p => p.id == idCercato);
    if (trovato == null) {
        Debug.LogWarning($"Database: Oggetto con ID {idCercato} non trovato.");
        return null;
    }
    return trovato as T;
}
}
