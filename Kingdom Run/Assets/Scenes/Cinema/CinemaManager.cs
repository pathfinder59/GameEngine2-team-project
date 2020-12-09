using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CinemaManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] PlayableDirector playableDirector;
    private void Update()
    {
        if(playableDirector.time == 0)
        {

        }
    }
}
