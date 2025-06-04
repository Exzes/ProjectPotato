using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance; //implementación de patrón singleton simple

    [System.Serializable]
    public class PoolItem //se define una estructura para configurar cada tipo de objeto a pooler
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public List<PoolItem> itemsToPool; //lista que se rellena desde el inspector
    private Dictionary<string, Queue<GameObject>> poolDictionary; //diccionario que asocia cada tag con una queue de gameobjects

    void Awake() //guarda la instancia actual en la variable estática para que sea accesible globalmente
    {
        Instance = this;
    }

    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>(); //inicializa el diccionario

        foreach (var item in itemsToPool) //para cada tipo de objeto configurado en PoolItem, crea una cola nueva
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < item.size; i++) //instancia el size de objetos de ese prefab, los desactiva con el SetActive(false) y los pone en la cola
            {
                GameObject obj = Instantiate(item.prefab);
                obj.SetActive(false); 
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(item.tag, objectPool); //se guarda la cola en el diccionario con la clave tag
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation) //recibe un tag que identifica el tipo de objeto a sacar y recibe una posición
    {
        GameObject objectToSpawn = poolDictionary[tag].Dequeue(); //toma el primer objeto disponible inactivo de la pila

        objectToSpawn.transform.position = position; //pisiciona el objeto en la escena
        objectToSpawn.transform.rotation = rotation;
        objectToSpawn.SetActive(true); //ahora el objeto existe

        Transform visual = objectToSpawn.transform.GetChild(0); //esto resetea la posición y rotación del modelo visual del "hijo"
        visual.localPosition = Vector3.zero;
        visual.localRotation = Quaternion.identity;

        poolDictionary[tag].Enqueue(objectToSpawn); //lo manda de vuelta a la pila

        return objectToSpawn;
    }


    public void DeactivateAll() //función para limpiar la escena al terminar el nivel
    {
        foreach (var queue in poolDictionary.Values)
        {
            foreach (var obj in queue)
            {
                obj.SetActive(false);
            }
        }
    }
}
