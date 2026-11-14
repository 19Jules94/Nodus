namespace Nodus.Application.Services;

public class DocumentService : IDocumentService
{
    private IDocumentReader _documentReader;

    public DocumentService(IDocumentReader documentReader)
    {
        _documentReader = documentReader;
    }
    
    public DocumentDTO GetDocument(Stream streamDocument,string pathDocument)
    {
        if (streamDocument == null)
        {
            throw new ArgumentNullException(nameof(streamDocument));
        }
        
        Document documentContent = _documentReader.GetDocumentContent(streamDocument);
        return new DocumentDTO()
        {
            PathDocument = pathDocument,
            NumberPages = documentContent.NumberPages,
            ContentDocument = documentContent.Content,
        };
    }
}