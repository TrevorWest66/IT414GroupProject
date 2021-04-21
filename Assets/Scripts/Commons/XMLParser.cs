//Written by Lance Graham
// February 5th, 2021
//This class will be used for loading and parsing XML documents
//Helpful links
// https://answers.unity.com/questions/59366/input-manager-from-string-to-keycode.html
// https://docs.microsoft.com/en-us/dotnet/api/system.xml.xmldocument?redirectedfrom=MSDN&view=net-5.0

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class XmlParser
{
    protected XmlDocument anXmlDoc;
    protected XmlNodeList anXMlNodeList;

    //Takes in a string parameter which will be the path to the XML document.
    //This method loads the XML document. Must load the document before we can parse it!
    public void loadDocument(string document)
    {
        anXmlDoc = new XmlDocument();
        anXmlDoc.Load(document);
    }

    //Takes in a string parameter for the element to parse then parses document for the element.
    //Then, the value found for the element is converted into the correct KeyCode using the KeyCode Enum.
    //**Important: While this will grab a list of value/s for the specified element, this method will only return 
    //the value for the first element found when the document was parsed, regardless if more elements with that 
    //same name were found.
    public KeyCode parseXml(string element)
    {
        anXMlNodeList = anXmlDoc.GetElementsByTagName(element);
        KeyCode key = (KeyCode)System.Enum.Parse(typeof(KeyCode), anXMlNodeList[0].InnerText);

        return key;
    }
}
