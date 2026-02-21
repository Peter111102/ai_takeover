using UnityEngine;

public class Character_enemy_base : Character_padre {
    
    [Header("Targeting")]
    public Transform player;
    public float chaseDistance = 5f;

    [Header("Pattugliamento")]
    public float patrolDistance = 3f; 
    private Vector2 startPosition;
    private int direction = 1; // 1 = destra, -1 = sinistra

    protected override void Start() {
        base.Start();
        startPosition = transform.position; 

        // Ricerca automatica del player se non assegnato
        if (player == null) {
            player = GameObject.FindGameObjectWithTag("Player")?.transform;
        }
    }

    protected override void Update() {
        // Il padre non ha logica nell'Update, quindi non serve base.Update()
        
        if (player != null) {
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);
            
            if (distanceToPlayer < chaseDistance) {
                // STATO: INSEGUIMENTO
                inputMovimento = (player.position - transform.position).normalized;
            } else {
                // STATO: PATTUGLIAMENTO
                LogicaPattugliamento();
            }
        }
    }

    protected override void FixedUpdate() {
        // Richiamiamo il sistema di movimento ereditato dal padre
        // Passiamo 1f come moltiplicatore e false perché il nemico base non "sprinta"
        movementSystem.Muovi(
            rb, 
            inputMovimento, 
            speed, 
            1f, 
            false
        );
    }

    private void LogicaPattugliamento() {
        float distanceFromStart = transform.position.x - startPosition.x;

        if (distanceFromStart >= patrolDistance) {
            direction = -1;
        } 
        else if (distanceFromStart <= -patrolDistance) {
            direction = 1;
        }

        inputMovimento = new Vector2(direction, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            Debug.Log("SCONTRO AVVIATO!");
            // In un gioco stile Fear & Hunger, qui scatterebbe il cambio scena
            Time.timeScale = 0; 
        }
    }
}