using Microsoft.AspNetCore.Components;
using SimpleVideoGameLibrary.Client.Abstraction;
using SimpleVideoGameLibrary.Shared;
using System.Net.Http.Json;

namespace SimpleVideoGameLibrary.Client.ViewModels;

public class VideoGamesViewModel : BaseViewModel, IVideoGamesViewModel
{
	private readonly HttpClient _httpClient;
	private readonly NavigationManager _navigationManager;
	private List<VideoGame> _games = [];

	public List<VideoGame> Games
	{
		get => _games;
		private set
		{
			SetValue(ref _games, value);
		}
	}

	public VideoGamesViewModel(HttpClient httpClient, NavigationManager navigationManager)
	{
		_httpClient = httpClient;
		_navigationManager = navigationManager;
	}

	public override async Task OnInitializedAsync()
	{
		await LoadVideoGamesAsync();
	}

	public async Task LoadVideoGamesAsync()
	{
		var result = await _httpClient.GetFromJsonAsync<List<VideoGame>>("http://localhost:5010/api/videogame");
		if (result != null)
		{
			IsBusy = true;
			Games = result;
		}
		OnPropertyChanged(nameof(Games));
		IsBusy = false;
	}

	public void AddVideoGame()
	{
		_navigationManager.NavigateTo("./videogame");
	}

	public void EditVideoGame(int id)
	{
		_navigationManager.NavigateTo($"./videogame/{id}");
	}

	public async Task DeleteVideoGameAsync(int id)
	{
		await _httpClient.DeleteAsync($"http://localhost:5010/api/videogame/{id}");
		await LoadVideoGamesAsync();
	}
}