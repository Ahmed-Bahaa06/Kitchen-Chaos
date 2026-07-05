using System.Collections.Generic;
using System;
using UnityEngine;

public class PlateCompleteVisual : MonoBehaviour
{
    [Serializable]
    public struct KitchenObjectSO_GameObject
    {
        public KitchenObjectSO kitchenObjectSO;
        public GameObject visualGameObject;
    }

    [SerializeField] private List<KitchenObjectSO_GameObject> kitchenObjectSOGameObjectList;
    [SerializeField] private PlateKitchenObject plateKitchenObject;


    private void Start()
    {
        plateKitchenObject.OnIngredientAdded += PlateKitchenObject_OnIngredientAdded;
    }

    private void PlateKitchenObject_OnIngredientAdded(object sender, PlateKitchenObject.OnIngredientAddedEventArgs e)
    {
        foreach (KitchenObjectSO_GameObject obj in kitchenObjectSOGameObjectList)
        {
            if (obj.kitchenObjectSO == e.kitchenObjectSO)
            {
                obj.visualGameObject.SetActive(true);
            }
        }
    }
}
