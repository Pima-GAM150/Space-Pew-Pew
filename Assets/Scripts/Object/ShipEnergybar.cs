using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipEnergybar : MonoBehaviour {

    public GameObject energyBar;
    public float startingYScale;

    public void changeEnergyBar(float currentEnergy, float maxEnergy)
    {
        energyBar.GetComponent<RectTransform>().localScale = new Vector3(0.02f, (currentEnergy / maxEnergy) * startingYScale, 10f);
    }
}
