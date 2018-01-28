using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SingletonBase<T>: MonoBehaviour
    where T : SingletonBase<T>
{
    protected static T _instance;
    public static T Instance
    {
        get
        { 
			if (_instance==null)
			{
				_instance = FindObjectOfType (typeof (T)) as T;
				if (_instance == null)
				{
					Debug.LogError("There needs to be one active " + typeof(T).ToString()+ " script on a GameObject in your scene.");
				}
				else
				{
					_instance.Init();
				}
			}

            return _instance;
        }   
    }
	public static bool HasInstance()
	{
		return _instance != null;
	}
	protected abstract void Init();
}
