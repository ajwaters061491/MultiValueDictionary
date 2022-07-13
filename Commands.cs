using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiValueDictionary
{
    public class Commands
    {
        //Keys command
        public string keysCMD(Dictionary<string, List<string>> keyList)
        {
            string returnMSG = "";
            int keyCounter = 1;

            if (keyList.Count > 0)
            {
                //foreach (Key k in keyList)
                foreach (KeyValuePair<string, List<string>> p in keyList)
                {
                    returnMSG += keyCounter + ") " + p.Key + "\n";
                    keyCounter++;
                }

            }
            else
            {
                returnMSG += "ERROR: No keys are available.\n";
            }
            return returnMSG;
        }

        //members command
        public string membersCMD(string input, Dictionary<string, List<string>> keyList)
        {
            string returnMSG = "";
            string[] members = input.Split(" ");
            int counter = 1;
            bool memberFound = false;

            if (members.Length == 2)
            {
                foreach (KeyValuePair<string, List<string>> p in keyList)
                {
                    if (p.Key == members[1])
                    {
                        memberFound = true;

                        foreach (string s in p.Value)
                        {
                            returnMSG += counter + ") " + s + "\n";
                            counter++;
                        }
                    }
                }
                if (!memberFound)
                {
                    returnMSG += "ERROR: key does not exist.\n";
                }
            }
            else
            {
                returnMSG += "ERROR: Invalid entry.\n";
            }
            return returnMSG;
        }

        //allmembers command
        public string allmembersCMD(Dictionary<string, List<string>> keyList)
        {
            string returnMSG = "";

            if (keyList.Count > 0)
            {
                int keyCounter = 1;

                foreach (KeyValuePair<string, List<string>> p in keyList)
                {
                        foreach (string s in p.Value)
                        {
                            returnMSG += keyCounter + ") " + s + "\n";
                            keyCounter++;
                        }
                }
            }
            return returnMSG;
        }


        //Add command
        public string addCMD(string input, ref Dictionary<string, List<string>> keyList)
        {
            string returnMSG = "";
            bool keyFound = false;
            bool memberFound = false;

            string[] addedMember = input.Split(" ");

            if (addedMember.Length == 3)
            {
                foreach (KeyValuePair<string, List<string>> p in keyList)
                {
                    if (p.Key == addedMember[1])
                    {
                        keyFound = true;

                        {
                            foreach (string s in p.Value)
                            {
                                if (s == addedMember[2])
                                {
                                    memberFound = true;
                                }
                            }
                            if (!memberFound)
                            {
                                returnMSG += "Added " + addedMember[2] + " to " + addedMember[1] + "\n";
                                p.Value.Add(addedMember[2]);
                            }
                            else
                            {
                                returnMSG += "ERROR: Entered member was found for that key.\n";
                            }
                        }
                    }
                }
                if (!keyFound)
                {
                    returnMSG += "Added the key " + addedMember[1] + " with the value " + addedMember[2] + "\n";
                    keyList.Add(addedMember[1], new List<string> { addedMember[2] });
                }
            } 
            else
            {
                returnMSG += "ERROR: Invalid entry.\n";
            }
            return returnMSG;
        }

        //Remove command
        public string removeCMD(string input, ref Dictionary<string, List<string>> keyList)
        {
            string returnMSG = "";
            bool keyFound = false;
            bool memberFound = false;

            string[] removedMember = input.Split(" ");

            if (removedMember.Length == 3)
            {
                foreach (KeyValuePair<string, List<string>> p in keyList)
                {
                    if (p.Key == removedMember[1])
                    {
                        keyFound = true;

                        foreach (string s in p.Value.ToList())
                        {
                            if (s == removedMember[2])
                            {
                                memberFound = true;

                                returnMSG += "Removed the value " + s + " from the Key. \n";
                                p.Value.Remove(s);

                                if (p.Value.Count < 1)
                                {
                                    returnMSG += "Removed the key " + p.Key + " from the dictionary since there are no remaining values. \n";
                                    keyList.Remove(p.Key);
                                }
                            }
                        }
                    }
                }

                if (!keyFound)
                {
                    returnMSG += "ERROR: The key given does not exist.\n";
                }
                else if (!memberFound)
                {
                    returnMSG += "ERROR: The member is not present for the given key.\n";
                }
            }
            else
            {
                returnMSG += "ERROR: Invalid entry.\n";
            }
            return returnMSG;
        }

        //removeall command
        public string removeallCMD(string input, ref Dictionary<string, List<string>> keyList)
        {
            string returnMSG = "";
            bool keyFound = false;
            string[] removedKeys = input.Split(" ");

            if (removedKeys.Length == 2)
            {
                foreach (KeyValuePair<string, List<string>> p in keyList)
                {
                    if (p.Key == removedKeys[1])
                    {
                        keyFound = true;
                        keyList.Remove(p.Key);
                        returnMSG += "Removed all values for the key " + p.Key + " and removed it from the Dictionary.\n";
                    }
                }

                if (!keyFound)
                {
                    returnMSG += "ERROR: The key given does not exist.\n";
                }
            }
            else
            {
                returnMSG += "ERROR: Invalid entry.\n";
            }
            return returnMSG;
        }

        //clear command
        public string clearCMD(ref Dictionary<string, List<string>> keyList)
        {
            keyList.Clear();
            return "Removed all Keys and Members from the Dictionary.\n";
        }

        //keyexists command
        public string keyexistsCMD(string input, Dictionary<string, List<string>> keyList)
        {
            string returnMSG = "";
            string[] keysearch = input.Split(" ");
            bool keyFound = false;

            if (keysearch.Length == 2)
            {
                foreach (KeyValuePair<string, List<string>> p in keyList)
                {
                    if (p.Key == keysearch[1])
                    {
                        keyFound = true;
                    }
                }

                if (keyFound)
                {
                    returnMSG += "True.\n";
                }
                else
                {
                    returnMSG += "False.\n";
                }
            }
            else
            {
                returnMSG += "ERROR: Invalid entry.\n";
            }
            return returnMSG;
        }

        //memberexists command
        public string memberexistsCMD(string input, Dictionary<string, List<string>> keyList)
        {
            string returnMSG = "";
            string[] keysearch = input.Split(" ");
            bool memberFound = false;

            if (keysearch.Length == 3)
            {
                foreach (KeyValuePair<string, List<string>> p in keyList)
                {
                    if (p.Key == keysearch[1])
                    {
                        foreach (string s in p.Value)
                        {
                            if (s == keysearch[2])
                            {
                                memberFound = true;
                                returnMSG += "True.\n";
                            }
                        }

                    }
                    if (!memberFound)
                    {
                        returnMSG += "False.\n";
                    }
                }
            }
            else
            {
                returnMSG += "ERROR: Invalid entry.\n";
            }
            return returnMSG;
        }

        //items command
        public string itemsCMD(Dictionary<string, List<string>> keyList)
        {
            string returnMSG = "";
            int counter = 1;
            foreach (KeyValuePair<string, List<string>> p in keyList)
            {
                foreach (string s in p.Value)
                {
                    returnMSG += counter + ") " + p.Key + ": " + s + "\n";
                    counter++;
                }
            }
            return returnMSG;
        }

        //commands command
        public string commandsCMD()
        {
            string returnMSG = "";
            returnMSG += "Currently implemented commands include: keys, members, add, removeall,\n";
            returnMSG += "remove, clear, keyexists, memberexists, all members, items, and commands\n\n";

            returnMSG += "keys, clear, allmembers, items, and commands take no (0) arguments.\n";
            returnMSG += "members, removeall, and keyexists all take one (1) argument.\n";
            returnMSG += "add, remove, and memberexists takes two (2) argument.\n";

            return returnMSG;
        }



    }
}
