using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace UndervisningPersistens
{
    public class RunCountDemo
    {
        public static void Start()
        {
            var serializer = new XmlSerializer(typeof(RunningProgramStatistics));
            RunningProgramStatistics programData = null;
            var fileName = "ProgramData.xml";
            var fileInfo = new FileInfo(fileName);
            if (fileInfo.Exists)
            {
                programData = ReadProgramData(fileName, programData, serializer);
            }
            else
            {
                programData = new RunningProgramStatistics { RunCount = 0 };
                programData.Runs = new RunningProgramStatisticsRun[0];
            }

            programData.RunCount++;
            var count = programData.RunCount;
            var runs = new List<RunningProgramStatisticsRun>(programData.Runs);
            runs.Add(new RunningProgramStatisticsRun() { Timestamp = DateTime.Now });
            programData.Runs = runs.ToArray();
            Console.WriteLine($"Dette er {count}. gang du kjører programmet!");
            WriteProgramData(fileName, serializer, programData);
        }

        private static void WriteProgramData(string fileName, XmlSerializer serializer, RunningProgramStatistics programData)
        {
            using (var writer = new StreamWriter(fileName))
            {
                serializer.Serialize(writer, programData);
            }
        }

        private static RunningProgramStatistics ReadProgramData(string fileName, RunningProgramStatistics programData,
            XmlSerializer serializer)
        {
            using (var reader = new StreamReader(fileName))
            {
                programData = (RunningProgramStatistics)serializer.Deserialize(reader);
            }
            return programData;
        }

    }
}
