using AdminPortal.Shared.Enums;
using AdminPortal.Shared.ResponseModels;
using MudBlazor;

namespace AdminPortal.Frontend.Services
{
    public interface IInjectionService
    {
        void Go(string? url, bool forceReload = false);
        Task<Result<T>>CallApiAsync<T>(string endpoint,EnumHttpMethod httpMethod,object requeseModel = null);
        Task<DialogResult> ConfirmDialogAsync<T>(string title, T data);
    }
}
