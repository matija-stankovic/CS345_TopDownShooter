using UnityEngine;
using UnityEngine.UI;

public class WeaponDisplay : MonoBehaviour
{
    private Text weaponText;
    private TankWeapon tankWeapon;

    void Start()
    {
        weaponText = GetComponent<Text>();
        tankWeapon = GameObject.FindWithTag("PlayerTank").GetComponent<TankWeapon>();
    }

    void Update()
    {
        if (tankWeapon != null)
        {
            weaponText.text = "Current Weapon: " + tankWeapon.currentWeapon.ToString();
        }
    }
}