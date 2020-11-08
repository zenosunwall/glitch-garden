using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseHealthDisplay : MonoBehaviour
{
    [SerializeField] int baseHealth;

    Text baseHealthDisplay;

    private void Start()
    {
        baseHealthDisplay = GetComponent<Text>();
        AddJustHealthToDifficulty();
        UpdateDisplay();
    }

    private void AddJustHealthToDifficulty()
    {
        baseHealth = (int) (baseHealth / PlayerPrefsController.GetDifficulty());
        if (baseHealth <= 0)
        {
            baseHealth = 1;
        }
    }

    public void DamageBase(int damage)
    {
        baseHealth -= damage;
        if (baseHealth <= 0)
        {
            baseHealth = 0;
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        baseHealthDisplay.text = baseHealth.ToString();
    }

}
