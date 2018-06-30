using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Yellowstone
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

			BindingContext = new MainPageViewModel();
		}
	}

	public class MainPageViewModel
	{
		public ObservableCollection<Entry> Source { get; private set; }
		public MainPageViewModel()
		{
			Source = new ObservableCollection<Entry>
			{
				new Entry("First time ever launched application", VersionTracking.IsFirstLaunchEver.ToString()),
				new Entry("First time launching current version",
					VersionTracking.IsFirstLaunchForCurrentVersion.ToString()),
				new Entry("First time launching current build",
					VersionTracking.IsFirstLaunchForCurrentBuild.ToString()),
				new Entry("Current app version", VersionTracking.CurrentVersion),
				new Entry("Current build", VersionTracking.CurrentBuild),
				new Entry("Previous app version", VersionTracking.PreviousVersion),
				new Entry("Previous app build", VersionTracking.PreviousBuild),
				new Entry("First version of app installed", VersionTracking.FirstInstalledVersion),
				new Entry("First build of app installed", VersionTracking.FirstInstalledBuild),
				new Entry("List of versions installed", string.Join("; ", VersionTracking.VersionHistory)),
				new Entry("List of builds installed", string.Join("; ", VersionTracking.BuildHistory))
			};

		}
	}

	public class Entry
	{
		public Entry(string title, string content)
		{
			Title = title;
			Content = content;
		}
		public string Title { get; private set; }
		public string Content { get; private set; }
	}
}
