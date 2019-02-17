using UnityEngine;

namespace Assets.Scripts
{
    public class ObstaculoController : MonoBehaviour
    {
        private bool PodeDestruir
        {
            get { return transform.position.x <= -7; }
        }

        public float Velocidade;

        public void Start()
        {
        }

        public void Update()
        {
            MoveParaEsquerda();
            VerificaDestroi();
        }

        private void MoveParaEsquerda()
        {
            var x = transform.position.x - Velocidade * Time.deltaTime;
            transform.position = new Vector3(x, transform.position.y, transform.position.z);
        }

        private void VerificaDestroi()
        {
            if (PodeDestruir) Destroy(gameObject);
        }
    }
}