using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NuovoPartySystem", menuName = "RPG/Sistema Party")]
public class PartySystem : ScriptableObject {
    // Lista dei personaggi attualmente nel gruppo
    [SerializeField] private List<PartyMember> activeParty = new List<PartyMember>();
    public int membriMassimi = 4; // Limite massimo di membri nel party
    public void AggiungiMembro(PartyMember personaggio) {
        if (!activeParty.Contains(personaggio) && activeParty.Count <= membriMassimi) {
            activeParty.Add(personaggio);
            Debug.Log($"{activeParty.Count} si è connesso alla rete del gruppo.");
        }
    }
    public void RimuoviMembro(PartyMember personaggio) {
        activeParty.Remove(personaggio);
    }
    public List<PartyMember> GetPartyList() => activeParty;
}