using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour {
    [Header("Riferimenti")]
    public Character_player player; 
    public Slider staminaSlider; 

    [Header("Aspetto")]
    public Color coloreNormale = Color.green;
    public Color coloreAffanno = Color.red;
    public Image fillImage; 

    private void Start() {
        if (player != null && staminaSlider != null) {
            // Forza il valore massimo all'inizio
            staminaSlider.maxValue = player.stamina.max;
            staminaSlider.value = player.stamina.attuale;
        }
    }

    private void Update() {
        if (player == null || staminaSlider == null) return;

        // 1. Sincronizzazione forzata del MaxValue (per sicurezza)
        if (staminaSlider.maxValue != player.stamina.max) {
            staminaSlider.maxValue = player.stamina.max;
        }

        // 2. Aggiornamento valore attuale
        staminaSlider.value = player.stamina.attuale;

        // 3. Logica del colore basata sulla percentuale reale
        if (fillImage != null) {
            // Calcoliamo la percentuale (0.0 a 1.0)
            float percentuale = player.stamina.attuale / player.stamina.max;

            if (percentuale < player.stamina.percentualeSogliaAffanno) { // Sotto il 20%
                fillImage.color = coloreAffanno;
            } else {
                fillImage.color = coloreNormale;
            }
        }
    }
}