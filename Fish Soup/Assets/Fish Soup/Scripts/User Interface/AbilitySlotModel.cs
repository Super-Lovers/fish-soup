using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AbilitySlotModel : InterfaceController
{
    [SerializeField] private GameObject detailsPanel = null;
    [SerializeField] private TextMeshProUGUI abilityNameText = null;
    [SerializeField] private TextMeshProUGUI abilityDescriptionText = null;
    [SerializeField] private Image abilityImage = null;

    public void SetAbilitySlotDetails(string abilityName, string abilityDescription, Sprite portrait)
    {
        abilityNameText.text = abilityName;
        abilityDescriptionText.text = abilityDescription;
        abilityImage.sprite = portrait;
    }
}
