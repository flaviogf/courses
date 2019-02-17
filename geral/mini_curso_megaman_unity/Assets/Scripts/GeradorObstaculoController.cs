using UnityEngine;

namespace Assets.Scripts
{
    public class GeradorObstaculoController : MonoBehaviour
    {
        private float _tempoPassado;

        private Vector3 Posicao
        {
            get { return Random.Range(0, 100) >= 50 ? PosicaoCima : PosicaoBaixo; }
        }

        private bool PodeGerar
        {
            get { return _tempoPassado >= Intervalo; }
        }

        public float Intervalo;

        public Vector3 PosicaoCima;

        public Vector3 PosicaoBaixo;

        public GameObject Obstaculo;

        public void Start()
        {
        }

        public void Update()
        {
            AtualizaTempo();
            Gera();
        }

        private void AtualizaTempo()
        {
            _tempoPassado += Time.deltaTime;
        }

        private void Gera()
        {
            if (!PodeGerar) return;
            Instantiate(Obstaculo, Posicao, Quaternion.identity);
            _tempoPassado = 0;
        }
    }
}