using System.ComponentModel;

namespace SimpleVideoGameLibrary.Client.Abstraction;

public interface IBaseViewModel
{
	bool IsBusy { get; set; }

	event PropertyChangedEventHandler? PropertyChanged;

	Task OnInitializedAsync();
}
