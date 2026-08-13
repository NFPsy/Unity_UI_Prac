using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Image fillImage;

    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float currentHealth = 100f;

    private static readonly Color FillColor = Color.red;

    private void Awake()
    {
        if (slider == null) slider = GetComponent<Slider>();
    }

    private void Start()
    {
        SetMaxHealth(maxHealth);
        SetHealth(currentHealth);
    }

    public void SetMaxHealth(float value)
    {
        maxHealth = Mathf.Max(1f, value);
        slider.maxValue = maxHealth;
        SetHealth(currentHealth);
    }

    public void SetHealth(float value)
    {
        currentHealth = Mathf.Clamp(value, 0f, maxHealth);
        slider.value = currentHealth;

        if (fillImage != null)
        {
            fillImage.color = FillColor;
        }
    }

    public void TakeDamage(float amount) => SetHealth(currentHealth - amount);

    public void Heal(float amount) => SetHealth(currentHealth + amount);
}
