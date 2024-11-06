using UnityEngine;

public class DoorsScript : MonoBehaviour
{
    public GameObject doorL;
    public GameObject doorR;
    public bool activated = false;

    private float speed;

    // Update is called once per frame
    void Update()
    {
        if (activated)
        {
            speed = FindObjectOfType<GameManager>().gameSpeed;
            if (doorL.transform.position.x < -10)
            {
                doorL.transform.position += new Vector3(0.26f * Time.deltaTime * speed, 0, 0);
            }
            if (doorR.transform.position.x > 0)
            {
                doorR.transform.position += new Vector3(-0.26f * Time.deltaTime * speed, 0, 0);
            }
        }
    }



}
