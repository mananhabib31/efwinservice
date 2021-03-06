﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace PSScriptsExecuter
{
    class Program
    {
        static void Main(string[] args)
        {
            
            using (PowerShell powershell = PowerShell.Create())
            {
                PSCommand new1 = new PSCommand();
                
                GetPSScriptsFilesPaths().ForEach(path =>
                {
                    powershell.AddScript(@System.IO.File.ReadAllText(path).Replace("rootDirectoryPlaceHolder", @"C:\Program Files\Logon Events Watcher Service"));

                    Collection<PSObject> results = powershell.Invoke();

                });

                Process process = new Process();
                // Configure the process using the StartInfo properties.
                process.StartInfo.FileName = @"gpmc.msc";
                process.Start();


            }
        }

        static List<string> GetPSScriptsFilesPaths()
        {
            var executingPath = $@"C:\Program Files\Logon Events Watcher Service\PS Scripts";

            return Directory.GetFiles(executingPath).ToList();
        }
    }
}
