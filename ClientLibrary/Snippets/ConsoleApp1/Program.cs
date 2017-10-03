using Microsoft.TeamFoundation.SourceControl.WebApi;
using Microsoft.VisualStudio.Services.Common;
using Microsoft.VisualStudio.Services.WebApi;
using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        private static readonly string s_accountUrlPattern = "https://{0}.visualstudio.com";

        static void Main(string[] args)
        {
            var connection = new VssConnection(new Uri(string.Format(s_accountUrlPattern, "jacanotest123")), new VssBasicCredential("pat", "t77dabkbus5eu77bnvya6k4garoy3kxgyqn4jogktlmqslththea"));

            connection.ConnectAsync().SyncResult();

            TfvcHttpClient tfvcClient = connection.GetClient<TfvcHttpClient>();

            IEnumerable<TfvcBranch> branches = tfvcClient.GetBranchesAsync(includeParent: true, includeChildren: true).Result;
        }
    }
}
