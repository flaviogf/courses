using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Jogador : MonoBehaviour
    {
        private bool _estaPulando;

        private bool _estaNoChao;

        private bool _estaInvuneravel;

        private bool _estaViradoParaDireita;

        private float _proximoAtaque;

        private SpriteRenderer _spriteRenderer;

        private Rigidbody2D _rigidBody2D;

        private Animator _animator;

        private bool PodeAtacar
        {
            get { return Input.GetButtonDown("Fire1") && _estaNoChao && Time.time >= _proximoAtaque; }
        }

        private bool EstaAndando
        {
            get { return _rigidBody2D.velocity.x != 0 && _estaNoChao; }
        }

        public float Velocidade;

        public float ForcaPulo;

        public int Vida;

        public float AtrasoAtaque;

        public Transform PosicaoAtaque;

        public GameObject Ataque;

        public Transform ChecaChao;

        public void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _rigidBody2D = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
        }

        public void Update()
        {
            // _estaNoChao = _rigidBody2D.IsTouchingLayers(1 << LayerMask.NameToLayer("Chao"));
            _estaNoChao = Physics2D.Linecast(transform.position, ChecaChao.position, 1 << LayerMask.NameToLayer("Chao"));
            _estaPulando = Input.GetButtonDown("Jump") && _estaNoChao;
            ManipulaAtaque();
        }

        public void FixedUpdate()
        {
            ManipulaMovimento();
            ManipulaLado();
            ManipulaPulo();
            ManipulaQueda();
        }

        public void SofreDano()
        {
            if (_estaInvuneravel)
            {
                return;
            }
            if (--Vida <= 0)
            {
                Debug.Log("Morreu");
                return;
            }
            _estaInvuneravel = true;
            StartCoroutine(EfeitoDano());
        }

        private IEnumerator EfeitoDano()
        {
            for (var i = 0.0; i <= 1; i += 0.1)
            {
                _spriteRenderer.enabled = false;
                yield return new WaitForSeconds(0.1f);
                _spriteRenderer.enabled = true;
                yield return new WaitForSeconds(0.1f);
            }
            _estaInvuneravel = false;
        }

        private void ManipulaAtaque()
        {
            if (!PodeAtacar) return;
            _animator.SetTrigger("Atacando");
            var ataque = Instantiate(Ataque, PosicaoAtaque.position, Quaternion.identity);
            _proximoAtaque = Time.time + AtrasoAtaque;
            if (_estaViradoParaDireita) return;
            ataque.transform.Rotate(new Vector3(180, 0, 180));
        }

        private void ManipulaMovimento()
        {
            var horizontal = Input.GetAxis("Horizontal");
            _rigidBody2D.velocity = new Vector2(horizontal * Velocidade * Time.deltaTime, _rigidBody2D.velocity.y);
            _animator.SetBool("Andando", EstaAndando);
        }

        private void ManipulaLado()
        {
            _estaViradoParaDireita = _rigidBody2D.velocity.x >= 0;
            var x = _estaViradoParaDireita ? 1 : -1;
            transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);
        }

        private void ManipulaPulo()
        {
            if (!_estaPulando) return;
            _rigidBody2D.AddForce(Vector2.up * ForcaPulo * Time.deltaTime, ForceMode2D.Impulse);
            _estaPulando = false;
        }

        private void ManipulaQueda()
        {
            _animator.SetBool("Queda", !_estaNoChao);
            _animator.SetFloat("ValorY", _rigidBody2D.velocity.y);
        }
    }
}
