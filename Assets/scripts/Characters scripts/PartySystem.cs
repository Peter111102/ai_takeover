using UnityEngine;
using System.Collections.Generic;

public class PartySystem : MonoBehaviour
{
    [Header("Limite massimo membri nel party")]
    public int membriMassimi = 4;  // statico, non cambierà mai

    [Header("Membri attivi del Party")]
    private List<PartyMember> activeParty = new List<PartyMember>();

    /// <summary>
    /// Aggiunge un membro al party se non è già presente e se non si supera il limite massimo.
    /// </summary>
    public void AggiungiMembro(PartyMember personaggio)
    {
        if (!activeParty.Contains(personaggio) && activeParty.Count < membriMassimi)
        {
            activeParty.Add(personaggio);
            Debug.Log($"{personaggio.name} aggiunto al party.");
        }
    }

    /// <summary>
    /// Rimuove un membro dal party.
    /// </summary>
    public void RimuoviMembro(PartyMember personaggio)
    {
        if (activeParty.Contains(personaggio))
        {
            activeParty.Remove(personaggio);
            Debug.Log($"{personaggio.name} rimosso dal party.");
        }
    }

    /// <summary>
    /// Restituisce il numero attuale di membri nel party.
    /// </summary>
    public int NumberOfMembers()
    {
        return activeParty.Count;
    }

    /// <summary>
    /// Restituisce una lista dei membri attivi.
    /// </summary>
    public List<PartyMember> GetActiveParty()
    {
        return activeParty;
    }
}