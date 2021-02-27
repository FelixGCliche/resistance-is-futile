using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private GameCharacter.Character character;
        private Slider healthSlider;
        private TextMeshProUGUI healthText;
        private int maxHealth;
        private int currentHealth;

        public GameCharacter.Character Character
        {
            set => character = value;
        }

        private void Awake()
        {
            healthSlider = GetComponent<Slider>();
            healthText = GetComponentInChildren<TextMeshProUGUI>();
        }

        void Start()
        {
            StartCoroutine(LateStart());
        }

        private void Update()
        {
            healthSlider.value = currentHealth;
            healthText.text = currentHealth + " / " + maxHealth;
        }

        private IEnumerator LateStart()
        {
            yield return new WaitUntil(() => character != null);
            currentHealth = character.Stats.Health;
            maxHealth = character.Stats.MaxHealth;
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }
    }
}
