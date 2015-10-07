
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace AutomationUtilities.Utils
{
    public class CSVEditor
    {
        public static void FindReplaceElement(String elementToEdit, String newValue)
        {
            String path = Test.absolutePathToImportFile;
            List<String> lines = new List<String>();

            if (File.Exists(path))
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    String line;

                    while ((line = reader.ReadLine()) != null)
                    {

                        if (line.Contains(elementToEdit))
                        {
                            if (line.Contains(";"))
                            {
                                String[] split = line.Split(';');

                                for (int i = 0; i < split.Length; i++)
                                {
                                    if (split[i].Contains(elementToEdit))
                                    {
                                        split[i] = newValue;
                                    }
                                }

                                line = String.Join(";", split);
                            }
                            if (line.Contains(","))
                            {
                                String[] split = line.Split(',');

                                for (int i = 0; i < split.Length; i++)
                                {
                                    if (split[i].Contains(elementToEdit))
                                    {
                                        split[i] = newValue;
                                    }
                                }

                                line = String.Join(",", split);
                            }
                        }

                        lines.Add(line);
                    }
                }

                using (StreamWriter writer = new StreamWriter(Test.absolutePathToImportFile, false))
                {
                    writer.NewLine = "\n";
                    foreach (String line in lines)
                        writer.WriteLine(line);
                }
            }

        }


        public static void CreateNewTREMIR_R010(String fileName, String filePrefix)
        {
            String path = ConfigurationManager.AppSettings["assemblyLocation"] + @"\testFiles\" + fileName;
            List<String> lines = new List<String>();

            if (File.Exists(path))
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    String line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        lines.Add(line);
                    }
                }
                Test.fileName = filePrefix + Util.GetUniqueFileName("csv");
                using (StreamWriter writer = new StreamWriter(Test.absolutePathToImportFile = ConfigurationManager.AppSettings["remoteLocation"] + Test.fileName, false))
                {
                    writer.NewLine = "\n";
                    foreach (String line in lines)
                        writer.WriteLine(line);
                }
            }
            else
            {
                Test.verificationErrors.Append("Import File Template not found. ");
                throw new FileNotFoundException();
            }

        }

    }
}
