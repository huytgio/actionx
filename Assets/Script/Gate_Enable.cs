using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Gate_Enable : MonoBehaviour
{
    public int allowSoul;
    private int currentsoul;
    private Animator Gate;
    private Collider2D Gate2;
    //public int NextLevel;
    public float x, y;
    public Animator Transition;


    public void checksoul()
    {
        Gate = GetComponent<Animator>();
        Gate2 = GetComponent<Collider2D>();
        
        currentsoul = PlayerStat.playerstats.souls;
        if(currentsoul == allowSoul)
        {
            Gate.SetBool("Full", true);
            Gate2.isTrigger = true;
        }
    }

    private void Update()
    {
        checksoul();
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            other.transform.position = new Vector3(x, y, 0);
            LoadNextLevel();
            
        }

        
    }
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }
    IEnumerator LoadLevel(int LvIndex)
        {
            Transition.SetTrigger("Start");
            SceneManager.LoadScene(LvIndex);
            yield return new WaitForSeconds(2);
            
        }
}
