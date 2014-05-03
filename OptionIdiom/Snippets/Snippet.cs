using System;
using System.IO;
using System.Reflection;
using JetBrains.Annotations;

namespace Snippets
{
    public class Snippet
    {
        public static DirectoryInfo ExecutableDirectory
        {
            get { return new DirectoryInfo(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)); }
        }

        /// <summary>Source directory. This property is never null.</summary>
        public DirectoryInfo SourceDirectory { get; private set; }

        /// <summary>Destination directory. This property can be null.</summary>
        public DirectoryInfo DestinationDirectory { get; set; }

        /// <returns>Installation directory or null if the application is not already installed.</returns>
        public DirectoryInfo GetInstallationDirectory()
        {
            DateTime creationTime = DestinationDirectory.CreationTime;






            Console.WriteLine(creationTime);

            return null;
        }



        public class InnerSnippet
        {
            public static DirectoryInfo ExecutableDirectory
            {
                get { return new DirectoryInfo(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) ?? Environment.CurrentDirectory); }
            }

            public DirectoryInfo SourceDirectory { get; private set; }

            public DirectoryInfo DestinationDirectoryOrNull { get; set; }

            public DirectoryInfo GetInstallationDirectoryOrNull()
            {
                return null;
            }
        }


        public class ReSharperExternalAnnotations
        {
            [NotNull]
            public DirectoryInfo SourceDirectory { get; private set; }

            [CanBeNull]
            public DirectoryInfo DestinationDirectory { get; set; }

            [CanBeNull]
            public DirectoryInfo GetInstallationDirectory()
            {
                return null;
            }

            [CanBeNull]
            public DirectoryInfo GetResourceDirectory([NotNull] string resourceId)
            {
                DateTime creationTime = DestinationDirectory.CreationTime;





                Console.WriteLine(creationTime);

                return null;
            }
        }

        public void AccessingNullable()
        {
            int? a = 100;
            int b = a.Value;
        }


        public int GetYearOfManufacturing()
        {
            return 0;
        }

        public void UsageOfGetYearOfManufacturing()
        {
            int yearOfManufacturing = GetYearOfManufacturing();
            if (yearOfManufacturing == int.MinValue)
            {
                // Do something in case the year of manufacturing is not known.
            }
        }

        public int? GetYearOfManufacturing_Nullable()
        {
            return 0;
        }

        public void UsageOfGetYearOfManufacturing_Nullable()
        {
            int? yearOfManufacturing = GetYearOfManufacturing_Nullable();
            if (!yearOfManufacturing.HasValue)
            {
                // Do something in case the year of manufacturing is not known.
            }
        }

        public class User {}

        public User GetUser(string userName, string password)
        {
            return null;
        }

        public void UsageOfGetUser(string userName, string password)
        {
            User user = GetUser(userName, password);
            if (user == null)
            {
                // Do something in case the user does not exist.
            }
        }
    }
}
