using UnityEngine;
using System.Collections;

public class ClientVisitor : MonoBehaviour
{
    public PowerUp enginePowerUp;
    public PowerUp shieldPowerUp;
    public PowerUp weaponPowerUp;

    private BikeController _bikeController;

    // Use this for initialization
    void Start()
    {
        _bikeController = gameObject.AddComponent<BikeController>();
    }

    private void OnGUI()
    {
        if (GUILayout.Button("PowerUp Shield"))
            _bikeController.Accept(shieldPowerUp);
        if (GUILayout.Button("PowerUp Engine"))
            _bikeController.Accept(enginePowerUp);
        if (GUILayout.Button("PowerUp Weapon"))
            _bikeController.Accept(weaponPowerUp);

    }
}
