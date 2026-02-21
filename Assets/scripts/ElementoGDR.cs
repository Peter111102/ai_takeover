using UnityEngine;

[CreateAssetMenu(fileName = "ElementoGDR", menuName = "Scriptable Objects/ElementoGDR")]
// Deve essere uno ScriptableObject per permettere al Database di contenere riferimenti a file .asset
public class ElementoGDR : ScriptableObject {
    [Header("Identità Unica")]
    public string id; 
}