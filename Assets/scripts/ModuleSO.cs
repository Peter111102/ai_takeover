using System.Xml.Serialization;
using UnityEngine;

[CreateAssetMenu(fileName = "NewModule", menuName = "DigitalHorror/Module")]
public class ModuleSO : ElementoGDR 
{
    [Header("Dati Identificativi")]
    public string nome;
    public enum Categoria { Permanente, Temporaneo } // Permanente = Installabile, Temporaneo = Consumabile
    public Categoria categoria;
    
    [Header("Visualizzazione")]
    public Sprite icona;
    [TextArea] public string descrizioneUI;

    [Header("Logica di Utilizzo")]
    public bool isConsumable; // TRUE per .bat/.cmd/Hardware monouso, FALSE per .exe/.sys/Innesti
    public int slotRequired;  // Quanti slot RAM o Hardware occupa (0 per i consumabili)
    
    [Header("Parametri di Combattimento")]
    public EffettoTipo tipoEffetto;
    public int valoreBase;
    public float hitRate;
    
    [Header("Costi e Rischi")]
    public int costoBatteria;
    public int costoCC;        // Cyber-Corruzione
    public int costoSincronia; // Per gli innesti hardware
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