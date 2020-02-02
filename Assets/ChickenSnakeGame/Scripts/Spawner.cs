using UnityEngine;

namespace ChickenSnakeGame.Scripts
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private GameObject gameObjectToSpawn;
        public SpawnerParameter spawnerParameter;
        private Transform spawnTransform;
        public static Spawner instance;
        private GameObject currentSpawnedGameObject;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            spawnTransform = transform;
        }

        public void Spawn()
        {
            if (currentSpawnedGameObject == null)
            {
                currentSpawnedGameObject = Instantiate(gameObjectToSpawn, spawnTransform.position, Quaternion.identity);
                spawnerParameter.spawnCount++;
            }
        }
    
    
    }
}