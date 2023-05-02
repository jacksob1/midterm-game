using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PowerUp", menuName = "PowerUp")]
public class PowerUp : ScriptableObject, IVisitor
{
    public string powerupName;
    public GameObject powerupPrefab;
    public string powerupDescription;

    [Tooltip("Fully healed shield")]
    public bool healShield;

    [Range(0f, 50f)]
    [Tooltip("Boost Turbo Settings up to 50mph")]
    public float turboBoost;

    [Range(0f, 25f)]
    [Tooltip("Boost Weapon Range up to 25 units")]
    public int weaponRange;

    [Range(0f, 50f)]
    [Tooltip("Boost Weapon Strength up to 50%")]
    public int weaponStrength;
    public void Visit(BikeShield bikeShield)
    {
        if (healShield) bikeShield.health = 100f;
    }

    public void Visit(BikeEngine bikeEngine)
    {
        float boost = bikeEngine.turboBoost + turboBoost;
        bikeEngine.turboBoost = Mathf.Clamp(boost, 0, bikeEngine.maxTurboBoost);
    }

    public void Visit(BikeWeapon bikeWeapon)
    {
        int range = bikeWeapon.range + weaponRange;
        bikeWeapon.range = (int)Mathf.Clamp(range, 0, bikeWeapon.maxRange);

        float strength = bikeWeapon.strength + Mathf.Round(bikeWeapon.strength * weaponStrength / 100);
        bikeWeapon.strength = Mathf.Clamp(strength, 0f, bikeWeapon.maxStrength);
    }
}
