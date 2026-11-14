namespace Nodus.Application.Interfaces.Services;

public interface IDocumentService
{
    public DocumentDTO GetDocument(Stream streamDocument,string pathDocument);
}