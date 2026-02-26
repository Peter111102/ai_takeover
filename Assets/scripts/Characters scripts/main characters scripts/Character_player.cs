using UnityEngine;
using UnityEngine.InputSystem;

public class Character_player : Character_padre {

    [Header("Sistemi Ereditati")]
    public StaminaSystem stamina;
    public PartySystem partySystem;
    public PartyMember personaggio_selezionato_inizialmente;
    protected override void Start() {
        // Chiama lo Start del padre (se esiste) per inizializzare rb e altri componenti
        base.Start(); 
        
        // Inizializza i valori della stamina (max, attuale, ecc.)
        if (stamina != null) {
            stamina.Inizializza();
        }

        if (partySystem == null)
        {
            Debug.LogError("PartySystem non assegnato!");
            return;
        }

        // Aggiungi il personaggio iniziale al party
        if(partySystem.NumberOfMembers() == 0 && personaggio_selezionato_inizialmente != null) {
            partySystem.AggiungiMembro(personaggio_selezionato_inizialmente);
        }

    }

    protected override void Update() {
        // 1. Leggi input direzionale
        float moveX = 0, moveY = 0;
        if (Keyboard.current.wKey.isPressed) moveY = 1;
        if (Keyboard.current.sKey.isPressed) moveY = -1;
        if (Keyboard.current.aKey.isPressed) moveX = -1;
        if (Keyboard.current.dKey.isPressed) moveX = 1;
        inputMovimento = new Vector2(moveX, moveY);

        // 2. Chiamata al sistema di stamina
        bool vuoleSprintare = Keyboard.current.leftShiftKey.isPressed;
        bool siStaMuovendo = inputMovimento.sqrMagnitude > 0.01f;
        
        if (stamina != null) {
            stamina.AggiornaStamina(vuoleSprintare, siStaMuovendo);
        }

        // 3. Gira lo sprite (usando il sistema del padre)
        if (movementSystem != null) {
            movementSystem.GiraSprite(GetComponent<SpriteRenderer>(), inputMovimento);
        }
    }
    protected override void FixedUpdate() {
        // 4. Muovi usando il sistema ereditato dal padre
        // Usiamo 'rb' perché è il nome standard ereditato dal padre
        if (movementSystem != null && rb != null) {
            movementSystem.Muovi(
                rb, 
                inputMovimento, 
                speed, 
                stamina.moltiplicatoreVelocita, 
                stamina.isSprinting
            );
        }
    }
}