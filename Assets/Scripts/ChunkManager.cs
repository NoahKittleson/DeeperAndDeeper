using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class ChunkManager : MonoBehaviour
{
    [SerializeField]
    private Transform reference;
    [SerializeField]
    private GameObject chunkPrefab;

    private Vector2 chunkSize;
    private List<float> loadedChunkYs;
    private Dictionary<float, GameObject> loadedChunksByY;

    private void Awake()
    {
        this.loadedChunkYs = new List<float>();
        this.loadedChunksByY = new Dictionary<float, GameObject>();
    }

    private void Start()
    {
        this.chunkSize = chunkPrefab.GetComponent<Chunk>().size;
    }

    private void Update()
    {
        var nearestChunkY = reference.position.y - reference.position.y % chunkSize.y;

        var activeChunkYs = new List<float> { -2, -1, 0, 1, 2 }.Select(offset => nearestChunkY + offset * chunkSize.y);

        activeChunkYs
            .Where(y => !this.loadedChunkYs.Contains(y))
            .ToList()
            .ForEach(y => this.SpawnChunk(y));

        loadedChunkYs
            .Where(y => !activeChunkYs.Contains(y))
            .ToList()
            .ForEach(y => this.CullChunk(y));
    }

    private void SpawnChunk(float y)
    {
        var spawnPosition = new Vector3(0, y, 0);
        var chunk = Instantiate(chunkPrefab, spawnPosition, Quaternion.identity);
        this.loadedChunksByY[y] = chunk;
        this.loadedChunkYs.Add(y);
    }

    private void CullChunk(float y)
    {
        GameObject.Destroy(this.loadedChunksByY[y]);
        this.loadedChunksByY.Remove(y);
        this.loadedChunkYs.Remove(y);
    }
}
