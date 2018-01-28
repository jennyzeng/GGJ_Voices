using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;
public static class DataHelper {

	public static T DeserializeObject<T>(string dataPath, T obj)
	{

		TextAsset textAsset =  Resources.Load(dataPath) as TextAsset;
		if (textAsset==null)
		{
			Debug.LogError("file path "+ dataPath + " does not exist");
			return default(T);
		}
		string dataAsJson = textAsset.text;
		
		obj = JsonConvert.DeserializeObject<T>(dataAsJson);
		return obj;
	}

}
