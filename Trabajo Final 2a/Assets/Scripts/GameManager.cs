using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int kills;
    public TextMeshProUGUI killsText;

    // Start is called before the first frame update
    void Start()
    {
        UpdateKills(0);
        kills = 0;
    }

    // Update is called once per frame
    void Update()
    {
        killsText.text = $"Kills: {kills}";
    }

    // Indica que los kills se actualizan con los puntos obtenidos
    public void UpdateKills(int pointsToAdd)
    {
        kills += pointsToAdd;
        killsText.text = $"Kills: {kills}";
    }
}
