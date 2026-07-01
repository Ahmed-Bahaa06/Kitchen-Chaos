using System;
using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{
    [SerializeField] private BaseCounter baseCounter;
    [SerializeField] private GameObject[] visualGameObjects;

    void Start()
    {
        Player.Instance.OnSelectedCounterChanged += Player_OnSelectedCounterChanged;
    }

    private void Player_OnSelectedCounterChanged(object sender, Player.OnSelectedCounterChangedEventArgs e)
    {
        if (e.selectedCounter == baseCounter)
        {
            show();
        }
        else
        {
            hide();
        }
    }
    private void show()
    {
        foreach (GameObject visualGameObject in visualGameObjects)
            visualGameObject.SetActive(true);
    }
    private void hide()
    {
        foreach (GameObject visualGameObject in visualGameObjects)
            visualGameObject.SetActive(false);
    }
    }
