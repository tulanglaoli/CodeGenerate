using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Xml;


namespace DotNet.Tools
{
    /// <summary>
    /// XML管理类
    /// </summary>
    public class MyXMLManager
    {
        #region 公有属性
        private XmlDocument _Xmldoc;

        public XmlDocument Xmldoc
        {
            get { return this._Xmldoc; }
        }

        private string filename;

        /// <summary>
        /// 文件名字
        /// </summary>
        public string Filename
        {
            get { return this.filename; }
        }

        private string filepath;

        /// <summary>
        /// 文件绝对路劲
        /// </summary>
        public string FilePath
        {
            get { return this.filepath; }
        } 
        #endregion

        /// <summary>
        /// 初始化(如果不存在就新建一个文件)
        /// </summary>
        /// <param name="path">xml绝对路径</param>
        public MyXMLManager(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    filepath = path;
                    filename = Path.GetFileNameWithoutExtension(path);
                    XmlReaderSettings xs = new XmlReaderSettings();
                    xs.XmlResolver = null;
                    xs.ProhibitDtd = false;
                    XmlReader reader = XmlReader.Create(path, xs);
                    _Xmldoc = new XmlDocument();
                    _Xmldoc.Load(reader);
                }
                else
                {
                    throw new IOException("path is not exist!");
                }
            }
            catch (IOException e)
            {
                throw e;
            }
            catch (XmlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 初始化(如果不存在就新建一个文件)
        /// </summary>
        /// <param name="path">xml绝对路径</param>
        /// <param name="XR"></param>
        /// <param name="ProhibitDtd"></param>
        public MyXMLManager(string path,  bool ProhibitDtd,XmlResolver XR)
        {
            try
            {
                if (File.Exists(path))
                {
                    filepath = path;
                    filename = Path.GetFileNameWithoutExtension(path);
                    XmlReaderSettings xs = new XmlReaderSettings();
                    xs.XmlResolver = XR;
                    xs.ProhibitDtd = ProhibitDtd;
                    XmlReader reader = XmlReader.Create(path, xs);
                    _Xmldoc = new XmlDocument();
                    _Xmldoc.Load(reader);
                }
                else
                {
                    throw new IOException("path is not exist!");
                }
            }
            catch (IOException e)
            {
                throw e;
            }
            catch (XmlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #region 读取方法

        /// <summary>
        /// 临时读取某个文件的某个节点(读取第一个满足条件的节点)
        /// </summary>
        /// <param name="node">节点("/Node/Element[@Attribute='Name']")</param>
        /// <param name="IsSelf">显示自己</param>
        /// <returns></returns>
        public string readXml(string node,bool IsSelf)
        {
            return readXml(_Xmldoc, node, IsSelf);
        }

        /// <summary>
        /// 临时读取某个文件的某个节点(读取第一个满足条件的节点)
        /// </summary>
        /// <param name="node">节点("/Node/Element[@Attribute='Name']")</param>
        /// <returns></returns>
        public string readText(string node)
        {
            return readText(_Xmldoc, node);
        }

        /// <summary>
        /// 临时读取某个文件的某个节点(读取第一个满足条件的节点)
        /// </summary>
        /// <param name="node">节点("/Node/Element[@Attribute='Name']")</param>
        /// <returns></returns>
        public XmlNode readnode(string node)
        {
            return readnode(_Xmldoc, node);
        }

        /// <summary>
        /// 临时读取满足条件的所有节点
        /// </summary>
        /// <param name="node">节点("/Node/Element[@Attribute='Name']")</param>
        /// <returns></returns>
        public XmlNodeList readnodes(string node)
        {
            try
            {
                return Xmldoc.SelectNodes(node);
            }
            catch (XmlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region 插入
        /// <summary>
        /// 插入数据(请注意之后保存)
        /// </summary>
        /// <param name="node">节点("/Node/Element[@Attribute='Name']")</param>
        /// <param name="element">元素名，非空时插入新元素，否则在该元素中插入属性</param>
        /// <param name="attribute">属性名，非空时插入该元素属性值，否则插入元素值</param>
        /// <param name="value">值</param>
        public void Insert(string node, string element, string attribute, string value)
        {
            try
            {
                XmlNode xn = readnode(node);
                Insert(xn, element, attribute, value);
                
            }
            catch (XmlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 插入节点(请注意之后保存)
        /// </summary>
        /// <param name="node">节点("/Node/Element[@Attribute='Name']")</param>
        /// <param name="Insertnode">插入的节点</param>
        /// <param name="value">值</param>
        public void Insert(string node, XmlNode Insertnode)
        {
            try
            {
                XmlNode xn = readnode(node);
                Insert(xn, Insertnode);
            }
            catch(XmlException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 插入多个
        /// </summary>
        /// <param name="node">节点("/Node/Element[@Attribute='Name']")</param>
        /// <param name="element">元素名，非空时插入新元素，否则在该元素中插入属性</param>
        /// <param name="attribute">属性名，非空时插入该元素属性值，否则插入元素值</param>
        /// <param name="value">值</param>
        public void InsertMore(string node, string element, string attribute, string value)
        {
            try
            {
                XmlNodeList XNL = readnodes(node);
                foreach(XmlNode xn in XNL)
                {
                    Insert(xn, element, attribute, value);
                }
            }
            catch (XmlException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 插入多个节点(请注意之后保存)
        /// </summary>
        /// <param name="node">节点("/Node/Element[@Attribute='Name']")</param>
        /// <param name="Insertnode">插入的节点</param>
        /// <param name="value">值</param>
        public void InsertMore(string node, XmlNode Insertnode)
        {
            try
            {
                XmlNodeList XNL = readnodes(node);
                foreach(XmlNode xn in XNL)
                {
                    Insert(xn, Insertnode);
                }
            }
            catch (XmlException e)
            {
                throw e;
            }
        }

        
        #endregion

        #region 更新
        /// <summary>
        /// 修改指定节点的数据
        /// </summary>
        /// <param name="node">节点("/Node/Element[@Attribute='Name']")</param>
        /// <param name="value">值</param>
        public void Update(string node, string value)
        {
            Update(_Xmldoc, node,  value);
        }

        /// <summary>
        /// 修改指定节点的属性值
        /// </summary>
        /// <param name="node">节点</param>
        /// <param name="attribute">属性名，非空时修改该节点属性值，否则修改节点值</param>
        /// <param name="value">值</param>
        /// 使用示列:
        /// XMLProsess.Insert( "/Node", "", "Value")
        /// XMLProsess.Insert( "/Node", "Attribute", "Value")
        public void Update(string node, string attribute, string value)
        {
            Update(_Xmldoc, node,  attribute,  value);
        }


        /// <summary>
        /// 修改多个
        /// </summary>
        /// <param name="node">节点</param>
        /// <param name="attribute">属性名，非空时修改该节点属性值，否则修改节点值</param>
        /// <param name="value">值</param>
        public void UpdateMore(string node, string attribute, string value)
        {
            UpdateMore(_Xmldoc, node, attribute, value);
        }
        #endregion

        #region 删除

        

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="node">节点</param>
        /// <param name="attribute">属性名，非空时删除该节点属性值，否则删除节点值</param>
        /// <param name="value">值</param>
        public void Delete(string node, string attribute)
        {
            
            Delete(_Xmldoc, node, attribute);
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="node">节点</param>
        /// <param name="attribute">属性名，非空时删除该节点属性值，否则删除节点值</param>
        /// <param name="value">值</param>
        public void DeleteMore(string node, string attribute)
        {
            
            DeleteMore(_Xmldoc, node, attribute);
        }
        #endregion

        #region 其他
        /// <summary>
        /// 保存之前修改内容
        /// </summary>
        public void Save()
        {
            Save(Xmldoc, filepath);
        }

        /// <summary>
        /// 取消本次修改
        /// </summary>
        public void reback()
        {
            try
            {
                if (File.Exists(filepath))
                {
                    filename = Path.GetFileNameWithoutExtension(filepath);
                   
                    _Xmldoc = new XmlDocument();
                    _Xmldoc.Load(filepath);
                }
                else
                {
                    throw new IOException("path is not exist!");
                }
            }
            catch (IOException e)
            {
                throw e;
            }
            catch (XmlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

         
        #endregion

        #region 静态方法
        /// <summary>
        /// 临时读取某个文件的某个节点(读取第一个满足条件的节点)
        /// </summary>
        /// <param name="node">节点("/Node/Element[@Attribute='Name']")</param>
        /// <param name="path">文件绝对路径</param>
        /// <returns></returns>
        public static XmlNode read(string node, string path)
        {
            try
            {

                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                return doc.SelectSingleNode(node);
            }
            catch (XmlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 临时读取某个文件的某个节点(读取第一个满足条件的节点)
        /// </summary>
        /// <param name="node">节点("/Node/Element[@Attribute='Name']")</param>
        /// <param name="path">文件绝对路径</param>
        /// <returns></returns>
        public static string readnode(string node, string path)
        {
            try
            {

                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                return doc.SelectSingleNode(node).InnerText;
            }
            catch (XmlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// xml文件转化为dataset
        /// </summary>
        /// <param name="strXmlPath">路径</param>
        /// <returns></returns>
        public static DataSet GetDataSetByXml(string strXmlPath)
        {
            try
            {
                DataSet ds = new DataSet();
                ds.ReadXml(strXmlPath);
                if (ds.Tables.Count > 0)
                {
                    return ds;
                }
                return null;
            }
            catch (DataException e)
            {
                throw e;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        #region 读取方法

        /// <summary>
        /// 临时读取某个文件的某个节点(读取第一个满足条件的节点)
        /// </summary>
        /// <param name="Xmldoc">要处理的节点</param>
        /// <param name="node">节点("/Node/Element[@Attribute='Name']")</param>
        /// <param name="IsSelf">显示自己</param>
        /// <returns></returns>
        public static string readXml(XmlNode Xmldoc,string node, bool IsSelf)
        {
            try
            {

                if (IsSelf)
                    return Xmldoc.SelectSingleNode(node).OuterXml;
                else
                    return Xmldoc.SelectSingleNode(node).InnerXml;
            }
            catch (XmlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 临时读取某个文件的某个节点(读取第一个满足条件的节点)
        /// </summary>
        /// <param name="Xmldoc">要处理的节点</param>
        /// <param name="node">节点("/Node/Element[@Attribute='Name']")</param>
        /// <returns></returns>
        public static string readText(XmlNode Xmldoc, string node)
        {
            try
            {


                return Xmldoc.SelectSingleNode(node).InnerText;
            }
            catch (XmlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 临时读取某个文件的某个节点(读取第一个满足条件的节点)
        /// </summary>
        /// <param name="Xmldoc">要处理的节点</param>
        /// <param name="node">节点("/Node/Element[@Attribute='Name']")</param>
        /// <returns></returns>
        public static XmlNode readnode(XmlNode Xmldoc, string node)
        {
            try
            {
                return Xmldoc.SelectSingleNode(node);
            }
            catch (XmlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 临时读取满足条件的所有节点
        /// </summary>
        /// <param name="Xmldoc">要处理的节点</param>
        /// <param name="node">节点("/Node/Element[@Attribute='Name']")</param>
        /// <returns></returns>
        public static XmlNodeList readnodes(XmlNode Xmldoc, string node)
        {
            try
            {
                return Xmldoc.SelectNodes(node);
            }
            catch (XmlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region 插入

        /// <summary>
        /// 多个插入属性
        /// </summary>
        /// <param name="Xmldoc">要处理的节点</param>
        /// <param name="node">节点("/Node/Element[@Attribute='Name']")</param>
        /// <param name="element">元素名，非空时插入新元素，否则在该元素中插入属性</param>
        /// <param name="attribute">属性名，非空时插入该元素属性值，否则插入元素值</param>
        /// <param name="value">值</param>
        public static void InsertMore(XmlNode Xmldoc, string node, string element, string attribute, string value)
        {
            try
            {
                XmlNodeList XNL = readnodes(Xmldoc,node);
                foreach (XmlNode xn in XNL)
                {
                    Insert(xn, element, attribute, value);
                }
            }
            catch (XmlException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 插入多个节点(请注意之后保存)
        /// </summary>
        /// <param name="Xmldoc">要处理的节点</param>
        /// <param name="node">节点("/Node/Element[@Attribute='Name']")</param>
        /// <param name="Insertnode">插入的节点</param>
        /// <param name="value">值</param>
        public static void InsertMore(XmlNode Xmldoc,string node, XmlNode Insertnode)
        {
            try
            {
                XmlNodeList XNL = readnodes(Xmldoc,node);
                foreach (XmlNode xn in XNL)
                {
                    Insert(xn, Insertnode);
                }
            }
            catch (XmlException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="node">节点</param>
        /// <param name="element">元素名，非空时插入新元素，否则在该元素中插入属性</param>
        /// <param name="attribute">属性名，非空时插入该元素属性值，否则插入元素值</param>
        /// <param name="value">值</param>
        static void Insert(XmlNode node, string element, string attribute, string value)
        {
            try
            {
                XmlNode xn = node;
                if (element.Equals(""))
                {
                    if (!attribute.Equals(""))
                    {
                        XmlElement xe = (XmlElement)xn;
                        xe.SetAttribute(attribute, value);
                    }
                }
                else
                {
                    XmlElement xe = node.OwnerDocument.CreateElement(element);
                    if (attribute.Equals(""))
                        xe.InnerText = value;
                    else
                        xe.SetAttribute(attribute, value);
                    xn.AppendChild(xe);
                }

            }
            catch (XmlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 插入节点
        /// </summary>
        /// <param name="node">节点</param>
        /// <param name="Insertnode">插入的节点</param>
        static void Insert(XmlNode node, XmlNode Insertnode)
        {
            try
            {
                node.AppendChild(Insertnode);
            }
            catch (XmlException e)
            {
                throw e;
            }
        }
        #endregion

        #region 更新

        /// <summary>
        /// 修改指定节点的属性值
        /// </summary>
        /// <param name="Xmldoc">要处理的节点</param>
        /// <param name="node">节点</param>
        /// <param name="attribute">属性名，非空时修改该节点属性值，否则修改节点值</param>
        /// <param name="value">值</param>
        /// 使用示列:
        /// XMLProsess.Insert( "/Node", "", "Value")
        /// XMLProsess.Insert( "/Node", "Attribute", "Value")
        public static void Update(XmlNode Xmldoc,string node, string attribute, string value)
        {
            try
            {
                XmlNode xn = Xmldoc.SelectSingleNode(node);
                Update(xn, attribute, value);
            }
            catch (XmlException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 修改指定节点的属性值
        /// </summary>
        /// <param name="Xmldoc">要处理的节点</param>
        /// <param name="node">节点</param>
        /// <param name="attribute">属性名，非空时修改该节点属性值，否则修改节点值</param>
        /// <param name="value">值</param>
        public static void Update(XmlNode node, string attribute, string value)
        {
            try
            {
                XmlNode xn = node;
                XmlElement xe = (XmlElement)xn;
                if (attribute.Equals(""))
                    xe.InnerText = value;
                else
                    xe.SetAttribute(attribute, value);
            }
            catch (XmlException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 修改多个
        /// </summary>
        /// <param name="Xmldoc">要处理的节点</param>
        /// <param name="node">节点</param>
        /// <param name="attribute">属性名，非空时修改该节点属性值，否则修改节点值</param>
        /// <param name="value">值</param>
        public void UpdateMore(XmlNode Xmldoc, string node, string attribute, string value)
        {
            try
            {
                XmlNodeList XNL = Xmldoc.SelectNodes(node);
                foreach (XmlNode xn in XNL)
                {
                    Update(xn, attribute, value);
                }
            }
            catch (XmlException e)
            {
                throw e;
            }
        }
        #endregion

        #region 删除

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="node">节点</param>
        /// <param name="attribute">属性名，非空时删除该节点属性值，否则删除节点值</param>
        /// <param name="value">值</param>
        public static void Delete(XmlNode node, string attribute)
        {
            try
            {
                XmlElement xe = (XmlElement)node;
                if (attribute.Equals(""))
                    node.ParentNode.RemoveChild(node);
                else
                    xe.RemoveAttribute(attribute);
            }
            catch (XmlException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="Xmldoc">要处理的节点</param>
        /// <param name="node">节点</param>
        /// <param name="attribute">属性名，非空时删除该节点属性值，否则删除节点值</param>
        /// <param name="value">值</param>
        public void Delete(XmlNode Xmldoc, string node, string attribute)
        {
            try
            {
                XmlNode xn = Xmldoc.SelectSingleNode(node);
                Delete(xn, attribute);
            }
            catch (XmlException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="Xmldoc">要处理的节点</param>
        /// <param name="node">节点</param>
        /// <param name="attribute">属性名，非空时删除该节点属性值，否则删除节点值</param>
        /// <param name="value">值</param>
        public void DeleteMore(XmlNode Xmldoc, string node, string attribute)
        {
            try
            {
                XmlNodeList XNL = Xmldoc.SelectNodes(node);
                foreach (XmlNode xn in XNL)
                {
                    Delete(xn, attribute);
                }
            }
            catch (XmlException e)
            {
                throw e;
            }
        }
        #endregion

        #region
        /// <summary>
        /// 保存之前修改内容
        /// </summary>
        public static void Save(XmlDocument Xmldoc,string path)
        {
            try { Xmldoc.Save(path); }
            catch (XmlException e)
            {
                throw e;
            }

        }
        

        #endregion

        #endregion
    }
}
