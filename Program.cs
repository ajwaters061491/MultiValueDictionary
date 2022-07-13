using System;
using System.Collections;
using System.Collections.Generic;

namespace MultiValueDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Commands cmd = new Commands();
            Dictionary<string, List<string>> keyList = new Dictionary<string, List<string>>();

            while (true)
            {
                string msgOutput = "";
                Console.Write(">");
                string input = Console.ReadLine();


                //commands
                switch (input.ToLower())
                {
                    case ("keys"):
                        msgOutput = cmd.keysCMD(keyList);
                        break;

                    case string s when s.StartsWith("members"):
                        msgOutput = cmd.membersCMD(input, keyList);
                        break;

                    case string s when s.StartsWith("add"):
                        msgOutput = cmd.addCMD(input, ref keyList);
                        break;
                    case string s when s.StartsWith("removeall"):
                        msgOutput = cmd.removeallCMD(input, ref keyList);
                        break;
                    case string s when s.StartsWith("remove"):
                        msgOutput = cmd.removeCMD(input, ref keyList);
                        break;

                    case ("clear"):
                        msgOutput = cmd.clearCMD(ref keyList);
                        break;

                    case string s when s.StartsWith("keyexists"):
                        msgOutput = cmd.keyexistsCMD(input, keyList);
                        break;

                    case string s when s.StartsWith("memberexists"):
                        msgOutput = cmd.memberexistsCMD(input, keyList);
                        break;

                    case ("allmembers"):
                        msgOutput = cmd.allmembersCMD(keyList);
                        break;

                    case ("items"):
                        msgOutput = cmd.itemsCMD(keyList);
                        break;

                    case ("commands"):
                        msgOutput = cmd.commandsCMD();
                        break;
                    default:
                        Console.WriteLine("Please enter a valid command.\n");
                        break;

                }

                Console.Write(msgOutput);
                msgOutput = "";
            }
        }
    }
}
