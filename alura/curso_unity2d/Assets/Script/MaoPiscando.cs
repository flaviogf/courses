using UnityEngine;

namespace Assets.Script
{
    public class MaoPiscando : MonoBehaviour
    {
        private SpriteRenderer _sprite;

        public void Awake()
        {
            _sprite = GetComponent<SpriteRenderer>();
        }

        public void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                _sprite.enabled = false;
            }
        }

        public void Reiniciar()
        {
            _sprite.enabled = true;
        }
    }
}