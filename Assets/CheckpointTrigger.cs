using UnityEngine;

public class CheckpointTrigger : MonoBehaviour
{
    private CheckpointManager checkpointManager;

    // --- AQUÍ AGREGAMOS LAS NUEVAS VARIABLES ---
    public GameObject mensajeNivel;
    public Animator animadorBandera;

    void Start()
    {
        checkpointManager = FindFirstObjectByType<CheckpointManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Detecta si lo que tocó la bandera es el objeto principal llamado "Jugador"
        if (other.gameObject.name == "Jugador")
        {
            // Tu línea original que guarda la posición:
            checkpointManager.UpdateCheckpoint(transform.position);

            // --- AQUÍ AGREGAMOS LA NUEVA LÓGICA ---

            // 1. Encender el texto de victoria
            if (mensajeNivel != null)
            {
                mensajeNivel.SetActive(true);
            }

            // 2. Reproducir la animación de la bandera
            if (animadorBandera != null)
            {
                animadorBandera.Play("BanderaOndeando");
            }
        }
    }
}