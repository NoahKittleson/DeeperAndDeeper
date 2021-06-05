using UnityEngine;

public class Chunk : MonoBehaviour
{
    public Vector2 size = new Vector2(1, 1);

    [SerializeField]
    private GameObject backgroundPrefab;
    [SerializeField]
    private GameObject boulderPrefab;

    public void Start()
    {
        var bg = Instantiate(backgroundPrefab, this.transform);

        var boulderCount = Random.Range(1, 10);
        for (int i = 0; i < boulderCount; i++)
        {
            this.CreateBoulder();
        }
    }

    private void CreateBoulder()
    {
        var x = Random.Range(0, size.x) - size.x / 2;
        var y = Random.Range(0, size.y) - size.y / 2;
        var position = new Vector3(x, y, -0.5f) + this.transform.position;
        var boulder = Instantiate(boulderPrefab, position, Quaternion.identity, this.transform);
    }
}
