using AdminPortal.Models.DataGrid;
using Microsoft.AspNetCore.Components;
using Radzen;
using System.Buffers;

namespace AdminPortal.Frontend.Shared
{
    public partial class DataGridComponent<T>
    {
        [Parameter]
        public DataGridResponseModel<T>? Model { get; set; }
        [Parameter]
        public Action<T>? EditAction {  get; set; }
        [Parameter]
        public Action<T>? DeleteAction { get;set; }
        [Parameter]
        public string? CreateURL { get; set; }
        [Parameter]
        public EventCallback<LoadDataArgs> LoadData {  get; set; }
        private LoadDataArgs? loadDataArgs { get; set; }
        private async Task LoadDataAsync(LoadDataArgs args)
        {
            loadDataArgs = args;
            
            await LoadData.InvokeAsync(args);
        }
        private void EditData(T data)
        {
            EditAction?.Invoke(data);
        }
        private void DeleteData(T data) { DeleteAction?.Invoke(data); }
    }
}