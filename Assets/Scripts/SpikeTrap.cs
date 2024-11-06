using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    public bool activated;
    private float speed;
    void Update()
    {
        if (activated)
        {
            speed = FindObjectOfType<GameManager>().gameSpeed;
            if (transform.position.y > 10f)
            {
                this.transform.position -= new Vector3(0, 1f * Time.deltaTime * speed, 0);  
            }
        }
        
    }
}
