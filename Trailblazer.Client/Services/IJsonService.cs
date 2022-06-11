namespace Trailblazer.Services
{
    public interface IJsonService
    {
        T FromJson<T>(string json);
        T FromJson<T>(string json, T anonymousTypeObject);
        string ToJson<T>(T objectToSerialize);
        StringContent ToJsonStringContent<T>(T objectToSerialize);
    }
}
