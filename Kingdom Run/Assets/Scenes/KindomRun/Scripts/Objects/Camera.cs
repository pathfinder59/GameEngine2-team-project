using KPU.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Camera : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject checkpoints;
    int nCheckPoint;
    int currentCheckPoint;
    //[SerializeField] List<GameObject> checkpointList;
    void Start()
    {
        EventManager.On("game_ended", ResetProperty);
        nCheckPoint = checkpoints.transform.childCount;
        currentCheckPoint = 0;

        transform.eulerAngles = new Vector3(64.045f, - 0.104f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.State != KPU.State.Playing)
            return;
        if (currentCheckPoint < nCheckPoint)
        {
            Transform target = checkpoints.transform.GetChild(currentCheckPoint);

            transform.position = Vector3.MoveTowards(transform.position, target.position, 4f * Time.deltaTime);

            if (transform.position == target.position)
                currentCheckPoint++;
        }
    }
    private void ResetProperty(object obj)
    {
        transform.position = checkpoints.transform.GetChild(0).transform.position;
        currentCheckPoint = 0;
    }
}
