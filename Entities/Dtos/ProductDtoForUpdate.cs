namespace Entities.Dtos
{
    public record ProductDtoForUpdate : ProductDto
    {
        public bool Showcase { get; set; }// ProductDtoForUpdate s�n�f� ProductDto s�n�f�n� kal�t�m alarak showcase varl���n�da katar.
    }
}