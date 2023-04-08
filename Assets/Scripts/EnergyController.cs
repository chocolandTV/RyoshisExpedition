using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyController : MonoBehaviour
{
    public float maxEnergy = 100f; // Maximum energy that the object can store
    public float energy = 0f; // Current energy level
    public float energyGenerationRate = 5f; // Amount of energy generated per second
    public float energyConsumptionRate = 10f; // Amount of energy consumed per second
    public bool canConductElectricity = true; // Whether the object can conduct electricity

    // Update is called once per frame
    void Update()
    {
        // Generate energy
        energy += energyGenerationRate * Time.deltaTime;

        // Consume energy if the object can conduct electricity
        if (canConductElectricity)
        {
            energy -= energyConsumptionRate * Time.deltaTime;
        }

        // Keep energy within the maximum and minimum limits
        energy = Mathf.Clamp(energy, 0f, maxEnergy);
    }

    // Function to add energy to the object
    public void AddEnergy(float amount)
    {
        energy += amount;
        energy = Mathf.Clamp(energy, 0f, maxEnergy);
    }

    // Function to remove energy from the object
    public void RemoveEnergy(float amount)
    {
        energy -= amount;
        energy = Mathf.Clamp(energy, 0f, maxEnergy);
    }

    // Function to check if the object has enough energy to perform an action
    public bool HasEnoughEnergy(float amount)
    {
        return energy >= amount;
    }
}
