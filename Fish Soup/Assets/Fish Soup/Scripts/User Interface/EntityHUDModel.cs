using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EntityHUDModel : MonoBehaviour
{
    [Header("Please only insert entities of Foe type!")]
    [SerializeField] private EntityModel EntityToDisplay = null;

    [Header("Internal references to fields")]
    [Space(10)]
    [SerializeField] private TextMeshProUGUI labelText = null;

    [SerializeField] private Image portraitImage = null;

    [Space(10)]
    [SerializeField] private GameObject livesContainer = null;
    [SerializeField] private GameObject lifePrefab = null;
    private IProperties properties = null;

    [Space(10)]
    [SerializeField] private GameObject abilitiesContainer = null;
    [SerializeField] private GameObject abilitySlotPrefab = null;
    private AbilitiesController abilitiesController = null;

    private void Start()
    {
        properties = EntityToDisplay.GetProperties();

        abilitiesController = EntityToDisplay.GetProperties().GetCombatController().GetAbilitiesController();

        Refresh();
    }

    /// <summary>
    /// Refreshes the text component of the current entity on the user interface HUD
    /// </summary>
    public void RefreshLabel()
    {
        labelText.text = properties.GetLabel();
    }

    /// <summary>
    /// Refreshes the portrait image component of the current entity on the user interface HUD
    /// </summary>
    public void RefreshPortrait()
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Refreshes the lives list of the current entity on the user interface HUD
    /// </summary>
    public void RefreshLives()
    {
        List<GameObject> children = new List<GameObject>();

        for (int i = 0; i < livesContainer.transform.childCount; i++)
        {
            children.Add(livesContainer.transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < children.Count; i++)
        {
            Destroy(children[i]);
        }

        for (int i = 0; i < properties.GetHealthController().GetHealth(); i++)
        {
            Instantiate(lifePrefab, livesContainer.transform);
        }
    }

    /// <summary>
    /// Refreshes the abilities list of the current entity on the user interface HUD
    /// </summary>
    public void RefreshAbilities()
    {
        List<GameObject> children = new List<GameObject>();

        for (int i = 0; i < abilitiesContainer.transform.childCount; i++)
        {
            children.Add(abilitiesContainer.transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < children.Count; i++)
        {
            Destroy(children[i]);
        }

        AbilitiesController abilitiesController = properties.GetCombatController().GetAbilitiesController();
        List<AbilityModel> abilities = abilitiesController.GetAbilities();

        for (int i = 0; i < abilities.Count; i++)
        {
            AbilityModel ability = abilities[i];
            GameObject abilityObj = Instantiate(abilitySlotPrefab, abilitiesContainer.transform);
            AbilitySlotModel abilitySlotModel = abilityObj.GetComponent<AbilitySlotModel>();
            abilitySlotModel.SetAbilitySlotDetails(ability.GetAbilityName(), ability.GetAbilityDescription(), ability.GetAbilityPortrait());
        }
    }

    /// <summary>
    /// Refreshes all the view components on the user interface HUD
    /// </summary>
    public void Refresh()
    {
        RefreshLabel();
        //RefreshPortrait();
        RefreshLives();
        RefreshAbilities();
    }

    public GameObject GetAbilitiesContainer()
    {
        return abilitiesContainer;
    }

    public EntityModel GetEntity()
    {
        return EntityToDisplay;
    }
}
