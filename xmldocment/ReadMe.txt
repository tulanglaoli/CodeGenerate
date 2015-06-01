一、属性：

Attributes　　　　　　获取一个 XmlAttributeCollection，它包含该节点的属性。 （继承自 XmlNode。） 
BaseURI 　　  　  　　获取当前节点的基 URI。 （重写 XmlNode..::.BaseURI。） 
ChildNodes 　　　　　获取节点的所有子节点。 （继承自 XmlNode。） 
DocumentElement 　 获取文档的根 XmlElement。 
DocumentType 　　　获取包含 DOCTYPE 声明的节点。 
FirstChild 　　　　　　获取节点的第一个子级。 （继承自 XmlNode。） 
HasChildNodes 　　　 获取一个值，该值指示节点是否有任何子节点。 （继承自 XmlNode。） 
Implementation 　　  获取当前文档的 XmlImplementation 对象。 
InnerText 　　　　　  获取或设置节点及其所有子节点的串联值。 （继承自 XmlNode。） 
InnerXml 　　　　　　获取或设置表示当前节点子级的标记。 （重写 XmlNode..::.InnerXml。） 
IsReadOnly 　　　　　获取一个值，该值指示当前节点是否是只读的。 （重写 XmlNode..::.IsReadOnly。） 
Item 　　　　　　　　 已重载。 
LastChild 　　　　　　获取节点的最后一个子级。 （继承自 XmlNode。） 
LocalName 　　　　　 获取节点的本地名称。 （重写 XmlNode..::.LocalName。） 
Name 　　　　　　　　获取节点的限定名。 （重写 XmlNode..::.Name。） 
NamespaceURI 　　　获取该节点的命名空间 URI。 （继承自 XmlNode。） 
NameTable 　　　　　获取与此实现关联的 XmlNameTable。 
NextSibling 　　　　  获取紧接在该节点之后的节点。 （继承自 XmlNode。） 
NodeType 　　　　　 获取当前节点的类型。 （重写 XmlNode..::.NodeType。） 
OuterXml 　　　　　  获取表示此节点及其所有子节点的标记。 （继承自 XmlNode。） 
OwnerDocument 　　获取当前节点所属的 XmlDocument。 （重写 XmlNode..::.OwnerDocument。） 
ParentNode 　　　　  已重载。 
Prefix 　　　　　　　  获取或设置该节点的命名空间前缀。 （继承自 XmlNode。） 
PreserveWhitespace  获取或设置一个值，该值指示是否在元素内容中保留空白。 
PreviousSibling 　　　获取紧接在该节点之前的节点。 （继承自 XmlNode。） 
SchemaInfo 　　　　 返回节点的后架构验证信息集 (PSVI)。 （重写 XmlNode..::.SchemaInfo。） 
Schemas 　　　　　　获取或设置与此 XmlDocument 关联的 XmlSchemaSet 对象。 
Value 　　　　　　　　获取或设置节点的值。 （继承自 XmlNode。） 
XmlResolver 　　　　 设置 XmlResolver 以用于解析外部资源。

二、方法

AppendChild 　　　　　　　　　　　  将指定的节点添加到该节点的子节点列表的末尾。 （继承自 XmlNode。） 
Clone 　　　　　　　　　　　　　　    创建此节点的一个副本。 （继承自 XmlNode。） 
CloneNode 　　　　　　　　　　　　  创建此节点的一个副本。 （重写 XmlNode..::.CloneNode(Boolean)。） 
CreateAttribute 　　　　　　　　　　 已重载。 创建具有指定名称的 XmlAttribute。 
CreateCDataSection 　　　　　　　　创建包含指定数据的 XmlCDataSection。 
CreateComment　　　　 　　　　　　创建包含指定数据的 XmlComment。 
CreateDefaultAttribute 　　　　　　  创建具有指定前缀、本地名称和命名空间 URI 的默认属性。 
CreateDocumentFragment 　　　　   创建 XmlDocumentFragment。 
CreateDocumentType 　　　　　　   返回新的 XmlDocumentType 对象。 
CreateElement 　　　　　　　　　　  已重载。 创建 XmlElement。 
CreateEntityReference 　　　　　　   创建具有指定名称的 XmlEntityReference。 
CreateNavigator 　　　　　　　　　　 已重载。 创建一个用于导航此文档的新 XPathNavigator 对象。 
CreateNode　　　　　　　　　　　　  已重载。 创建 XmlNode。 
CreateProcessingInstruction 　　　　创建一个具有指定名称和数据的 XmlProcessingInstruction。 
CreateSignificantWhitespace 　　　　创建一个 XmlSignificantWhitespace 节点。 
CreateTextNode 　　　　　　　　　　创建具有指定文本的 XmlText。 
CreateWhitespace 　　　　　　　　　创建一个 XmlWhitespace 节点。 
CreateXmlDeclaration 　　　　　　　 创建一个具有指定值的 XmlDeclaration 节点。 
GetElementById 　　　　　　　　　　获取具有指定 ID 的 XmlElement。 
GetElementsByTagName 　　　　　  已重载。 返回一个 XmlNodeList，它包含与指定名称匹配的所有子代元素的列表。 
GetEnumerator 　　　　　　　　　　 提供对 XmlNode 中节点上“for each”样式迭代的支持。 （继承自 XmlNode。） 
GetHashCode 　　　　　　　　　　   用作特定类型的哈希函数。 （继承自 Object。） 
GetNamespaceOfPrefix 　　　　　　  查找当前节点范围内离给定的前缀最近的 xmlns 声明，并返回声明中的命名空间 URI。 （继承自 XmlNode。） 
GetPrefixOfNamespace 　　　　　　  查找当前节点范围内离给定的命名空间 URI 最近的 xmlns 声明，并返回声明中定义的前缀。 （继承自 XmlNode。） 
ImportNode 　　　　　　　　　　　　将节点从另一个文档导入到当前文档。 
InsertAfter 　　　　　　　　　　　　  将指定的节点紧接着插入指定的引用节点之后。 （继承自 XmlNode。） 
InsertBefore 　　　　　　　　　　　　将指定的节点紧接着插入指定的引用节点之前。 （继承自 XmlNode。） 
Load 　　　　　　　　　　　　　　　  已重载。 从 Stream、URL、TextReader 或 XmlReader 加载指定的 XML 数据。 
LoadXml 　　　　　　　　　　　　　  从指定的字符串加载 XML 文档。 
Normalize 　　　　　　　　　　　　　将此 XmlNode 下子树完全深度中的所有 XmlText 节点都转换成“正常”形式，在这种形式中只有标记（即标记、注释、处理指令、　　　　　　　　　　　　　　　　　　　　CDATA 节和实体引用）分隔 XmlText 节点，也就是说，没有相邻的 XmlText 节点。 （继承自 XmlNode。） 
PrependChild 　　　　　　　　　　　 将指定的节点添加到该节点的子节点列表的开头。 （继承自 XmlNode。） 
ReadNode 　　　　　　　　　　　　  根据 XmlReader 中的信息创建一个 XmlNode 对象。读取器必须定位在节点或属性上。 
RemoveAll 　　　　　　　　　　　　  移除当前节点的所有子节点和/或属性。 （继承自 XmlNode。） 
RemoveChild 　　　　　　　　　　　 移除指定的子节点。 （继承自 XmlNode。） 
ReplaceChild 　　　　　　　　　　　 用 newChild 节点替换子节点 oldChild。 （继承自 XmlNode。） 
Save 　　　　　　　　　　　　　　　 已重载。 将 XML 文档保存到指定的位置。 
SelectNodes 　　　　　　　　　　　  已重载。 
SelectSingleNode 　　　　　　　　　 已重载。 
Supports 　　　　　　　　　　　　　 测试 DOM 实现是否实现特定的功能。 （继承自 XmlNode。） 
Validate 　　　　　　　　　　　　　　已重载。 验证 XmlDocument 是不是 Schemas 属性中包含的 XML 架构定义语言 (XSD) 架构。 
WriteContentTo 　　　　　　　　　　将 XmlDocument 节点的所有子级保存到指定的 XmlWriter 中。 （重写 XmlNode..::.WriteContentTo(XmlWriter)。） 
WriteTo　　　　　　　　　　　　　　 将 XmlDocument 节点保存到指定的 XmlWriter。 （重写 XmlNode..::.WriteTo(XmlWriter)。） 

 三、事件

NodeChanged 　　　　　　 当属于该文档的节点的 Value 已被更改时发生。 
NodeChanging 　　　　　　当属于该文档的节点的 Value 将被更改时发生。 
NodeInserted 　　　　　　  当属于该文档的节点已被插入另一个节点时发生。 
NodeInserting 　　　　　　 当属于该文档的节点将被插入另一个节点时发生。 
NodeRemoved 　　　　　　 当属于该文档的节点已被从其父级移除时发生。 
NodeRemoving 　　　　　　当属于该文档的节点将被从文档中移除时发生。

助记属性：

PreviousSibling　　上一个兄弟节点
NextSibling　　　　下一个兄弟节点
FirstChild　　　　　第一个子节点
LastChild　　　　　最后一个子节点
ChildNodes　　　　子节点集合
ParentNode　　　  父节点
