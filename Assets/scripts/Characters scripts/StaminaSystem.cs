using UnityEngine;

[System.Serializable]
public class StaminaSystem {
    public float max = 100f;
    public float consumo = 25f;
    public float rigenerazione = 15f;
    public float tempoAttesaRicarica = 1.5f; // Secondi da aspettare prima di ricaricare
    public float moltiplicatoreVelocita = 1.8f;
    public float percentualeSogliaAffanno = 0.2f; // Soglia del 20% per il cambio di colore   
    
    [HideInInspector] public float attuale;
    [HideInInspector] public bool isSprinting;
    
    private float timerRicarica; // Timer interno

    public void Inizializza() {
        attuale = max;
    }

    public void AggiornaStamina(bool tastoPremuto, bool siStaMuovendo) {
        // Calcoliamo la soglia del percentualeSogliaAffanno%
        float sogliaMinima = max * percentualeSogliaAffanno;

        // Logica di attivazione sprint: 
        // 1. Se sta già sprintando, può continuare fino a 0.
        // 2. Se NON sta sprintando, può iniziare solo se ha più del percentualeSogliaAffanno% (sogliaMinima).
        bool puòSprintare = isSprinting ? attuale > 0 : attuale > sogliaMinima;

        if (tastoPremuto && siStaMuovendo && puòSprintare) {
            // STIAMO CONSUMANDO
            isSprinting = true;
            attuale -= consumo * Time.deltaTime;
            timerRicarica = tempoAttesaRicarica;
        } else {
            // NON STIAMO CONSUMANDO (o stamina insufficiente)
            isSprinting = false;

            if (timerRicarica > 0) {
                timerRicarica -= Time.deltaTime;
            }

            if (timerRicarica <= 0 && attuale < max) {
                attuale += rigenerazione * Time.deltaTime;
            }
        }

        attuale = Mathf.Clamp(attuale, 0, max);
    }
}