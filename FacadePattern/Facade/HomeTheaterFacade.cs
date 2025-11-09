using FacadePattern.Subsystems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern.Facade
{
    public class HomeTheaterFacade
    {
        private readonly DVDPlayer _dvd;
        private readonly Projector _projector;
        private readonly SoundSystem _sound;
        private readonly Lights _lights;
        private readonly PopcornMaker _popcorn;

        public HomeTheaterFacade(
            DVDPlayer dvd,
            Projector projector,
            SoundSystem sound,
            Lights lights,
            PopcornMaker popcorn)
        {
            _dvd = dvd;
            _projector = projector;
            _sound = sound;
            _lights = lights;
            _popcorn = popcorn;
        }

        public void WatchMovie(string movie)
        {
            Console.WriteLine("\n🎬 Get ready to watch a movie...\n");

            _popcorn.On();
            _popcorn.Pop();
            _lights.Dim(10);
            _projector.On();
            _projector.SetWideScreenMode();
            _sound.On();
            _sound.SetVolume(5);
            _sound.SetSurroundSound();
            _dvd.On();
            _dvd.Play(movie);

            Console.WriteLine("\n🍿 Enjoy your movie!\n");
        }

        public void EndMovie()
        {
            Console.WriteLine("\n🎬 Shutting down movie theater...\n");

            _dvd.Stop();
            _dvd.Off();
            _sound.Off();
            _projector.Off();
            _lights.On();
            _popcorn.Off();

            Console.WriteLine("\n✅ Movie theater shut down complete!\n");
        }

        public void ListenToMusic(string album)
        {
            Console.WriteLine("\n🎵 Setting up music mode...\n");

            _lights.Dim(30);
            _sound.On();
            _sound.SetVolume(7);
            _sound.SetSurroundSound();
            _dvd.On();
            _dvd.Play(album);

            Console.WriteLine("\n🎶 Music is playing!\n");
        }

        public void PlayGame(string game)
        {
            Console.WriteLine("\n🎮 Setting up gaming mode...\n");

            _lights.Dim(20);
            _projector.On();
            _projector.SetWideScreenMode();
            _sound.On();
            _sound.SetVolume(8);
            _sound.SetSurroundSound();

            Console.WriteLine($"\n🕹️  Ready to play {game}!\n");
        }
    }
}
