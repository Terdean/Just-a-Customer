using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuForLoh : MonoBehaviour
{
    public void AhNewShit( int Memenu )
    {
        SceneManager.LoadScene( Memenu );
    }

    public void ScrewIt()
    {
        Application.Quit();
    }
}
