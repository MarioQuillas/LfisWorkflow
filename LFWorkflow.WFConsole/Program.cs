namespace LFWorkflow.WFConsole
{
    using System;
    using System.Activities;
    using System.Activities.Statements;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;

    using Newtonsoft.Json;

    class Program
    {
        static void Main(string[] args)
        {
            //var toto = Assembly.GetEntryAssembly();
            //var titi = Assembly.GetEntryAssembly();
            //var ff = Directory.GetCurrentDirectory();
            //var vv = System.AppDomain.CurrentDomain.BaseDirectory;

            //            var dd = LFWorkflow.WFConsole.Properties.Resources.wfTest;

            //            var toto = System.Text.Encoding.UTF8.GetString(dd);

            //            var ss = @"
            //[
            //	{
            //		""Id"": ""1"",
            //        ""Script"" : ""script1"",
            //        ""Resources"" : [""UC2232"", ""UC1111""],
            //        ""Next"" : [""2"", ""3""]
            //    },
            //	{
            //		""Id"": ""2"",
            //        ""Script"" : ""script1"",
            //        ""Resources"" : [""UC2232"", ""UC1111""],
            //        ""Next"" : []
            //    },
            //	{
            //		""Id"": ""3"",
            //        ""Script"" : ""script1"",
            //        ""Resources"" : [""UC2232"", ""UC1111""],
            //        ""Next"" : []
            //    }
            //]
            //";

            //            var node4 = new LFActivity()
            //                            {
            //                                Id = "4",
            //                                Script = "script4",
            //                                Resources = new List<string>() { "UC4" },
            //                                Next = new List<LFActivity>()
            //                            };

            //            var node3 = new LFActivity()
            //                            {
            //                                Id = "3",
            //                                Script = "script3",
            //                                Resources = new List<string>() { "UC3" },
            //                                Next = new List<LFActivity>() { node4 }
            //                            };

            //            var node2 = new LFActivity()
            //                            {
            //                                Id = "2",
            //                                Script = "script2",
            //                                Resources = new List<string>() { "UC2" },
            //                                Next = new List<LFActivity>() { node4 }
            //                            };

            //            var node1 = new LFActivity()
            //                            {
            //                                Id = "1",
            //                                Script = "script1",
            //                                Resources = new List<string>() { "UC1" },
            //                                Next = new List<LFActivity>() { node2, node3 }
            //                            };

            //            var jsonSerializerSettings = new JsonSerializerSettings()
            //                                             {
            //                                                 Formatting = Formatting.Indented,
            //                                                 ReferenceResolverProvider =
            //                                                     () => new LFActivityReferenceResolver()
            //                                             };

            //            var serializeJson = JsonConvert.SerializeObject(node1, jsonSerializerSettings);

            //            System.Console.WriteLine(serializeJson);


            //WorkflowApplication

            WorkflowInvoker.Invoke(GetWorkflow());
            System.Console.ReadLine();

            //var ff = JsonConvert.DeserializeObject<List<LFActivity>>(toto, jsonSerializerSettings);
            //var fd = JsonConvert.DeserializeObject<List<LFActivity>>(ss, jsonSerializerSettings);
        }

        private static Activity GetWorkflow()
        {
            var textValue = new Variable<string>(){Default = "default value"};
            return new LFNativeActivity()
                       {
                           Variables = {textValue},
                           Children =
                               {
                                   new WriteLine(){Text = textValue},
                                   new Assign<string>(){To = textValue, Value = "Assigned value"},
                                   new WriteLine(){Text = textValue}
                               }
                       };
        }

        //private static void Bookmarktest()
        //{
        //    var wfApp = new WorkflowApplication(
        //        new ReportProcessing(),
        //        new Dictionary<string, object>()
        //            {
        //            {"report", model.Report }
        //            }
        //        );

        //    wfApp.Completed += (wce) =>
        //        {
        //            var response = (ManagerResponse)wce.Outputs[""];
        //            MessageBox.show("qsdf");
        //        }

        // wfApp.resumebookmark("qfqsdf", model.response);
        //}

        //private static Activity GetParallelWorkflow()
        //{
        //    return new Sequence
        //               {
        //                   Activities =
        //                       {
        //                           new CustomActivities.MyParallel{
        //                                                                  Branches = {
        //                                                                                     new WriteLine{Text = "First"},
        //                                                                                     new Sequence {
        //                                                                                                          Activities  = {
        //                                                                                                                                new Delay {Duration = TimeSpan.FromSeconds(2)},
        //                                                                                                                                new WriteLine{Text = "Second"}
        //                                                                                                                            }
        //                                                                                                      }

        //                                                                                 }
        //                                                              },
        //                           new WriteLine{Text="After parallel"}
        //                       }
        //               };
        //}

        //private static Activity GetWorkflow() => new Sequence()
        //                                             {
        //                                                 Activities =
        //                                                     {
        //                                                         new LFNativeActivity()
        //                                                             {
        //                                                                 Branches
        //                                                                     =
        //                                                                         {
        //                                                                             new
        //                                                                                 Sequence()
        //                                                                                     {
        //                                                                                         Activities
        //                                                                                             =
        //                                                                                                 {
        //                                                                                                     new
        //                                                                                                         WriteLine()
        //                                                                                                             {
        //                                                                                                                 Text
        //                                                                                                                     = "qdf from branch"
        //                                                                                                             },
        //                                                                                                     new
        //                                                                                                         WriteLine()
        //                                                                                                             {
        //                                                                                                                 Text
        //                                                                                                                     = "qdf from branch 22"
        //                                                                                                             }
        //                                                                                                 }
        //                                                                                     }
        //                                                                         }
        //                                                             },
        //                                                         new WriteLine() { Text = "qdf" }
        //                                                     }
        //                                             };
    }
}