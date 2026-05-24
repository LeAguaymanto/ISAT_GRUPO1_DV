using UnityEngine;
using TMPro; // Necesario para usar TextMeshPro

public class MetaNivel : MonoBehaviour
{
    [Header("Elementos de la Interfaz (UI)")]
    public TextMeshProUGUI textoTemporizador; // Arrastra aquí tu texto del tiempo
    public TextMeshProUGUI textoVictoria;     // Arrastra aquí tu texto de victoria

    private float tiempoActual = 0f;
    private bool nivelCompletado = false;

    void Start()
    {
        // Nos aseguramos de que el texto de victoria esté oculto al empezar a jugar
        if (textoVictoria != null)
        {
            textoVictoria.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        // Si el nivel no se ha completado, el tiempo sigue corriendo
        if (!nivelCompletado)
        {
            tiempoActual += Time.deltaTime;
            ActualizarReloj();
        }
    }

    void ActualizarReloj()
    {
        // Convierte los segundos en un formato de minutos:segundos (ej: 01:23)
        int minutos = Mathf.FloorToInt(tiempoActual / 60f);
        int segundos = Mathf.FloorToInt(tiempoActual % 60f);

        // Actualiza lo que dice el texto en pantalla
        if (textoTemporizador != null)
        {
            textoTemporizador.text = string.Format("{0:00}:{1:00}", minutos, segundos);
        }
    }

    // Cuando algo choca con la meta
    private void OnTriggerEnter2D(Collider2D otro)
    {
        // Usamos tu misma validación: verificar si se llama "Jugador"
        if (otro.gameObject.name == "Jugador" && !nivelCompletado)
        {
            nivelCompletado = true; // Esto detiene el reloj en el Update()

            // Mostramos el mensaje de victoria
            if (textoVictoria != null)
            {
                textoVictoria.gameObject.SetActive(true);
                textoVictoria.text = "¡Felicidades completaste el nivel!";
            }
        }
    }
}
