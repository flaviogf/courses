namespace CourseLibrary.Api.Services
{
    public interface IPropertyCheckerService
    {
        bool TypeHasProperties<T>(string fields);
    }
}
