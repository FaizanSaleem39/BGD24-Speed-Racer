using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInfoManager : MonoBehaviour
{
    public string manufacturerN;
    public string modelN = "GTR R35";
    public string engineDescription = "V6, Twin Turbo";

    public int vehicleWeight = 1609;
    public int manufacturingYear = 2009;

    public float maxSpeedAcceleration = 0.98f;

    public bool isSedanType = false;
    public bool hasEngineInFront = true;

    public class FuelInfo
    {
        public int currentFuelLevel;

        public FuelInfo(int initialFuel)
        {
            currentFuelLevel = initialFuel;
        }
    }

    public FuelInfo fuelData = new FuelInfo(100);

    void Start()
    {
        Debug.Log("The vehicle model is " + modelN + " by " + manufacturerN + ". It features a " + engineDescription + " engine.");

        EvaluateWeight();

        if (manufacturingYear <= 2009)
        {
            Debug.Log("This model was first introduced in " + manufacturingYear);

            int vehicleAge = CalculateVehicleAge(manufacturingYear);
            Debug.Log("The vehicle is " + vehicleAge + " years old.");
        }
        else
        {
            Debug.Log("This model was introduced after 2009.");
            Debug.Log("Its maximum acceleration is " + maxSpeedAcceleration + " m/s².");
        }

        Debug.Log(AnalyzeVehicleType());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DecreaseFuelLevel();
            DisplayFuelStatus();
        }
    }

    void EvaluateWeight()
    {
        if (vehicleWeight < 1500)
        {
            Debug.Log("The " + modelN + " weighs less than 1500 kg.");
        }
        else
        {
            Debug.Log("The " + modelN + " weighs over 1500 kg.");
        }
    }

    int CalculateVehicleAge(int manufacturingYear)
    {
        return 2023 - manufacturingYear;
    }

    string AnalyzeVehicleType()
    {
        if (isSedanType)
        {
            return "The vehicle is a sedan type.";
        }
        else if (hasEngineInFront)
        {
            return "The vehicle is not a sedan but has a front engine.";
        }
        else
        {
            return "The vehicle is neither a sedan nor does it have a front engine.";
        }
    }

    void DecreaseFuelLevel()
    {
        fuelData.currentFuelLevel -= 10;
    }

    void DisplayFuelStatus()
    {
        switch (fuelData.currentFuelLevel)
        {
            case 70:
                Debug.Log("Fuel level is nearing two-thirds.");
                break;
            case 50:
                Debug.Log("Fuel level is at half capacity.");
                break;
            case 10:
                Debug.Log("Warning! Fuel level is critically low.");
                break;
            default:
                Debug.Log("No significant fuel status to report.");
                break;
        }
    }
}
