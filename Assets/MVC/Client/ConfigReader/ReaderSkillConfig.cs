using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Reflection;
using System;
using UnityEngine.UI;

/// <summary>
/// 读取技能配置表
/// </summary>
public class ReaderSkillConfig
{

    //技能集合
    public List<SkillConfigInfo> SkillConfigInfosList = new List<SkillConfigInfo>();
    public ReaderSkillConfig(string xmlFilePath)
    {
        //读取xml 文件内容
        TextAsset textAsset = TF_ResourcesFactory.Instance.Load<TextAsset>(xmlFilePath);

        XmlDocument doc = new XmlDocument();
        
        doc.LoadXml(textAsset.text);

        XmlNodeList infoList= doc.SelectSingleNode("SkillConfig").ChildNodes;//获取根节点下面的所有子节点
        
        for (int i = 0; i < infoList.Count; i++)
        {
            string ID = (infoList[i] as XmlElement).GetAttribute("ID");
            SkillConfigInfo skillConfigInfo = new SkillConfigInfo();

            skillConfigInfo.Id = int.Parse(ID);

            Type type = skillConfigInfo.GetType();
            foreach (XmlElement element in infoList[i])
            {
                FieldInfo info = type.GetField(element.Name);
                if (info != null) 
                {
                    //Convert.ChangeType(element.InnerText,info.FieldType) 转换为字段类型
                    info.SetValue(skillConfigInfo,Convert.ChangeType(element.InnerText,info.FieldType)); 
                }
            }
            Debug.Log(skillConfigInfo.Name);
            SkillConfigInfosList.Add(skillConfigInfo);
        }

    }
}

/// <summary>
/// 技能信息表 实体类
/// </summary>
public class SkillConfigInfo
{
    public string Name;//名字
    public int Id;//技能id
    public string IsNormallSkill;//是否是普通技能
    public string SkillName; //技能名字
    public string Level; //技能等级
    public string PrepareTime; //冷却时间

}
