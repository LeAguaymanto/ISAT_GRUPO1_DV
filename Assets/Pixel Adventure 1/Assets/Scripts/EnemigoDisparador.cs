using UnityEngine;

public class EnemigoDisparador : MonoBehaviour
{
    // Creamos una lista de opciones para elegir en el Inspector
    public enum Direccion { Arriba, Abajo, Izquierda, Derecha }

    [Header("Configuración")]
    public GameObject prefabBala;        // El objeto bala que va a disparar
    public Transform puntoDeDisparo;     // Desde dónde sale la bala
    public float tiempoEntreDisparos = 2f; // Segundos entre cada disparo
    public Direccion direccionDisparo = Direccion.Derecha; // Dirección por defecto

    private float temporizador;

    void Update()
    {
        // Temporizador para disparar automáticamente
        temporizador += Time.deltaTime;
        if (temporizador >= tiempoEntreDisparos)
        {
            Disparar();
            temporizador = 0f; // Reiniciamos el reloj
        }
    }

    void Disparar()
    {
        // 1. Creamos la bala en la posición del punto de disparo
        GameObject nuevaBala = Instantiate(prefabBala, puntoDeDisparo.position, Quaternion.identity);

        // 2. Buscamos el script de la bala y le decimos hacia dónde ir
        Bala scriptBala = nuevaBala.GetComponent<Bala>();
        if (scriptBala != null)
        {
            scriptBala.ConfigurarDireccion(direccionDisparo);
        }
    }
}
