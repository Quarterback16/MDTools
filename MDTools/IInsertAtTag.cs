using CSharpFunctionalExtensions;

namespace MDTools
{
    public interface IInsertAtTag
    {
        public Result<string> InsertAtTag(
            string tag,
            string insertionText,
            string filename);
    }
}
