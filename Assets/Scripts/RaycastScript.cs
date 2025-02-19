using UnityEngine;

public class RaycastScript : MonoBehaviour
{
    Camera cam;
    public LayerMask mask;
    public GameObject losePanel;
    public PlayerInteractions player;
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
            losePanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
