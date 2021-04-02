using System.Linq;

namespace DotwoGames.Quests
{
    public class Parser {

        // TODO: Validation
        // TODO: Make sure no ' ' characters are there
        /// <summary>
        /// Is a given semver-style predicate valid for a given resolved version?
        /// </summary>
        /// <param name="predicate">Predicate to be confirmed (e.g. ">1.2.3", "=2.0.0", "<3.1.0")</param>
        /// <param name="version">Specific version to be checked, in format "x.y.z"</param>
        /// <returns></returns>
        public static bool IsValid(string predicate, string version)
        {
            // Sanitise input
            predicate = predicate.Replace(" ", "");
            version = version.Replace(" ", "");

            string _operator = predicate.Substring(0, 1);
            string versionInTest = predicate.Replace(_operator, "");

            return _operator switch
            {
                "=" => string.CompareOrdinal(versionInTest, version) == 0,
                "<" => LessThan(versionInTest, version),
                ">" => GreaterThan(versionInTest, version),
                _ => false
            };
        }

        private static bool LessThan(string predicate, string version)
        {
            int[] parsedPredicate = ParseVersionString(predicate);
            int[] parsedVersion = ParseVersionString(version);

            // Act
            if (parsedVersion[0] < parsedPredicate[0])
            {
                // <2.*.*, 1.*.*
                return true;
            }
            else if (parsedVersion[0] > parsedPredicate[0])
            {
                return false;
            }

            // Chapter
            if (parsedVersion[1] < parsedPredicate[1])
            {
                // <1.2.*, 1.1.*
                return true;
            }
            else if (parsedVersion[1] > parsedPredicate[1])
            {
                return false;
            }

            // Task
            // <1.2.3, 1.2.?
            return parsedVersion[2] < parsedPredicate[2];
        }

        private static bool GreaterThan(string predicate, string version)
        {
            int[] parsedPredicate = ParseVersionString(predicate);
            int[] parsedVersion = ParseVersionString(version);

            // Act
            if (parsedVersion[0] > parsedPredicate[0])
            {
                // >1.*.*, 2.*.*
                return true;
            }
            else if (parsedVersion[0] < parsedPredicate[0])
            {
                return false;
            }

            // Chapter
            if (parsedVersion[1] > parsedPredicate[1])
            {
                // >1.1.*, 1.2.*
                return true;
            }
            else if (parsedVersion[1] < parsedPredicate[1])
            {
                return false;
            }

            // Task
            // >1.2.3, 1.2.?
            return parsedVersion[2] > parsedPredicate[2];
        }

        private static int[] ParseVersionString(string version)
        {
            return version.Split('.').Select(int.Parse).ToArray();
        }
    }
}
