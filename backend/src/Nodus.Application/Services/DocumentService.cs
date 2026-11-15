namespace Nodus.Application.Services;

public class DocumentService : IDocumentService
{
    private IDocumentReader _documentReader;

    public DocumentService(IDocumentReader documentReader)
    {
        _documentReader = documentReader;
    }

    public DocumentDTO GetDocument(Stream streamDocument, string pathDocument)
    {
        if (streamDocument == null)
        {
            throw new ArgumentNullException(nameof(streamDocument));
        }

        string extensionFile = checkHeaderFiler(streamDocument);

        if (!extensionFile.Equals(FileTypes.Pdf.ToString(), StringComparison.OrdinalIgnoreCase))
        {
            throw new Exception("The file doesn't a pdf file");
        }

        Document documentContent = _documentReader.GetDocumentContent(streamDocument);
        return new DocumentDTO()
        {
            PathDocument = pathDocument,
            NumberPages = documentContent.NumberPages,
            ContentDocument = documentContent.Content,
        };
    }

    private string checkHeaderFiler(Stream stream)
    {
        Dictionary<string, FileTypes> extensionsFile = new()
        {
            { "25-50-44-46", FileTypes.Pdf },
        };
        byte[] header = new byte[4]; //Por el momento 4 bytes para pdf, cambiar en un futuro si soportamos mas
        stream.ReadExactly(header, 0, header.Length);

        if (stream.CanSeek)
        {
            stream.Position = 0;
        }

        string hex = BitConverter.ToString(header);

        foreach (KeyValuePair<string, FileTypes> item in extensionsFile)
        {
            if (hex.StartsWith(item.Key))
            {
                return item.Value.ToString();
            }
        }

        return string.Empty;
    }
}