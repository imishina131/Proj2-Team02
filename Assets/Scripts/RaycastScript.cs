using UnityEngine;
using UnityEngine.SceneManagement;

public class RaycastScript : MonoBehaviour
{
    Camera cam;
    public LayerMask mask;
    public GameObject losePanel;
    public PlayerInteractions player;

    public GameObject timerObject;

    Animator animator;

    public LoseAndExplode lose;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       cam = Camera.main; 
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10f;
        mousePos = cam.ScreenToWorldPoint(mousePos);

        //Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 100f, mask) && player.typing == false)
        {
            Debug.Log("hit eyes");
            hit.collider.gameObject.GetComponent<LoseAndExplode>().Explode();
        }
    }

}
