using UnityEngine;
using System.Collections;

public class EaseUtility
{
    public static Vector3 GetEaseInPosition( float time, float duration, Vector3 start, Vector3 end )
    {
        return GetNormalizedEaseInTime( time, duration ) * ( end - start ) + start;
    }

    public static Vector3 GetEaseOutPosition( float time, float duration, Vector3 start, Vector3 end )
    {
        return GetNormalizedEaseOutTime( time, duration ) * ( end - start ) + start;
    }


    public static Vector3 GetEaseInOutPosition( float time, float duration, Vector3 start, Vector3 end )
    {
        return GetNormalizedEaseInOutTime( time, duration ) * ( end - start ) + start;
    }

    public static float GetEaseInOutPosition( float time, float duration, float start, float end )
    {
        return GetNormalizedEaseInOutTime( time, duration ) * ( end - start ) + start;
    }

    public static float GetEaseInOutTime( float time, float duration )
    {
        return GetNormalizedEaseInOutTime( time, duration ) * duration;
    }

    public static float GetNormalizedEaseInOutTime( float time, float duration )
    {
        if ( time >= duration )
        {
            return 1.0f;
        }

        float t = time / ( duration / 2.0f );

        //ease in / out
        if ( t < 1.0f )
        {
            //ease in
            return 0.5f * t * t;
        }
        else
        {
            //ease out
            t -= 1.0f;
            return -0.5f * ( t * ( t - 2.0f ) - 1.0f );
        }
    }

    public static float GetNormalizedEaseInTime( float time, float duration )
    {
        if ( time >= duration )
        {
            return 1.0f;
        }

        float t = time / duration;
        return t * t;
    }

    public static float GetNormalizedEaseOutTime( float time, float duration )
    {
        if ( time >= duration )
        {
            return 1.0f;
        }

        float t = time / duration;
        return -1.0f * t * ( t - 2.0f ) + 0.0f;
    }
}