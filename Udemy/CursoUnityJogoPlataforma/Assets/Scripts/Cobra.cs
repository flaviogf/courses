using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Cobra : MonoBehaviour
    {
        private bool _estaViradaParaDireita = true;

        private bool _sofreuDano;

        private Color _corPadrao;

        private SpriteRenderer _spriteRenderer;

        private Rigidbody2D _rigidBody2D;

        private Vector2 Direcao
        {
            get { return _estaViradaParaDireita ? Vector2.right : Vector2.left; }
        }

        private int ScaleX
        {
            get { return _estaViradaParaDireita ? 1 : -1; }
        }

        public float Velocidade;

        public float TempoDano;

        public float ForcaPulo;

        public int Vida;

        public Transform ChecaParede;

        public void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _rigidBody2D = GetComponent<Rigidbody2D>();
            _corPadrao = _spriteRenderer.color;
        }

        public void Update()
        {
            VerificaToqueParede();
            AtualizaDirecao();
        }

        public void FixedUpdate()
        {
            Anda();
            if (_sofreuDano)
            {
                _rigidBody2D.AddForce(Vector2.up * ForcaPulo * Time.deltaTime, ForceMode2D.Impulse);
                _sofreuDano = false;
            }
        }

        public void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Ataque"))
            {
                SofreDano();
            }
        }

        private void SofreDano()
        {
            if (--Vida <= 0)
            {
                Destroy(gameObject);
                return;
            }
            StartCoroutine(EfeitoDano());
        }

        private IEnumerator EfeitoDano()
        {
            _sofreuDano = true;
            _spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(TempoDano);
            _spriteRenderer.color = _corPadrao;
        }

        private void VerificaToqueParede()
        {
            bool tocouNaParede = Physics2D.Linecast(transform.position, ChecaParede.position, 1 << LayerMask.NameToLayer("Chao"));
            if (tocouNaParede) _estaViradaParaDireita = !_estaViradaParaDireita;
        }

        private void AtualizaDirecao()
        {
            transform.localScale = new Vector3(ScaleX, transform.localScale.y, transform.localScale.z);
        }

        private void Anda()
        {
            _rigidBody2D.velocity = Direcao * Velocidade * Time.deltaTime;
        }
    }
}
