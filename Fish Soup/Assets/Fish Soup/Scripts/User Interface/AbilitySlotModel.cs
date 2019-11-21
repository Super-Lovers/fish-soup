using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AbilitySlotModel : InterfaceController
{
    [Header("Internal References")]
    [SerializeField] private GameObject detailsPanel = null;
    [SerializeField] private TextMeshProUGUI abilityNameText = null;
    [SerializeField] private TextMeshProUGUI abilityDescriptionText = null;
    [SerializeField] private Image abilityImage = null;
    [SerializeField] private GameObject CooldownContainer = null;
    [SerializeField] private TextMeshProUGUI cooldownText = null;

    private float cooldownTime = 0;

    private void Update()
    {
        if (cooldownTime > 0)
        {
            cooldownTime -= Time.deltaTime;
            cooldownText.text = ((int)cooldownTime + 1).ToString();
        }
        else if (CooldownContainer.activeSelf == true)
        {
            cooldownTime = 0;
            cooldownText.text = ((int)cooldownTime + 1).ToString();
            CooldownContainer.SetActive(false);
        }
    }

    public void SetAbilitySlotDetails(string abilityName, string abilityDescription, Sprite portrait)
    {
        abilityNameText.text = abilityName;
        abilityDescriptionText.text = abilityDescription;
        abilityImage.sprite = portrait;
    }

    public string GetAbilityName()
    {
        return abilityNameText.text;
    }

    public void Cooldown(float time)
    {
        CooldownContainer.SetActive(true);
        cooldownText.text = time.ToString();
        cooldownTime = time;
    }

    public float GetCooldown()
    {
        return cooldownTime;
    }
}
