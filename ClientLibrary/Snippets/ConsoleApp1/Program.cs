using Microsoft.TeamFoundation.SourceControl.WebApi;
using Microsoft.VisualStudio.Services.Client;
using Microsoft.VisualStudio.Services.Common;
using Microsoft.VisualStudio.Services.WebApi;
using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = new Uri("https://jacanotest123.visualstudio.com");

            var connection = new VssConnection(url, new VssClientCredentials());
            //var connection = new VssConnection(url, new VssBasicCredential("pat", "t77dabkbus5eu77bnvya6k4garoy3kxgyqn4jogktlmqslththea"));

            connection.ConnectAsync().SyncResult();

            TfvcHttpClient tfvcClient = connection.GetClient<TfvcHttpClient>();

            IEnumerable<TfvcBranch> branches = tfvcClient.GetBranchesAsync(includeParent: true, includeChildren: true).Result;
        }
    }
}
