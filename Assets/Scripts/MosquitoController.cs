using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MosquitoController : MonoBehaviour
{
    [SerializeField] float initialLimitY;
    [SerializeField] float finalLimitY;
   
    [SerializeField] float initialLimitX;
    [SerializeField] float finalLimitX;

    [SerializeField] GameObject targetGameObject;
    [SerializeField] float speed;

    bool canMove = false;

    float time = 0;

    float x, y;

    int life;

    //SpriteRenderer sr;
    BoxCollider2D boxCollider;
    public Image img;


    void Start()
    {
        img = GetComponent<Image>();
        //sr = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        life = 3;
        StartMovement();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            canMove = true;

        if (canMove)
        {
            //time += Time.deltaTime;

            GetComponent<RectTransform>().anchoredPosition = Vector2.MoveTowards(GetComponent<RectTransform>().anchoredPosition, targetGameObject.GetComponent<RectTransform>().anchoredPosition, speed);

            if (transform.position == targetGameObject.transform.position)
            {
                x = UnityEngine.Random.Range(initialLimitX, finalLimitX);
                y = UnityEngine.Random.Range(initialLimitY, finalLimitY);
   

                targetGameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(x, y);
            }

            //else
            //{
            //    x = 10.65f;
            //    y = 0.32f;

            //    targetGameObject.transform.position = new Vector2(x, y);

            //    transform.position = Vector2.MoveTowards(transform.position, targetGameObject.transform.position, speed);
            //}
        }
    }
    void StartMovement()
    {
        x = UnityEngine.Random.Range(initialLimitX, finalLimitX);
        y = UnityEngine.Random.Range(initialLimitY, finalLimitY);

        targetGameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(x, y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ColliderHit"))
        {
            if (life >= 1)
                StartCoroutine(TakeDamage());
            else
            {
                CheckForOtherMosquitos();
                Destroy(gameObject);
            }
        }
    }

    private IEnumerator TakeDamage()
    {
        life--;
        boxCollider.enabled = false;
        img.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        img.color = Color.white;

        img.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        img.color = Color.white;

        img.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        img.color = Color.white;

        img.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        img.color = Color.white;
        boxCollider.enabled = true;
    }

    private void CheckForOtherMosquitos()
    {
        List<GameObject> mosquitos = GameObject.FindGameObjectsWithTag("Mosquito").ToList();

        if (mosquitos.Count == 1) //Ainda tem que ter um, que é o mosquito atual!
        {
            var actualLevelIndex = SceneManager.GetActiveScene().buildIndex;
            var exclude = new HashSet<int>() { actualLevelIndex };
            var range = Enumerable.Range(1, 3).Where(x => !exclude.Contains(x));
            var rand = new System.Random();
            int index = rand.Next(0, 3 - exclude.Count);
            SceneManager.LoadScene(range.ElementAt(index));
        }
            
    }
}