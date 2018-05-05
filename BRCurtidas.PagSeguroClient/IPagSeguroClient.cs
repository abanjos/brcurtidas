using System.Threading.Tasks;

namespace BRCurtidas.PagSeguro
{
    public interface IPagSeguroClient
    {
        Task<CheckoutResponse> CreateCheckoutAsync(CheckoutRequest request);
    }
}
