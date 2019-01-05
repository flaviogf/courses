using UnityEngine;

namespace Assets.Script
{
    public class Jogador : MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;

        private Vector3 _posicaoInicial;

        private bool _deveImpulsionar;

        private Animator _animator;

        public Diretor Diretor;

        public float Forca;

        public void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _posicaoInicial = transform.position;
            _animator = GetComponent<Animator>();
        }

        public void Update()
        {
            _animator.SetFloat("VelocidadeY", transform.position.y);
            if (Input.GetButtonDown("Fire1"))
            {
                _deveImpulsionar = true;
            }
        }

        public void FixedUpdate()
        {
            if (_deveImpulsionar)
            {
                Impulsionar();
            }
        }

        public void OnCollisionEnter2D(Collision2D outro)
        {
            if (outro.gameObject.CompareTag("Obstaculo") || outro.gameObject.CompareTag("Chao"))
            {
                _rigidbody2D.simulated = false;
                Diretor.FinalizaJogo();
            }
        }

        private void Impulsionar()
        {
            _rigidbody2D.velocity = Vector2.zero;
            _rigidbody2D.AddForce(Vector2.up * Forca * Time.deltaTime, ForceMode2D.Impulse);
            _deveImpulsionar = false;
        }

        public void Reiniciar()
        {
            transform.position = _posicaoInicial;
            _rigidbody2D.simulated = true;
        }
    }
}