using UnityEngine;

namespace Assets.Script
{
    public class GeradorObstaculo : MonoBehaviour
    {
        private ControleDificuldade _controleDificuldade;

        private float _cronometro;

        public GameObject ObstaculoPrefab;

        public float TempoEsperaDificil;

        public float TempoEsperaFacil;

        public void Awake()
        {
            _cronometro = TempoEsperaFacil;
            _controleDificuldade = FindObjectOfType<ControleDificuldade>();
        }

        public void Update()
        {
            _cronometro -= Time.deltaTime;
            if (_cronometro < 0)
            {
                Instantiate(ObstaculoPrefab, transform.position, Quaternion.identity);
                _cronometro = Mathf.Lerp(TempoEsperaFacil, TempoEsperaDificil, _controleDificuldade.Dificulade);
            }
        }
    }
}