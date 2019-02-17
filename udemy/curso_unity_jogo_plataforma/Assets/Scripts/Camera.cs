using UnityEngine;

namespace Assets.Scripts
{
    public class Camera : MonoBehaviour
    {
        private float _velocidadeY;

        private float _velocidadeX;

        public Transform Jogador;

        public float TempoDeEspera;

        public void Start()
        {

        }

        public void Update()
        {
            var posicaoY = Mathf.SmoothDampAngle(transform.position.y, Jogador.position.y, ref _velocidadeY, TempoDeEspera);
            var posicaoX = Mathf.SmoothDampAngle(transform.position.x, Jogador.position.x, ref _velocidadeX, TempoDeEspera);
            transform.position = new Vector3(posicaoX, posicaoY, transform.position.z);
        }
    }
}
