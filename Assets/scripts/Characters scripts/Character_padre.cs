using UnityEngine;
using UnityEngine.InputSystem;

public class Character_padre : MonoBehaviour {
    [Header("Statistiche Base")]
    public float speed = 5f;
    protected Rigidbody2D rb;
    protected Vector2 inputMovimento;

    [Header("Sistemi Ereditati")]
    // Questo permette a tutti i figli di avere un motore di movimento
    public MovementSystem movementSystem; 

    protected virtual void Start() {
        rb = GetComponent<Rigidbody2D>();
        
        // Se non trasciniamo un MovementSystem dall'inspector, lo crea da solo
        if (movementSystem == null) movementSystem = new MovementSystem();

        if (rb != null) {
            rb.gravityScale = 0;      // Fondamentale per il top-down 2D
            rb.freezeRotation = true; // Impedisce al player di rotolare come una palla
        }
    }

    // L'Update nel padre lo teniamo "Virtual" e vuoto.
    protected virtual void Update() { }

    // Anche il FixedUpdate è vuoto perché il movimento fisico 
    // viene richiamato esplicitamente dai figli tramite il movementSystem.
    protected virtual void FixedUpdate() { }
}