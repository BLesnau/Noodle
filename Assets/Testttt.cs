using UnityEngine;
using System.Collections;

public class Testttt : MonoBehaviour
{
   private int Width = 100;
   private int Height = 50;
   public Color Color = Color.grey;

   // Use this for initialization
   void Start()
   {
      Width = (int) transform.localScale.x;
      Height = (int) transform.localScale.y;
      
      //transform.localScale = new Vector3( Width, Height, transform.localScale.z );

      //var r = renderer as SpriteRenderer;
      //if ( r )
      //{
      //   r.color = Color;
      //}

      var tex = new Texture2D( Width, Height );
      for ( int i = 0; i < Width; i++ )
      {
         for ( int j = 0; j < Height; j++ )
         {
            tex.SetPixel( i, j, Color );
         }
      }
      tex.Apply();

      renderer.material.mainTexture = tex;
      //renderer.material.color = Color;
   }

   // Update is called once per frame
   void Update()
   {

      //Texture2D tex = new Texture2D( Width, Height );
      //for ( int i = 0; i < Width; i++ )
      //{
      //   for ( int j = 0; j < Height; j++ )
      //   {
      //      tex.SetPixel( i, j, Color );
      //   }
      //}
      //tex.Apply();

      //renderer.material.mainTexture = tex;
      //renderer.material.color = Color;

      //Debug.Log( this.renderer.bounds.size.x.ToString() + " " + this.renderer.bounds.size.y.ToString() );

      //var w = this.renderer.material.GetTexture().width;
      //var h = this.renderer.material.GetTexture().height;

      //Debug.Log( w );
      //Debug.Log( h );

      //Debug.Log("HEY");
   }
}
