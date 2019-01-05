using UnityEngine;

namespace Assets.Scripts
{
    public class Ataque : MonoBehaviour
    {
        public float TempoParaDestruir;

        public float Velocidade;

        public void Start()
        {

        }

        public void Update()
        {
            transform.Translate(Vector3.right * Velocidade * Time.deltaTime);
            Destroy(gameObject, TempoParaDestruir);
        }
    }
}
