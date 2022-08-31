
using MAUI.Sound.AudioPlayer;

namespace MAUI.Sound.App;

public partial class MainPage : ContentPage
{
    int count = 0;

    IPlayer Player { get; set; }

    public MainPage(IPlayer player)
    {
        InitializeComponent();

        Player = player;

        using var data = FileSystem.OpenAppPackageFileAsync("song.mp3").Result;
        Player.LoadData(data, AudioFileTypes.MP3);
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;

        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";

        SemanticScreenReader.Announce(CounterBtn.Text);
    }

    private void ToggleSoundBtn_Clicked(object sender, EventArgs e)
    {
        if (Player.IsPlaying)
            Player.Pause();
        else
            Player.Play();
    }
}

