namespace Entities.Dtos
{
    public record ProductDtoForUpdate : ProductDto
    {
        public bool Showcase { get; set; }// ProductDtoForUpdate sýnýfý ProductDto sýnýfýný kalýtým alarak showcase varlýðýnýda katar.
    }
}