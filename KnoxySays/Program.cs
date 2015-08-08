using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace KnoxySays
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            try
            {
                ExecuteKnoxysCommands(args);
            }
	        catch (Exception ex)
	        {
	            Console.Write("Something went wrong!" + ex.Message);
	        }

        }

        private static void ExecuteKnoxysCommands(string[] args)
        {
            if (args.Length > 0)
            {

                var action = args[0].ToLower();
                var passthroughArgs = "";

                switch (action)
                {
                    case "start":
                    case "s":
                        action = "start";
                        break;
                    case "stop":
                    case "x":
                        action = "stop";
                        break;
                    case "help":
                    case "h":
                        action = "help";
                        break;
                }

                //if not help then check we have second arg
                if (args.Length > 1)
                {
                    action = String.Format("{0}-{1}", action, args[1]);
                }

                //if we have more args then just pass them through to the bat file
                if (args.Length > 2)
                {
                    for (int i = 2; i < args.Length; i++)
                    {
                        passthroughArgs += " " + args[i];
                    }
                        
                }

                try
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.FileName = String.Format(@"{0}\Scripts\{1}.bat", AppDomain.CurrentDomain.BaseDirectory,
                        action);
                    startInfo.Arguments = passthroughArgs;
                    startInfo.UseShellExecute = false;
                    startInfo.WindowStyle = ProcessWindowStyle.Hidden;

                    //Start the process
                    var proc = Process.Start(startInfo);
                    proc.WaitForExit();

                    Console.WriteLine("Launched " + args[1]);
                    Environment.Exit(1);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Something went wrong. " + ex.Message);
                    Environment.Exit(2);

                }


            }
            else
            {
                Console.WriteLine("Please provide arguments, type help or h for info");
                Environment.Exit(2);
                    
            }
           
        }
        }
    }
