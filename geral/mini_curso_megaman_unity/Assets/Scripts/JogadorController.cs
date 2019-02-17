using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class JogadorController : MonoBehaviour
    {
        private Collider2D _collider2D;

        private Rigidbody2D _rigidbody2D;

        private bool _estaNoChao = true;

        private Animator _animator;

        private bool AcionouPulo
        {
            get { return Input.GetMouseButtonDown(0); }
        }

        private bool AcionouDeslize
        {
            get { return Input.GetMouseButtonDown(1); }
        }

        private bool PodePular
        {
            get { return AcionouPulo && _estaNoChao; }
        }

        private bool PodeDeslizar
        {
            get { return AcionouDeslize && _estaNoChao; }
        }

        public float TempoAnimacaoDeslizar;

        public float TempoAnimacaoPulando;

        public Vector2 BoxColiderPosicaoAndando;

        public Vector2 BoxColiderPosicaoPulando;

        public Vector2 BoxColiderPosicaoDeslizando;

        public int ForcaPulo;

        public void Start()
        {
            _collider2D = GetComponent<BoxCollider2D>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
        }

        public void Update()
        {
            if (PodePular)
            {
                Pula();
            }
            else if (PodeDeslizar)
            {
                Desliza();
            }
        }

        public void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Obstaculo"))
            {
                SceneManager.LoadScene("Inicio");
            }

            if (col.CompareTag("Chao"))
            {
                _estaNoChao = true;
            }
        }

        public void OnTriggerExit2D(Collider2D col)
        {
            if (col.CompareTag("Chao"))
            {
                _estaNoChao = false;
            }
        }

        private void Pula()
        {
            _rigidbody2D.AddForce(Vector2.up * ForcaPulo * Time.deltaTime, ForceMode2D.Impulse);
            MudaPosicaoBoxColider(BoxColiderPosicaoPulando);
            _animator.SetBool("pulando", true);
            StartCoroutine(AguardaPulo());
        }

        private IEnumerator AguardaPulo()
        {
            yield return new WaitForSeconds(TempoAnimacaoPulando);
            ParaPulo();
        }

        private void ParaPulo()
        {
            MudaPosicaoBoxColider(BoxColiderPosicaoAndando);
            _animator.SetBool("pulando", false);
        }

        private void Desliza()
        {
            MudaPosicaoBoxColider(BoxColiderPosicaoDeslizando);
            _animator.SetBool("deslizando", true);
            StartCoroutine(AguardaDeslize());
        }

        private IEnumerator AguardaDeslize()
        {
            yield return new WaitForSeconds(TempoAnimacaoDeslizar);
            ParaDeslize();
        }

        private void ParaDeslize()
        {
            MudaPosicaoBoxColider(BoxColiderPosicaoAndando);
            _animator.SetBool("deslizando", false);
        }

        private void MudaPosicaoBoxColider(Vector2 posicao)
        {
            _collider2D.offset = posicao;
        }
    }
}