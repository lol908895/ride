
using UnityEngine;
public class PipeSpawner : MonoBehaviour
{
    private float timer;
    public GameObject pipe;
    public float timeSpawn;
    public float height;

    void Start()
    {
        Instantiate(pipe, new Vector3(transform.position.x, 0, 0), transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        var top = transform.position.y + height;
        var down = transform.position.y - height;
        if (timer > timeSpawn)
        {
            Instantiate(pipe, new Vector3(transform.position.x, Random.Range(down,top), 0), transform.rotation);
            timer = 0;
        }
    }
}
