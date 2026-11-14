namespace Nodus.Infrastructure.Persistence;

public class PdfDocumentReader : IDocumentReader
{
    public Document GetDocumentContent(Stream stream)
    {
        using PdfDocument document = PdfDocument.Open(stream);

        StringBuilder sb = new StringBuilder();

        foreach (var page in document.GetPages())
        {
            sb.AppendLine(ContentOrderTextExtractor.GetText(page));
        }

        return new Document(){NumberPages = document.NumberOfPages ,Content = sb.ToString()};
    }
}


