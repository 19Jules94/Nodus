using Moq;
using Nodus.Application.Interfaces;
using Nodus.Application.Services;
using Nodus.Domain.Entities;

namespace Nodus.Application.Tests;

public class DocumentTest
{
    [Fact]
    public void GetDocument_WhenStreamIsNull_ThrowsArgumentNullException()
    {
        // Arrange
        var mockReader = new Mock<IDocumentReader>();
        var service = new DocumentService(mockReader.Object);

        // Act
        Action act = () => service.GetDocument(null!, string.Empty);

        // Assert
        Assert.Throws<ArgumentNullException>(act);
    }

    [Fact]
    public void GetDocument_WhenStreamIsValid_ReturnsDocumentDTO()
    {
        // Arrange
        var mockReader = new Mock<IDocumentReader>();

        var document = new Document
        {
            NumberPages = 1,
            Content = "Hola Nodus desde un documento creado con Moq"
        };

        mockReader
            .Setup(x => x.GetDocumentContent(It.IsAny<Stream>()))
            .Returns(document);

        var service = new DocumentService(mockReader.Object);
        using var stream = new MemoryStream();

        // Act
        var documentDto = service.GetDocument(stream, "sample.pdf");

        // Assert
        Assert.Equal(1, documentDto.NumberPages);
        Assert.Equal("Hola Nodus desde un documento creado con Moq",
            documentDto.ContentDocument);
        Assert.Equal("sample.pdf", documentDto.PathDocument);
    }
}