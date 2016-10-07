using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HomeProperty.EF.Migrations {

    public class CsvReaderService {

        #region Properties

        private static string m_binFolder = AppDomain.CurrentDomain.BaseDirectory;
        private const string SeedingDataFolder = "SeedingData";
        private static List<string> m_files = new List<string>();

        #endregion

        public CsvReaderService() {

        }

        #region Methods

        public static void FolderProcess<T>(string folder, Action<List<T>> action) {
            m_files = GetFiles(folder);
            if (m_files == null)
                throw new NullReferenceException("files object collection is null");

            m_files.ForEach((file) => {

                if (!File.Exists(file))
                    throw new FileNotFoundException(file);

                using (var sr = new StreamReader(file)) {
                    var reader = new CsvReader(sr);
                    var records = reader.GetRecords<T>().ToList();

                    if (records != null)
                        action(records);
                }
            });
        }

        public static void FileProcess<T>(string fileName, Action<T> action) {
            if (File.Exists(fileName)) {
                using (var sr = new StreamReader(fileName)) {
                    var reader = new CsvReader(sr);
                    while (reader.Read()) {
                        var record = reader.GetRecord<T>();
                        if (record != null)
                            action(record);
                    }
                }
            }
        }

        public static List<string> GetFiles(string folder) {
            if (Directory.Exists(folder)) {
                return Directory.GetFiles(folder).ToList();
            }
            return null;
        }

        public static string GetSeedingDataFolder() {
            m_binFolder = m_binFolder.Replace("\\bin\\Debug", string.Empty);
            var dir = m_binFolder + "Migrations";
            var dataFolder = string.Format("{0}\\{1}", dir, SeedingDataFolder);
            return dataFolder;
        }

        #endregion
    }
}
