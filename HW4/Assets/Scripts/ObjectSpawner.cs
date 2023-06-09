using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] GameObject circle_prefab;
    [SerializeField] GameObject capsule_prefab;
    [SerializeField] GameObject square_prefab;
    [SerializeField] GameObject diamond_prefab;
    [SerializeField] GameObject anvil_prefab;
    float respawn_time = 6f;
    float time_to_respawn = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool game_over = gameObject.GetComponent<GameManager>().GetGameOver();
        if (!game_over) { 
            time_to_respawn -= Time.deltaTime;
            if (time_to_respawn <= 0) {
                GameObject new_obj;
                int random = Random.Range(0,101);

                if (random <= 15)
                {
                    new_obj = Instantiate(circle_prefab);
                }
                else if (random <= 30) {
                    new_obj = Instantiate(capsule_prefab);
                }
                else if (random <= 63)
                {
                    new_obj = Instantiate(square_prefab);
                }
                else if (random <= 95)
                {
                    new_obj = Instantiate(diamond_prefab);
                }
                else
                {
                    new_obj = Instantiate(anvil_prefab);
                }
                float new_X = Random.Range(-7f, 7f);
                float new_Y = Random.Range(7f, 10f);

                new_obj.transform.position = new Vector3(new_X, new_Y, new_obj.transform.position.z);
                time_to_respawn = respawn_time;
            }
        }
    }
}
