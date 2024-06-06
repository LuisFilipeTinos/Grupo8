using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour,IDragHandler, IDropHandler
{
    private RectTransform rectTransform;

    [SerializeField] RectTransform upCollisionCheck;
    [SerializeField] RectTransform downCollisionCheck;
    [SerializeField] RectTransform leftCollisionCheck;
    [SerializeField] RectTransform rightCollisionCheck;

    private Dictionary<string, Dictionary<string, System.Action>> actions;

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / 3;
        //transform.position = Input.mousePosition;
    }

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        actions = new Dictionary<string, Dictionary<string, System.Action>>()
        {
            { "Vidro", new Dictionary<string, System.Action>()
                {
                    { "Vidro", () => Destroy(gameObject) },
                    { "Metal", () => { Destroy(gameObject); /* Link para aba de perca de pontos */ } },
                    { "Plastico", () => { Destroy(gameObject); /* Link para aba de perca de pontos */ } },
                    { "Papel", () => { Destroy(gameObject); /* Link para aba de perca de pontos */ } },
                }
            },
            { "Papel", new Dictionary<string, System.Action>()
                {
                    { "Vidro", () => { Destroy(gameObject); /* Link para aba de perca de pontos */ } },
                    { "Metal", () => { Destroy(gameObject); /* Link para aba de perca de pontos */ } },
                    { "Plastico", () => { Destroy(gameObject); /* Link para aba de perca de pontos */ } },
                    { "Papel", () => Destroy(gameObject) },
                }
            },
            { "Plastico", new Dictionary<string, System.Action>()
                {
                    { "Vidro", () => { Destroy(gameObject); /* Link para aba de perca de pontos */ } },
                    { "Metal", () => { Destroy(gameObject); /* Link para aba de perca de pontos */ } },
                    { "Plastico", () => Destroy(gameObject) },
                    { "Papel", () => { Destroy(gameObject); /* Link para aba de perca de pontos */ } },
                }
            },
            { "Metal", new Dictionary<string, System.Action>()
                {
                    { "Vidro", () => { Destroy(gameObject); /* Link para aba de perca de pontos */ } },
                    { "Metal", () => Destroy(gameObject) },
                    { "Plastico", () => Destroy(gameObject) },
                    { "Papel", () => { Destroy(gameObject); /* Link para aba de perca de pontos */ } },
                }
            }
        };
    }

     void Update()
    {
        Debug.DrawLine(rectTransform.position, upCollisionCheck.position);
        Debug.DrawLine(rectTransform.position, downCollisionCheck.position);
        Debug.DrawLine(rectTransform.position, leftCollisionCheck.position);
        Debug.DrawLine(rectTransform.position, rightCollisionCheck.position);
    }

    public void OnDrop(PointerEventData eventData)
    {
        var uphittedTrashcan = Physics2D.Linecast(rectTransform.position, upCollisionCheck.position, 1 << LayerMask.NameToLayer("Trashcan"));
        var downhittedTrashcan = Physics2D.Linecast(rectTransform.position, downCollisionCheck.position, 1 << LayerMask.NameToLayer("Trashcan"));
        var lefthittedTrashcan = Physics2D.Linecast(rectTransform.position, leftCollisionCheck.position, 1 << LayerMask.NameToLayer("Trashcan"));
        var righthittedTrashcan = Physics2D.Linecast(rectTransform.position, rightCollisionCheck.position, 1 << LayerMask.NameToLayer("Trashcan"));

        Debug.DrawLine(rectTransform.position, upCollisionCheck.position);

        RaycastHit2D hittedTrashcan = new RaycastHit2D();

        if (uphittedTrashcan != false && uphittedTrashcan.collider != null)
            hittedTrashcan = uphittedTrashcan;
        else if (downhittedTrashcan != false && downhittedTrashcan.collider != null)
            hittedTrashcan = downhittedTrashcan;
        else if (lefthittedTrashcan != false && lefthittedTrashcan.collider != null)
            hittedTrashcan = lefthittedTrashcan;
        else if (righthittedTrashcan != false && righthittedTrashcan.collider != null)
            hittedTrashcan = righthittedTrashcan;

        if (hittedTrashcan)
        {
            if (actions.ContainsKey(this.transform.tag) &&
                actions[this.transform.tag].ContainsKey(hittedTrashcan.collider.gameObject.tag))
                actions[this.transform.tag][hittedTrashcan.collider.gameObject.tag]();
        }
    }
}