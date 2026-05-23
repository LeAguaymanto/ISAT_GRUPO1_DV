using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    private Vector2 checkpointPosition;

    void Start()
    {
        GameObject player = GameObject.Find("Jugador");
        if (player != null)
        {
            checkpointPosition = player.transform.position;
        }
    }

    public void UpdateCheckpoint(Vector2 newPosition)
    {
        checkpointPosition = newPosition;
        Debug.Log("¡Posición del Checkpoint guardada con éxito!");
    }

    public void Respawn(GameObject player)
    {
        player.transform.position = checkpointPosition;

        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
        }
    }
}