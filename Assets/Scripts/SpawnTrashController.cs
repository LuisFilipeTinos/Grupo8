using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrashController : MonoBehaviour
{
    [SerializeField] List<GameObject> objectsList;
    [SerializeField] GameObject canvas;

    [SerializeField] float initialXPosition;
    [SerializeField] float finalXPosition;
    [SerializeField] float initialYPosition;
    [SerializeField] float finalYPosition;

    void Start()
    {
        if (objectsList.Count > 0)
        {
            foreach (var element in objectsList)
            {
                var x = Random.Range(initialXPosition, finalXPosition);
                var y = Random.Range(initialYPosition, finalYPosition);

                var randomPos = new Vector2(x, y);

                var objectInstatiated = Instantiate(element);
                objectInstatiated.GetComponent<RectTransform>().anchoredPosition = randomPos;
                objectInstatiated.transform.SetParent(canvas.transform, false);
            }
        }
    }
}
