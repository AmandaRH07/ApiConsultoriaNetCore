using Consultoria.Core.Domain;
namespace Consultoria.Manager.Interfaces.Services
{
    public interface IJWTService
    {
        string GerarToken(Usuario usuario);
    }
}
