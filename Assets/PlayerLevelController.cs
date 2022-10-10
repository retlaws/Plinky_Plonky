using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevelController : MonoBehaviour
{
    [SerializeField] int playerLevel = 1;
    [SerializeField] int[] scoreUpgradeLevels;

    int nextScoreBarrier;

    WeaponsController weaponsController;

    private void Start()
    {
        nextScoreBarrier = scoreUpgradeLevels[0];
        weaponsController = FindObjectOfType<WeaponsController>();
    }

    public void UpdatePlayerLevel(float currentScore)
    {
        if (playerLevel == scoreUpgradeLevels.Length) { return; }

        if (currentScore == 0) // Player died and resets them to level one
        {
            playerLevel = 1;
            nextScoreBarrier = scoreUpgradeLevels[0];
            weaponsController.ChangeWeapon(playerLevel);
            uiManager.Instance.UpdatePlayerLevelText(playerLevel);
            return;
        }

        if(currentScore < nextScoreBarrier) { return; }

        nextScoreBarrier = scoreUpgradeLevels[playerLevel]; // this is a bit confusing - basically the array is one beihnd the player level which is why this is before the player level up
        playerLevel++;
        weaponsController.ChangeWeapon(playerLevel);
        uiManager.Instance.UpdatePlayerLevelText(playerLevel);

    }
}
