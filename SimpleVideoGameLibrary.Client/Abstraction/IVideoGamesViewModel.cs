using SimpleVideoGameLibrary.Shared;

namespace SimpleVideoGameLibrary.Client.Abstraction;

public interface IVideoGamesViewModel : IBaseViewModel
{
	List<VideoGame> Games { get; }

	Task LoadVideoGamesAsync();

	void AddVideoGame();

	void EditVideoGame(int id);

	Task DeleteVideoGameAsync(int id);
}
