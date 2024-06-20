using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class DragAndDrop : MonoBehaviour,IDragHandler, IDropHandler
{
    private RectTransform rectTransform;

    [SerializeField] RectTransform upCollisionCheck;
    [SerializeField] RectTransform downCollisionCheck;
    [SerializeField] RectTransform leftCollisionCheck;
    [SerializeField] RectTransform rightCollisionCheck;

    private Dictionary<string, Dictionary<string, System.Action>> actions;

    private Collider2D objCollider;

    float controleVelocidade = 14/4;

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta /controleVelocidade;
        //transform.position = Input.mousePosition;
        objCollider.isTrigger = false;
    }
    void Start()
    {
        objCollider = GetComponent<Collider2D>();

        rectTransform = GetComponent<RectTransform>();

        actions = new Dictionary<string, Dictionary<string, System.Action>>()
        {
            { "Vidro", new Dictionary<string, System.Action>()
                {
                    { "Vidro", () => ManageCorrectAction()  },
                    { "Metal", () =>  ManageWrongAction()  },
                    { "Plastico", () =>  ManageWrongAction()   },
                    { "Papel", () => ManageWrongAction() },
                }
            },
            { "Papel", new Dictionary<string, System.Action>()
                {
                    { "Vidro", () => ManageWrongAction() },
                    { "Metal", () => ManageWrongAction() },
                    { "Plastico", () => ManageWrongAction() },
                    { "Papel", () => ManageCorrectAction() },
                }
            },
            { "Plastico", new Dictionary<string, System.Action>()
                {
                    { "Vidro", () => ManageWrongAction() },
                    { "Metal", () => ManageWrongAction() },
                    { "Plastico", () => ManageCorrectAction() },
                    { "Papel", () => ManageWrongAction() },
                }
            },
            { "Metal", new Dictionary<string, System.Action>()
                {
                    { "Vidro", () => ManageWrongAction() },
                    { "Metal", () => ManageCorrectAction() },
                    { "Plastico", () => ManageWrongAction() },
                    { "Papel", () => ManageWrongAction() },
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

        if (objCollider != null)
        {
            objCollider.isTrigger = true;
        }
    }

    public void ManageCorrectAction()
    {
        //A quantidade de cada lixeira + 1 (que é o último objeto a ser contabilizado)
        if (GameObject.FindGameObjectsWithTag("Papel").Length +
            GameObject.FindGameObjectsWithTag("Plastico").Length +
            GameObject.FindGameObjectsWithTag("Vidro").Length +
            GameObject.FindGameObjectsWithTag("Metal").Length == 5)
            SceneManager.LoadScene(Random.Range(1, 3));

        Destroy(gameObject);
    }

    public void ManageWrongAction()
    {
        SceneManager.LoadScene(3);
    }
}