using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

public class SaveLoad {
	public static int Money;

	public static BinaryFormatter binaryFormatter = new BinaryFormatter();

	public static void Save (string saveTag, int Money) {
		MemoryStream memoryStream = new MemoryStream();
		binaryFormatter.Serialize(memoryStream, Money);
		string temp = System.Convert.ToBase64String (memoryStream.ToArray());
		PlayerPrefs.SetString(saveTag, temp);
	}

	public static object Load(string saveTag) {
		string temp = PlayerPrefs.GetString (saveTag);
		if (temp == string.Empty) {
			return null;
		}
		MemoryStream memoryStream = new MemoryStream (System.Convert.FromBase64String (temp));
		return binaryFormatter.Deserialize (memoryStream);
	}

}
