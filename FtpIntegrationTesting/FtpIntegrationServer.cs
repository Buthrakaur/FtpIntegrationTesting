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

		public FtpIntegrationServer(string rootDirectory, int port = 21)
		{
			ftpProcess = Process.Start("ftpdmin.exe", String.Format("-p {0} -ha 127.0.0.1 \"{1}\"", port, rootDirectory));
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
