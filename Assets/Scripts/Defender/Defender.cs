using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    
    [SerializeField] int starCost = 100;

    StarDisplay starDisplay;

    // Start is called before the first frame update
    void Start()
    {
        starDisplay = FindObjectOfType<StarDisplay>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddStars(int amount)
    {
        starDisplay.AddToStars(amount);
    }

    public int GetStarCost()
    {
        return starCost;
    }
}
