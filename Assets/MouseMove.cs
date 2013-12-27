using UnityEngine;
using System.Collections;

public class MouseMove : MonoBehaviour
{

   // Use this for initialization
   void Start()
   {

   }

   // Update is called once per frame
   void Update()
   {
      //Debug.Log(Input.mousePosition);

      //transform.Translate( .0f, .01f, .0f );

      //transform.localPosition = Camera.main.ScreenToWorldPoint( Input.mousePosition );

      var prevZ = transform.position.z;
      transform.position = Camera.main.ScreenToWorldPoint( Input.mousePosition );
      transform.position = new Vector3( transform.position.x, transform.position.y, prevZ );
   }
}