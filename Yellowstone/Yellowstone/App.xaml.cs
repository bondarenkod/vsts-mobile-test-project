using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Json;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Distribute;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Yellowstone
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			try
			{
				VersionTracking.Track();

				var config = ReadConfiguration();

				var appcentersharedsecret = config["appcenter_appsecret"].ToString();

				AppCenter.Start($"ios={appcentersharedsecret};android={appcentersharedsecret};uwp={appcentersharedsecret}",
					typeof(Analytics),
					typeof(Crashes),
					typeof(Distribute));
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}

			MainPage = new MainPage();
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}

		private JObject ReadConfiguration()
		{
			string file;
			var assembly = typeof(App).GetTypeInfo().Assembly;

			using (var stream = assembly.GetManifestResourceStream("Yellowstone.Resources.config.json"))
			{
				using (var reader = new StreamReader(stream))
				{
					file = reader.ReadToEnd();
				}
			}

			var conf = JObject.Parse(file);

			return conf;

		}
	}
}
