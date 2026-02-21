using UnityEngine;

[System.Serializable]
public class MovementSystem {

    /// <summary>
    /// Gestisce il movimento fisico tramite Rigidbody2D.
    /// </summary>
    /// <param name="rb">Il Rigidbody del personaggio</param>
    /// <param name="input">La direzione (Vector2) dell'input</param>
    /// <param name="velocitaBase">Velocità di camminata</param>
    /// <param name="moltiplicatore">Moltiplicatore dello sprint (es. 1.8f)</param>
    /// <param name="staSprintando">Stato attuale della stamina/shift</param>
    public void Muovi(Rigidbody2D rb, Vector2 input, float velocitaBase, float moltiplicatore, bool staSprintando) {
        
        // Sicurezza: se non c'è il corpo o non c'è input, non fare nulla
        if (rb == null) return;
        if (input.sqrMagnitude < 0.01f) return;

        // 1. Normalizziamo la direzione
        // Impedisce di andare più veloce quando ci si muove in diagonale
        Vector2 direzione = input.normalized;

        // 2. Calcolo della velocità finale
        float velocitaFinale = velocitaBase;
        if (staSprintando) {
            velocitaFinale *= moltiplicatore;
        }

        // 3. Applicazione del movimento
        // Usiamo MovePosition per una gestione fluida delle collisioni 2D
        rb.MovePosition(rb.position + direzione * velocitaFinale * Time.fixedDeltaTime);
    }

    /// <summary>
    /// Ruota graficamente lo sprite in base alla direzione del movimento.
    /// </summary>
    public void GiraSprite(SpriteRenderer sr, Vector2 input) {
        if (sr == null) return;

        if (input.x > 0.1f) {
            sr.flipX = false; // Guarda a destra
        } else if (input.x < -0.1f) {
            sr.flipX = true;  // Guarda a sinistra
        }
    }
}