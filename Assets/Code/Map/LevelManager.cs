using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private int playerCurLayer;

    public Player player;
    public LayerMask playerLayerMask;

    public LTpoint[] TEnterance;
    public Transform[] TExit;
    public GameObject[] MLayers;
    public Transform[] FalloffMapPoint;
    

    private static readonly LevelManager instance = new LevelManager();

    static LevelManager()
    {

    }
    private LevelManager()
    {

    }
    public static LevelManager Instance { get { return instance; } }


    private void Start()
    {
        playerCurLayer = 0;
        SetLayerActive();


    }
    public void SetLayerActive()
    {
        for (int i = 0; i < MLayers.Length; i++)
        {
            if(MLayers[i] == MLayers[playerCurLayer])
            {
                MLayers[i].SetActive(true);
            }
            else
            {
                MLayers[i].SetActive(false);
            }
        }
    }

   public void RelocatePlayer(int PMapLayer)
    {
        playerCurLayer = PMapLayer;
        SetLayerActive();
        player.transform.position = TExit[PMapLayer].transform.position;
    }
    public void ResetCharacterFromFall(Transform Tpoint)
    {

    }
   

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(TEnterance[0].transform.position, 2);
    }

 

}
