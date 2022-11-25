using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class DBAccess2 : MonoBehaviour
{
    
    public GameObject BestTimeText;

    public void OnClick()
    {

        BestTimeText = GameObject.Find("BestTimeText");


        StartCoroutine("Access");
      
    }


    private IEnumerator Access()
    {
        
      


        StartCoroutine(Post("http://localhost/dbaccess/selecttest1.php"));
      

        yield return 0;
    }

    private IEnumerator Post(string url, Dictionary<string, string> post)
    {

        using (UnityWebRequest www = UnityWebRequest.Post)
        {


            yield return www.SendWebRequest();

            BestTimeText.GetComponent<Text>().text = www.downloadHandler.text;



        }


    }
}



    

