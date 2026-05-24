using UnityEngine;

public class Ememigo1 : MonoBehaviour
{
    [Header("Configuración de Movimiento")]
    public float distancia = 5f;
    public float velocidad = 2f;

    [Header("Controles (Old Input)")]
    public bool moverseAutomaticamente = true;
    

    private Vector3 posicionInicial;
    private float tiempoActual = 0f;

    // Nueva variable para recordar dónde estaba en el frame anterior
    private float posicionAnteriorX;

    void Start()
    {
        posicionInicial = transform.position;
        posicionAnteriorX = transform.position.x;
    }

    void Update()
    {

        if (moverseAutomaticamente)
        {
            // 1. Guardamos la posición antes de calcular el nuevo movimiento
            posicionAnteriorX = transform.position.x;

            // 2. Calculamos y aplicamos el nuevo movimiento
            tiempoActual += Time.deltaTime * velocidad;
            float desplazamientoX = Mathf.PingPong(tiempoActual, distancia);

            transform.position = new Vector3(
                posicionInicial.x + desplazamientoX,
                posicionInicial.y,
                posicionInicial.z
            );

            // 3. Comparamos las posiciones para voltear el objeto
            if (transform.position.x > posicionAnteriorX)
            {
                // Yendo a la derecha: Forzamos que la escala X sea positiva usando Mathf.Abs
                transform.localScale = new Vector3(
                    Mathf.Abs(transform.localScale.x),
                    transform.localScale.y,
                    transform.localScale.z
                );
            }
            else if (transform.position.x < posicionAnteriorX)
            {
                // Yendo a la izquierda: Forzamos que la escala X sea negativa
                transform.localScale = new Vector3(
                    -Mathf.Abs(transform.localScale.x),
                    transform.localScale.y,
                    transform.localScale.z
                );
            }
        }
    }
}