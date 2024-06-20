using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelSetterController : MonoBehaviour
{
    ActualLevelController actualLevelController;
    [SerializeField] TextMeshProUGUI levelLabel;

    // Start is called before the first frame update
    void Start()
    {
        actualLevelController = GameObject.FindGameObjectWithTag("ActualLevelManager").GetComponent<ActualLevelController>();

        actualLevelController.level++;
        levelLabel.text = "Nível " + actualLevelController.level.ToString();
    }
}
