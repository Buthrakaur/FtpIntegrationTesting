using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace FtpIntegrationTesting
{
	public class FtpIntegrationServer: IDisposable
	{
		private readonly Process ftpProcess;

		public FtpIntegrationServer(string rootDirectory, int port = 21, bool hideFtpWindow = true)
		{
			var psInfo = new ProcessStartInfo
				{
					FileName = "ftpdmin.exe",
					Arguments = String.Format("-p {0} -ha 127.0.0.1 \"{1}\"", port, rootDirectory),
					WindowStyle = hideFtpWindow ? ProcessWindowStyle.Hidden : ProcessWindowStyle.Normal
				};
			ftpProcess = Process.Start(psInfo);
		}


		public void Dispose()
		{
			if (!ftpProcess.HasExited)
			{
				ftpProcess.Kill();
				Thread.Sleep(100);
			}
		}
	}
}
