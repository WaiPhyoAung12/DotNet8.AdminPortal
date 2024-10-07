using AdminPortal.Frontend.Shared;
using AdminPortal.Shared.Enums;
using AdminPortal.Shared.ResponseModels;
using AdminPortal.Shared.Services.ApiService;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace AdminPortal.Frontend.Services
{
    public class InjectionService : IInjectionService
    {
        private readonly HttpClientService _httpClientService;
        private readonly NavigationManager _navigationManager;
        private readonly IDialogService _dialogService;

        public InjectionService(HttpClientService httpClientService,NavigationManager navigationManager,IDialogService dialogService)
        {
            _httpClientService = httpClientService;
            _navigationManager = navigationManager;
            _dialogService = dialogService;
        }
        public async Task<Result<T>> CallApiAsync<T>(string endpoint, EnumHttpMethod httpMethod, object requeseModel = null)
        {
            var response=await _httpClientService.ExucuteAsync<Result<T>>(endpoint, httpMethod, requeseModel);
            return response;
        }

        public async Task<DialogResult> ConfirmDialogAsync<T>(string title, T data)
        {
            var parameters = new DialogParameters<MessageDialogComponent<T>>
        {
            { x => x.ContentText, "Do you really want to delete this record?" },
            { x => x.ButtonText, "Delete" },
            { x => x.Color, Color.Error },
            { x => x.Data, data }
        };

            var options = new MudBlazor.DialogOptions()
            {
                Position = MudBlazor.DialogPosition.TopCenter,
                CloseButton = true,
                MaxWidth = MaxWidth.Small,
                FullWidth = true
            };

            var dialog = await _dialogService.ShowAsync<MessageDialogComponent<T>>(title, parameters, options);
            return await dialog.Result;
        }

        public void Go(string? url,bool forceReload = false)
        {
            _navigationManager.NavigateTo(url,forceReload);
        }
    }
}
