﻿using DeveImageOptimizer.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using WebOptimizationProject.Configuration;
using WebOptimizationProject.Helpers;

namespace WebOptimizationProject
{
    public class GitHandler
    {
        private readonly Config config;

        public GitHandler(Config config)
        {
            this.config = config;
        }

        public async Task<string> GitClone(string userName, string repositoryName)
        {
            var cloneingDir = Path.Combine(Directory.GetCurrentDirectory(), repositoryName);
            await DirectoryHelper.DeleteDirectory(cloneingDir);
            Console.WriteLine("Nu2");
            var totalUrl = $"https://github.com/{userName}/{repositoryName}.git";

            await RunGitCommand($"clone {totalUrl}");

            return cloneingDir;
        }

        public async Task RunGitCommand(string command)
        {
            var psi = new ProcessStartInfo("git", command);

            await WopProcessRunner.RunProcessAsync(psi);
        }

        public async Task RunHubCommand(string command)
        {
            var psi = new ProcessStartInfo("hub", command);

            await WopProcessRunner.RunProcessAsync(psi);
        }
    }
}
