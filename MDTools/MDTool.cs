using CSharpFunctionalExtensions;
using System.Text;
namespace MDTools
{
    public class MDTool : IInsertAtTag
    {
        public Result<string> InsertAtTag(
            string tag, 
            string insertionText, 
            string filename)
        {
            var foundTag = false;
            var result = Result.Success("");
            if (!File.Exists(filename))
                return Result.Failure<string>($"File {filename} does not exist");
            var sb = new StringBuilder();
            foreach (string s in File.ReadAllLines(filename))
            {
                if (s.Contains(TagFor(tag)))
                    foundTag = true;
                sb.AppendLine(s.Replace($"{TagFor(tag)}", insertionText));
            }
            if (foundTag)
            {
                using (var file = new StreamWriter(File.Create(filename)))
                {
                    file.Write(sb.ToString());
                }
                result = sb.ToString();
            }
            else
                result = Result.Failure<string>($"tag:{tag} not found");
            return result;
        }

        private static string TagFor(string tag)
        {
            return "{" + tag + "}";
        }
    }
}
