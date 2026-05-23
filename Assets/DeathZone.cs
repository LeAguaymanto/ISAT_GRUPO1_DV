using UnityEngine;

public class DeathZone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // Si lo que cae al vacío e impacta esta zona se llama "Jugador", lo regresa al checkpoint
        if (other.gameObject.name == "Jugador")
        {
            FindFirstObjectByType<CheckpointManager>().Respawn(other.gameObject);
        }
    }
}