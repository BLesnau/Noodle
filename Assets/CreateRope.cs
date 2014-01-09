using System;
using UnityEngine;

public class CreateRope : MonoBehaviour
{
   public Vector2 _segmentSize = new Vector2( 1, 1 );
   public int _numberOfSegments = 25;
   public float _segmentMass = 0.5f;
   public float _segmentGravityScale = 0.25f;
   public RigidbodyInterpolation2D _segmentRigidbodyInterpolation = RigidbodyInterpolation2D.Interpolate;
   public CollisionDetectionMode2D _segmentCollisionDetectionMode = CollisionDetectionMode2D.None;
   public bool _connectedSegmentsCollide = false;
   public float _segmentRotationAllowed = 60.0f;
   public float _springDampeningRatio = 0.5f;
   public float _springFrequency = 100.0f;

   // Use this for initialization
   void Start()
   {
      HingeJoint2D prevHingeJoint = null;
      SpringJoint2D prevSpringJoint = null;

      for ( int i = 0; i < _numberOfSegments; i++ )
      {
         var obj = new GameObject( String.Format( "RopeSegment-{0}", i ), new Type[]
         {
            typeof( BoxCollider2D ), typeof( Rigidbody2D )
         } );
         obj.transform.parent = transform;
         obj.transform.position = transform.position + new Vector3( i * _segmentSize.x, 0, 0 );

         var boxCollider = obj.GetComponent( typeof( BoxCollider2D ) ) as BoxCollider2D;
         if ( boxCollider != null )
         {
            boxCollider.size = _segmentSize;
         }

         var rigidBody = obj.GetComponent( typeof( Rigidbody2D ) ) as Rigidbody2D;
         if ( rigidBody != null )
         {
            rigidBody.mass = _segmentMass;
            rigidBody.drag = 0;
            rigidBody.angularDrag = 0;
            rigidBody.gravityScale = _segmentGravityScale;
            rigidBody.interpolation = _segmentRigidbodyInterpolation;
            rigidBody.collisionDetectionMode = _segmentCollisionDetectionMode;

            if ( i > 0 && prevHingeJoint != null )
            {
               prevHingeJoint.connectedBody = rigidBody;
            }

            if ( i > 0 && prevSpringJoint != null )
            {
               prevSpringJoint.connectedBody = rigidBody;
            }
         }

         if ( i < _numberOfSegments - 1 )
         {
            obj.AddComponent<HingeJoint2D>();
            var hingeJointComp = obj.GetComponent( typeof( HingeJoint2D ) ) as HingeJoint2D;
            if ( hingeJointComp != null )
            {
               hingeJointComp.collideConnected = _connectedSegmentsCollide;
               hingeJointComp.anchor = new Vector2( _segmentSize.x / 2.0f, 0 );
               hingeJointComp.connectedAnchor = new Vector2( _segmentSize.x / -2.0f, 0 );
               hingeJointComp.useLimits = true;
               hingeJointComp.limits = new JointAngleLimits2D
               {
                  min = _segmentRotationAllowed / -2.0f,
                  max = _segmentRotationAllowed / 2.0f
               };
            }

            prevHingeJoint = hingeJointComp;
         }

         if ( i < _numberOfSegments - 1 )
         {
            obj.AddComponent<SpringJoint2D>();
            var springJoint = obj.GetComponent( typeof( SpringJoint2D ) ) as SpringJoint2D;
            if ( springJoint != null )
            {
               springJoint.collideConnected = _connectedSegmentsCollide;
               //springJoint.anchor = new Vector2( _segmentSize.x / 2.0f, 0 );
               //springJoint.connectedAnchor = new Vector2( _segmentSize.x / -2.0f, 0 );
               springJoint.anchor = new Vector2( 0, 0 );
               springJoint.connectedAnchor = new Vector2( 0, 0 );
               springJoint.dampingRatio = _springDampeningRatio;
               springJoint.frequency = _springFrequency;
            }

            prevSpringJoint = springJoint;
         }
      }
   }

   // Update is called once per frame
   void Update()
   {

   }
}