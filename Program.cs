using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace SoapParser
{
    class Program
    {
        static void Main(string[] args)
        {
          
            //This would do Serialization 
            var soap = @"<?xml version=""1.0"" encoding=""utf-8""?>
                        <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" 
                            xmlns:xsd=""http://www.w3.org/2001/XMLSchema""
                            xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">
                          <soap:Body>
                            <GetImagesByAssetResponse  xmlns=""http://tempuri.org/"">
                              <GetImagesByAssetResult>
                              <anyType xsi:type=xsd:string>1</anyType>
                                <anyType xsi:type=xsd:string>1</anyType>
                              </GetImagesByAssetResult>
                            </GetImagesByAssetResponse >
                          </soap:Body>
                        </soap:Envelope>";
            XmlDocument document = new XmlDocument();
            document.LoadXml(soap);

            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(Envelope));
            Envelope envelope = (Envelope)serializer.Deserialize(new StringReader(document.OuterXml));


            //var rawXML = XDocument.Parse(soap);
            //SOAPEnvelope deserializedObject;
            //using (var reader = rawXML.CreateReader(System.Xml.Linq.ReaderOptions.None))
            //{
            //    var ser = new XmlSerializer(typeof(SOAPEnvelope));
            //    deserializedObject = (SOAPEnvelope)ser.Deserialize(reader);
            //}
            //Console.WriteLine("Object Desirialized - Product name:-" + deserializedObject.body.Product.Name);
            //Console.Read();
        }
    }
    [XmlRoot(ElementName = "anyType", Namespace = "http://tempuri.org/")]
    public class AnyType
    {
        [XmlAttribute(AttributeName = "type", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string Type { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "GetImagesByAssetResult", Namespace = "http://tempuri.org/")]
    public class GetImagesByAssetResult
    {
        [XmlElement(ElementName = "anyType", Namespace = "http://tempuri.org/")]
        public List<AnyType> AnyType { get; set; }
    }

    [XmlRoot(ElementName = "GetImagesByAssetResponse", Namespace = "http://tempuri.org/")]
    public class GetImagesByAssetResponse
    {
        [XmlElement(ElementName = "GetImagesByAssetResult", Namespace = "http://tempuri.org/")]
        public GetImagesByAssetResult GetImagesByAssetResult { get; set; }
        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns { get; set; }
    }

    [XmlRoot(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public class Body
    {
        [XmlElement(ElementName = "GetImagesByAssetResponse", Namespace = "http://tempuri.org/")]
        public GetImagesByAssetResponse GetImagesByAssetResponse { get; set; }
    }

    [XmlRoot(ElementName = "Envelope", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public class Envelope
    {
        [XmlElement(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        public Body Body { get; set; }
        [XmlAttribute(AttributeName = "soap", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Soap { get; set; }
        [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Xsi { get; set; }
        [XmlAttribute(AttributeName = "xsd", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Xsd { get; set; }
    }



    //[XmlType(Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    //[XmlRoot(ElementName = "Envelope", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    //public class SOAPEnvelope
    //{
    //    [XmlAttribute(AttributeName = "soapenv", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    //    public string soapenva { get; set; }
    //    [XmlAttribute(AttributeName = "xsd", Namespace = "http://www.w3.org/2001/XMLSchema")]
    //    public string xsd { get; set; }
    //    [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
    //    public string xsi { get; set; }
    //    [XmlElement(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    //    public ResponseBody<Product> body { get; set; }
    //    [XmlNamespaceDeclarations]
    //    public XmlSerializerNamespaces xmlns = new XmlSerializerNamespaces();
    //    public SOAPEnvelope()
    //    {
    //        xmlns.Add("soapenv", "http://schemas.xmlsoap.org/soap/envelope/");
    //    }
    //}
    //[XmlRoot(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    //public class ResponseBody<T>
    //{
    //    [XmlElement(Namespace = "http://xmlns.xyz.com/webservice/version")]
    //    public T Product { get; set; }
    //}
    //public class Product
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}

}
