namespace BeautyClinic.Api.Commons;

public interface IEndpoint
{
    static abstract void Map(IEndpointRouteBuilder app);
}