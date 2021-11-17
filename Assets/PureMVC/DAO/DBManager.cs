using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using UnityEngine.Networking;
using SYFramework;
public class DBManager : Single<DBManager>
{

	#region 字段
	//private SqliteConnection mSqlConn;
	//private SqliteCommand mSqlComd;
	//private SqliteDataReader mSqlDataReader;

	private string dataPath;
	private string mStremingPath;
	private string mFilePath;
	private string dataName="Test.db";
	#endregion


	#region 方法
	public void InitDB()
	{
		//沙盒路径
		mFilePath = Application.persistentDataPath + "/" + dataName;
		dataPath = "URI=file:" + mFilePath;
		mStremingPath = "jar:file://" + Application.dataPath + "!assets/" + dataName;
		//pc端:可读可写     移动端:只读不可写
		if (Application.platform==RuntimePlatform.WindowsEditor)
		{
			mFilePath = Application.streamingAssetsPath + "/" + dataName;
			dataPath = "Data Sourec=" + mFilePath;
		}
		
	}
	/// <summary>
	/// 打开数据库
	/// </summary>
	public void Open()
	{
		//if (mSqlConn==null)
		//{
		//	InitDB();
		//	if (File.Exists(mFilePath))
		//	{
		//		//UnityWebRequest unityWebRequest = UnityWebRequest.Get(mStremingPath);
		//		//unityWebRequest.SendWebRequest();
		//		//if (!unityWebRequest.isHttpError||!unityWebRequest.isHttpError)
		//		//{

		//		//}
		//		WWW www = new WWW(mStremingPath);
		//		while (!www.isDone)
		//		{

		//		}
		//		File.WriteAllBytes(mFilePath, www.bytes);
		//	}
		//	mSqlConn = new SqliteConnection(dataPath);
		//}
		
		//mSqlConn.Open();
		//mSqlComd =mSqlConn.CreateCommand();
		
	}
	/// <summary>
	/// 关闭数据库
	/// </summary>
	public void Close()
	{
		//if (mSqlConn!=null)
		//{
		//	mSqlConn.Clone();
		//	//mSqlConn.Dispose();//释放内存  
		//}
		//if (mSqlComd!=null)
		//{
		//	mSqlComd.Dispose();//释放内存
		//}
	}
	#endregion

	public void Test()
	{
		Open();
	}

}
