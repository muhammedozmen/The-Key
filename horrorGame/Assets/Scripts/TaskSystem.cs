using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TaskSystem : MonoBehaviour
{
    [SerializeField] private OpenLockedChest lockedChest;
    [SerializeField] private Doors secretDoor;
    [SerializeField] private GameObject key;
    [SerializeField] private TextMeshProUGUI task_1;
    [SerializeField] private TextMeshProUGUI task_2;
    [SerializeField] private TextMeshProUGUI task_3;
    [SerializeField] private TextMeshProUGUI task_4;


    private void Update()
    {
        if(key.activeInHierarchy == true)
        {
            task_1.fontStyle = FontStyles.Strikethrough;
            task_1.color = Color.gray;
            task_2.enabled = true;
        }

        if(lockedChest.isOpen == true)
        {
            task_2.fontStyle = FontStyles.Strikethrough;
            task_2.color = Color.gray;
            task_3.enabled = true;
        }

        if(secretDoor.isOpened == true)
        {
            task_3.fontStyle = FontStyles.Strikethrough;
            task_3.color = Color.gray;
            task_4.enabled = true;
        }
    }



}
