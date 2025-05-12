using Plugin.Maui.Audio;

namespace Clicker;

public partial class Bombardino : ContentPage
{
    private readonly IAudioPlayer _crocodino;
    private readonly IAudioPlayer _bgmusic;
    private readonly IAudioPlayer _patapim;
    private readonly IAudioPlayer _fish;
    private readonly IAudioPlayer _tung;
    private readonly IAudioPlayer _bobr;
    public Bombardino()
	{
		InitializeComponent();

        var audioManager = AudioManager.Current;
        var bomb = FileSystem.OpenAppPackageFileAsync("bomb.wav").Result;
        _crocodino = audioManager.CreatePlayer(bomb);
        var brr = FileSystem.OpenAppPackageFileAsync("brr.mp3").Result;
        _patapim = audioManager.CreatePlayer(brr);
        var tra = FileSystem.OpenAppPackageFileAsync("tralalero.mp3").Result;
        _fish = audioManager.CreatePlayer(tra);
        var sahur = FileSystem.OpenAppPackageFileAsync("tung.mp3").Result;
        _tung = audioManager.CreatePlayer(sahur);
        var gang = FileSystem.OpenAppPackageFileAsync("bobr.mp3").Result;
        _bobr = audioManager.CreatePlayer(gang);

        var bgm = FileSystem.OpenAppPackageFileAsync("bgmusic.mp3").Result;
        _bgmusic = audioManager.CreatePlayer(bgm);
        _bgmusic.Play();



        Device.StartTimer(new TimeSpan(0, 0, 1), () =>
        {
            // do something every second
            Device.BeginInvokeOnMainThread(() =>
            {
                if (timerTotal >= 0)
                {
                    TimerMon.Text = $"{timerTotal}";
                    timerTotal--;
                }
                else
                {
                    _bgmusic.Stop();
                    Dead = true;
                }
            });
            return true;
        });
    }

    int timerTotal = 60;
    int clickTotal = 0;
    bool Dead = false;
    int character = 1;
    //cro 1 default
    //brr 2
    //tra 3
    //tun 4
    //bob 5
    void OnBombardinoClicked(object sender, EventArgs e)
    {
        if (Dead == false)
        {
            switch (character)
            {
                case 1: _crocodino.Play();
                    break;
                case 2:
                    _patapim.Play();
                    break;
                case 3:
                    _fish.Play();
                    break;
                case 4:
                    _tung.Play();
                    break;
                case 5:
                    _bobr.Play();
                    break;
            }
            clickTotal += 1;
            Monitor.Text = $"{clickTotal}";
        }
    }
    void Reset()
    {
        timerTotal = 60;
        TimerMon.Text = $"{timerTotal}";
        clickTotal = 0;
        Monitor.Text = $"{clickTotal}";
        Dead = false;
    }

    void cro(object sender, EventArgs e)
    {
        Reset();
        character = 1;
        bg.Source = "cloud_612x612.jpg";
        clicker.Source = "crocodino.png";
    }
    void brr(object sender, EventArgs e)
    {
        Reset();
        character = 2;
        bg.Source = "forest.jpg";
        clicker.Source = "patapim.png";
    }
    void tra(object sender, EventArgs e)
    {
        Reset();
        character = 3;
        bg.Source = "beach.jfif";
        clicker.Source = "fish.png";
    }
    void tun(object sender, EventArgs e)
    {
        Reset();
        character = 4;
        bg.Source = "sahur.jpg";
        clicker.Source = "tung.webp";
    }
    void bob(object sender, EventArgs e)
    {
        Reset();
        character = 5;
        bg.Source = "gangsta.jpg";
        clicker.Source = "bobr.png";
    }
}