Humidity
========

A WPF BitTorrent client


## TODO

- Get settings flyout flying out
- Show a list of things in a list view - which whill be a list of torrents eventually
- Show a cute progress bar for each thing
- Add a .torrent file to the list of things
- Persist list of torrents to local storage
- Configure path to persist .torrent files and download location
- Pull in torrent library
  - https://github.com/mono/monotorrent (might have to fork it, looks a bit stale, [nuget package here](http://www.nuget.org/packages/MonoTorrent/))
  - more on nuget - http://www.nuget.org/packages?q=torrent
- Actually download torrents yay
- Hook up speeds and progress bars
- Facility to remove a selected torrent - just remove the torrent file from the list
- ADD MORE THINGS HERE ;-)


## Third party libraries

- Autofac (MIT License)
- Caliburn.Micro (MIT License)
- Caliburn.Micro.Autofac (MIT License)
- MahApps.Metro (Microsoft Public License)
- Shouldly (BSD License)
- xUnit (Apache License 2.0)
- Fody.NotifyProperyChanged
