using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NuovoMembro", menuName = "RPG/Membro Party")]
public class PartyMember : ElementoGDR {
    public string characterName;
    public Sprite characterSprite;
    public Statistiche_partyMember statistiche;
    

    [System.Serializable]
    public class Statistiche_partyMember {
        public Arti arti = new Arti(); // Inizializza subito per evitare null
        public int armor, agility, cyber_corruption, accuracy, power;
        public List<ModuleSO> moduli= new List<ModuleSO>(); // Lista dei moduli OS equipaggiati
    }

    [System.Serializable]
    public class Arti {
        public int head_health = 20, body_health = 100;
        public int left_arm_health = 40, right_arm_health = 40;
        public int left_leg_health = 50, right_leg_health = 50;
    }

    public void InstallaModulo(ModuleSO nuovoModulo) {
        statistiche.moduli.Add(nuovoModulo);
        Debug.Log($"{characterName}: Modulo {nuovoModulo.nome} installato. ");
    }

    public void RimuoviModulo(ModuleSO modulo) {
        if (statistiche.moduli.Contains(modulo)) {
            statistiche.moduli.Remove(modulo);
            Debug.Log($"{characterName}: Modulo {modulo.nome} rimosso.");
        }
    }
}