using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.AddIn.Hosting;
using System.Collections.ObjectModel;

namespace MAF
{
    class Program
    {
        [Serializable]
        public class ConfigMain
        {
            public string Test { get; set; }

            public List<ConfigSub> lst { get; set; }

            public ConfigMain()
            {
                
            }
        }

        [Serializable]
        public class ConfigSub
        {
            public string A { get; set; }
            public ConfigSub()
            {
                
            }
        }



        static void Main(string[] args)
        {
            string path = Environment.CurrentDirectory;


            ConfigMain aaa = new ConfigMain();
            ConfigSub b1 = new ConfigSub { A = "1" };
            ConfigSub b2 = new ConfigSub { A = "1" };
            aaa.lst = new List<ConfigSub>();
            aaa.lst.Add(b1);
            aaa.lst.Add(b2);
            string filename = "test";
            QCP.Tool.ConfigFileManager.SaveConfig(path, filename, aaa);


            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += new UnhandledExceptionEventHandler(MyHandler);

            string[] warnings = AddInStore.Update(path);
            foreach (var tmp in warnings)
            {
                Console.WriteLine(tmp);
            }

            //发现  
            var tokens = AddInStore.FindAddIns(typeof(HostSideView), path);
            Console.WriteLine("当前共有{0}个插件可以选择。它们分别为：", tokens.Count);

            var index = 1;

            foreach (var tmp in tokens)
            {
                Console.WriteLine(string.Format("[{4}]名称：{0}，描述：{1}，版本：{2}，发布者：{3}", tmp.Name, tmp.Description, tmp.Version, tmp.Publisher, index++));
            }

            var token = ChooseCalculator(tokens);
            //隔离和激活插件  
            AddInProcess process = new AddInProcess(Platform.X64);

            process.Start();
            var addin = token.Activate<HostSideView>(process, AddInSecurityLevel.FullTrust);
            //token.Activate<MAF.HostSideView.MyHostSideView>(
            Console.WriteLine("PID:{0}", process.ProcessId);

            Console.WriteLine("Begin call addin's method.");

            //调用插件  
            Console.WriteLine(addin.Say());

            try
            {
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }

            Console.WriteLine("After call addin's method.");

            Console.ReadKey();
        }

        static void MyHandler(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;
            Console.WriteLine("MyHandler caught : " + e.Message);
            Console.WriteLine("Runtime terminating: {0}", args.IsTerminating);
        }

        private static AddInToken ChooseCalculator(Collection<AddInToken> tokens)
        {

            if (tokens.Count == 0)
            {
                Console.WriteLine("No calculators are available");
                return null;
            }

            Console.WriteLine("Available Calculators: ");

            // Show the token properties for each token in the AddInToken collection   

            // (tokens), preceded by the add-in number in [] brackets.  

            int tokNumber = 1;

            foreach (AddInToken tok in tokens)
            {
                Console.WriteLine(String.Format("\t[{0}]: {1} - {2}\n\t{3}\n\t\t {4}\n\t\t {5} - {6}",
                    tokNumber.ToString(),
                    tok.Name,
                    tok.AddInFullName,
                    tok.AssemblyName,
                    tok.Description,
                    tok.Version,
                    tok.Publisher));
                tokNumber++;
            }

            Console.WriteLine("Which calculator do you want to use?");
            String line = Console.ReadLine();
            int selection;
            if (Int32.TryParse(line, out selection))
            {
                if (selection <= tokens.Count)
                {
                    return tokens[selection - 1];
                }
            }
            Console.WriteLine("Invalid selection: {0}. Please choose again.", line);
            return ChooseCalculator(tokens);
        }
    }
}
