using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Targeting")]
    public Transform target;        // Trascina qui il tuo Player nell'Inspector
    public float smoothing = 5f;    // Più alto è, più la camera è "rigida"

    [Header("Limiti Mappa")]
    public bool useLimits;          // Spunta per non far vedere il vuoto fuori mappa
    public Vector2 minCoords;       // Coordinate minime (angolo basso sx)
    public Vector2 maxCoords;       // Coordinate massime (angolo alto dx)

    void FixedUpdate()
    {
        if (target != null)
        {
            // Calcoliamo la posizione desiderata (Z deve restare -10 per la camera)
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

            // Se abbiamo dei limiti, blocchiamo la posizione della camera
            if (useLimits)
            {
                targetPosition.x = Mathf.Clamp(targetPosition.x, minCoords.x, maxCoords.x);
                targetPosition.y = Mathf.Clamp(targetPosition.y, minCoords.y, maxCoords.y);
            }

            // Movimento fluido (Lerp)
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.fixedDeltaTime);
        }
    }
}