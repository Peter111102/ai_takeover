using System.Xml.Serialization;
using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewModule", menuName = "DigitalHorror/Module")]
public class ModuleSO : ElementoGDR 
{
    [Header("Dati Identificativi")]
    public string nome;
    public enum Categoria { Permanente, Temporaneo, Corrotto } // Permanente = Installabile, Temporaneo = Consumabile
    public Categoria categoria;

    [Header("Rarità")]
    public RaritaModulo rarita; // rarità del modulo, da Comune a Leggendario, per influenzare drop rate e potenza

    [Header("Visualizzazione")]
    public Sprite icona;
    [TextArea] public string descrizioneUI;

    [Header("Logica di Utilizzo")]
    public bool isConsumable; // TRUE se è un modulo usa e getta, FALSE se è un modulo permanente da installare
    
    [Header("Parametri di Combattimento")]
    public List<EffettoTipo> tipiEffetto = new List<EffettoTipo>();
    public int DoannoBase;
    public float percentualeHit; 
    
    [Header("Costi e Rischi")]
    public int costoBatteria;
    public int costoCC;        // Cyber-Corruzione
    public int costoVita;      // Danno diretto all'utilizzatore costoIntegritaDati

}

public enum EffettoTipo 
{ 
    DannoFisico,    // Toglie HP
    DannoVirus,     // Applica DOT
    CuraIntegrita,  // Aggiunge HP
    BuffDifesa,     // Firewall
    Speciale        // Per casi come l'Empty Module
}

public enum RaritaModulo
{
    Comune,       // Facile da trovare
    NonComune,    // Più raro
    Raro,         // Difficile da trovare
    Epico,        // Molto raro
    Leggendario   // Unico o quasi
}