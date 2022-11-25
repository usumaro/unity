using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class DBAccess1 : MonoBehaviour
{
    
    public GameObject Name;
    public GameObject PlaceHolder;
    public GameObject Time;

    public void Button_Push()
    {
        
        Name = GameObject.Find("Name");
        PlaceHolder = GameObject.Find("PlaceHolder");
        
        Time = GameObject.Find("Time");

        if (string.IsNullOrEmpty(Name.name))
        {PlaceHolder.GetComponent<Text>().text = "名前が空欄です";
        }else{ StartCoroutine("Access"); }
      
    }


    private IEnumerator Access()
    {
        Dictionary<string, string> dic = new Dictionary<string, string>();
        dic.Add("time1", Time.GetComponent<Text>().text);
        dic.Add("name1", Name.GetComponentInChildren<InputField>().text);


        StartCoroutine(Post("http://localhost/dbaccess/selecttest1.php", dic));
      

        yield return 0;
    }

    private IEnumerator Post(string url, Dictionary<string, string> post)
    {
        WWWForm form = new WWWForm();
        foreach (KeyValuePair<string, string> post_arg in post)
        {
            form.AddField(post_arg.Key, post_arg.Value);
        }

        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();

        }


    }



}



    

