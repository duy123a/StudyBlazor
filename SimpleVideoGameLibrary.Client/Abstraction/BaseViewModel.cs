using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SimpleVideoGameLibrary.Client.Abstraction;

public class BaseViewModel : INotifyPropertyChanged, IBaseViewModel
{
	private bool isBusy = false;
	public bool IsBusy
	{
		get => isBusy;
		set
		{
			SetValue(ref isBusy, value);
		}
	}

	public event PropertyChangedEventHandler? PropertyChanged;

	protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}

	protected void SetValue<T>(ref T backingFiled, T value, [CallerMemberName] string? propertyName = null)
	{
		// Class need to implement IEquatable<T>, or they are compared by memory address
		if (EqualityComparer<T>.Default.Equals(backingFiled, value)) return;
		backingFiled = value;
		OnPropertyChanged(propertyName);
	}

	public virtual Task OnInitializedAsync()
	{
		return Task.CompletedTask;
	}
}
