using UnityEngine;

namespace Assets.Script
{
    public class Carrosel : MonoBehaviour
    {
        private Vector3 _posicaoInicial;

        private float _tamanhoSprite;

        public VariavelCompartilhadaFloat Velocidade;

        public void Awake()
        {
            _posicaoInicial = transform.position;
            CalculaTamanhoSprite();
        }

        public void Update()
        {
            var deslocamento = Mathf.Repeat(Time.time * Velocidade.Valor, _tamanhoSprite);
            transform.position = _posicaoInicial + Vector3.left * deslocamento;
        }

        private void CalculaTamanhoSprite()
        {
            var tamanhoImagem = GetComponent<SpriteRenderer>().size.x;
            var scalaX = transform.localScale.x;
            _tamanhoSprite = tamanhoImagem * scalaX;
        }
    }
}