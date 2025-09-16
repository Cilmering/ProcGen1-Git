using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    public int randomSeed;

    public GameObject snowRock1;
    public GameObject snowRock2;

    public GameObject rock1;
    public GameObject rock2;

    public GameObject tree1;
    public GameObject tree2;

    public float snowThreshold = 15f;
    public float rockThreshold = 5f;
    public float treeThreshold = -7f;

    // x 0 to 128; z 0 to 128
    private float areaXMin = 0;
    private float areaXMax = 128;
    private float areaZMin = 0;
    private float areaZMax = 128;

    public int numberOfObjects = 100;

    public float raycastHeight = 100f; // Height from which rays are cast

    void Start()
    {
        //GenerateObjects();
    }

    public void GenerateObjects()
    {
        Random.InitState(randomSeed);

        for (int i = 0; i < numberOfObjects; i++)
        {
            float x = Random.Range(areaXMin, areaXMax);
            float z = Random.Range(areaZMin, areaZMax);
            Vector3 origin = new Vector3(x, raycastHeight, z);

            if (Physics.Raycast(origin, Vector3.down, out RaycastHit hit))
            {
                float y = hit.point.y;
                GameObject prefabToSpawn = null;

                if (y > snowThreshold)
                {
                    prefabToSpawn = (Random.value < 0.5f) ? snowRock1 : snowRock2;
                } else if (y > rockThreshold)
                {
                    prefabToSpawn = (Random.value < 0.5f) ? rock1 : rock2;
                } else if (y > treeThreshold)
                {
                    prefabToSpawn = (Random.value < 0.5f) ? tree1 : tree2;
                }

                if (prefabToSpawn != null)
                {
                    Instantiate(prefabToSpawn, hit.point, Quaternion.identity, transform);
                }
            }
        }
    }

    void Update()
    {

    }
}