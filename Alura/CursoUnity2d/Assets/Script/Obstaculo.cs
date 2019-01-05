using UnityEngine;

namespace Assets.Script
{
    public class Obstaculo : MonoBehaviour
    {
        public VariavelCompartilhadaFloat Velocidade;

        public float VariacaoPosicaoY;

        public void Awake()
        {
            transform.Translate(Vector3.up * Random.Range(-VariacaoPosicaoY, VariacaoPosicaoY));
        }

        public void Update()
        {
            transform.Translate(Vector3.left * Velocidade.Valor * Time.deltaTime);
        }

        public void OnTriggerEnter2D(Collider2D outro)
        {
            if (outro.CompareTag("BarreiraObstaculo"))
            {
                Destruir();
            }
        }

        public void Destruir()
        {
            Destroy(gameObject);
        }
    }
}