using UnityEngine;

public class Bala : MonoBehaviour
{
    public float velocidad = 5f;
    public float tiempoDeVida = 4f; // Se destruye sola si no choca con nada

    private Vector2 direccionEnVector;

    void Start()
    {
        Destroy(gameObject, tiempoDeVida);
    }

    // El enemigo llama a este método al crear la bala para decirle a dónde ir
    public void ConfigurarDireccion(EnemigoDisparador.Direccion dir)
    {
        if (dir == EnemigoDisparador.Direccion.Arriba) direccionEnVector = Vector2.up;
        else if (dir == EnemigoDisparador.Direccion.Abajo) direccionEnVector = Vector2.down;
        else if (dir == EnemigoDisparador.Direccion.Izquierda) direccionEnVector = Vector2.left;
        else if (dir == EnemigoDisparador.Direccion.Derecha) direccionEnVector = Vector2.right;
    }

    void Update()
    {
        transform.Translate(direccionEnVector * velocidad * Time.deltaTime);
    }

    // --- AQUÍ ESTÁ LA INTEGRACIÓN DE TU SCRIPT ---
    private void OnTriggerEnter2D(Collider2D otro)
    {
        // 1. Usamos tu misma condición para identificar al jugador
        if (otro.gameObject.name == "Jugador")
        {
            // 2. Ejecutamos tu lógica exacta para mandarlo al checkpoint
            FindFirstObjectByType<CheckpointManager>().Respawn(otro.gameObject);

            // 3. Destruimos la bala para que desaparezca al chocar
            Destroy(gameObject);
        }
    }
}