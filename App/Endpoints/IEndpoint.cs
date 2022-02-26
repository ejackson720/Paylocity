using System.Threading.Tasks;

namespace App.Endpoints
{
    public interface IEndpoint
    {
        Task<string> SubmitToApi();
    }
}
