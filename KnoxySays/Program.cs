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
                int startArgs = 0;

                switch (action)
                {
                    case "start":
                    case "s":
                        action = "start";
                        startArgs = 2;
                        break;
                    case "stop":
                    case "x":
                        action = "stop";
                        startArgs = 2;
                        break;
                    default:
                        action = "start";
                        startArgs = 1;
                        break;
                }

                if (args.Length == 0)
                {
                    Console.WriteLine("Please provide arguments, type help or h for command list");
                    Environment.Exit(2);
                }
                //if only one arg we will assume its a start action
                if (startArgs == 1)
                {
                    action = String.Format("{0}-{1}", action, args[0]);
                }

                //if two args it will be action and script
                if (startArgs == 2)
                {
                    action = String.Format("{0}-{1}", action, args[1]);
                }

                //if we have more args then just pass them through to the bat file
               passthroughArgs = PassthroughArgs(args, startArgs, passthroughArgs);

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

                    Console.WriteLine(action + " complete");
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

        private static string PassthroughArgs(string[] args, int startArgs, string passthroughArgs)
        {
            if (args.Length > startArgs)
            {
                for (int i = startArgs; i < args.Length; i++)
                {
                    passthroughArgs += " " + args[i];
                }
            }
            return passthroughArgs;
        }
    }
    }
