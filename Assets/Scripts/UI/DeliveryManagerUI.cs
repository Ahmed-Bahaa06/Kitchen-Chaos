using System;
using UnityEngine;

public class DeliveryManagerUI : MonoBehaviour
{
    [SerializeField] private Transform recipeTemplate;
    [SerializeField] private Transform container;
    [SerializeField] private Transform iconContainer;
    [SerializeField] private Transform iconTemplate;

    private void Awake()
    {
        recipeTemplate.gameObject.SetActive(false);
        iconTemplate.gameObject.SetActive(false);
    }

    private void Start()
    {
        DeliveryManager.Instance.OnRecipeSpawned += DeliveryManager_OnRecipeSpawned;
        DeliveryManager.Instance.OnRecipeCompleted += DeliveryManager_OnRecipeCompleted;

        UpdateVisual();
    }

    private void DeliveryManager_OnRecipeCompleted(object sender, EventArgs e)
    {
        UpdateVisual();
    }

    private void DeliveryManager_OnRecipeSpawned(object sender, EventArgs e)
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        foreach (Transform child in container)
        {
            if (child == recipeTemplate) continue;
            Destroy(child.gameObject);
        }

        foreach (RecipeSO recipeSO in DeliveryManager.Instance.GetWaitingRecipeSOList())
        {
            Transform recipeTransform = Instantiate(recipeTemplate, container);
            recipeTransform.gameObject.SetActive(true);
            recipeTransform.Find("RecipeNameText").GetComponent<TMPro.TextMeshProUGUI>().text = recipeSO.recipeName;

            Transform recipeIconContainer = recipeTransform.Find("IconContainer");
            Transform recipeIconTemplate = recipeIconContainer != null ? recipeIconContainer.Find("IconTemplate") : null;

            if (recipeIconContainer == null) recipeIconContainer = iconContainer;
            if (recipeIconTemplate == null) recipeIconTemplate = iconTemplate;

            if (recipeIconContainer == null || recipeIconTemplate == null)
            {
                continue;
            }

            recipeIconTemplate.gameObject.SetActive(false);

            foreach (Transform child in recipeIconContainer)
            {
                if (child == recipeIconTemplate) continue;
                Destroy(child.gameObject);
            }

            foreach (KitchenObjectSO kitchenObjectSO in recipeSO.kitchenObjectSOList)
            {
                Transform iconTransform = Instantiate(recipeIconTemplate, recipeIconContainer);

                iconTransform.gameObject.SetActive(true);
                var img = iconTransform.GetComponent<UnityEngine.UI.Image>();

                if (img != null) img.sprite = kitchenObjectSO.sprite;
            }
        }
    }
}