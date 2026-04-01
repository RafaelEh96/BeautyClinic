namespace BeautyClinic.Core.Extensions;

public static class GuidExtensions
{
    /// <summary>
    /// Cria um novo Guid na versão 7 (time-ordered), garantindo
    /// unicidade e ordenação cronológica para melhor performance nos índices do banco.
    /// </summary>
    public static Guid NewId() => Guid.CreateVersion7();
}