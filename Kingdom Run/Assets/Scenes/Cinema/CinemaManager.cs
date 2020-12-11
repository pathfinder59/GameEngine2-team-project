using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class CinemaManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] PlayableDirector playableDirector;
    private void Update()
    {
        if(playableDirector.duration-0.1f <= playableDirector.time)
        {
            SceneManager.LoadScene("KindomRun");
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("KindomRun");
        }
    }
}
