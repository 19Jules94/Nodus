namespace Nodus.Application.Interfaces;

public interface IDocumentReader
{
    public Document GetDocumentContent(Stream stream);
}