using System;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

class SvgParser
{
    static void Main()
    {
        string svgFilePath = "/home/yee/tubemap.svg";

        try
        {
            XDocument svgDocument = XDocument.Load(svgFilePath);

            // Parse SVG elements
            ParseSvg(svgDocument);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void ParseSvg(XDocument svgDocument)
    {
        XNamespace svgNamespace = "http://www.w3.org/2000/svg";

        XmlNamespaceManager namespaceManager = new XmlNamespaceManager(new NameTable());
        namespaceManager.AddNamespace("svg", svgNamespace.NamespaceName);

        // Find the root 'svg' element using XPath with the declared namespace
        XElement rootSvgElement = svgDocument.XPathSelectElement("/svg:svg", namespaceManager);

        if (rootSvgElement != null)
        {
            // Extract attributes or perform any other parsing logic
            string width = rootSvgElement.Attribute("width")?.Value ?? "N/A";
            string height = rootSvgElement.Attribute("height")?.Value ?? "N/A";

            Console.WriteLine($"SVG Width: {width}, Height: {height}");

            // You can continue parsing other SVG elements as needed
        }
        else
        {
            Console.WriteLine("Invalid SVG file. Missing 'svg' root element.");
        }
    }
}