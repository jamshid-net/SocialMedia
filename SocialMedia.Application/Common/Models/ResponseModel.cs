namespace SocialMedia.Application.Common.Models;
public class ResponseModel<T>
{
    public ResponseModel(bool isSuccess, object errors)
            => (IsSuccess, Errors) = (isSuccess, errors);
       
    

    public ResponseModel(T result)
           =>Result = result;
    
    
    public ResponseModel()
    {

    }

    public bool IsSuccess { get; set; } = true;

    public T Result { get; set; }
    public object Errors { get; set; }
}
