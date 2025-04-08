using UnityEngine;

public class Moneda_recoleccion : MonoBehaviour
{
    public int score = 0;  // Variable para contar las monedas

    public GameObject efectoVFX;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Moneda"))  // Detecta si tocó una moneda
        {
            if (efectoVFX != null)
            {
                Vector3 posicion = transform.position + new Vector3(0, 5f, 0);
                Instantiate(efectoVFX, posicion, Quaternion.identity);
            }
            score += 1;  // Suma un punto
            Destroy(other.gameObject);  // Elimina la moneda
        }
    }
}